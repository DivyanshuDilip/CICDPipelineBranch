using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObject;


namespace PipelineByGithubAction
{
    class AmazonPlatform
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.amazon.in/");

            driver.Manage().Window.Maximize();

            AmazonHomepage homePage = new AmazonHomepage();

            driver.FindElement(homePage.searchBarInput).SendKeys("Laptop");

            Thread.Sleep(3000);

            IList<IWebElement> differentOption = driver.FindElements(homePage.allOptionsField);

            foreach (var i in differentOption)
            {
                string allOptions = i.Text;
                Console.WriteLine(allOptions);

                if (allOptions == "laptop table stand")
                {
                    i.Click();
                    break;

                }
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //  WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));

            ProductSearchPage products = new ProductSearchPage();

            IList<IWebElement> checkboxes = driver.FindElements(products.differentBrandCheckbox);

            foreach (var checkbox in checkboxes)
            {
                string brandNames = checkbox.Text;
                Console.WriteLine(brandNames);

                if (brandNames == "ZEBRONICS")
                {
                    checkbox.Click();
                    break;
                }
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            IList<IWebElement> differentProducts = driver.FindElements(products.productDetail);

            foreach (var productOptions in differentProducts)
            {
                string product = productOptions.Text;
                Console.WriteLine(product);

                if (product == "ZEBRONICS DOW Y2, Foldable Laptop Table, Cup Holder, Tablet | Pen | Mobile - Holder, Sturdy Legs, Anti Slip Feet, Table for Study | Work | Craft (Black)")
                {
                    productOptions.Click();
                    break;
                }
            }

            var allWindows = driver.WindowHandles;

            driver.SwitchTo().Window(allWindows[1]);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            // IWebElement clickableElement = wait.Until(d => d.FindElement(products.addToCartButton)).Displayed;

            driver.FindElement(products.addToCartButton).Click();
            driver.FindElement(products.proceedToBuyButton).Click();

            Thread.Sleep(Timeout.Infinite);


        }
    }
}