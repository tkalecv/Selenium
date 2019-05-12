using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SeleniumProject.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.PageObjects
{
   public class PageObject
    {
        //It is used if ID of WebElement SearchID changes

        private IWebDriver driver;

        public PageObject(IWebDriver _driver) => driver = _driver;

        public IWebElement searchField => driver.FindElement(By.Name("q"));
        public IWebElement searchBtn => driver.FindElement(By.Name("btnK"));

        //Method for search
        public void Search(string search)
        {
            //Calling set method for entering text
            SetMethods.EnterText(searchField, search);

            //Calling click method
            SetMethods.Submit(searchBtn);
        }
    }
}
