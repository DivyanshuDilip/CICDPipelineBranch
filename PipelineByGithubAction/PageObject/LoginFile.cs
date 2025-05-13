using System;
using OpenQA.Selenium;

namespace PageObject
{
    class LoginFile
    {

        By username = By.Id("email");

        By password = By.Id("pass");

        By logInButton = By.Name("login");


        public void LoginFunction(IWebDriver driver, string userName, string pass)
        {
            driver.FindElement(username).SendKeys(userName);
            driver.FindElement(password).SendKeys(pass);
            driver.FindElement(logInButton).Click();
        }
    }



}