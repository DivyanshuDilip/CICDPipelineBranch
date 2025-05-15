using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PipelineByGithubAction
{
    [TestFixture]
    class AmazonPlatform
    {
        private IWebDriver driver;

        [SetUp]
        public void loginPage()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless=new"); // Modern headless mode for Chrome >= 109
            options.AddArgument("--disable-gpu");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--user-data-dir=/tmp/unique-user-data-dir-" + Guid.NewGuid().ToString()); // avoid profile conflicts

            driver = new ChromeDriver(options);


            driver.Navigate().GoToUrl("https://www.flipkart.com");
            driver.Manage().Window.Maximize();

        }

        [Test]
        public async Task FlipkartPage()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.XPath("//a[@aria-label='Mobiles']")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            // Scroll down by a specified number of pixels
            js.ExecuteScript("window.scrollBy(0, 2000);");  // Scrolls down by 250 pixels

            // Thread.Sleep(Timeout.Infinite);
            // driver.FindElement(By.XPath("//div[@class='e+xvXX KvHRYS']/span")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            // IList<IWebElement> allMobiles = driver.FindElements(By.XPath("//div[@class='uHlz8t']//div[@class='lx8H6m']/div/div"));
            // TestContext.Progress.WriteLine("Number of Mobiles Found: ");
            // foreach (IWebElement a in allMobiles)
            // {
            //     // var mobileBrand = a.Text;
            //     // Console.WriteLine(mobileBrand);

            //     if (!a.Selected)
            //     {
            //         a.Click();
            //         driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            //     }


            //     // if (mobileBrand == "LG")
            //     // {

            //     //     a.Click();
            //     // }
            // }

            //  driver.FindElement(By.XPath("//a[@href='/tyy/4io/~cs-udlfwh2343/pr?sid=tyy,4io&collection-tab-name=OPPO+K12x+5G&pageCriteria=default&param=2311&otracker=CLP_BannerX3&fm=organic&ppt=hp&ppn=homepage&ssid=4dmx763w1s0000001743751620744']")).Click();
            driver.FindElement(By.XPath("//a[contains(@href, '/tyy/4io/~cs-udlfwh2343/pr?sid=tyy,4io&collection-tab-name=OPPO+K12x+5G&pageCriteria=default&param=2311')]")).Click();

            IList<IWebElement> oppoMobiles = driver.FindElements(By.XPath("//div[@class='KzDlHZ']"));

            foreach (var m in oppoMobiles)
            {
                var mobiles = m.Text;
                Console.WriteLine(mobiles);

                if (mobiles == "OPPO K12x 5G with 45W SUPERVOOC Charger In-The-Box (Midnight Violet, 256 GB)")
                {
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                    m.Click();
                }
            }

            var allWindows = driver.WindowHandles;

            Console.WriteLine(allWindows);

            driver.SwitchTo().Window(allWindows[1]);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //  Thread.Sleep(Timeout.Infinite);
            //   driver.FindElement(By.XPath("//button[text()='Buy Now']")).Click();

            //  Thread.Sleep(Timeout.Infinite);
        }
        [TearDown]
        public void FlipkartLogoutPage()
        {
            driver.Quit();
        }

    }
}