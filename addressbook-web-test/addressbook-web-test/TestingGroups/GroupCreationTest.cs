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
        public void CreateGroupsTests()
        {
            OpenHomePage();
            LogIn(new AccountData() { Username = "admin", Password = "secret" });
            GoToGroupsPage();
            InitNewGroupCreation();
            FillGroupForm(new GroupData("name 1", "group 1", "footer 1"));
            SubmitGroupCreation();
            OpenHomePage();
            LogOut();
        }        
    }
}
