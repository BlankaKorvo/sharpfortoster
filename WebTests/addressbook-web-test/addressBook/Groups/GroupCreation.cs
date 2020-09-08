using WebTests.appmanager;
using WebTests.model;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;
using System.Xml.Serialization;
using System.IO;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;

namespace WebTests.addressBook.Groups
{
    [TestFixture]
    public class GroupCreation : AuthTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData()
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100),
                    Name = GenerateRandomString(30)
                }) ;
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"addressbook-web-test\groups.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData()
                {
                    Name = parts[0],
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            return (List<GroupData>) 
                new XmlSerializer(typeof(List<GroupData>)).Deserialize(new StreamReader(@"addressbook-web-test\groups.xml"));
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(File.ReadAllText(@"addressbook-web-test\groups.json"));
        }

        public static IEnumerable<GroupData> GroupDataFromExcelFile()
        {
            List<GroupData> groups = new List<GroupData>();
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"addressbook-web-test\groups.xlsx"));
            Excel.Worksheet sheet = wb.ActiveSheet;
            Excel.Range range = sheet.UsedRange;
            for (int i = 1; i <= range.Rows.Count; i++)
            {
                groups.Add(new GroupData()
                {
                    Name = range.Cells[i, 1].Value,
                    Header = range.Cells[i, 2].Value,
                    Footer = range.Cells[i, 3].Value
                });
            }
            wb.Close();
            app.Visible = false;
            app.Quit();
            return groups;
        }

        [Test, TestCaseSource("GroupDataFromExcelFile")]
         public void CreateGroup(GroupData group)
        {
            //prepair
            // GroupData group = new GroupData() { Name = "Group1", Footer = "Footer1", Header = "Header" };
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            //action
            app.Groups.CreateGroup(group);

            //verification
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> NewGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            NewGroups.Sort();
            Assert.AreEqual(oldGroups, NewGroups);
        }

        [Test]
        public void CreateEmptyGroup()
        {
            //prepair
            GroupData group = new GroupData() { Name = "" };
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            //action
            app.Groups.CreateGroup(group);

            //verification
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> NewGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            NewGroups.Sort();
            Assert.AreEqual(oldGroups, NewGroups);
        }

        [Test]
        public void CreateBadGroup()
        {
            //prepair
            GroupData group = new GroupData() {Name = "a'a" };
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            //action
            app.Groups.CreateGroup(group);

            //verification
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> NewGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            NewGroups.Sort();
            Assert.AreEqual(oldGroups, NewGroups);
        }
    }
}