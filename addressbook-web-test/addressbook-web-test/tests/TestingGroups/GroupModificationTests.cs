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
    class GroupModificationTests : TestBase
    {
        [Test]
        public void EditGroupTests()
        {
            GroupData group = new GroupData("edited name 1", "edited group 1", "edited footer 1");
            appManager.Groups.EditGroup(group, 1);
        }

    }
}
