using OpenQA.Selenium;
using StandardTask.Global;
using StandardTask.Pages.Profile;
using System;
using TechTalk.SpecFlow;

namespace StandardTask.StepDefinitions
{
    [Binding, Scope(Feature = "ProfileCertificate")]
    public class ProfileCertificateSteps 
    {
        private IWebDriver driver;
        public ProfileCertificateSteps(IWebDriver _driver)
        {
            driver = _driver;
        }

        //ProfileCerPage CertificateObj;
        //private ProfileCerPage Obj = new ProfileCerPage();
        

        [Given(@"I clicked on the Certifcation tabunder Profile page")]
        public void GivenIClickedOnTheCertifcationTabunderProfilePage()
        {
            //click on Certificate tab
            driver.FindElement(By.XPath("//div[@class='ui top attached tabular menu']/a[4]")).Click();
        }
        
        [When(@"i add new certification")]
        public void WhenIAddNewCertification()
        {
             ProfileCerPage Obj = new ProfileCerPage(driver);
             Obj.AddCertificate();
        }

        [Then(@"i should see  the certification displayed on my listings")]
        public void ThenIShouldSeeTheCertificationDisplayedOnMyListings()
        {
            ProfileCerPage Obj = new ProfileCerPage(driver);
            Obj.ValidateAddCer();
        }

        [When(@"i update certification")]
        public void WhenIUpdateCertification()
        {
            ProfileCerPage Obj = new ProfileCerPage(driver);
            Obj.UpdateCertificate();
        }

        [Then(@"i should see updated certification displayed on my listings")]
        public void ThenIShouldSeeUpdatedCertificationDisplayedOnMyListings()
        {
            ProfileCerPage Obj = new ProfileCerPage(driver);
            Obj.ValidateUpdatedCer();
        }

        [When(@"i delete certification")]
        public void WhenIDeleteCertification()
        {
            ProfileCerPage Obj = new ProfileCerPage(driver);
            Obj.DeleteCertificate();
        }    
                      
        [Then(@"i should not see the deleted certification displayed on my listings")]
        public void ThenIShouldNotSeeTheDeletedCertificationDisplayedOnMyListings()
        {
            ProfileCerPage Obj = new ProfileCerPage(driver);
            Obj.ValidateDeletedCer();
        }
    }
}
