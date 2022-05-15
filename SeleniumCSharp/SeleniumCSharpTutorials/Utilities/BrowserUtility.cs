﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharpTutorials.Utilities
{
    public class BrowserUtility
    {
        public IWebDriver Init(IWebDriver driver)
        {
            var options = new ChromeOptions();
            options.BinaryLocation = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            driver = new ChromeDriver(options);
            driver.Url = "https://www.facebook.com/";
            return driver;
        }
    }
}
