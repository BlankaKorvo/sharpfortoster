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
using System.Collections.Generic;

namespace WebTests.addressBook.Groups
{
    [TestFixture]
    public class GroupRemoval : AuthTestBase
    {
        [Test]
        public void RemoveGroup()
        {
            //prepair
            GroupData group = new GroupData() { Name = "zhertva", Footer = "zhertva", Header = "zhertva" };
            app.Groups.CreateGroupIfExist(group);
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            //action
            app.Groups.Remove(0);

            //verification
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
