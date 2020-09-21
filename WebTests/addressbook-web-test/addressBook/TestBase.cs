using WebTests.appmanager;
using WebTests.model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using WebTests.addressBook;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;

namespace WebTests.addressBook
{
    public class TestBase
    {
        public static bool PERFORM_LONG_UI_CHEKS = true;
        protected ApplicationManager app;


        [OneTimeSetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }

        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65)));
            }
            return builder.ToString();
        }

        public static IEnumerable<T> DataFromXmlFile<T>(string path)
        {
            return (List<T>)
                new XmlSerializer(typeof(List<T>)).Deserialize(new StreamReader(path));
        }

        public static IEnumerable<T> DataFromJsonFile<T>(string path)
        {
            return JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(path));
        }
    }
}
