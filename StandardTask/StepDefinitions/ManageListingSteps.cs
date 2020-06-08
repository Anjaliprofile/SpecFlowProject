using OpenQA.Selenium;
using StandardTask.Global;
using StandardTask.Pages;
using System;
using System.Threading;
using TechTalk.SpecFlow;


namespace StandardTask.StepDefinitions
{
    [Binding, Scope(Feature = "ManageListing")]
  
    public class ManageListingSteps
    {
        private readonly IWebDriver driver;
        //Constructor for Content injection
        public ManageListingSteps(IWebDriver _driver)
        {
            driver = _driver;
        }

        [Given(@"Click on Manage Listings tab")]
        public void GivenClickOnManageListingsTab()
        {
            driver.FindElement(By.LinkText("Manage Listings")).WaitForElementClickable(driver, 60).Click();
            Thread.Sleep(3000);
        }
        
        [When(@"I click on View icon")]
        public void WhenIClickOnViewIcon()
        {
            ManageListings obj = new ManageListings(driver);
            obj.ViewServiceList();
        }

        [Then(@"Service details should be displayed")]
        public void ThenServiceDetailsShouldBeDisplayed()
        {
            ManageListings obj = new ManageListings(driver);
            obj.ValidateViewedService();
        }

        [When(@"I click on edit icon and able to update all details")]
        public void WhenIClickOnEditIconAndAbleToUpdateAllDetails()
        {
            ManageListings obj = new ManageListings(driver);
            obj.EditSkill();
        }

        [Then(@"Updated Service list should be displayed on managelisting page")]
        public void ThenUpdatedServiceListShouldBeDisplayedOnManagelistingPage()
        {
            ManageListings obj = new ManageListings(driver);
            obj.ValidateUpdSkill();
        }

        [When(@"I click on delete icon and able to delete service")]
        public void WhenIClickOnDeleteIconAndAbleToDeleteService()
        {
            ManageListings obj = new ManageListings(driver);
            obj.DeleteServiceList();
        }


        [Then(@"Popup message should be displayed")]
        public void ThenPopupMessageShouldBeDisplayed()
        {
            ManageListings obj = new ManageListings(driver);
            obj.ValidateDeletedService();
        }

    }
}
