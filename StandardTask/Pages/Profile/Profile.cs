using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static StandardTask.Global.GlobalDefinitions;
using static StandardTask.Global.Base;
using AventStack.ExtentReports.Gherkin.Model;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using StandardTask.Global;
using AventStack.ExtentReports;

namespace StandardTask.Pages.Profile
{
    class Profile 
    {
        private IWebDriver driver;
        public Profile(IWebDriver _driver)
        {
            driver = _driver;
        }

        public void Description()
        {
            //// click on Description edit icon
            //var Des = driver.FindElement(By.XPath("// h3[contains(text(),'Description')]/span/i"));
            //Des.WaitForElementClickable(Global.Base.driver, 60).Click();
            // Populate Login page test data collection
            ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "Profile");
            //Clear Description box
            
            // Clear description
            driver.FindElement(By.XPath("//div[@class='field  ']/textarea")).Clear();
            Thread.Sleep(1000);
            // Tell us more about yourself. 
            driver.FindElement(By.XPath("//div[@class='field  ']/textarea")).SendKeys(ExcelLib.ReadData(2, "Description"));
            // click on save
            driver.FindElement(By.XPath("//button[@class='ui teal button'][@type='button']")).Click();
            Thread.Sleep(3000);
            //Switch to next window
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Thread.Sleep(3000);
            string msg = driver.FindElement(By.ClassName("ns-box-inner")).Text;
            Console.WriteLine(msg);
            // Validate description
            Assert.AreEqual(msg, "Description has been saved successfully");
            driver.SwitchTo().DefaultContent();           
        }

        // ChangePassword
        public void ChangePassword()
        {
            #region Click on ChangePassword
            // Populate Login page test data collection
            ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "Profile");
            Thread.Sleep(2000);
            //// Navigate to change password page
            //driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/span")).Click();
            //Thread.Sleep(2000);
            //driver.FindElement(By.XPath("//div/span/div/a[2]")).Click();
            Thread.Sleep(1000);
            //IWebElement element = driver.FindElement(By.XPath("//a[text()='Change Password']"));
            //element.Click();
            driver.FindElement(By.XPath("//input[@name='oldPassword']")).SendKeys(ExcelLib.ReadData(2,"CurrentPassword"));
            driver.FindElement(By.XPath("//input[@name='newPassword']")).SendKeys(ExcelLib.ReadData(2, "NewPassword"));
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@name='confirmPassword']")).SendKeys(ExcelLib.ReadData(2, "CnfPassword"));
            // click on save button
            driver.FindElement(By.XPath("//button[@type='button' and text()='Save']")).Click();
            Thread.Sleep(1000);           
            #endregion
        }

        // Validate password changed successfully
        public void ValidateChangedPassword()
        {
            //Switch to next window
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            string msg = driver.FindElement(By.ClassName("ns-box-inner")).Text;
            Console.WriteLine(msg);
            Assert.AreEqual(msg, "Password Changed Successfully");            
            driver.SwitchTo().DefaultContent();
        }

        // Search Share Skills 
        public void SerachSkills()
        {
            //// Populate Login page test data collection
            //ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "Profile");
            //// Search skills through type keys
            //driver.FindElement(By.XPath("(//input[@placeholder='Search skills'])[1]")).SendKeys(ExcelLib.ReadData(2, "SearchSkills"));
            ////click on search button
            //driver.FindElement(By.XPath("(//i[@class='search link icon'])[1]")).Click();
            // Search skills using filter
            string value = ExcelLib.ReadData(3, "FilterButtons");
            // Click on button
            //string button = driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]")).Text;
           
            Thread.Sleep(3000);
            for(int i=1; i<=3; i++)
            {
                // Click on ith button
                string actualvalue = driver.FindElement(By.XPath("//div/section/div/div[1]/div[5]/button[" + i + "]")).Text;
                if(actualvalue == value)
                {
                    driver.FindElement(By.XPath("//div/section/div/div[1]/div[5]/button[" + i + "]")).Click();
                    Console.WriteLine("Test Passed");
                    Thread.Sleep(2000);
                }
                else                
                    Console.WriteLine("Test failed");
                
            }
        }
        
        public void Availability()
        {
            // Populate Login page test data collection
            ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "Profile");

            //// Click on availability edit button
            //driver.FindElement(By.XPath("//div[3]/div/div[2]/div/span/i")).Click();
            // Select Availability

            driver.FindElement(By.XPath("//select[@name='availabiltyType']")).WaitForElementClickable(driver, 60).Click();
            SelectElement selectType = new SelectElement(driver.FindElement(By.XPath("//select[@name='availabiltyType']")));
            //selectType.SelectByText
            selectType.SelectByValue("1");
            //Switch to next window
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Thread.Sleep(3000);
            string msg = driver.FindElement(By.ClassName("ns-box-inner")).Text;
            Console.WriteLine(msg);            
            // Validate availability
            Assert.AreEqual(msg, "Availability updated");
            driver.SwitchTo().DefaultContent();
        }
        
        public void AvailabilityHour()
        {
            // Populate Login page test data collection
            ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "Profile");

            //// Click on availability hour edit button
            //driver.FindElement(By.XPath("//div[3]/div/div[3]/div/span/i")).Click();
            // select AvailabilityHour

            //driver.FindElement(By.XPath("//select[@name='availabiltyHour']")).WaitForElementClickable(driver, 60).Click();
            SelectElement selectType = new SelectElement(driver.FindElement(By.XPath("//select[@name='availabiltyHour']")));
            selectType.SelectByValue("1");

            //Switch to next window
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Thread.Sleep(3000);
            string msg = driver.FindElement(By.ClassName("ns-box-inner")).Text;
            Console.WriteLine(msg);
            // Validate availability
            Assert.AreEqual(msg, "Availability updated");
            driver.SwitchTo().DefaultContent();
        }

        public void EarnTarget()
        {
            // Populate Login page test data collection
            ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "Profile");

            //// Click on earn Target edit button
            //driver.FindElement(By.XPath("//div[3]/div/div[4]/div/span/i")).Click();
            // Select earn target
            
            driver.FindElement(By.XPath("//select[@name='availabiltyTarget']")).WaitForElementClickable(driver, 60).Click();
            SelectElement selectType = new SelectElement(driver.FindElement(By.XPath("//select[@name='availabiltyTarget']")));
            selectType.SelectByValue("1");

            //Switch to next window
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Thread.Sleep(3000);
            string msg = driver.FindElement(By.ClassName("ns-box-inner")).Text;
            Console.WriteLine(msg);
            // Validate availability
            Assert.AreEqual(msg, "Availability updated");
            driver.SwitchTo().DefaultContent();
        }

    }
}
