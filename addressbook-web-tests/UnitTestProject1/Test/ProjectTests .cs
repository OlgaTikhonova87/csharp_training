using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]

    public class ProjectTests : BaseTest
    {
        [Test]
        public void ProjectCreationTest()
        {
            ProjectData project = new ProjectData 
            {
                Name = "pr0"+DateTime.Now.ToString(),
                Description = "Description"
            };
            app.Login.Login();
            
            List<ProjectData> oldProjects = app.Projects.GetProjectList();
            app.Projects.CreateProject(project);

            List<ProjectData> newProjects = app.Projects.GetProjectList();

            oldProjects.Add(project);

            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);

            app.Login.Logout();
        }
        [Test]
        public void ProjectDeletionTest()
        {
            ProjectData project = new ProjectData {
                Name = "pr0" + DateTime.Now.ToString(),
                Description = "Description"
            };

            app.Login.Login();
            if (app.Projects.GetProjectList().Count == 0)
            {
                app.Projects.CreateProject(project);
            }

            List<ProjectData> oldProjects = app.Projects.GetProjectList();
            app.Projects.DeleteProject(project);

            List<ProjectData> newProjects = app.Projects.GetProjectList();

            oldProjects.Remove(project);

            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);

            app.Login.Logout();
        }
    }
}
