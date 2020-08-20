using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebTests.appmanager;
using WebTests.model;

namespace WebTests.addressBook.Groups
{
    [TestFixture]
    class GroupModification : AuthTestBase
    {
        [Test]
        public void EditGroup()
        {
            GroupData group = new GroupData() {Name = "edited name 1",  Header = "edited header 1", Footer = "edited footer 1" };
            app.Groups.EditGroup(group, 1);
        }

        [Test]
        public void EditGroupSmart()
        {
            GroupData group = new GroupData() { Name = "edited name 1", Header = "edited footer 1" };
            app.Groups.EditGroupSmart(group, 1);
        }


    }
}
