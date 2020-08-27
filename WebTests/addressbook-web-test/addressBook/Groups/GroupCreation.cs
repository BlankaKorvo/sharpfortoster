using WebTests.appmanager;
using WebTests.model;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebTests.addressBook.Groups
{
    [TestFixture]
    public class GroupCreation : AuthTestBase
    {
        [Test]
        public void CreateGroup()
        {
            //prepair
            GroupData group = new GroupData() { Name = "Group1", Footer = "Footer1", Header = "Header" };
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
        [Test]
        public void CreateEmptyGroup()
        {
            //prepair
            GroupData group = new GroupData() {Name=""};
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