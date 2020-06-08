using OpenQA.Selenium;
using StandardTask.Global;
using StandardTask.Pages.Profile;
using System;
using TechTalk.SpecFlow;
using static StandardTask.Global.GlobalDefinitions;

namespace StandardTask.StepDefinitions
{
    [Binding]
    public class ProfileSteps1
    {
        private IWebDriver driver;
        public ProfileSteps1(IWebDriver _driver)
        {
            driver = _driver;
        }

        [Given(@"Click on Description icon")]
        public void GivenClickOnDescriptionIcon()
        {
            // click on Description edit icon
            var Des = driver.FindElement(By.XPath("// h3[contains(text(),'Description')]/span/i"));
            Des.WaitForElementClickable(driver, 60).Click();
        }

        [Then(@"Description should be updated")]
        public void ThenDescriptionShouldBeUpdated()
        {
            Profile profileObj = new Profile(driver);
            profileObj.Description();
        }

        [Given(@"keys for searching")]
        public void GivenKeysForSearching()
        {
            // Populate Login page test data collection
            ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "Profile");
            // Search skills through type keys
            driver.FindElement(By.XPath("(//input[@placeholder='Search skills'])[1]")).SendKeys(ExcelLib.ReadData(2, "SearchSkills"));
        }

        [When(@"Click on search button")]
        public void WhenClickOnSearchButton()
        {
            //click on search button
            driver.FindElement(By.XPath("(//i[@class='search link icon'])[1]")).Click();
        }

        [Then(@"Skills detail should be displayed")]
        public void ThenSkillsDetailShouldBeDisplayed()
        {
            Profile profileObj = new Profile(driver);
            profileObj.SerachSkills();
        }

        [Given(@"Click on Availability icon")]
        public void GivenClickOnAvailabilityIcon()
        {
            // Click on availability edit icon
            driver.FindElement(By.XPath("//div[3]/div/div[2]/div/span/i")).WaitForElementClickable(driver, 60).Click();
        }


        [Then(@"Select your availability")]
        public void ThenSelectYourAvailability()
        {
            Profile profileObj = new Profile(driver);
            profileObj.Availability();
        }

        [Given(@"Click on Availability Hour icon")]
        public void GivenClickOnAvailabilityHourIcon()
        {
            // Click on availability hour edit icon
            driver.FindElement(By.XPath("//div[3]/div/div[3]/div/span/i")).WaitForElementClickable(driver, 60).Click();
        }

        [Then(@"Select your availability Hour")]
        public void ThenSelectYourAvailabilityHour()
        {
            Profile profileObj = new Profile(driver);
            profileObj.AvailabilityHour();
        }

        [Given(@"Click on Earn Target icon")]
        public void GivenClickOnEarnTargetIcon()
        {
            // Click on earn Target edit button
            driver.FindElement(By.XPath("//div[3]/div/div[4]/div/span/i")).WaitForElementClickable(driver, 60).Click();
        }


        [Then(@"Select your Earn Target")]
        public void ThenSelectYourEarnTarget()
        {
            Profile profileObj = new Profile(driver);
            profileObj.EarnTarget();
        }
    }
}
