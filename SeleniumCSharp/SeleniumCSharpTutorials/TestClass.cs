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
using OpenQA.Selenium.Interactions;

namespace SeleniumCSharpTutorials
{
    [TestFixture]
    public class TestClass : BaseTest
    {
        [Test, Category("Smoke Testing")]
        public void TestMethod1()
        {
            IWebElement emailTExtField = driver.FindElement(By.XPath(".//*[@id='email']"));
            emailTExtField.SendKeys("Selenium C#");
            driver.FindElement(By.XPath(".//*[@data-testid='cookie-policy-manage-dialog-accept-button']")).Click();
            IWebElement registerButton;
            Thread.Sleep(3000);
            try
            {
                registerButton = driver.FindElement(By.XPath(".//*[text()='Create new account']"));
                Actions action = new Actions(driver);
                action.MoveToElement(registerButton).Click().Perform();
            }
            catch (NoSuchElementException)
            {
                registerButton = driver.FindElement(By.XPath(".//*[text()='Create New Account']"));
                Actions action = new Actions(driver);
                action.MoveToElement(registerButton).Click().Perform();
            }
            Thread.Sleep(3000);

            try
            {
                IWebElement monthDropdownList = driver.FindElement(By.XPath(".//*[@title='month']"));
                Actions action = new Actions(driver);
                action.MoveToElement(registerButton).Click().Perform();
                SelectElement element = new SelectElement(monthDropdownList);
                element.SelectByIndex(1);
                element.SelectByText("Mar");
                element.SelectByValue("6");
            }
            catch (NoSuchElementException)
            {
                IWebElement monthDropdownList = driver.FindElement(By.XPath(".//*[@title='Month']"));
                Actions action = new Actions(driver);
                action.MoveToElement(registerButton).Click().Perform();
                SelectElement element = new SelectElement(monthDropdownList);
                element.SelectByIndex(1);
                element.SelectByText("Mar");
                element.SelectByValue("6");
            }
            
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
