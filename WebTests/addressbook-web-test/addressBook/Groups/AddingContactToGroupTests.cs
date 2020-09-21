using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTests.model;

namespace WebTests.addressBook.Groups
{
    public class AddingContactToGroupTests: GroupTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(oldList).First();

            //action
            app.Contacts.AddContactToGroup(contact, group);



            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();


            Assert.AreEqual(oldList, newList);

        }
    }
}
