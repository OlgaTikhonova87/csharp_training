using NUnit.Framework;
namespace mantis_tests
{
    [TestFixture]

    public class AccountCreationTest : bBaseTest
    
    {
        public string localPath =  @"\config_inc.php";
        //TestContext.CurrentContext.TestDirectory +
        [TestFixtureSetUp]
        public void setupConfig()
        {
            
            //app.Ftp.BackupFile(localPath);
            //using (Stream localFile = File.Open("config_inc.php", FileMode.Open))
            //{
            //    app.Ftp.Upload(localPath, localFile);
            //}
                
        }
        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData
            {
                Name = "testuser8",
                Password = "password",
                Email = "testuser8@localhost"
            };
       //     app.James.Delete(account);

      //      app.Registration.Register(account);
     //       app.James.Add(account);
        }
        public void restoreConfig()
        {
            app.Ftp.RestoreBackupFile(localPath);
        }
    }
}
