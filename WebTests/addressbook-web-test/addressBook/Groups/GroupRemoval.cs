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
    public class GroupRemoval : AuthTestBase
    {
        [Test]
        public void RemoveGroup()
        {
            if (app.GroupsAtomic.IsGroupPresent())
            {
                app.Groups.Remove(1);
            }
            else
            {
                GroupData group = new GroupData() { Name = "zhertva", Footer = "zhertva", Header = "zhertva" };
                app.Groups.CreateGroup(group);
                app.Groups.Remove(1);
            }
        }
    }
}
