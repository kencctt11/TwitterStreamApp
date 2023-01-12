using System.Net.Http;
using System;
using Tweetinvi;
using Tweetinvi.Models;
using TwitterStream;

internal class Program
{

    //gets the stream from twitter and calls Process to add up tags and tweet count
    private static async Task Main(string[] args)
    {
        Process process = new();
        var appCredentials = new ConsumerOnlyCredentials("", "")
        {
            BearerToken = process.BearerToken
        };

        var appClient = new TwitterClient(appCredentials);
        var sampleStreamV2 = appClient.StreamsV2.CreateSampleStream();
        sampleStreamV2.TweetReceived += (sender, args) =>
        {
            Console.WriteLine(args.Tweet.Text);
            ++process.totaltweets;
            process.ProccesTags(args.Tweet.Text);
            Console.WriteLine(process.totaltweets.ToString());
        };

        //start the stream and call the TweetRecieved event

        await sampleStreamV2.StartAsync();   
    }
}