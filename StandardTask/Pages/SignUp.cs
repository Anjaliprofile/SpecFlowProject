using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using StandardTask.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static StandardTask.Global.Base;

namespace StandardTask.Pages
{
    class SignUp 
    {
        private IWebDriver driver;
        public SignUp(IWebDriver _driver)
        {
            driver = _driver;
        }
        internal void register()
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "SignUp");
            // Navigate to Url
            driver.Navigate().GoToUrl(GlobalDefinitions.ExcelLib.ReadData(2, "Url"));
            //Click on Join button
            driver.FindElement(By.XPath("//*[@id='home']//button[text()='Join']")).Click();
            Thread.Sleep(2000);

            //Enter FirstName
            driver.FindElement(By.XPath("//input[@name='firstName']")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "FirstName"));

            //Enter LastName
            driver.FindElement(By.XPath("//input[@name='lastName']")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "LastName"));

            //Enter Email
            driver.FindElement(By.XPath("//input[@name='email']")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EmailAddress"));

            //Enter Password
            driver.FindElement(By.XPath("//input[@name='password']")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            //Enter Password again to confirm
            driver.FindElement(By.XPath("//input[@name='confirmPassword']")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "ConfirmPassword"));

            //Click on Checkbox
            driver.FindElement(By.XPath("//input[@name='terms']")).Click();

            //Click on join button to Sign Up  //*[@id='submit-btn']
            driver.FindElement(By.XPath("//*[@id='submit-btn']")).Click();


        }
    }
}

