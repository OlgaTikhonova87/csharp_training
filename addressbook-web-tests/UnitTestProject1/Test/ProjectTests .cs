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
            AccountData account = new AccountData
            {
                Name = "administrator",
                Password = "root"
            };
            ProjectData project = new ProjectData 
            {
                Name = "pr0"+DateTime.Now.ToString(),
                Description = "Description"
            };
            
            var oldProjects = app.API.GetAPIProjectsList(account);
            //List<ProjectData> oldProjects = app.Projects.GetProjectList();

            app.Login.Login();
            app.Projects.CreateProject(project);

            List<ProjectData> newProjects = app.API.GetAPIProjectsList(account);
            //List<ProjectData> newProjects = app.Projects.GetProjectList();

            oldProjects.Add(project);

            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);

            app.Login.Logout();
        }
        [Test]
        public void ProjectDeletionTest()
        {
            AccountData account = new AccountData
            {
                Name = "administrator",
                Password = "root"
            };
            ProjectData newproject = new ProjectData {
                Name = "pr0" + DateTime.Now.ToString(),
                Description = "Description"
            };

            //if (app.Projects.GetProjectList().Count == 0)
            //{
            //    app.Projects.CreateProject(project);
            //}

            //Проверим, есть ли проекты. Если нет - создадим
            if (app.API.GetAPIProjectsList(account).Count == 0)
            {
                app.Projects.CreateProject(newproject);
            }

            //получим список проектов через апи и первый из них, который будем удалять
            List<ProjectData> oldProjects = app.API.GetAPIProjectsList(account);
            ProjectData delproject = new ProjectData
            {
                Name = oldProjects[0].Name,
                Description = oldProjects[0].Description
            };

            //Удалим интерфейсно и в старом списке
            app.Login.Login();
            app.Projects.DeleteProject(delproject);
            oldProjects.Remove(delproject);
            //получим по апи список оставшихся проектов
            List<ProjectData> newProjects = app.API.GetAPIProjectsList(account);

            //отсортируеи и сравним
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);

            app.Login.Logout();
        }
    }
}
