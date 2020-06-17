using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace selenium_core
{
    [TestClass]
    public class HomepageFeature
    {
        IWebDriver _driver;
        [TestMethod]
        public void ShouldBeAbleToLogin()
        {
            // var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            var loginButtonLocator = By.ClassName("btn_action");
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(loginButtonLocator));

            var userNameField = _driver.FindElement(By.Id("user-name"));
            var passwordField = _driver.FindElement(By.Id("password"));
            var loginButton = _driver.FindElement(loginButtonLocator);
            
            userNameField.SendKeys("standard_user");
            passwordField.SendKeys("secret_sauce");
            loginButton.Click();
            
            // // wait the loaded page
            // var footerLocator = By.ClassName("footer_robot");
            // var footerWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            // footerWait.Until(ExpectedConditions.ElementIsVisible(footerLocator));
            
            // Assert.IsTrue(_driver.Url.Contains("saucedemo"));
            Assert.IsTrue(_driver.Url.Contains("inventory.html"));
        }

        [TestCleanup]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }
}
