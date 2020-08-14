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
    public class GroupRemovalTest : TestBase
    {
        [Test]
        public void RemoveGroupTests()
        {
            app.Navigator.OpenHomePage();
            app.Auth.LogIn(new AccountData() { Username = "admin", Password = "secret" });
            app.Navigator.OpenGroupsPage();
            app.Groups.SelectGroup(1);
            app.Groups.DeleteGroup();
            app.Auth.LogOut();
        }
    }
}
