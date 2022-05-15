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

namespace SeleniumCSharpTutorials
{
    [TestFixture]
    public class TestClass : BaseTest
    {
        [Test, Category("Smoke Testing")]
        public void TestMethod1()
        {
            Assert.Ignore("Facebook zmienił dostęp do rejestracji, przez co wykonanie testu jest niemożliwe na obecnej wersji.");
            IWebElement emailTExtField = driver.FindElement(By.XPath(".//*[@id='email']"));
            emailTExtField.SendKeys("Selenium C#"); 
            IWebElement monthDropdownList = driver.FindElement(By.XPath(".//*[@id='month']"));
            SelectElement element = new SelectElement(monthDropdownList);
            element.SelectByIndex(1);
            element.SelectByText("Mar");
            element.SelectByValue("6");
        }

        [Test, Category("Regression Testing")]
        public void TestMethod2()
        {
            IWebElement emailTExtField = driver.FindElement(By.XPath(".//*[@id='email']"));
            emailTExtField.SendKeys("Selenium C#");
        }

        [Test, Category("Smoke Testing")]
        public void TestMethod3()
        {
            IWebElement emailTExtField = driver.FindElement(By.XPath(".//*[@id='email']"));
            emailTExtField.SendKeys("Selenium C#");
            Thread.Sleep(5000);
        }
    }
}
