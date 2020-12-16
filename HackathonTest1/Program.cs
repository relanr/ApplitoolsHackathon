using Applitools;
using Applitools.Selenium;
using Applitools.Utils.Geometry;
using Applitools.VisualGrid;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Drawing;
using System.Threading;
using Configuration = Applitools.Selenium.Configuration;


namespace HackathonTest1
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Create a new chrome web driver
            IWebDriver webDriver = new ChromeDriver();

            // Create a runner with concurrency of 1
            VisualGridRunner runner = new VisualGridRunner(1);

            // Create Eyes object with the runner, meaning it'll be a Visual Grid eyes.
            Eyes eyes = new Eyes(runner);

            SetUp(eyes);

            try
            {
                Test1(webDriver, eyes);
                Test2(webDriver, eyes);
                Test3(webDriver, eyes);
            }
            finally
            {
                TearDown(webDriver, runner);
            }         
        }

        public static void SetUp(Eyes eyes)
        {
            // Initialize eyes Configuration
            Configuration config = new Configuration();
          
            config.SetApiKey("3xHYsqXjxBhhuNRDcDpQHcaMaUgYU111MBD0fXq5QNxMo110");

            config.SetBatch(new BatchInfo("Holiday Shopping"));
            config.SetViewportSize(1200, 800);
            config.AddBrowser(1200, 800, BrowserType.CHROME);
            config.AddBrowser(1200, 800, BrowserType.FIREFOX);
            config.AddBrowser(1200, 800, BrowserType.EDGE_CHROMIUM);
            config.AddBrowser(1200, 800, BrowserType.SAFARI);
            config.AddDeviceEmulation(DeviceName.iPhone_X);
            eyes.SetConfiguration(config);
            eyes.ForceFullPageScreenshot = true;
            eyes.StitchMode = StitchModes.CSS;
        }

        public static void Test1(IWebDriver webDriver, Eyes eyes)
        {
            try
            {

                // V1 URL
                 //webDriver.Url = "https://demo.applitools.com/tlcHackathonMasterV1.html";

                // Dev URL   
                 // webDriver.Url = "https://demo.applitools.com/tlcHackathonDev.html";

                // V2 URL
                webDriver.Url = "https://demo.applitools.com/tlcHackathonMasterV2.html";

                // Call Open on eyes to initialize a test session
                eyes.Open(webDriver, "AppliFashion", "Test 1", new RectangleSize(1200, 800));


                eyes.Check(Target.Window().Fully().WithName("main page"));

                 
                eyes.CloseAsync();

            }
            catch (Exception e)
            {
                eyes.AbortAsync();
            }
        }

        public static void Test2(IWebDriver webDriver, Eyes eyes)
        {

            try
            {

                // V1 URL
                 //webDriver.Url = "https://demo.applitools.com/tlcHackathonMasterV1.html";

                // Dev URL   
                //  webDriver.Url = "https://demo.applitools.com/tlcHackathonDev.html";

                // V2 URL
                webDriver.Url = "https://demo.applitools.com/tlcHackathonMasterV2.html";

                // Call Open on eyes to initialize a test session
                eyes.Open(webDriver, "AppliFashion", "Test 2", new Size(1200, 800));

                webDriver.FindElement(By.XPath("//label[text()='Black ']")).Click();
                webDriver.FindElement(By.Id("filterBtn")).Click();
                Thread.Sleep(3000);
                eyes.CheckRegion(By.Id("product_grid"), "filter by color", 3);
              
                eyes.CloseAsync();

            }
            catch (Exception e)
            {
                eyes.AbortAsync();
            }
        }

        public static void Test3(IWebDriver webDriver, Eyes eyes)
        {

            try
            {
                // V1 URL
                 // webDriver.Url = "https://demo.applitools.com/tlcHackathonMasterV1.html";

                // Dev URL   
                 // webDriver.Url = "https://demo.applitools.com/tlcHackathonDev.html";

                // V2 URL
                webDriver.Url = "https://demo.applitools.com/tlcHackathonMasterV2.html";

                // Call Open on eyes to initialize a test session
                eyes.Open(webDriver, "AppliFashion", "Test 3", new Size(1200, 800));


                webDriver.FindElement(By.XPath("//img[@alt='Appli Air x Night']")).Click();
                Thread.Sleep(3000);
                eyes.Check(Target.Window().Fully().WithName("product details"));
               
                eyes.CloseAsync();

            }
            catch (Exception e)
            {
                eyes.AbortAsync();
            }
        }

        private static void TearDown(IWebDriver webDriver, VisualGridRunner runner)
        {
            // Close the browser
            webDriver.Quit();

            TestResultsSummary allTestResults = runner.GetAllTestResults();
            System.Console.WriteLine(allTestResults);
        }
    }
}

