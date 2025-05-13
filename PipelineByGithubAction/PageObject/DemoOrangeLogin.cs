using System;
using OpenQA.Selenium;

namespace PageObject
{
    class DemoOrangeLogin
    {
        public By usernameInput = By.Name("username");

        public By passwordInput = By.Name("password");

        public By loginButton = By.XPath("//button[text()=' Login ']");


        public void loginMethod (IWebDriver driver,string Username,string Password)
        {
             driver.FindElement(usernameInput).SendKeys(Username);
             driver.FindElement(passwordInput).SendKeys(Password);
             driver.FindElement(loginButton).Click();

        }
    }
}