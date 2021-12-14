using NUnit.Framework;

namespace WebAddressbookTests
{
    public class bBaseTest
    {
        protected mApplicationManager app;
        [SetUp]
        public void SetupTest()
        {
            app = new mApplicationManager();
        }
        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }
    }
}
