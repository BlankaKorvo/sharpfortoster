﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebTests.appmanager;
using WebTests.model;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebTests.appmanager.atomicHelpers
{
    public class GroupHelperAtomic : HelperBase
    {
        public GroupHelperAtomic(ApplicationManager manager) : base(manager)
        {
        }
        public GroupHelperAtomic SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }
        public GroupHelperAtomic DeleteGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }
        public GroupHelperAtomic SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelperAtomic FillGroupForm(GroupData groupData)
        {

            Type(By.Name("group_name"), groupData.Name);
            Type(By.Name("group_header"), groupData.Header);
            Type(By.Name("group_footer"), groupData.Footer);
            return this;
        }

        public GroupHelperAtomic InitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelperAtomic InitGroupEdition()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
        public GroupHelperAtomic SubmitGroupEdition()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }
        public GroupHelperAtomic ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

    }
}
