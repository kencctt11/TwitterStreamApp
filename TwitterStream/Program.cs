using System.Net.Http;
using System;
using Tweetinvi;
using Tweetinvi.Models;
using TwitterStream;
using Tweetinvi.Exceptions;

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
            process.ProccesTags(args.Tweet.Text);
            Console.WriteLine(process.totaltweets.ToString());
        };

        //start the stream and call the TweetRecieved event
        try
        {
            await sampleStreamV2.StartAsync();
        }
        catch (TwitterException e)
        {
            Console.WriteLine("Please check your Bearer Token");
        }
        catch (TwitterAuthException e)
        {
            Console.WriteLine("Please check your Bearer Token");
        }
        catch (Exception e)
        {
            Console.WriteLine("Please check your Bearer Token");
        }
    }
}