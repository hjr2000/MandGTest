using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;
using TechTalk.SpecFlow;

namespace MandG_Test.Utilities
{
    [Binding]
    class StartupTearDown
    {
        private static IWebDriver driver;

        [Before]
        public static void StartWebdriver()
        {
            System.Console.WriteLine("Test running");
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
          
            if (FeatureContext.Current.Keys.Any(currentKey => currentKey == "CurrentDriver"))
            {
                FeatureContext.Current.Remove("CurrentDriver");
            }
            FeatureContext.Current.Add("CurrentDriver", driver);
        }

        [After]
        public static void StopWebdriver()
        {
            // Comment out the line below to keep the browser instance open when tests are complete
            driver.Quit();
        }
    }
}
