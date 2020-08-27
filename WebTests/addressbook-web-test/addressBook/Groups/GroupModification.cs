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
    class GroupModification : AuthTestBase
    {   
        [Test]
        public void EditGroup()
        {
            //prepair
            GroupData groupData = new GroupData() { Name = "nameGroup", Header = "headerGroup", Footer = "footerGroup" };
            app.Groups.CreateGroupIfExist(groupData);            
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            groupData.Name += groupData.Name;
            GroupData groupDataBefore = oldGroups[0];

            //action
            app.Groups.EditGroup(groupData, 0);

            //verification
            int count = app.Groups.GetGroupCount();
            Assert.AreEqual(oldGroups.Count, count);

            List<GroupData> NewGroups = app.Groups.GetGroupList();            
            oldGroups[0].Name = groupData.Name;
            oldGroups.Sort();
            NewGroups.Sort();
            Assert.AreEqual(oldGroups, NewGroups);
            foreach (GroupData item in NewGroups)
            {
                if (item.Id == groupDataBefore.Id)
                {
                    Assert.AreEqual(groupData.Name, item.Name);
                }
            }
        }
    }
}
