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

namespace WebTests.addressBook.Groups
{
    [TestFixture]
    public class GroupRemoval : AuthTestBase
    {
        [Test]
        public void RemoveGroup()
        {
            //prepair
            GroupData group = new GroupData() { Name = "zhertva", Footer = "zhertva", Header = "zhertva" };
            app.Groups.CreateGroupIfExist(group);
            //action
            app.Groups.Remove(1);
            //verification
        }
    }
}
