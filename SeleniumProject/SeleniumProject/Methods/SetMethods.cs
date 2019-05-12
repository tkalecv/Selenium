using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.DriverModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SeleniumProject.Methods
{
    public class SetMethods
    {
        //Static means that this method can be called without creating instance of this class

        //Method for entering text into textBox
        public static void EnterText(IWebElement element, string value)
        {
            element.SendKeys(value);
        }

        //Click on a button
        public static void Click(IWebElement element)
        {
            element.Click();
        }

        //Submit method for buttons that have class submit
        public static void Submit(IWebElement element)
        {
            element.Submit();
        }



        //**PlusPlaner**//

        //Waits for page to load completly
        public static void WaitPageToLoad(IWebDriver driver, int seconds)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(seconds)).Until(
                  d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

    }
}
