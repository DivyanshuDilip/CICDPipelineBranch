using System;
using OpenQA.Selenium;

namespace PageObject
{
    class AmazonHomepage
    {
        public By searchBarInput = By.Id("twotabsearchtextbox");
        public By allOptionsField = By.XPath("//div[@id='sac-autocomplete-results-container']//div[@role='row']");
    }
}