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
            GroupData group = new GroupData("edited name 1", null, "edited footer 1");
            app.Groups.EditGroup(group, 1);
        }

    }
}
