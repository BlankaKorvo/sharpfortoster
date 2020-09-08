using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WebTests.addressBook;
using WebTests.model;
using Excel = Microsoft.Office.Interop.Excel;

namespace AddressBookTestDataGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeData = args[0];
            int count = Convert.ToInt32(args[1]);
            string fileName = args[2];
            string format = args[3];

            List<GroupData> groups = new List<GroupData>();
            for (int i = 1; i <= count; i++)
            {
                groups.Add(new GroupData()
                {
                    Name = TestBase.GenerateRandomString(10),
                    Header = TestBase.GenerateRandomString(100),
                    Footer = TestBase.GenerateRandomString(100)
                }) ;
            }

            List<ContactData> contacts = new List<ContactData>();
            for (int i = 1; i <= count; i++)
            {
                contacts.Add(new ContactData()
                {
                    FirstName = TestBase.GenerateRandomString(10),
                    MiddleName = TestBase.GenerateRandomString(100),
                    LastName = TestBase.GenerateRandomString(100)
                });
            }           

            switch (typeData)
            {
                case "groups":
                    if (format == "xml")
                    {
                        WriteDataToXmlFile(groups, fileName);
                    }
                    else if (format == "json")
                    {
                        WriteDataToJsonFile(groups, fileName);
                    }
                    else 
                    {
                        Console.Out.Write("Unrecognized format: " + format);        
                    }
                    break;

                case "contacts":
                    if (format == "xml")
                    {
                        WriteDataToXmlFile(contacts, fileName);
                    }
                    else if (format == "json")
                    {
                        WriteDataToJsonFile(contacts, fileName);
                    }
                    else
                    {
                        Console.Out.Write("Unrecognized format: " + format);
                    }
                    break;
                default:
                    {
                        Console.WriteLine("Unrecognized type of test data: " + typeData);
                    }
                    break;
            }
            {
                //if (format == "exel")
                //{
                //    WriteGroupsToExcelFile(groups, fileName + ".xlsx");
                //}
                //else
                //{
                //    StreamWriter writer = new StreamWriter(fileName + "." + format);
                //    if (format == "csv")
                //    {
                //        WriteGroupsToCsvFile(groups, writer);
                //    }
                //    else if (format == "xml")
                //    {
                //        WriteGroupsToXmlFile(groups, writer);
                //    }
                //    else if (format == "json")
                //    {
                //        WriteGroupsToJsonFile(groups, writer);
                //    }
                //    else
                //    {
                //        Console.Out.Write("Unrecognized format " + format);
                //    }
                //    writer.Close();
                //}    
            }
        }

        static void WriteGroupsToExcelFile(List<GroupData> groups, string fileName)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;

            int row = 1;
            foreach (GroupData group in groups)
            {
                sheet.Cells[row, 1] = group.Name;
                sheet.Cells[row, 2] = group.Header;
                sheet.Cells[row, 3] = group.Footer;
                row++;
            }
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            File.Delete(fullPath);
            wb.SaveAs(fullPath);

            wb.Close();
            app.Visible = false;
            app.Quit();
        }

        static void WriteGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0}, ${1}, ${2}",
                group.Name, group.Header, group.Footer));
            }
        }

        static void WriteDataToXmlFile<T>(List<T> content, string fileName)
        {
            StreamWriter writer = new StreamWriter(fileName + ".xml");
            new XmlSerializer(typeof(List<T>)).Serialize(writer, content);
            writer.Close();
        }

        static void WriteDataToJsonFile<T>(List<T> content, string fileName)
        {
            StreamWriter writer = new StreamWriter(fileName + ".json");
            writer.Write(JsonConvert.SerializeObject(content, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore}));
            writer.Close();
        }
    }
}
