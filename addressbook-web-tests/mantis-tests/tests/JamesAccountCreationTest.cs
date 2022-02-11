using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class JamesAccountCreationTest : bBaseTest
    {
        [Test]
        public void JamesAccountCreationTests()
        {
            AccountData account = new AccountData() {
                Name = "xxx",
                Password = "yyy"
            };
           Assert.IsFalse( app.James.Verify(account));
           app.James.Add(account);
            Assert.IsTrue(app.James.Verify(account));
            app.James.Delete(account);
            Assert.IsFalse(app.James.Verify(account));
        }
    }
}
