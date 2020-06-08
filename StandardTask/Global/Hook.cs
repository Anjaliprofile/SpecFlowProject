using AventStack.ExtentReports;
using BoDi;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using StandardTask.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using static StandardTask.Global.GlobalDefinitions;
using static StandardTask.Global.Base;
using AventStack.ExtentReports.Reporter;
using Gherkin.Events.Args.Ast;
using Gherkin.Ast;
using AventStack.ExtentReports.Gherkin.Model;
using System.Reflection;

namespace StandardTask.Global
{
    [Binding]
    public class Hook 
    {
        // Define global variables for extent report
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;

        private IWebDriver driver;

        private readonly IObjectContainer objectContainer;

        public Hook(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }


            //private FeatureContext _featureContext;

            //public Hook(FeatureContext featureContext)
            //{
            //    _featureContext = featureContext;
            //}

        //private ScenarioContext _scenarioContext;
        //public Hook(ScenarioContext scenarioContext)
        //{
        //    _scenarioContext = scenarioContext;
        //}
       

        [BeforeTestRun]
        public static void InitializeReport()
        {
            var htmlReporter = new ExtentHtmlReporter(@"A:\AdvanceTask\StandardTaskPart2\StandardTask\TestReports\ExtentReport.html");
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            extent.Flush();
        }

        [BeforeFeature]     
        public static void BeforeFeature(FeatureContext featureContext)
        {
            //featureName = extent.CreateTest(new GherkinKeyword(AventStack.ExtentReports.Gherkin.Model.Feature), FeatureContext.Current.FeatureInfo.Title);
            featureName = extent.CreateTest<AventStack.ExtentReports.Gherkin.Model.Feature>(featureContext.FeatureInfo.Title);
            
        }

        [AfterStep]

        public static void InsertReportingSteps(ScenarioContext scenarioContext)
        {
            var stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();

            //PropertyInfo propertyInfo = typeof(ScenarioContext).GetProperty("TestStatus", BindingFlags.Instance | BindingFlags.NonPublic);
            //MethodInfo getter = propertyInfo.GetGetMethod(nonPublic: true);
            //object TestResult = getter.Invoke(scenarioContext, null);

            if(scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(scenarioContext.StepContext.StepInfo.Text);
            }

            else if(scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.InnerException);
                else if (stepType == "When")
                    scenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.InnerException);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message);               
            }
            
        }


        #region setup and tear down
        [BeforeScenario]
        public void InititalizeTest(ScenarioContext scenarioContext)
        {

            driver = new ChromeDriver(@"C:\Users\anjal\Downloads\chromedriver_win32\");
            scenario = featureName.CreateNode<AventStack.ExtentReports.Gherkin.Model.Scenario>(scenarioContext.ScenarioInfo.Title);
            objectContainer.RegisterInstanceAs<IWebDriver>(driver);                     

            #region          
            // Maximize browser
            driver.Manage().Window.Maximize();
            // Navigate to Url
            driver.Navigate().GoToUrl(MarsResources.Url);
            #endregion

            if (MarsResources.IsLogin == "true")
            {
                SignIn loginobj = new SignIn(driver);
                loginobj.SignInStep();
            }
            else
            {
                SignUp signUp = new SignUp(driver);
                signUp.register();
            }
        }

        [AfterScenario]
        public void TearDown()
        {
            //if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            //{
            //    // Screenshot
            //    String img = SaveScreenShotClass.SaveScreenshot(driver, "Report");
            //    test.Log(Status.Error, "Image example: " + img);
            //}
            // calling Flush writes everything to the log file (Reports)
            //extent.Flush();
            // Close the driver :)            
            driver.Quit();
        }
        #endregion

    }
}
