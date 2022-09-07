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
    public class DuplicateUserRegistrationTest : utilities.Base
    {
        IWebDriver driver;

        [Test]
        [TestCase("Stummari", "sainath", "tummari", "Admin@123", "Admin@123")]

        public void ExistingUserRegistration(String loginName, String firstName, String lastname, String password, String confirmPassword)
        {
            
            BuggyCarsRegistrationPage buggycarsPage = new BuggyCarsRegistrationPage(getDriver());

            buggycarsPage.getRegisterbutton().Click();
            buggycarsPage.getLoginName().SendKeys(loginName);
            buggycarsPage.getFirstName().SendKeys(firstName);
            buggycarsPage.getLastName().SendKeys(lastname);
            buggycarsPage.getPassword().SendKeys(password);
            buggycarsPage.getConfirmPassword().SendKeys(confirmPassword);
            Thread.Sleep(2000);
            buggycarsPage.getSubmitButton().Click();
         
            String actualsuccessMessge = buggycarsPage.getSuccessMessage().Text;
            TestContext.Progress.WriteLine(actualsuccessMessge);
            Thread.Sleep(2000);
            
            //Error message validation
            String expectedSuccessMessage = "UsernameExistsException: User already exists";
            Assert.AreEqual(expectedSuccessMessage, actualsuccessMessge);
          //  driver.Close();

        }
    }
}





