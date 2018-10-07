using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace MandG_Test.PageObjects
{
    class SeleniumPageBase
    {
        public IWebDriver driver = (IWebDriver)FeatureContext.Current["CurrentDriver"];

        public SeleniumPageBase()
        {
            PageFactory.InitElements(driver, this);
        }
    }
}
