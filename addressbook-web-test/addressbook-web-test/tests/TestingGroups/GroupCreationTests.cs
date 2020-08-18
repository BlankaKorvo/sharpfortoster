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
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void CreateGroupTests()
        {
            GroupData group = new GroupData("name 1", "group 1", "footer 1");            
            appManager.Groups.CreateGroup(group);
        }
        [Test]
        public void CreateEmptyGroupTests()
        {
            GroupData group = new GroupData("", "", "");
            appManager.Groups.CreateGroup(group);
        }
    }
}
