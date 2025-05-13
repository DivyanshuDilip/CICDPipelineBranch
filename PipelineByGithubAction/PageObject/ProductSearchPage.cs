using System;
using OpenQA.Selenium;

namespace PageObject
{
    class ProductSearchPage
    {
        public By differentBrandCheckbox = By.XPath("//div[@id='brandsRefinements']/ul/span/span/li/span/a");

        public By productDetail = By.XPath("//div[@data-cy='title-recipe']//h2/span");

        public By addToCartButton = By.XPath("//input[@id='add-to-cart-button']");
        public By proceedToBuyButton = By.Name("proceedToRetailCheckout");
    }
}