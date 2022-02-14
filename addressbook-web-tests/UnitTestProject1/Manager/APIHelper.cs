using System.Collections.Generic;
namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) { }

        public void CreateNewIssue(AccountData account, IssueData issueData, ProjectData project)
        {
            UnitTestProject1.Mantis.MantisConnectPortTypeClient client = new UnitTestProject1.Mantis.MantisConnectPortTypeClient();
            UnitTestProject1.Mantis.IssueData issue = new UnitTestProject1.Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new UnitTestProject1.Mantis.ObjectRef();
            issue.project.id = project.Id;
            client.mc_issue_add(account.Name, account.Password, issue);
        }
        public List<ProjectData> GetAPIProjectsList(AccountData account)
        {
            var projectList = new List<ProjectData>();
            UnitTestProject1.Mantis.MantisConnectPortTypeClient client = new UnitTestProject1.Mantis.MantisConnectPortTypeClient();
            UnitTestProject1.Mantis.ProjectData[] projectData = client.mc_projects_get_user_accessible(account.Name, account.Password);
            foreach (var project in projectData)
            {
                projectList.Add( new ProjectData {
                    Id = project.id, 
                    Description = project.description, 
                    Name = project.name 
                });
            }
            return projectList;
        }
    }
}
