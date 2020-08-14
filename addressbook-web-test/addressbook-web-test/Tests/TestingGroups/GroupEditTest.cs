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
    class GroupEditTest : TestBase
    {
        [Test]
        public void EditGroupTests()
        {
            app.Navigator.OpenHomePage();
            app.Auth.LogIn(new AccountData() { Username = "admin", Password = "secret" });
            app.Navigator.OpenGroupsPage();
            app.Groups.SelectGroup(1);
            app.Groups.InitGroupEdition();
            app.Groups.FillGroupForm(new GroupData("edited name 1", "edited group 1", "edited footer 1"));
            app.Groups.SubmitGroupEdition();
            app.Navigator.OpenHomePage();
            app.Auth.LogOut();
        }

    }
}
