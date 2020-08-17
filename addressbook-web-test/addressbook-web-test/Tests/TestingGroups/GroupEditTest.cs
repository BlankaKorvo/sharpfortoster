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
            appManager.Navigator.OpenGroupsPage();
            appManager.Groups.SelectGroup(1);
            appManager.Groups
                .InitGroupEdition()
                .FillGroupForm(new GroupData("edited name 1", "edited group 1", "edited footer 1"))
                .SubmitGroupEdition();
            appManager.Navigator.OpenHomePage();
            appManager.Auth.LogOut();
        }

    }
}
