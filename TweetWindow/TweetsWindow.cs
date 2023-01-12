using Tweetinvi;
using Tweetinvi.Models;

namespace TweetWindow
{
    public partial class TweetsWindow : Form
    {
        List<string> TweetList = new();
        public TweetsWindow()
        {
            InitializeComponent();
            
        }

        private void buttonStopStream_Click(object sender, EventArgs e)
        {

        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private async void buttonStartStream_Click(object sender, EventArgs e)
        {
            var appCredentials = new ConsumerOnlyCredentials("",
         "")
            {
                BearerToken = "AAAAAAAAAAAAAAAAAAAAAJ2SlAEAAAAAOqv%2FiKFZwxLcVLU3D5W%2FQYXqFGk%3D75cjh4pi2MCAFwfJxByugk79NE7K3x9Qou2prPZ493VfmvisDY"
            };

            var appClient = new TwitterClient(appCredentials);
            var sampleStreamV2 = appClient.StreamsV2.CreateSampleStream();
                sampleStreamV2.TweetReceived += (sender, args) =>
                {
                   textBoxTweets.Text = textBoxTweets.Text + args.Tweet.Text;
                };
            await sampleStreamV2.StartAsync();
        }
    }
}