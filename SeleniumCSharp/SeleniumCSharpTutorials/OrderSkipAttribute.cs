// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumCSharpTutorials.BaseClass;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using SeleniumCSharpTutorials.Utilities;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace SeleniumCSharpTutorials
{
    [TestFixture]
    public class OrderSkipAttribute
    {
        [Test, Order(2), Category("OrderSkipAttribute")]
        public void TestMethod1()
        {
            var options = new ChromeOptions();
            options.BinaryLocation = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            IWebDriver driver = new ChromeDriver(options);
            driver.Url = "https://pl-pl.facebook.com/";
            IWebElement emailTExtField = driver.FindElement(By.XPath(".//*[@id='email']"));
            emailTExtField.SendKeys("Selenium C#");
            driver.Close();
        }

        [Test, Order(1), Category("OrderSkipAttribute")]
        public void TestMethod2()
        {
            Assert.Ignore("Nie posiadam Firefox by wykonać test."); // Do usunięcia w przypadku posiadania
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "https://pl-pl.facebook.com/";
            IWebElement emailTExtField = driver.FindElement(By.XPath(".//*[@id='email']"));
            emailTExtField.SendKeys("Selenium C#");
            driver.Close();
        }

        // Na komputerze nie posiadam internetu exploler
        [Test, Order(0), Category("OrderSkipAttribute")]
        public void TestMethod3()
        {
            Assert.Ignore("Nie posiadam Internetu Exploler by wykonać test."); // Do usunięcia w przypadku posiadania
            IWebDriver driver = new InternetExplorerDriver();
            driver.Url = "https://pl-pl.facebook.com/";
            IWebElement emailTExtField = driver.FindElement(By.XPath(".//*[@id='email']"));
            emailTExtField.SendKeys("Selenium C#");
            driver.Close();
        }
    }
}
