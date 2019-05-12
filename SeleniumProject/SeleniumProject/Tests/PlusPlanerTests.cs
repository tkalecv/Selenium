using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.DriverModel;
using SeleniumProject.Methods;
using SeleniumProject.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.Tests
{
    public class PlusPlanerTests
    {


        [SetUp]
        public void SetUp()
        {
            WebDriver.driver = new ChromeDriver();

            //Navigate to page you want to test
            WebDriver.driver.Navigate().GoToUrl("http://www.plusplaner.com");

            //Maximaze browser if it is not 
            WebDriver.driver.Manage().Window.Maximize();

            //Waits until page is completly loaded
            SetMethods.WaitPageToLoad(WebDriver.driver, 15);

            Console.WriteLine("Opened URL!" + "\n***********************");
        }

        [Test]
        public void Check_If_Correct_Page_Is_Loaded()
        {
            string url = WebDriver.driver.Url;
            GetMethods.CheckPage(url, "login");
        }

        //Attribute that this is a test by NUnit
        [Test]
        public void ElementTests()
        {
            PlusPlanerPageObjects page = new PlusPlanerPageObjects(WebDriver.driver);

            //Checks if textBox for UserName is displayed, empty and enabled
            page.ElementExist(page.userName);
            page.IsElementEmpty(page.userName);
            page.isElementEnabled(page.userName);

            //Checks if textBox for Password is displayed, empty and enabled
            page.ElementExist(page.password);
            page.IsElementEmpty(page.password);
            page.isElementEnabled(page.password);

            //Checks if Button exists and if it is enabled
            page.ElementExist(page.btnLogIn);
            page.isElementEnabled(page.btnLogIn);
        }


        [Test]
        public void AlertMessagesTest()
        {
            PlusPlanerPageObjects page = new PlusPlanerPageObjects(WebDriver.driver);

            Console.WriteLine("Test 1: ");

            //Checks if both alert messages are displayed
            page.userName.Clear();
            page.password.Clear();
            SetMethods.Click(page.btnLogIn);
            page.AlertMessages("Korisničko ime je obvezno.");


            Console.WriteLine("Test 2: ");

            //Checks if alert message for UserName is displayed
            SetMethods.EnterText(page.password, "test");
            SetMethods.Click(page.btnLogIn);
            page.AlertMessages("Korisničko ime je obvezno.");

            Console.WriteLine("Test 3: ");

            //Checks if alert message for Password is displayed
            SetMethods.EnterText(page.userName, "test");
            SetMethods.Click(page.btnLogIn);
            page.AlertMessages("Lozinka je obvezna.");

            Console.WriteLine("Test 4: ");

            //Checks if alert message for Password and Username when they both are incorrect is displayed
            page.userName.Clear();
            SetMethods.EnterText(page.userName, "test");
            SetMethods.EnterText(page.password, "test");
            SetMethods.Click(page.btnLogIn);
            page.AlertMessages("Neispravno korisničko ime ili lozinka.");
        }

        [Test]
        public void LogInTest()
        {
            PlusPlanerPageObjects page = new PlusPlanerPageObjects(WebDriver.driver);
            page.LogIn("user21", "Pass21");
        }

        [TearDown]
        public void TearDown()
        {
            //Close the driver at the end of testing
            WebDriver.driver.Close();
            Console.WriteLine("Closed the browser!");
        }

    }
}
