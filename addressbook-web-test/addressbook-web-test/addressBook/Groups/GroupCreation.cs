using WebTests.appmanager;
using WebTests.model;
using NUnit.Framework;

namespace WebTests.addressBook.Groups
{
    [TestFixture]
    public class GroupCreation : AuthTestBase
    {
        [Test]
        public void CreateGroup()
        {
            GroupData group = new GroupData("name 1", "group 1", "footer 1");
            app.Groups.CreateGroup(group);
        }
        [Test]
        public void CreatePartialGroup()
        {
            GroupData group = new GroupData("name 2", null, null);
            app.Groups.CreateGroup(group);


            //    [Test]
            //    public void CreateEmptyGroupTests()
            //    {
            //        GroupData group = new GroupData("", "", "");
            //        appManager.Groups.CreateGroup(group);
            //    }
        }


    }
}