using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTests.appmanager;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebTests.appmanager
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
            this.manager = manager;
        }
        public void OpenHomePage()
        {
            if (driver.Url == baseURL + "/addressbook")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/addressbook");
        }
        public void ReturnToHomePage()
        {
            if (driver.Url == baseURL + "/addressbook")
            {
                return;
            }
            driver.FindElement(By.LinkText("home")).Click();
        }
        public void OpenGroupsPage()
        {
            if (driver.Url == baseURL + "/addressbook/group.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }
    }
}
