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
            GroupData group = new GroupData() { Name = "Group1", Footer = "Footer1", Header = "Header"};
            app.Groups.CreateGroup(group);
        }
    }
}