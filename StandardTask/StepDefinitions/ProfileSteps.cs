using OpenQA.Selenium;
using StandardTask.Global;
using StandardTask.Pages.Profile;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static StandardTask.Global.GlobalDefinitions;

namespace StandardTask.StepDefinitions
{
    [Binding, Scope(Feature = "Profile", Scenario = "I'd like to change password")]
    public class ProfileSteps
    {
        private IWebDriver driver;
        public ProfileSteps(IWebDriver _driver)
        {
            driver = _driver;
        }         

        [Given(@"Click on Change Password button")]
        public void GivenClickOnChangePasswordButton()
        {
            // Navigate to change password page
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/span")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//div/span/div/a[2]")).Click();
        }

        [When(@"provide all details")]
        public void WhenProvideAllDetails()
        {
            Profile profileObj = new Profile(driver);
            profileObj.ChangePassword();
        }

        [Then(@"password should be changed")]
        public void ThenPasswordShouldBeChanged()
        {
            Profile profileObj = new Profile(driver);
            profileObj.ValidateChangedPassword();
        }

        
    }
}
