using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumProject.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.PageObjects
{
    public class PlusPlanerPageObjects
    {
        //It is used if ID of WebElement SearchID changes

        private IWebDriver driver;

        public PlusPlanerPageObjects(IWebDriver _driver) => driver = _driver;

        public IWebElement userName => driver.FindElement(By.Id("Username"));
        public IWebElement password => driver.FindElement(By.Id("password"));
        public IWebElement btnLogIn => driver.FindElement(By.Name("action"));
        public IWebElement ul_alert => driver.FindElement(By.CssSelector("body > div.container > div > div > div > div > div > div > div > div > ul"));



        public void ElementExist(IWebElement element)
        {
            try
            {
                //print your message for the case assert pass and/or perform any other event
                Assert.IsTrue(element.Displayed);
                Console.WriteLine("Element exist! \n***********************");
            }
            catch (Exception e)
            {
                //print your message for the case assert fails and/or perform any other event
                Console.WriteLine("Element does not exist: " + e);
            }
        }

        public void isElementEnabled(IWebElement element)
        {
            try
            {
                //print your message for the case assert pass and/or perform any other event
                Assert.IsTrue(element.Enabled);
                Console.WriteLine("Element is enabled! \n***********************");
            }
            catch (Exception e)
            {
                //print your message for the case assert fails and/or perform any other event
                Console.WriteLine("Element is not enabled: " + e);
            }

        }

        public void IsElementEmpty(IWebElement element)
        {
            string text = element.GetAttribute("value");

            try
            {
                //print your message for the case assert pass and/or perform any other event
                Assert.IsEmpty(text);
                Console.WriteLine("Element is empty! \n***********************");
            }
            catch (Exception e)
            {
                //print your message for the case assert fails and/or perform any other event
                Console.WriteLine("Element is not empty: " + e);
            }
        }


        public void AlertMessages(string message)
        {
            IList<IWebElement> li_All = ul_alert.FindElements(By.TagName("li"));

            foreach (IWebElement element in li_All)
            {
                try
                {
                    //print your message for the case assert pass and/or perform any other event
                    Assert.AreEqual(message, element.Text);
                    Console.WriteLine("Correct message showed!! \n***********************");
                }
                catch (Exception e)
                {
                    //print your message for the case assert fails and/or perform any other event
                    Console.WriteLine("Wrong message showed: " + e);
                }
            }
        }

        public void LogIn(string username, string pass)
        {
            try
            {
                userName.Clear();
                userName.SendKeys(username);
                password.Clear();
                password.SendKeys(pass);

                btnLogIn.Submit();

                string url2 = driver.Url;
                SetMethods.WaitPageToLoad(driver, 30);
                GetMethods.CheckPage(url2, "raspored");
                Console.WriteLine(" And LogIn successful! \n***********************");
            }
            catch (Exception e)
            {
                Console.WriteLine("LogIn failed: " + e);
            }

        }



    }
}
