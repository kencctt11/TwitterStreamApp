using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterStream
{
    public class Process
    {
        //put your bearer token here
        public string BearerToken { get; set; } = "$YOUR BEARER TOKEN HERE";
        public int totaltweets { get; set; }
        public int popularcount { get; set; } = 0;
        public string populartag { get; set; }
        public List<string> Tags { get; set; } = new List<string>();

        //processes the tweets to find hashtags and count them. 
        //Finds hastag that is most common
        //this can be expanded to save common hashtags in memory stream also

        public void ProccesTags(string tweet)
        {
            int start;
            string sub = "";
           if(tweet.Contains('#'))
            {
                start = tweet.IndexOf('#');
                sub = tweet.Substring(start);
                Tags.Add(sub);
            }
            if (Tags != null)
            {
                //find most popular hashtag
                var q = from x in Tags
                        group x by x into g
                        let count = g.Count()
                        orderby count descending
                        select new { Value = g.Key, Count = count };
                foreach (var x in q)
                {
                    //if hashtag has higher count then it becomes most popular
                    if (x.Count > popularcount)
                    {
                        popularcount = x.Count;
                        populartag = x.Value;
                    }
                }
            }
        }
    }
}
