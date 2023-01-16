using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterStreamAcces.Models
{
    public class TweetModel
    {
        public string? Id { get; set; }  
        public string? TweetText { get; set; }
        public string? HashTag { get; set; }
        public int totaltweets { get; set; }
        public int popularcount { get; set; } = 0;
        public string populartag { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
    }
}
