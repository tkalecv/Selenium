using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumProject.DriverModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.Methods
{
    public class GetMethods
    {
        //Static means that this methods can be called without creating instance of this class

        //Get text from TextBox
        public static string GetText(IWebElement element)
        {
            return element.GetAttribute("value");
        }


        //**PlusPlaner**//

        public static void CheckPage(string url, string condition)
        {
            try
            {
                //print your message for the case assert pass and/or perform any other event
                Assert.IsTrue(url.Contains(condition), condition);
                Console.WriteLine("Correct page loaded! \n***********************");
            }
            catch (Exception e)
            {
                //print your message for the case assert fails and/or perform any other event
                Console.WriteLine("Wrong page loaded: " + e);
            }

        }

    }
}
