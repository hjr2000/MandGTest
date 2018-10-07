using MandG_Test.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MandG_Test.Utilities
{
    class CommonUtilities
    {
        public void WaitForElementVisibilityTakesCSSSelector(IWebDriver driver, string cssSelectorAsString)
        {
            const int secondsToWait = 15;
            WaitForElementVisibilityTakesCSSSelector(driver, cssSelectorAsString, secondsToWait);
        }

        public void WaitForElementVisibilityTakesCSSSelector(IWebDriver driver, string cssSelectorAsString, int timeInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(cssSelectorAsString)));
        }

    }
}
