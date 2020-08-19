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

namespace WebTests.addressBook
{
    public class TestBase
    {
        protected ApplicationManager app;

        [OneTimeSetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
         }

         
    }
}
