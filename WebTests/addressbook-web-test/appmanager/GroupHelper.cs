using System;
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
        public GroupHelper (ApplicationManager manager) : base(manager)
        {
        }
        public GroupHelper CreateGroup(GroupData group)
        {
            manager.Navigator.OpenGroupsPage();
            manager.GroupsAtomic.InitNewGroupCreation();
            manager.GroupsAtomic.FillGroupForm(group);
            manager.GroupsAtomic.SubmitGroupCreation();
            manager.GroupsAtomic.ReturnToGroupsPage(); 
            return this;
        }
        public GroupHelper EditGroup (GroupData group, int index)
        {
            manager.Navigator.OpenGroupsPage();
            manager.GroupsAtomic.SelectGroup(index);
            manager.GroupsAtomic.InitGroupEdition();
            manager.GroupsAtomic.FillGroupForm(group);
            manager.GroupsAtomic.SubmitGroupEdition();
            return this;
        }
        public GroupHelper EditGroupSmart(GroupData group, int index)
        {
            if (manager.GroupsAtomic.IsGroupPresent())
            {
                EditGroup(group, index);
            }
            else
            {
                CreateGroup(group);
                group.Name += group.Name;
                group.Header += group.Header;
                group.Footer += group.Footer;
                EditGroup(group, index);
            }
            return this;
        }

        public GroupHelper Remove(int index)
        {
            manager.Navigator.OpenGroupsPage();
            manager.GroupsAtomic.SelectGroup(index);
            manager.GroupsAtomic.RemoveGroup();
            return this;
        }
        public GroupHelper RemoveGroupSmart(int index)
        {            
            if (manager.GroupsAtomic.IsGroupPresent())
            {
                Remove(index);
            }
            else
            {
                GroupData group = new GroupData() { Name = "zhertva", Footer = "zhertva", Header = "zhertva" };
                CreateGroup(group);
                Remove(index);
            }
            return this;
        }

    }
}

