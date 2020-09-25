using MySqlX.XDevAPI.CRUD;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebTests.model;

namespace WebTests.addressBook.Groups
{
    public class ContactToGroupTests: GroupTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            //prepair
            ContactData newContact = new ContactData() { FirstName = "contactAddToGroup" };
            app.Contacts.CreateContactIfExist(newContact);

            GroupData newGroup = new GroupData() { Name = "groupWhictAddingContact" };
            app.Groups.CreateGroupIfExist(newGroup);

            ContactData contactWhichAddToGroup = null;
            GroupData groupWhichAddingContact = null;

            //Ищем контакт, который не входит в какую либо группу
            List<GroupData> allgroups = GroupData.GetAllGroups();
            List<ContactData> allContacts = ContactData.GetAllContacts();
            foreach (ContactData contact in allContacts)
            {
                List<GroupData> contactGroups =  contact.GetGroups();
                List<GroupData> groupsWithoutThisContact = allgroups.Except(contactGroups).ToList();
                if (groupsWithoutThisContact.Count > 0)
                {
                    contactWhichAddToGroup = contact;
                    groupWhichAddingContact = groupsWithoutThisContact[0];
                    break;
                }
            }

            //Если не нашли создаем новый
            if (contactWhichAddToGroup == null)
            {
                app.Contacts.CreateContact(newContact);
                List<ContactData> newAllContacts = ContactData.GetAllContacts();
                //contactWithAddToGroup = newAllContacts.Last(); //будет быстрее, но есть подозрение, что могут быть баги. Тестить ради учебы - лениво. 
                contactWhichAddToGroup = newAllContacts.FirstOrDefault(x=>!allContacts.Remove(x)); //except метод тут не годится, так как в случае одноименных груп, может (проверено) не найти лишний элемент.
                groupWhichAddingContact = allgroups[0];
            }

            //Оставляем для истории старый список контактов для данной группы
            List<ContactData> oldListContactsInGroup = groupWhichAddingContact.GetContacts();

            //action add contact
            app.Contacts.AddContactToGroup(contactWhichAddToGroup, groupWhichAddingContact);


            //Verification add contact
            List<ContactData> newListContactsInGroup = groupWhichAddingContact.GetContacts();
            oldListContactsInGroup.Add(contactWhichAddToGroup);
            oldListContactsInGroup.Sort();
            newListContactsInGroup.Sort();
            Assert.AreEqual(oldListContactsInGroup, newListContactsInGroup);
        }

        [Test]
        public void TestRemovalContactFromGroup()
        {
            //prepair
            GroupData newGroup = new GroupData() { Name = "groupWhictAddingContact" };
            app.Groups.CreateGroupIfExist(newGroup);

            ContactData newContact = new ContactData() { FirstName = "contactAddToGroup" };
            app.Contacts.CreateContactIfExist(newContact);

            GroupData testGroup = null;
            ContactData testContact = null;
            //ищем группы, где есть контакт
            List<GroupData> groups = GroupData.GetAllGroups();
            foreach(GroupData item in groups)
            {
                if (item.GetContacts().Count != 0)
                {
                    testGroup = item;
                    testContact = testGroup.GetContacts().FirstOrDefault();
                }
                break;
            }
            //если не нашли - добавляем первый попавшийся контакт в первую попавшуюся группу
            if (testGroup == null)
            {
                testContact = ContactData.GetAllContacts().FirstOrDefault();
                testGroup = GroupData.GetAllGroups().FirstOrDefault();
                app.Contacts.AddContactToGroup(testContact, testGroup);          
            }
            //прикапываем список контактов в тестовой группе, до удаления
            List<ContactData> oldListContactsInTestGroup = testGroup.GetContacts();

            //action test
            app.Contacts.RemoveContactFromGroup(testContact, testGroup);

            //verification
            List<ContactData> newListContactsInTestGroup = testGroup.GetContacts();
            oldListContactsInTestGroup.Remove(testContact);
            oldListContactsInTestGroup.Sort();
            newListContactsInTestGroup.Sort();

            Assert.AreEqual(oldListContactsInTestGroup, newListContactsInTestGroup);
        }

    }
}
