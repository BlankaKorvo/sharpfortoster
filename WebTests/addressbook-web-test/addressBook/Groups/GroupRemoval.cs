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
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData item in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
