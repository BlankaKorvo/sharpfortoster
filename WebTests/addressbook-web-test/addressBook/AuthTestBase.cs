using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTests.appmanager;
using WebTests.model;

namespace WebTests.addressBook
{
    public class AuthTestBase : TestBase
    {
        //protected ApplicationManager app;
        [SetUp]
        public void SetupLogin()
        {
            app.Auth.LogIn(new AccountData() { Username = "admin", Password = "secret" });
        }
    }
}
