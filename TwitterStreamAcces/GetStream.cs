using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Models;
using Tweetinvi;
using TwitterStreamAcces.Models;

namespace TwitterStreamAcces
{
    public class GetStream : IGetStream
    {
        private List<TweetModel> tweetlist = new();

        private TweetModel tweetmodel = new();

        readonly IConfiguration _config;

        public GetStream(IConfiguration config)
        {
            _config = config;
        }

        public async Task Connect()
        {

            var appCredentials = new ConsumerOnlyCredentials("", "")
            {
                BearerToken = _config["BearerToken"]
            };

            var appClient = new TwitterClient(appCredentials);
            var sampleStreamV2 = appClient.StreamsV2.CreateSampleStream();

            sampleStreamV2.TweetReceived += (sender, args) =>
            {
                tweetmodel.TweetText = args.Tweet.Text;
                tweetlist.Add(tweetmodel);
                if(tweetlist.Count > 100)
                {
                    //now proccess the list
                    foreach(var item in tweetlist)
                    {
                        ProccesTags(item.TweetText);
                    }
                    tweetlist.Clear();
                }

            };

            //start the stream and call the TweetRecieved event
            try
            {
                await sampleStreamV2.StartAsync();
            }
            catch 
            { 
                
            }
        }

        public void ProccesTags(string tweet)
        {
            int start;
            string sub = "";
            ++tweetmodel.totaltweets;
            if (tweet.Contains('#'))
            {
                start = tweet.IndexOf('#');
                sub = tweet.Substring(start);
                tweetmodel.Tags.Add(sub);
            }
            if (tweetmodel.Tags != null)
            {
                //find most popular hashtag
                var query = from hashmark in tweetmodel.Tags
                            group hashmark by hashmark into hashkey
                            let count = hashkey.Count()
                            orderby count descending
                            select new { Value = hashkey.Key, Count = count };
                foreach (var hashmark in query)
                {
                    //if hashtag has higher count then it becomes most popular
                    if (hashmark.Count > tweetmodel.popularcount)
                    {
                        tweetmodel.popularcount = hashmark.Count;
                        tweetmodel.populartag = hashmark.Value;
                    }
                }
            }
        }
    }
}
