

using System;
using System.Configuration;
using System.IO;
using System.Threading;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using CSharpSelFramework.utilities;
using NPOI.XSSF.UserModel;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace CSharpSelFramework.utilities
{
    public class Base
    {
        public ExtentReports extent;
        public ExtentTest test;
        String browserName;
        //report file
        [OneTimeSetUp]
        public void Setup()

        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            String reportPath =projectDirectory + "//index.html";
            var htmlReporter = new  ExtentHtmlReporter(reportPath);
             extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "Local host");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Username", "Sainath");

        }

        public void scrollDown() {

            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            Thread.Sleep(1000);
             js.ExecuteScript("window.scrollBy(0,1500);");
        }

        public void excelDataReadoSecnario1()
        {
            string path = @"C:\Users\saina\Desktop\TestData.xlsx";
            XSSFWorkbook workbook = new XSSFWorkbook(File.Open(path, FileMode.Open));
            var sheet = workbook.GetSheetAt(0);
            var scenario1 = sheet.GetRow(1);
            var loginName1 = scenario1.GetCell(0).StringCellValue.Trim();
            var firstName1 = scenario1.GetCell(1).StringCellValue.Trim();
            var lastName1 = scenario1.GetCell(2).StringCellValue.Trim();
            var password1 = scenario1.GetCell(3).StringCellValue.Trim();
            var confirmpassword1 = scenario1.GetCell(4).StringCellValue.Trim();
            var expectedMessage1 = scenario1.GetCell(5).StringCellValue.Trim();

        }


        // public IWebDriver driver;
        public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
        [SetUp]

        public void StartBrowser()

        {
          test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

            //Configuration
            browserName = TestContext.Parameters["browserName"];
            if (browserName == null)
            {

                browserName = ConfigurationManager.AppSettings["browser"];
            }
            InitBrowser(browserName);

            driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Value.Manage().Window.Maximize();
            driver.Value.Url = "https://buggy.justtestit.org/register";


        }

        public IWebDriver getDriver()

        {
            return driver.Value;
        }

        public void InitBrowser(string browserName)

        {

            switch (browserName)
            {

                case "Firefox":

                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver.Value = new FirefoxDriver();
                    break;



                case "Chrome":

                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver.Value = new ChromeDriver();
                    break;


                case "Edge":

                    driver.Value = new EdgeDriver();
                    break;

            }


        }

       
        [TearDown]
        public void AfterTest()

        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;



            DateTime time = DateTime.Now;
            String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";

            if (status == TestStatus.Failed)
            {
              
                test.Fail("Test failed", captureScreenShot(driver.Value, fileName));
                test.Log(Status.Fail,"test failed with logtrace"+ stackTrace);

            }
            else if (status == TestStatus.Passed)
            {
          
            }

            extent.Flush();
             driver.Value.Quit();
        }

        public MediaEntityModelProvider captureScreenShot(IWebDriver driver,String screenShotName)

        {
            ITakesScreenshot ts= (ITakesScreenshot)driver;
           var screenshot= ts.GetScreenshot().AsBase64EncodedString;

           return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();

        }




    }
}
