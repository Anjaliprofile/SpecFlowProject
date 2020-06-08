using AutoItX3Lib;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using StandardTask.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static StandardTask.Global.Base;
using static StandardTask.Global.GlobalDefinitions;


namespace StandardTask.Pages
{
   class ManageListings
    {
        private IWebDriver driver;
        public ManageListings(IWebDriver _driver)
        {
            driver = _driver;
        }
        public void ManageList()
        {
                Thread.Sleep(2000);
                // Navigate to page Manage Listing
            driver.FindElement(By.LinkText("Manage Listings")).Click();
            driver.FindElement(By.XPath("(//input[@name='isActive'])[1]")).WaitForElementClickable(driver, 60).Click();
            Thread.Sleep(3000);
        }

        #region Edit Skill
        public void EditSkill()
        {
            // Click on Edit button
            driver.FindElement(By.XPath("(//i[@class='outline write icon'])[1]")).WaitForElementClickable(driver, 60).Click();
            Thread.Sleep(3000);

            #region populate excel         

            //Populate the excel data            
            GlobalDefinitions.ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "Managelisting");
            #endregion

            #region Enter Title 
            //Enter the data in Title textbox
            driver.FindElement(By.Name("title")).WaitForElementClickable(driver, 60).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "title"));
            #endregion

            #region Enter Description
            //Enter the data in Description textbox
            driver.FindElement(By.Name("description")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EnterDescription"));
            #endregion

            #region Category Drop Down

            // Click on Category Dropdown
            driver.FindElement(By.Name("categoryId")).WaitForElementClickable(driver, 60).Click();
            // Select Category from Category Drop Down
            var selectElement = new SelectElement(driver.FindElement(By.Name("categoryId")));
            selectElement.SelectByValue("1");
            // Click on Sub-Category Dropdown
            driver.FindElement(By.Name("subcategoryId")).WaitForElementClickable(driver, 60).Click();
            //Select Sub-Category from the Drop Down
            var SelectElement1 = new SelectElement(driver.FindElement(By.Name("subcategoryId")));
            SelectElement1.SelectByValue("2");
            #endregion

            #region Tags
            // Eneter Tag
            var Tags = driver.FindElement(By.XPath("//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]"));
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "TagName"));
            Tags.SendKeys(Keys.Enter);
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "TagName"));
            Tags.SendKeys(Keys.Enter);
            #endregion

            #region Service Type Selection
            // Service Type Selection
            if (GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType") == "Hourly basis service")
            {
                driver.FindElement(By.XPath("//input[@name='serviceType' and @value='0']")).Click();
            }
            else if (GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType") == "One-off service")
            {
                driver.FindElement(By.XPath("//input[@name='serviceType' and @value='1']")).Click();
            }
            #endregion

            #region Select Location Type
            // Location Type Selection

            if (GlobalDefinitions.ExcelLib.ReadData(2, "SelectLocationType") == "On-site")
            {
                driver.FindElement(By.XPath("//input[@name='locationType' and @value='0']")).Click();
            }
            else if (GlobalDefinitions.ExcelLib.ReadData(2, "SelectLocationType") == "Online")
            {
                driver.FindElement(By.XPath("//input[@name='locationType' and @value='1']")).Click();
            }
            #endregion

            #region Select Available Dates from Calendar
            // Select Start Date
            //driver.FindElement(By.Name("startDate")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "StartDate"));
            // Select End Date
            driver.FindElement(By.Name("endDate")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EndDate"));
            // select available days and start time and End time           
            for (int i = 2; i < 9; i++)
            {
                for (int j = 2; j < 9; j++)
                {
                    for (int k = 2; k < 9; k++)
                    {
                        IWebElement SatrtTime = driver.FindElement(By.XPath("//div[" + i + "]/div[2]/input"));
                        IWebElement EndTime = driver.FindElement(By.XPath("//div[" + j + "]/div[3]/input"));
                        IWebElement AvailableDays = driver.FindElement(By.XPath("//div[7]/div[2]/div/div[" + k + "]/div[1]/div/input"));
                        if (i == 2 && j == 2 && k == 2)
                        {
                            AvailableDays.Click();
                            SatrtTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "StartTime"));
                            EndTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EndTime"));
                        }
                        if (i == 3 && j == 3 && k == 3)
                        {
                            AvailableDays.Click();
                            SatrtTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "StartTime"));
                            EndTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "EndTime"));
                        }
                        if (i == 4 && j == 4 && k == 4)
                        {
                            AvailableDays.Click();
                            SatrtTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(4, "StartTime"));
                            EndTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(4, "EndTime"));
                        }

                    }
                }
            }
            #endregion

            #region Select Skill Trade
            // Select Skill Trade
            if (GlobalDefinitions.ExcelLib.ReadData(2, "SelectSkillTrade") == "Skill-exchange")
            {
                driver.FindElement(By.XPath("//input[@name='skillTrades' and @value='true']")).Click();
                var RequiredSkills = driver.FindElement(By.XPath("//div[@class='form-wrapper']//input[@placeholder='Add new tag']"));
                RequiredSkills.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "ExchangeSkill"));
                RequiredSkills.SendKeys(Keys.Enter);
                RequiredSkills.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "ExchangeSkill"));
                RequiredSkills.SendKeys(Keys.Enter);
            }
            else if (GlobalDefinitions.ExcelLib.ReadData(2, "SelectSkillTrade") == "Credit")
            {
                driver.FindElement(By.XPath("//input[@name='skillTrades' and @value='false']")).Click();
                var CreditAmount = driver.FindElement(By.XPath("//input[@placeholder='Amount']"));
                CreditAmount.Click();
                CreditAmount.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "AmountInExchange"));
                CreditAmount.SendKeys(Keys.Enter);
            }
            #endregion

            #region Select User Status
            // Select User Status

            if (GlobalDefinitions.ExcelLib.ReadData(2, "UserStatus") == "Active")
            {
                driver.FindElement(By.XPath("//input[@name='isActive' and @value='true']")).Click();
            }
            else if (GlobalDefinitions.ExcelLib.ReadData(2, "UserStatus") == "Hidden")
            {
                driver.FindElement(By.XPath("//input[@name='isActive' and @value='false']")).Click();
            }
            #endregion

            #region Add Work Sample
            //Click on Work sample
            driver.FindElement(By.XPath("//i[@class='huge plus circle icon padding-25']")).Click();
            //AutoIT            
            AutoItX3 AutoIt = new AutoItX3();
            AutoIt.WinActivate("Open");
            Thread.Sleep(3000);
            AutoIt.Send(@"A:\AdvanceTask\StandardTaskPart2\TW.docx");
            Thread.Sleep(2000);
            AutoIt.Send("{ENTER}");
            #endregion

            #region Save / Cancel Skill
            // Save or Cancel New Skill
            if (Global.GlobalDefinitions.ExcelLib.ReadData(2, "SaveOrCancel") == "Save")
            {
                driver.FindElement(By.XPath("//input[@value='Save' and @type='button']")).Click();
            }
            else if (Global.GlobalDefinitions.ExcelLib.ReadData(2, "SaveOrCancel") == "Cancel")
            {
                driver.FindElement(By.XPath("//input[@value='Cancel' and @type='button']")).Click();
            }
            #endregion
            Thread.Sleep(3000);
        }
        #endregion

        #region Check whether the skill updated sucessfully 
        public void ValidateUpdSkill()
        {
            //Populate the excel data            
            GlobalDefinitions.ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "Managelisting");
            String expectedValue = ExcelLib.ReadData(2, "title");
            //Get the table list
            IList<IWebElement> Tablerows = driver.FindElements(By.XPath("//div[2]/div[1]/div[1]/table/tbody/tr"));
            //Get the row count in table
            var rowCount = Tablerows.Count;
            for (var i = 1; i < rowCount; i++)
            {
                string actualValue = driver.FindElement(By.XPath("//table/tbody/tr[" + i + "]/td[3]")).Text;
                //Check if expected value is equal to actual value
                if (expectedValue == actualValue)
                {
                    SaveScreenShotClass.SaveScreenshot(driver, "AddLanguage");
                    Assert.IsTrue(true);
                }
                else
                    Console.WriteLine("Test failed");
            }
        }
        #endregion

        public void DeleteServiceList()
            {
            Thread.Sleep(2000);
            // click on delete button             
            driver.FindElement(By.XPath("(//i[@class='remove icon'])[1]")).WaitForElementClickable(driver, 60).Click();
            // Switch to Popup button
            driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[2]")).WaitForElementClickable(driver, 60).Click();
            Thread.Sleep(1000);    
            }
        public void ValidateDeletedService()
        {
            //Populate the excel data            
            GlobalDefinitions.ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "Managelisting");
            //Switch to next window
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            string msg = driver.FindElement(By.ClassName("ns-box-inner")).Text;
            Console.WriteLine(msg);
            // Validate deleted service
            driver.FindElement(By.ClassName("ns-close")).Click();
            driver.SwitchTo().DefaultContent();
        }
            public void ViewServiceList()
            {
            Thread.Sleep(2000);
            // View Service Listing
            driver.FindElement(By.XPath("(//i[@class='eye icon'])[1]")).WaitForElementClickable(driver, 60).Click();
          
                Thread.Sleep(3000);               
            }

        public void ValidateViewedService()
        {
            // Validate view listing through Page title
            String actualTitle = driver.Title;
            Assert.AreEqual(actualTitle, "Service Detail");
        }
    }
}

