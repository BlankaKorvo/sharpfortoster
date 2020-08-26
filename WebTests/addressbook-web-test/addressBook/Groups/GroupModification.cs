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
            GroupData oldGroup = new GroupData() { Name = "name 1", Header = "header 1", Footer = "footer 1" };
            app.Groups.CreateGroupIfExist(oldGroup);            
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData newGroup = new GroupData() { Name = oldGroups[0].Name + " new Edit", Header = "new Edit", Footer = "edited name 1" };   
            
            //action
            app.Groups.EditGroup(newGroup, 0);

            //verification
            List<GroupData> NewGroups = app.Groups.GetGroupList();            
            oldGroups[0].Name = newGroup.Name;
            oldGroups.Sort();
            NewGroups.Sort();            
            Assert.AreEqual(oldGroups, NewGroups);
        }
    }
}
