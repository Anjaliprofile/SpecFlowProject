using AventStack.ExtentReports;
using NUnit.Framework;
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

namespace StandardTask.Pages.Profile
{
    class ProfileEduPage
    {

        private IWebDriver driver;
        public ProfileEduPage(IWebDriver _driver)
        {
            driver = _driver;
        } 

        #region Add your Education
        public void AddEducation()
        {
            // Populate Login page test data collection
            ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "ProEducation");
            //click on Education tab
            //driver.FindElement(By.XPath("//div[@class='ui top attached tabular menu']/a[3]")).Click();
            //Click on Add New button
            driver.FindElement(By.XPath("(//div[contains(.,'Add New')])[21]")).Click();
            // Enter collage Name
            driver.FindElement(By.XPath("//input[@name ='instituteName']")).SendKeys(ExcelLib.ReadData(2, "University"));
            // Select Country of College
            SelectElement selectcountry = new SelectElement(driver.FindElement(By.XPath("//select[@class='ui dropdown' and @name='country']")));
            selectcountry.SelectByValue(ExcelLib.ReadData(2, "CountryOfCollege"));
            // Select Title
            SelectElement Title = new SelectElement(driver.FindElement(By.XPath("//select[@class='ui dropdown' and @name='title']")));
            Title.SelectByValue(ExcelLib.ReadData(2, "Title"));
            //Enter the Degree
            driver.FindElement(By.XPath("//input[@name='degree']")).SendKeys(ExcelLib.ReadData(2, "Degree"));
            //Select the Year of Passing.
            SelectElement selectYear = new SelectElement(driver.FindElement(By.XPath("//select[@class='ui dropdown' and @name= 'yearOfGraduation']")));
            selectYear.SelectByValue(ExcelLib.ReadData(2, "YearOfPassing"));
            //Click on Add
            driver.FindElement(By.XPath("//input[@value='Add']")).Click();

        }
        #endregion 

        #region Validate the Education is added sucessfully 
        public void ValidateAddEdu()
        {
            try
            {
                String expectedValue = ExcelLib.ReadData(2, "Title");
                //Get the table list
                IList<IWebElement> Tablerows = driver.FindElements(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody/tr"));
                //Get the row count in table
                var rowCount = Tablerows.Count;
                for (var i = 1; i < rowCount; i++)
                {
                    Thread.Sleep(3000);
                    string actualValue = driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]")).Text;

                    //Check if expected value is equal to actual value
                    if (expectedValue == actualValue)
                    {
                        SaveScreenShotClass.SaveScreenshot(driver, "AddEducation");
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

        #region Update the given Education
        public void UpdateEducation()
        {
            Thread.Sleep(3000);
            // Populate Login page test data collection  
            ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "ProEducation");
            String expectedValue = ExcelLib.ReadData(2, "Title");
            //Get the table list
            IList<IWebElement> Tablerows = driver.FindElements(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody/tr"));
            //Get the row count in table
            var rowCount = Tablerows.Count;
            for (int i = 1; i <= rowCount; i++)
            {
                //Get the xpath of ith row Title
                String actualValue = driver.FindElement(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]")).Text;
                //check if the editLanguage Parameter matches with ith row Title
                if (actualValue.Equals(expectedValue))
                {
                    //CliCk on Edit icon
                    driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[6]/span[1]/i")).Click();
                    //Send University name to update
                    IWebElement editRowValue = driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/div[1]/input"));
                    //Clear Previous text 
                    editRowValue.Clear();
                    editRowValue.SendKeys(ExcelLib.ReadData(2, "UpdUniversity"));
                    // update Country of College
                    SelectElement selectcountry = new SelectElement(driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div[1]/div[2]/select")));
                    selectcountry.SelectByValue(ExcelLib.ReadData(2, "UpdCountryOfCollege"));
                    // update Title
                    SelectElement Title = new SelectElement(driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div[2]/div[1]/select")));
                    Title.SelectByValue(ExcelLib.ReadData(2, "UpdTitle"));
                    //update the Degree
                    IWebElement EditDegree = driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div[2]/div[2]/input"));
                    // Clear Previous text
                    EditDegree.Clear();
                    EditDegree.SendKeys(ExcelLib.ReadData(2, "UpdDegree"));
                    //update the Year of Passing.
                    SelectElement selectYear = new SelectElement(driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div[2]/div[3]/select")));
                    selectYear.SelectByValue(ExcelLib.ReadData(2, "UpdYearOfPassing"));

                    // Click on update button
                    driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div[3]/input[1]")).Click();
                    #endregion
                }
            }
        }


        #region validate updated Education
        public void ValidateUpdatedEdu()
        {
            try
            {
                String expectedValue1 = ExcelLib.ReadData(2, "UpdTitle");
                //Get the table list
                IList<IWebElement> UpdatedTablerows = driver.FindElements(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody/tr"));
                //Get the row count in table
                var UpdatedrowCount1 = UpdatedTablerows.Count;
                for (var j = 1; j < UpdatedrowCount1; j++)
                {
                    string actualValue1 = driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + j + "]/tr/td[3]")).Text;

                    //Check if expected value is equal to actual value
                    if (expectedValue1 == actualValue1)
                    {
                        SaveScreenShotClass.SaveScreenshot(driver, "EditEducation");
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


        #region Delete given Education
        public void DeleteEdu()
        {
            // Populate Login page test data collection
            ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "ProEducation");
            String expectedValue = ExcelLib.ReadData(2, "DeleteUniversity");
            //Get the table row list
            IList<IWebElement> Tablerows = driver.FindElements(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody/tr"));
            //Get the row count of table
            var rowCount = Tablerows.Count;
            for (int i = 1; i <= rowCount; i++)
            {
                //Get the xpath of ith row SkillName
                String actualValue = driver.FindElement(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[2]")).Text;
                //check if the DeleteSkill parameter matches with ith Row SkillName
                if (actualValue == expectedValue)
                {
                    // Click on delete button
                    driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[6]/span[2]/i")).Click();

                }
            }
        }
        #endregion

        #region validate Deleted Education
        public void ValidateDeletedEdu()
        {           
            try
            {
                String expectedValue1 = ExcelLib.ReadData(2, "DeleteUniversity");
                //Get the table list
                IList<IWebElement> UpdatedTablerows = driver.FindElements(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody/tr"));
                //Get the row count in table
                var UpdatedrowCount1 = UpdatedTablerows.Count;
                for (var j = 1; j < UpdatedrowCount1; j++)
                {
                    string actualValue1 = driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + j + "]/tr/td[2]")).Text;

                    //Check if expected value is equal to actual value
                    if (expectedValue1 != actualValue1)
                    {
                        SaveScreenShotClass.SaveScreenshot(driver, "DeleteEducation");
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
    }
}
 