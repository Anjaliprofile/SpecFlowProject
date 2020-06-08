using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StandardTask.Global.GlobalDefinitions;
using static StandardTask.Global.Base;
using AventStack.ExtentReports;
using NUnit.Framework;
using System.Threading;
using StandardTask.Global;
using StandardTask;

namespace StandardTask.Pages.Profile
{
    class ProfileLangPage
    {
        private IWebDriver driver;
        public ProfileLangPage(IWebDriver _driver)
        {
            driver = _driver;
        }

        //Add New Language
        public void AddLang()
        {
            #region Add New Language
            // Populate Login page test data collection
            ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "ProfileLanguage");
            //click on Language
            //driver.FindElement(By.XPath("//div[@class='ui top attached tabular menu']/a[1]")).Click();
            //Click on Add New button
            driver.FindElement(By.XPath("(//div[contains(.,'Add New')])[11]")).Click();
            //Enter the language
            driver.FindElement(By.XPath("//input[@name ='name']")).SendKeys(ExcelLib.ReadData(2, "Language"));
            //Select the language level.
            SelectElement select = new SelectElement(driver.FindElement(By.XPath("//select[@name ='level']")));
            select.SelectByValue(ExcelLib.ReadData(2, "LanguagesLavel"));
            //Click on Add
            driver.FindElement(By.XPath("//input[@value='Add']")).Click();
            #endregion            
        }

        public void ValidateAddLang()
        {
            #region Validate the language is added sucessfully 
            try
            {               
                String expectedValue = ExcelLib.ReadData(2, "Language");
                //Get the table list
                IList<IWebElement> Tablerows = driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody/tr"));
                //Get the row count in table
                var rowCount = Tablerows.Count;
                for (var i = 1; i < rowCount; i++)
                {
                    Thread.Sleep(3000);
                    string actualValue = driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[1]")).Text;

                    //Check if expected value is equal to actual value
                    if (expectedValue == actualValue)
                    {
                       // test.Log(Status.Pass, "Add Language Successful");
                        SaveScreenShotClass.SaveScreenshot(driver, "AddLanguage");
                        Assert.IsTrue(true);
                    }                  
                        
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Thread.Sleep(3000);
            #endregion
        }

        // Update the given Language
        public void UpdateLang()
        {
            #region Update the given Language
            Thread.Sleep(3000);
            // Populate Login page test data collection
            ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "ProfileLanguage");
            String expectedValue = ExcelLib.ReadData(2, "Language");
            //Get the table list
            IList<IWebElement> Tablerows = driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody/tr"));
            //Get the row count in table
            var rowCount = Tablerows.Count;
            for (int i = 1; i <= rowCount; i++)
            {
                //Get the xpath of ith row Language name
                String actualValue = driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[1]")).Text;
                //check if the editLanguage Parameter matches with ith row Language name
                if (actualValue.Equals(expectedValue))
                {
                    //CliCk on Edit icon
                    driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[3]/span[1]/i")).Click();
                    //Send Language name to update
                    IWebElement editRowValue = driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td/div/div[1]/input"));
                    //Clear Previous text 
                    editRowValue.Clear();
                    editRowValue.SendKeys(ExcelLib.ReadData(2, "UpdatedLanguage"));
                    //Select Language Level to update
                    var langLevelList = driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td/div/div[2]/select"));
                    var selectElement = new SelectElement(langLevelList);
                    selectElement.SelectByValue(ExcelLib.ReadData(2, "UpdLanguagesLavel"));
                    // Click on update button
                    driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td/div/span/input[1]")).Click();
                    #endregion
                }
            }
        }
        public void ValidateUpdatedLang()
        {
            #region validate updated language
            try
            {
                String expectedValue1 = ExcelLib.ReadData(2, "UpdatedLanguage");
                //Get the table list
                IList<IWebElement> UpdatedTablerows = driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody/tr"));
                //Get the row count in table
                var UpdatedrowCount1 = UpdatedTablerows.Count;
                for (var j = 1; j < UpdatedrowCount1; j++)
                {
                    string actualValue1 = driver.FindElement(By.XPath("//div/table/tbody[" + j + "]/tr/td[1]")).Text;

                    //Check if expected value is equal to actual value
                    if (expectedValue1 == actualValue1)
                    {
                        //test.Log(Status.Pass, "Language updated Successful");
                        SaveScreenShotClass.SaveScreenshot(driver, "UpdateLanguage");
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

        //Delete a given language
        public void DeleteLang()
        {
            #region Delete given language
            // Populate Login page test data collection
            ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "ProfileLanguage");
            String expectedValue = ExcelLib.ReadData(2, "DeleteLanguage");
            //Get the table row list
            IList<IWebElement> Tablerows = driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody/tr"));
            //Get the row count of table
            var rowCount = Tablerows.Count;
            for (int i = 1; i <= rowCount; i++)
            {
                //Get the xpath of ith row LanguageName
                String actualValue = driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[1]")).Text;
                //check if the DeleteLanguage parameter matches with ith Row LanguageName
                if (actualValue == expectedValue)
                {
                    // Click on delete button
                    driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[3]/span[2]/i")).Click();

                }
            }
            #endregion
        }
        public void ValidateDeletedLang()
        {

            #region Valdidate deleted laguage

            try
            {
                String expectedValue1 = ExcelLib.ReadData(2, "DeleteLanguage");
                //Get the table list
                IList<IWebElement> Tablerows1 = driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody/tr"));
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
                       // test.Log(Status.Pass, "Language deleted Successful");
                        SaveScreenShotClass.SaveScreenshot(driver, "DeleteLanguage");
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
    }
}


