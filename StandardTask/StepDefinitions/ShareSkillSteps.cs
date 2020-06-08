using OpenQA.Selenium;
using StandardTask.Global;
using StandardTask.Pages;
using System;
using TechTalk.SpecFlow;

namespace StandardTask.StepDefinitions
{
    [Binding, Scope(Feature = "ShareSkill")]
    public class ShareSkillSteps
    {
        private IWebDriver driver;
        public ShareSkillSteps(IWebDriver _driver)
        {
            driver = _driver;
        }

        [Given(@"Click on ShareSkill tab")]
        public void GivenClickOnShareSkillTab()
        {
            driver.FindElement(By.LinkText("Share Skill")).Click();
        }
        
        [When(@"I provide all details of service and click on save button")]
        public void WhenIProvideAllDetailsOfServiceAndClickOnSaveButton()
        {
            ShareSkills shareSkill = new ShareSkills(driver);
            shareSkill.AddNewSkill();
        }
        
        [Then(@"Service list should be displayed on managelisting page")]
        public void ThenServiceListShouldBeDisplayedOnManagelistingPage()
        {
            ShareSkills shareSkill = new ShareSkills(driver);
            shareSkill.ValidateAddSkill();  
        }
    }
}
