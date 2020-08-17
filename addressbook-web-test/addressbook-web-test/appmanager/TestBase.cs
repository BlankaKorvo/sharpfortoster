using CoreTestFrameWork;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace TestingFrameworkLibrary
{
    public class TestBase
    {
        protected ApplicationManager appManager;

        [SetUp]
        public void SetupTest()
        {
            appManager = new ApplicationManager();
            appManager.Navigator.OpenHomePage();
            appManager.Auth.LogIn(new AccountData() { Username = "admin", Password = "secret" });
        }

        [TearDown]
        public void TeardownTest()
        {
            appManager.StopTest();
        }
    }
}
