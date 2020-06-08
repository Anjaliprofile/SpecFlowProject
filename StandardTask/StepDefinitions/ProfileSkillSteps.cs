using NUnit.Framework;
using OpenQA.Selenium;
using StandardTask.Global;
using StandardTask.Pages.Profile;
using System;
using TechTalk.SpecFlow;

namespace StandardTask.StepDefinitions
{

    [Binding, Scope(Feature = "ProfileSkill")]
    public class ProfileSkillSteps
    {

        private IWebDriver driver;
        public ProfileSkillSteps(IWebDriver _driver)
        {
            driver = _driver;
        }        

        [Given(@"I clicked on the Skills tab under Profile page")]
        public void GivenIClickedOnTheSkillsTabUnderProfilePage()
        {
            //click on Skill
            driver.FindElement(By.XPath("//div[@class='ui top attached tabular menu']/a[2]")).Click();
        }

        [When(@"I add new skill")]
        public void WhenIAddNewSkill()
        {
            //Call Skill page 
            ProfileSkillPage skillObj = new ProfileSkillPage(driver);
            skillObj.AddSkill(driver);
        }

        [Then(@"i should see the skill displayed on my listings")]
        public void ThenIShouldSeeTheSkillDisplayedOnMyListings()
        {
            //Call Skill page 
            ProfileSkillPage skillObj = new ProfileSkillPage(driver);
            skillObj.ValidateAddSkill();
        }

        [When(@"I update skill")]
        public void WhenIUpdateSkill()
        {
            //Call Skill page 
            ProfileSkillPage skillObj = new ProfileSkillPage(driver);
            skillObj.UpdateSkill();
        }

        [Then(@"i should see updated skill displayed on my listings")]
        public void ThenIShouldSeeUpdatedSkillDisplayedOnMyListings()
        {
            //Call Skill page 
            ProfileSkillPage skillObj = new ProfileSkillPage(driver);
            skillObj.ValidateUpdatedSkill();
        }

        [When(@"I delete skill")]
        public void WhenIDeleteSkill()
        {
            //Call Skill page 
            ProfileSkillPage skillObj = new ProfileSkillPage(driver);
            skillObj.DeleteSkill();
        }             

        
        [Then(@"i should not see deleted skill displayed on my listings")]
        public void ThenIShouldNotSeeDeletedSkillDisplayedOnMyListings()
        {
            //Call Skill page 
            ProfileSkillPage skillObj = new ProfileSkillPage(driver);
            skillObj.ValidateDeletedSkill();
        }
    }
}
