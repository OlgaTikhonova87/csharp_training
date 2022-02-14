using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AddNewIssues : BaseTest
    {
        [Test]
        public void AddNewIssue()
        {
            AccountData account = new AccountData
            {
                Name = "administrator",
                Password = "root"
            };
            IssueData issueData = new IssueData
            {
                Summary = "administrator",
                Description = "root",
                Category = "1"
            };
            ProjectData project = new ProjectData
            {
                Id = "General"
            };
            app.API.CreateNewIssue(account, issueData, project);
        }
    }
}
