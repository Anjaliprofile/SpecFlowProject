using OpenQA.Selenium;
using StandardTask.Global;
using StandardTask.Pages.Profile;
using System;
using TechTalk.SpecFlow;


namespace StandardTask.StepDefinitions
{
    [Binding, Scope(Feature = "ProfileEducation")]
    public class ProfileEducationSteps 
    {
        private IWebDriver driver;
        public ProfileEducationSteps(IWebDriver _driver)
        {
            driver = _driver;
        }        

        [Given(@"I clicked on the Education tabunder Profile page")]
        public void GivenIClickedOnTheEducationTabunderProfilePage()
        {
            // Click on Education tab
            driver.FindElement(By.XPath("//div[@class='ui top attached tabular menu']/a[3]")).Click();
        }
        
        [When(@"i add new education")]
        public void WhenIAddNewEducation()
        {
            ProfileEduPage educationObj = new ProfileEduPage(driver);
            educationObj.AddEducation();
        }

        [Then(@"i should see the education displayed on my listings")]
        public void ThenIShouldSeeTheEducationDisplayedOnMyListings()
        {
            ProfileEduPage educationObj = new ProfileEduPage(driver);
            educationObj.ValidateAddEdu();
        }

        [When(@"I update education")]
        public void WhenIUpdateEducation()
        {
            ProfileEduPage educationObj = new ProfileEduPage(driver);
            educationObj.UpdateEducation();
        }

        [Then(@"i should see the updated education displayed on my listings")]
        public void ThenIShouldSeeTheUpdatedEducationDisplayedOnMyListings()
        {
            ProfileEduPage educationObj = new ProfileEduPage(driver);
            educationObj.ValidateUpdatedEdu();
        }

        [When(@"I delete Education")]
        public void WhenIDeleteEducation()
        {
            ProfileEduPage educationObj = new ProfileEduPage(driver);
            educationObj.DeleteEdu();  
        }        
        
        [Then(@"i should not see deleted education displayed on my listings")]
        public void ThenIShouldNotSeeDeletedEducationDisplayedOnMyListings()
        {
            ProfileEduPage educationObj = new ProfileEduPage(driver);
            educationObj.ValidateDeletedEdu();
        }
    }
}
