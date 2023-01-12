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
            process.ProccesTags("This is a test tweet. #Test");
            process.ProccesTags("This is a test tweet. #Test2");
            Assert.IsTrue(process.totaltweets ==3);
            Assert.IsTrue(process.popularcount==2);
            Assert.IsTrue(process.Tags.Count==3);
            Assert.IsTrue(process.populartag == "#Test");
        }
    }
}