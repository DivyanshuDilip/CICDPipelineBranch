using System;
using OpenQA.Selenium;

namespace CSharpPrograms
{
    class PageObject
    {
        public By pimOptionField = By.XPath("//span[text()='PIM']");

        public By employeeNameInput = By.CssSelector("input[placeholder='Type for hints...']");
        
    }
}