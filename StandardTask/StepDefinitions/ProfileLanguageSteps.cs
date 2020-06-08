using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using Gherkin.Ast;
using NUnit.Framework;
using OpenQA.Selenium;
using StandardTask.Global;
using StandardTask.Pages.Profile;
using System;
using TechTalk.SpecFlow;
using static StandardTask.Global.Base;

namespace StandardTask.StepDefinitions
{

    [Binding, Scope(Feature = "ProfileLanguage")]
    public class ProfileLanguageSteps 
    {

        private IWebDriver driver;
        public ProfileLanguageSteps(IWebDriver _driver)
        {
            driver = _driver;
        }

        [Given(@"I clicked on the Language tab under Profile page")]
        public void GivenIClickedOnTheLanguageTabUnderProfilePage()
        {         
            // Click on Language tab
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();
        }
        
        [When(@"I add a new language")]
        public void WhenIAddANewLanguage()
        {
            //Call AddLang Mehthod to add new Language
            ProfileLangPage languageObj = new ProfileLangPage(driver);
            languageObj.AddLang();
        }

        [Then(@"that language should be displayed on my listings")]
        public void ThenThatLanguageShouldBeDisplayedOnMyListings()
        {
            //Call ValidateAddLang Mehthod to validate added language   
            ProfileLangPage languageObj = new ProfileLangPage(driver);
            languageObj.ValidateAddLang();
        }

        [When(@"I  update Language")]
        public void WhenIUpdateLanguage()
        {
            //Call UpdateLang Mehthod to update the give language
            ProfileLangPage languageObj = new ProfileLangPage(driver);
            languageObj.UpdateLang();

        }

        [Then(@"that updated language should be displayed on my listings")]
        public void ThenThatUpdatedLanguageShouldBeDisplayedOnMyListings()
        {
            //Call ValidateUpdatedLang Mehthod to Validate updated language
            ProfileLangPage languageObj = new ProfileLangPage(driver);
            languageObj.ValidateUpdatedLang();
        }

        [When(@"I delete language")]
        public void WhenIDeleteLanguage()
        {
            //Call DeleLang Mehthod to delete a given langaguge
            ProfileLangPage languageObj = new ProfileLangPage(driver);
            languageObj.DeleteLang();
        }  
              
        [Then(@"that language should not be displayed on my listings")]
        public void ThenThatLanguageShouldNotBeDisplayedOnMyListings()
        {
            //Call ValidatedeletedLang to validate deleted language
            ProfileLangPage languageObj = new ProfileLangPage(driver);
            languageObj.ValidateDeletedLang();
        }
    }
}
