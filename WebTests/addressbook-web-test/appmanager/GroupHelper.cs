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
using WebTests.appmanager.atomicHelpers;
using NUnit.Framework.Constraints;

namespace WebTests.appmanager
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public GroupHelper CreateGroup(GroupData group)
        {
            manager.Navigator.OpenGroupsPage();
            manager.GroupsAtomic.InitNewGroupCreation();
            manager.GroupsAtomic.FillGroupForm(group);
            manager.GroupsAtomic.SubmitGroupCreation();
            manager.GroupsAtomic.ReturnToGroupsPage();
            //groupCache = null;
            return this;
        }



        public GroupHelper EditGroup(GroupData group, int index)
        {
            manager.Navigator.OpenGroupsPage();
            manager.GroupsAtomic.SelectGroup(index);
            manager.GroupsAtomic.InitGroupEdition();
            manager.GroupsAtomic.FillGroupForm(group);
            manager.GroupsAtomic.SubmitGroupEdition();
            //groupCache = null;
            return this;
        }

        public GroupHelper Remove(int index)
        {
            manager.Navigator.OpenGroupsPage();
            manager.GroupsAtomic.SelectGroup(index);
            manager.GroupsAtomic.RemoveGroup();
            //groupCache = null;
            return this;
        }

        internal void Remove(GroupData group)
        {
            manager.Navigator.OpenGroupsPage();
            manager.GroupsAtomic.SelectGroup(group.Id);
            manager.GroupsAtomic.RemoveGroup();
        }

        public GroupHelper RemoveAllGroups()
        {
            manager.Navigator.OpenGroupsPage();
            manager.GroupsAtomic.SelectAllGroups();
            manager.GroupsAtomic.RemoveGroup();
            return this;
        }

        public GroupHelper CreateGroupIfExist(GroupData group)
        {
            if (!manager.GroupsAtomic.IsGroupPresentDB())
            {
                CreateGroup(group);
            }
            return this;
        }

        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.OpenGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData()
                    {
                        Name = null,
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
                string allGroupNames = driver.FindElement(By.CssSelector("div#content form")).Text;
                string[] parts = allGroupNames.Split('\n');
                int shift = groupCache.Count - parts.Length;
                for (int i = 0; i < groupCache.Count; i++)
                {
                    if (i < shift)
                    {
                        groupCache[i].Name = "";
                    }
                    else
                    {
                        groupCache[i].Name = parts[i - shift].Trim();
                    }
                }
            }
            return new List<GroupData>(groupCache);
        }
        public int GetGroupCount()
        {
            manager.Navigator.OpenGroupsPage();
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }


    }
}

