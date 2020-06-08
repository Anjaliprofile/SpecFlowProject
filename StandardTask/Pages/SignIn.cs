using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using StandardTask.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static StandardTask.Global.GlobalDefinitions;
using static StandardTask.Global.Base;

namespace StandardTask.Pages
{
    public class SignIn 
    {
        private IWebDriver driver;
        public SignIn(IWebDriver _driver)
        {
            driver = _driver;
        }
        internal void SignInStep()
        {
            // populate Excel
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "SignIn");
            driver.FindElement(By.XPath("//a[contains(text(),'Sign')]")).Click();
            driver.FindElement(By.Name("email")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Username"));
            driver.FindElement(By.Name("password")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));
            driver.FindElement(By.XPath("//button[contains(text(),'Login')]")).Click();        
            Thread.Sleep(2000);
            if (driver.WaitForElementDisplayed(By.XPath("//a[contains(text(),'Mars Logo')]"), 60))
            {
                SaveScreenShotClass.SaveScreenshot(driver, "Login");
            }
            else
            {
                SaveScreenShotClass.SaveScreenshot(driver, "LoginFailed");
            }       
        }
    }
}
