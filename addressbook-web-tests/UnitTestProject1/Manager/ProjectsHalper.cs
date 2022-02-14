using System.Collections.Generic;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class ProjectsHalper : HelperBase
    {
        public ProjectsHalper(ApplicationManager manager) : base(manager) { }

        public void CreateProject(ProjectData project)
        {
            OpenManagement();
            OpenProjects();
            ClickOnCreateButton();
            FillProjectForm(project);
            SubmitCreation();
        }

        private void SubmitCreation()
        {
            driver.FindElement(By.XPath("//input[@type= 'submit']")).Click();
        }

        private void FillProjectForm(ProjectData project)
        {
            driver.FindElement(By.Id("project-name")).SendKeys(project.Name);
            driver.FindElement(By.Id("project-description")).SendKeys(project.Description);
        }

        private void ClickOnCreateButton()
        {
            driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[2]/div/div/div[2]/div[2]/div/div[1]/form/button")).Click();

        }

        private void OpenProjects()
        {
            driver.FindElement(By.CssSelector(".nav-tabs > li:nth-child(3) > a:nth-child(1)")).Click();
        }

        private void OpenManagement()
        {
            driver.FindElement(By.CssSelector(".nav-list > li:nth-child(7) > a:nth-child(1) > span:nth-child(2)")).Click();
        }
         List<ProjectData> projectList = new List<ProjectData>();
         
        public List<ProjectData> GetProjectList()
        {
            OpenManagement();
            OpenProjects();
            projectList.Clear();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//table[@class='table table-striped table-bordered table-condensed table-hover']/tbody/tr/td/a"));
            foreach (IWebElement element in elements)
            {
                projectList.Add(new ProjectData() {
                    Name = element.Text
                });
            }
            return projectList;
        }

        internal void DeleteProject(ProjectData project)
        {
            OpenManagement();
            OpenProjects();
            ClickOnProjectLink();
            SubmitDelete();
        }

        private void ClickOnProjectLink()
        {
            driver.FindElement(By.XPath("//table[@class='table table-striped table-bordered table-condensed table-hover']/tbody/tr/td/a")).Click();

        }

        private void SubmitDelete()
        {
            driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[2]/div/div[2]/div/form/fieldset/input[3]")).Click();
            driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[2]/div/div/div[2]/form/input[4]")).Click();
            

        }
    }
}
