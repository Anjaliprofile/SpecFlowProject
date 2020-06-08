using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using BoDi;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using StandardTask.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using static StandardTask.Global.GlobalDefinitions;

namespace StandardTask.Global
{
    [Binding]
    public class Base
    {
        // public static IWebDriver driver { get; set; }

        //private readonly IObjectContainer objectContainer;

        //public Base(IObjectContainer objectContainer)
        //{
        //    this.objectContainer = objectContainer;
        //}

        //#region reports
        //public static ExtentTest test;
        //public static ExtentReports extent;
        //public static ExtentHtmlReporter htmlReporter;

        //#endregion

        //#region Initialise Reports 
        //public void extentmanager()
        //{
        //    if (extent == null)
        //    {
        //        string reportPath = MarsResources.ReportPath;
        //        string reportFile = DateTime.Now.ToString().Replace("/", "_").Replace(":", "_").Replace(".", "_");
        //        htmlReporter = new ExtentHtmlReporter(reportPath + reportFile);
        //        extent = new ExtentReports();
        //        extent.AttachReporter(htmlReporter);
        //        extent.AddSystemInfo("OS", "Window 10 Home");
        //        extent.AddSystemInfo("Host Name", "Anjali");
        //        extent.AddSystemInfo("Environment", "QA");
        //        extent.AddSystemInfo("UserName", "Anjali");
        //        // adding Config.xml file
        //        extent.AddTestRunnerLogs(reportPath + "Extent Config.xml");
        //    }
        //}
        //#endregion

        //#region setup and tear down
        //[BeforeScenario]
        //    public void InititalizeTest()
        //    {

        //        driver = new ChromeDriver(@"C:\Users\anjal\Downloads\chromedriver_win32\");
        //       // objectContainer.RegisterInstanceAs<IWebDriver>(driver);                     

        //        #region          
        //        // Maximize browser
        //        driver.Manage().Window.Maximize();
        //        // Navigate to Url
        //        driver.Navigate().GoToUrl(MarsResources.Url);
        //        #endregion

        //        if (MarsResources.IsLogin == "true")
        //        {
        //            SignIn loginobj = new SignIn();
        //            loginobj.SignInStep(driver);
        //        }
        //        else
        //        {
        //            SignUp signUp = new SignUp();
        //            signUp.register();
        //        }


        //    }

        //    [AfterScenario]
        //    public void TearDown()
        //    {
        //        if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
        //        {
        //            // Screenshot
        //            String img = SaveScreenShotClass.SaveScreenshot(driver, "Report");
        //            test.Log(Status.Error, "Image example: " + img);
        //        }
        //        // end test. (Reports)
        //        extent.RemoveTest(test);
        //        // calling Flush writes everything to the log file (Reports)
        //        extent.Flush();
        //        // Close the driver :)            
        //        driver.Quit();
        //    }
        //    #endregion
    }
}



