﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebTests.appmanager;

namespace WebTests.addressBook.Groups
{
    [TestFixture]
    public class GroupRemoval : AuthTestBase
    {
        [Test]
        public void RemoveGroup()
        {
            app.Groups.Remove(1);
            app.Groups.Remove(1);
        }

        [Test]
        public void RemoveGroupSmart()
        {
            app.Groups.RemoveGroupSmart(1);
            Assert.IsFalse(app.GroupsAtomic.IsGroupPresent());
        }
    }
}