using System.Diagnostics;

namespace Tests
{
    [TestClass]
    public class UnitTestTwitter
    {
        [TestMethod]
        public void PutTestTweetinProcessShouldReturn1Item()
        {
            TwitterStream.Process process = new TwitterStream.Process();
            process.ProccesTags("This is a test tweet. #Test");
            Assert.IsTrue(process.totaltweets ==1);
            Assert.IsTrue(process.popularcount==1);
            Assert.IsTrue(process.Tags.Count==1);   
        }
    }
}