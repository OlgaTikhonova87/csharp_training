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
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
        }
        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }
    }
}
