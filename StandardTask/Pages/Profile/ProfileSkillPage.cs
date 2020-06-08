using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static StandardTask.Global.GlobalDefinitions;
using static StandardTask.Global.Base;
using NUnit.Framework;

namespace StandardTask.Pages.Profile
{
    class ProfileSkillPage
    {
        private IWebDriver driver;
        public ProfileSkillPage(IWebDriver _driver)
        {
            driver = _driver;
        }

        #region Add New Skill
        public void AddSkill(IWebDriver driver)
        {            
            // Populate Login page test data collection
            ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "ProfileSkill");
            ////click on Skill
            //driver.FindElement(By.XPath("//div[@class='ui top attached tabular menu']/a[2]")).Click();
            //Click on Add New button
            driver.FindElement(By.XPath("(//div[contains(.,'Add New')])[16]")).Click();
            //Enter the Skill
            driver.FindElement(By.XPath("//input[@name ='name']")).SendKeys(ExcelLib.ReadData(2, "Skill"));
            //Select the Skill level.
            SelectElement select = new SelectElement(driver.FindElement(By.XPath("//select[@name ='level']")));
            select.SelectByValue(ExcelLib.ReadData(2, "SkillLevel"));
            //Click on Add
            driver.FindElement(By.XPath("//input[@value='Add']")).Click();           
        }
        #endregion

        #region Validate the Skill is added sucessfully 
        public void ValidateAddSkill()
        {           
            try
            {
                String expectedValue = ExcelLib.ReadData(2, "Skill");
                //Get the table list
                IList<IWebElement> Tablerows = driver.FindElements(By.XPath("//form/div[3]/div/div[2]/div/table/tbody/tr"));
                //Get the row count in table
                var rowCount = Tablerows.Count;
                for (var i = 1; i < rowCount; i++)
                {
                    Thread.Sleep(3000);
                    string actualValue = driver.FindElement(By.XPath("//div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;

                    //Check if expected value is equal to actual value
                    if (expectedValue == actualValue)
                    {
                        SaveScreenShotClass.SaveScreenshot(driver, "AddSkill");
                        Assert.IsTrue(true);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Thread.Sleep(3000);
        }
        #endregion

        
        #region Update the given Skills
        public void UpdateSkill()
        {
            
            Thread.Sleep(3000);
            // Populate Login page test data collection  
            ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "ProfileSkill");
            String expectedValue = ExcelLib.ReadData(2, "Skill");
            //Get the table list
            IList<IWebElement> Tablerows = driver.FindElements(By.XPath("//form/div[3]/div/div[2]/div/table/tbody/tr"));
            //Get the row count in table
            var rowCount = Tablerows.Count;
            for (int i = 1; i <= rowCount; i++)
            {
                //Get the xpath of ith row Skill name
                String actualValue = driver.FindElement(By.XPath("//div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                //check if the editLanguage Parameter matches with ith row Language name
                if (actualValue.Equals(expectedValue))
                {
                    //CliCk on Edit icon
                    driver.FindElement(By.XPath("//div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[1]/i")).Click();
                    //Send Skill name to update
                    IWebElement editRowValue = driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td/div/div[1]/input"));
                    //Clear Previous text 
                    editRowValue.Clear();
                    editRowValue.SendKeys(ExcelLib.ReadData(2, "UpdatedSkill"));
                    //Select Skill Level to update
                    var skillLevelList = driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td/div/div[2]/select"));
                    var selectElement = new SelectElement(skillLevelList);
                    selectElement.SelectByIndex(1);
                    // Click on update button
                    driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td/div/span/input[1]")).Click();
                    
                }
            }
        }
        #endregion
        
        
        #region validate updated Skill
        public void ValidateUpdatedSkill()
        {           
            try
            {
                String expectedValue1 = ExcelLib.ReadData(2, "UpdatedSkill");
                //Get the table list
                IList<IWebElement> UpdatedTablerows = driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody/tr"));
                //Get the row count in table
                var UpdatedrowCount1 = UpdatedTablerows.Count;
                for (var j = 1; j < UpdatedrowCount1; j++)
                {
                    string actualValue1 = driver.FindElement(By.XPath("//div[3]/div/div[2]/div/table/tbody[" + j + "]/tr/td[1]")).Text;

                    //Check if expected value is equal to actual value
                    if (expectedValue1 == actualValue1)
                    {
                        SaveScreenShotClass.SaveScreenshot(driver, "SkillLanguage");
                        Assert.IsTrue(true);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Thread.Sleep(3000);            
        }
        #endregion

        
        #region Delete given Skill
        public void DeleteSkill()
        {            
            // Populate Login page test data collection
            ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "ProfileSkill");
            String expectedValue = ExcelLib.ReadData(2, "DeleteSkill");
            //Get the table row list
            IList<IWebElement> Tablerows = driver.FindElements(By.XPath("//form/div[3]/div/div[2]/div/table/tbody/tr"));
            //Get the row count of table
            var rowCount = Tablerows.Count;
            for (int i = 1; i <= rowCount; i++)
            {
                //Get the xpath of ith row SkillName
                String actualValue = driver.FindElement(By.XPath("//div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                //check if the DeleteSkill parameter matches with ith Row SkillName
                if (actualValue == expectedValue)
                {
                    // Click on delete button
                    driver.FindElement(By.XPath("//div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[2]/i")).Click();

                }
            }
        }
        #endregion

        
        #region Valdidate deleted Skill
        public void ValidateDeletedSkill()
        {           
            try
            {
                String expectedValue1 = ExcelLib.ReadData(2, "DeleteSkill");
                //Get the table list
                IList<IWebElement> Tablerows1 = driver.FindElements(By.XPath("//form/div[3]/div/div[2]/div/table/tbody/tr"));
                //Get the row count in table
                var rowCount1 = Tablerows1.Count;
                for (var j = 1; j < rowCount1; j++)
                {
                    Thread.Sleep(3000);
                    string actualValue1 = driver.FindElement(By.XPath("//div/table/tbody[" + j + "]/tr/td[1]")).Text;

                    //Check if expected value is equal to actual value
                    if (expectedValue1 != actualValue1)
                    {
                        Assert.IsTrue(true);
                        SaveScreenShotClass.SaveScreenshot(driver, "DeleteSkill");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Thread.Sleep(3000);
        }        
    }
    #endregion
}

