using AventStack.ExtentReports;
using OpenQA.Selenium;
using StandardTask.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StandardTask.Global.GlobalDefinitions;
using static StandardTask.Global.Base;
using NUnit.Framework;
using System.Threading;

namespace StandardTask.Pages.Profile
{
    class ProfileDesPage
    {
        public void Description()
        {
            // click on Description
            IWebElement Des = driver.FindElement(By.XPath("// h3[contains(text(),'Description')]/span/i"));
            Des.WaitForElementClickable(Global.Base.driver, 60).Click();
            // Populate Login page test data collection
            ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "Profile");
            // Tell us more about yourself. 
            driver.FindElement(By.XPath("//div[@class='field  ']/textarea")).SendKeys(ExcelLib.ReadData(2, "Description"));
            // click on save
            driver.FindElement(By.XPath("//button[@class='ui teal button'][@type='button']")).Click();
            Thread.Sleep(5000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            // verify Description is save successfully 
            Assert.AreEqual(driver.FindElement(By.XPath("/html/body/div[1]/div")).Text, "Description has been saved successfully");
            driver.SwitchTo().DefaultContent();
        }
        
    }
}
