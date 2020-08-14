using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using CoreTestFrameWork;
using TestingFrameworkLibrary;

namespace TestingGroups
{
    [TestFixture]
    public class GroupCreationTest : TestBase
    {
        [Test]
        public void CreateGroupTests()
        {
            app.Navigator.OpenHomePage();
            app.Auth.LogIn(new AccountData() { Username = "admin", Password = "secret" });
            app.Navigator.OpenGroupsPage();
            app.Groups.InitNewGroupCreation();
            app.Groups.FillGroupForm(new GroupData("name 1", "group 1", "footer 1"));
            app.Groups.SubmitGroupCreation();
            app.Navigator.OpenHomePage();
            app.Auth.LogOut();
        }        
    }
}
