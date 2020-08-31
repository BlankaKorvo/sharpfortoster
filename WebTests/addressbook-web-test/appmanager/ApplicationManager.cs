using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebTests.appmanager.atomicHelpers;

namespace WebTests.appmanager    
{
    public class ApplicationManager
    {
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();
        protected IWebDriver driver;
        protected string baseURL;

        protected LoginHelper loginHelper; 
        protected NavigationHelper navigationHelper;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;
        protected GroupHelperAtomic groupHelperAtomic;
        protected ContactHelperAtomic contactHelperAtomic;
        protected LoginHelperAtomic loginHelperAtomic;
        private ApplicationManager()
        {
            driver = new ChromeDriver();
            baseURL = "http://10.0.1.45";
            loginHelper = new LoginHelper(this);
            navigationHelper = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
            groupHelperAtomic = new GroupHelperAtomic(this);
            contactHelperAtomic = new ContactHelperAtomic(this);
            loginHelperAtomic = new LoginHelperAtomic(this);
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public LoginHelper Auth => loginHelper;
        public NavigationHelper Navigator => navigationHelper;
        public GroupHelper Groups => groupHelper;
        public ContactHelper Contacts => contactHelper;
        public GroupHelperAtomic GroupsAtomic => groupHelperAtomic;
        public ContactHelperAtomic ContactAtomic => contactHelperAtomic;
        public LoginHelperAtomic AuthAtomic => loginHelperAtomic;
        public IWebDriver Driver => driver;

        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();                 
                newInstance.Navigator.OpenHomePage();
                app.Value = newInstance;
            }
            return app.Value;
        }
    }
}
