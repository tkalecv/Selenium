using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumProject.DriverModel;
using SeleniumProject.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumProject.PageObjects;

namespace SeleniumProject.Tests
{
    public class FirstAssignmentTests
    {
        [SetUp]
        public void Initialize()
        {
            WebDriver.driver = new ChromeDriver();

            //Navigate to page you want to test
            WebDriver.driver.Navigate().GoToUrl("https://www.google.hr/");

            //Maximaze browser if it is not 
            WebDriver.driver.Manage().Window.Maximize();

            Console.WriteLine("Opened URL!");
        }

        //Attribute that this is a test by NUnit
        [Test]
        public void ExecuteTest()
        {
            PageObject page = new PageObject(WebDriver.driver);

            //Calling PageObject search method
            page.Search("facebook");

            Console.WriteLine("Executed Test!");

            //Check what is entered text
            Console.WriteLine("Entered text is: " + page.searchField);
        }

        [TearDown]
        public void Close()
        {
            //Close the driver at the end of testing
            WebDriver.driver.Close();
            Console.WriteLine("Closed the browser!");
        }
    }
}
