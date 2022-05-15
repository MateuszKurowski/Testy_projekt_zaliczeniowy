using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumCSharpTutorials
{
    [TestFixture]
    public class SeleniumCSharpTutorial04
    {
        [Test]
        [Author("Mateusz Kurowski", "testowy.mail@gmail.com")]
        [Description("Facebook login Verify")]
        [TestCaseSource("DataDrivenTesting")]
        public void Test1(string urlName)
        {
            IWebDriver driver = null;
            try
            {
                var options = new ChromeOptions();
                options.BinaryLocation = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
                driver = new ChromeDriver(options);
                driver.Manage().Window.Maximize();
                //driver.Url = "https://pl-pl.facebook.com/";
                driver.Url = urlName;
                IWebElement emailTExtField = driver.FindElement(By.XPath(".//*[@id='email']"));
                //IWebElement emailTExtField = driver.FindElement(By.XPath(".//*[@id='abcd']"));
                emailTExtField.SendKeys("Selenium C#");
                driver.Quit();
            }
            catch (Exception e)
            {
                ITakesScreenshot ts = driver as ITakesScreenshot;
                Screenshot screenshot = ts.GetScreenshot();
                screenshot.SaveAsFile(@"E:\Projects\Test_i_kontrola_jakosci_oprogramowania\SeleniumCSharp\SeleniumCSharpTutorials\Screenshots\Screenshot1.jpeg", ScreenshotImageFormat.Jpeg);
                Console.WriteLine(e.StackTrace);
                throw;
            }
            finally
            {
                if (driver != null)
                {
                    driver.Quit();
                }
            }
        }

        static IList DataDrivenTesting()
        {
            ArrayList list = new ArrayList();
            list.Add("https://pl-pl.facebook.com/");
            //list.Add("https://www.youtube.com/");
            //list.Add("https://twitter.com/");
            return list;
        }

        //[Test]
        //[Author("Mateusz Kurowski", "testowy.mail@gmail.com")]
        //[Description("Facebook login Verify")]
        //public void Test2()
        //{
        //    var options = new ChromeOptions();
        //    options.BinaryLocation = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
        //    IWebDriver driver = new ChromeDriver(options);
        //    driver.Manage().Window.Maximize();
        //    driver.Url = "https://pl-pl.facebook.com/";
        //    IWebElement emailTExtField = driver.FindElement(By.XPath(".//*[@id='email']"));
        //    emailTExtField.SendKeys("Selenium C#");
        //    driver.Quit();
        //}
    }
}
