using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTests.model;

namespace WebTests.addressBook.Groups
{
    public class ContactToGroupTests: GroupTestBase
    {
        [Test]
        public void TestAddingRemovalContactToGroup()
        {
            //prepair
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAllContacts().Except(oldList).First();

            //action add contact
            app.Contacts.AddContactToGroup(contact, group);


            //Verification add contact
            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);

            //action remove contact
            app.Contacts.RemoveContactFromGroup(contact, group);
            //verification
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
