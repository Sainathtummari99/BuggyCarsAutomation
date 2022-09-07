using System;
using System.Collections.Generic;
using System.Threading;
using CSharpSelFramework.pageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace CSharpSelFramework
{
    public class NewUserRegistrationTest : utilities.Base

    {
        IWebDriver driver;              
       
        [Test]
        [TestCase("RossTaylor8", "Ross", "taylor", "Kiwi@1234", "Kiwi@1234")]


        public void NewUserRegistration(String loginName, String firstName, String lastname, String password, String confirmPassword)
        {
            BuggyCarsRegistrationPage buggycarsPage = new BuggyCarsRegistrationPage(getDriver());
            
            buggycarsPage.getRegisterbutton().Click();
            buggycarsPage.getLoginName().SendKeys(loginName);
            buggycarsPage.getFirstName().SendKeys(firstName);
            buggycarsPage.getLastName().SendKeys(lastname);
            buggycarsPage.getPassword().SendKeys(password);
            buggycarsPage.getConfirmPassword().SendKeys(confirmPassword);
            Thread.Sleep(2000);   //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
            buggycarsPage.getSubmitButton().Click();

             //  scrollDown();
            //Assertion or validation of success message
            String actualsuccessMessge = buggycarsPage.getSuccessMessage().Text;
            TestContext.Progress.WriteLine(actualsuccessMessge);
            String expectedSuccessMessage = "Registration is successful";
            Assert.AreEqual(expectedSuccessMessage, actualsuccessMessge);
            //driver.Close();
        }


    }
}






