using WebTests.appmanager;
using WebTests.model;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;

namespace WebTests.addressBook.Groups
{
    [TestFixture]
    public class GroupCreation : AuthTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData()
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100),
                    Name = GenerateRandomString(30)
                }) ;
            }
            return groups;
        }

        [Test, TestCaseSource("RandomGroupDataProvider")]
         public void CreateGroup(GroupData group)
        {
            //prepair
            // GroupData group = new GroupData() { Name = "Group1", Footer = "Footer1", Header = "Header" };
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            //action
            app.Groups.CreateGroup(group);

            //verification
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> NewGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            NewGroups.Sort();
            Assert.AreEqual(oldGroups, NewGroups);
        }

        //[Test]
        //public void CreateEmptyGroup()
        //{
        //    //prepair
        //    GroupData group = new GroupData() {Name=""};
        //    List<GroupData> oldGroups = app.Groups.GetGroupList();

        //    //action
        //    app.Groups.CreateGroup(group);

        //    //verification
        //    Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

        //    List<GroupData> NewGroups = app.Groups.GetGroupList();
        //    oldGroups.Add(group);
        //    oldGroups.Sort();
        //    NewGroups.Sort();
        //    Assert.AreEqual(oldGroups, NewGroups);
        //}

        [Test]
        public void CreateBadGroup()
        {
            //prepair
            GroupData group = new GroupData() {Name = "a'a" };
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            //action
            app.Groups.CreateGroup(group);

            //verification
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> NewGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            NewGroups.Sort();
            Assert.AreEqual(oldGroups, NewGroups);
        }
    }
}