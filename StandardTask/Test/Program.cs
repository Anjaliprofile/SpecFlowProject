using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using StandardTask.Global;
using StandardTask.Pages;
using StandardTask.Pages.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StandardTask.Global.GlobalDefinitions;


namespace StandardTask
{
    //[TestFixture(BrowserType.Firefox)]
    //[TestFixture(BrowserType.Chrome)]
    //[Parallelizable(ParallelScope.Fixtures)]
    //[Category("Sprint1")]
    //public class Program : Base
    //{
    //    public Program(BrowserType browser) : base(browser)
    //    {
    //    }
    public class Program
    {
        static void Main(string[] args)
        {

        }
    }
    //    [Test]
    //    [Obsolete]
    //    public void ProfileLang()
    //    {
    //        // create object for add language
    //        ProfileLangPage obj = new ProfileLangPage();
    //        obj.AddLang(driver);
    //        obj.UpdateLang();
    //        obj.DeleteLang();            
    //    }
    //    [Test]
    //    [Obsolete]
    //    public void ProfileSkill()
    //    {
    //        // create object for add language
    //        ProfileSkillPage obj = new ProfileSkillPage();
    //        obj.AddSkill(driver);
    //        obj.UpdateSkill();
    //        obj.DeleteSkill();
    //    }
    //    [Test]
    //    [Obsolete]
    //    public void ProfileEdu()
    //    {
    //        // create object for add language
    //        ProfileEduPage obj = new ProfileEduPage();
    //        obj.AddEducation(driver);
    //        obj.UpdateEducation();
    //        obj.DeleteEdu();
    //    }
    //    [Test]
    //    [Obsolete]
    //    public void ProfileCer()
    //    {
    //        // create object for add language
    //        ProfileCerPage obj = new ProfileCerPage();
    //        obj.AddCertificate(driver);
    //        obj.UpdateCertificate();
    //        obj.DeleteCertificate();
    //    }
    //    [Test]
    //    [Obsolete]
    //    public void ProfileDes()
    //    {
    //        // create object for description
    //        ProfileDesPage obj = new ProfileDesPage();
    //        obj.Description();         

    //    }
    //    [Test]
    //    [Obsolete]
    //    public void ChangePwd()
    //    {
    //        //Create Extent Report
    //        test = extent.CreateTest("ChangePassword");
    //        test.Log(Status.Info, "Password Changing");
    //        // taking Screenshots of adding skills
    //        SaveScreenShotClass.SaveScreenshot(driver, "ChangePassword");
    //        // create object for Change password
    //        Profile obj = new Profile();
    //        obj.ChangePassword(driver);

    //    }

    //    [Test]
    //    [Obsolete]
    //    public void CreatNewSkill()
    //    {
    //        //Create Extent Report
    //        test = extent.CreateTest("ShareSkill");
    //        test.Log(Status.Info, "Adding ShareSkills");
    //        // taking Screenshots of adding skills
    //        SaveScreenShotClass.SaveScreenshot(driver, "ShareSkill");
    //        // Create Share Skills      
    //        ShareSkills obj = new ShareSkills();
    //        obj.AddNewSkill();

    //    }

    //    [Test]
    //    [Obsolete]
    //    public void ManageListing()
    //    {
    //        //Create Extent Report
    //        test = extent.CreateTest("ManageListing");
    //        test.Log(Status.Info, "Managing listing");
    //        // taking Screenshots of adding skills
    //        SaveScreenShotClass.SaveScreenshot(driver, "ManageList");
    //        // Create Share Skills      
    //        ManageListings obj = new ManageListings();
    //        obj.EditServiceList();
    //        obj.DeleteServiceList();
    //        obj.ViewServiceList();

    //    }
    //    [Test]
    //    [Obsolete]
    //    public void SearchSkills()
    //    {
    //        Profile obj = new Profile();
    //        obj.SerachSkills();
    //        //Create Extent Report
    //        test = extent.CreateTest("SearchSkills");
    //        test.Log(Status.Info, "Searching Skills");
    //        // taking Screenshots of adding skills
    //        SaveScreenShotClass.SaveScreenshot(driver, "SearchSkills");
    //    }
    //    }

}

