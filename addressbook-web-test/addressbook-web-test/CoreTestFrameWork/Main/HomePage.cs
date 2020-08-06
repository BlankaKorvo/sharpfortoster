﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTestFrameWork.Main
{
    class HomePage
    {
        private IWebDriver _driver;
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }
        public void Open()
        {
            _driver.Navigate().GoToUrl(new BaseUrl().Url + "/addressbook");
        }
    }
}
