using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreTestFrameWork;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestingFrameworkLibrary
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
            driver.Navigate().GoToUrl(baseURL + "/addressbook");
        }
        public void ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }
        public void OpenGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

    }
}
