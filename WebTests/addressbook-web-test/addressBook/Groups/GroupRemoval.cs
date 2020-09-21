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
using System.Threading.Tasks;

namespace WebTests.addressBook.Groups
{
    [TestFixture]
    public class GroupRemoval : GroupTestBase
    {
        [Test]
        public void RemoveGroup()
        {
            //prepair
            GroupData group = new GroupData() { Name = "zhertva", Footer = "zhertva", Header = "zhertva" };
            app.Groups.CreateGroupIfExist(group);
            List<GroupData> oldGroups = GroupData.GetAll();
            //List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[0];

            //action
            app.Groups.Remove(oldGroups[0]);

            //verification
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            //GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
            Parallel.ForEach(newGroups, item =>
            {
                Assert.AreNotEqual(item.Id, toBeRemoved.Id);
            });
            //foreach (GroupData item in newGroups)
            //{
            //    Assert.AreNotEqual(item.Id, toBeRemoved.Id);
            //}
        }
        //[Test]
        //public void RemoveAllGroup()
        //{
        //    //prepair
        //    GroupData group = new GroupData() { Name = "zhertva", Footer = "zhertva", Header = "zhertva" };
        //    app.Groups.CreateGroupIfExist(group);

        //    //action
        //    app.Groups.RemoveAllGroups();

        //    //Assert
        //    Assert.IsFalse(app.GroupsAtomic.IsGroupPresent());

        //}
    }
}
