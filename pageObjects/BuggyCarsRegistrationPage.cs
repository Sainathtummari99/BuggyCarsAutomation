using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CSharpSelFramework.pageObjects
{
    public class BuggyCarsRegistrationPage
    {
        public IWebDriver driver;

        public BuggyCarsRegistrationPage(IWebDriver driver)
        {

            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }
        public IWebElement getLoginName() {
            return loginName;
        }
        public IWebElement getFirstName()
        {
            return firstName;
        }
        public IWebElement getLastName()
        {
            return lastName;
        }
        public IWebElement getPassword()
        {
            return password;
        }
        public IWebElement getConfirmPassword()
        {
            return confirmPassword;
        }
        public IWebElement getRegisterbutton()
        {
            return registerButton;
        }
        public IWebElement getSubmitButton()
        {
            return submitButton;
        }

        public IWebElement getCancelButton()
        {
            return cancelButton;
        }
        public IWebElement getSuccessMessage()
        {
            return successMessage;
        }


        //Pageobject factory

        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement loginName;

        [FindsBy(How = How.Id, Using = "firstName")]
        private IWebElement firstName;

        [FindsBy(How = How.Id, Using = "lastName")]
        private IWebElement lastName;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement password;

             [FindsBy(How = How.Id, Using = "confirmPassword")]
        private IWebElement confirmPassword;


        [FindsBy(How = How.XPath, Using = "(//button[@type='submit'])[2]")]
        private IWebElement submitButton;

        [FindsBy(How = How.XPath, Using = "//a[text()='Register']")]
        private IWebElement registerButton;


        [FindsBy(How = How.XPath, Using = "//button[@type='Cancel']")]
        private IWebElement cancelButton;

        [FindsBy(How = How.XPath, Using = "//a[text()='Logout']")]
        private IWebElement logoutButton;
               


        [FindsBy(How = How.XPath, Using = "//a[text()='Cancel']/following-sibling::div")]
        private IWebElement successMessage;

        [FindsBy(How = How.XPath, Using = "(//button[@type='submit'])[1]")]
        private IWebElement loginButton;

        [FindsBy(How = How.XPath, Using = "//span[text()='Hi, Sainath1']")]
        private IWebElement profileName;

        public IWebElement getProfileName()
        {
            return profileName;
        }


        [FindsBy(How = How.Name, Using = "login")]
        private IWebElement loginUserName;

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement loginPassword;

        public IWebElement getLoginButton()
        {
            return loginButton;
        }
        public IWebElement getloginPassword()
        {
            return loginPassword;
        }
        public IWebElement getLoginUserName()
        {
            return loginUserName;
        }
        public IWebElement getLogoutButton()
        {
            return logoutButton;
        }

    }
}
