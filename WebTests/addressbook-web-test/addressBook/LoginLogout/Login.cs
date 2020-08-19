using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebTests.appmanager;
using WebTests.model;

namespace WebTests.addressBook.Authorization
{
    [TestFixture]
    public class Login : AuthTestBase
    {
        [Test]
        public void LoginWithValidCredential()
        {
            //prepair
            app.Auth.Logout();
            app.Auth.Logout();
            //action
            AccountData account = new AccountData() { Username = "admin", Password = "secret" };
            app.Auth.LogIn(account);
            //verification
            Assert.IsTrue(app.AuthAtomic.IsLoggedIn(account));
        }
        [Test]
        public void LoginWithInvalidCredential()
        {
            //prepair
            app.Auth.Logout();
            app.Auth.Logout();
            //action
            AccountData account = new AccountData() { Username = "admin", Password = "12345" };
            app.Auth.LogIn(account);
            //verification
            Assert.IsFalse(app.AuthAtomic.IsLoggedIn(account));
        }

    }
}
