using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AuthTestBase : bBaseTest
    {
        [SetUp]
        public void SetupLogin()
        {
            app = mApplicationManager.GetInstance();
            app.Auth.Login(new AccountData("admin", "secret"));

        }
    }
}
