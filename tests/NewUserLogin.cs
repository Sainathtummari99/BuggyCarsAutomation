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
    public class FunctionalTLoginest : utilities.Base
    {
        IWebDriver driver;

        [Test]
        [TestCase("Ztummari", "Admin@123")]
        public void LoginToBuggyCars(String loginUserName, String loginPassword)
        {
            BuggyCarsRegistrationPage buggycarsPage = new BuggyCarsRegistrationPage(getDriver());
            buggycarsPage.getLoginUserName().SendKeys(loginUserName);
            buggycarsPage.getloginPassword().SendKeys(loginPassword);
            buggycarsPage.getLoginButton().Click();

            Thread.Sleep(4000);
            if (buggycarsPage.getProfileName().Displayed)
            { buggycarsPage.getLogoutButton().Click(); }

            else
            { Console.WriteLine("Profile is not seen- login unsuccessful"); }
           // driver.Quit();
        } } 
}





