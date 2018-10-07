using MandG_Test.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace MandG_Test.PageObjects
{
    class SeleniumPageObjects : SeleniumPageBase
    {
        private CommonUtilities commonUtilities = new CommonUtilities();

        [FindsBy(How = How.CssSelector, Using = IsValidSedolCheckboxCSSSelector)]
        private IWebElement isValidSedolCheckbox;

        [FindsBy(How = How.CssSelector, Using = IsUserDefinedCheckboxCSSSelector)]
        private IWebElement isUserDefinedCheckbox;

        [FindsBy(How = How.CssSelector, Using = validationDetailsTextCSSSelector)]
        private IWebElement validationDetailsText;

        [FindsBy(How = How.CssSelector, Using = testSEDOLInputBoxCSSSelector)]
        private IWebElement testSEDOLInputBox;

        [FindsBy(How = How.CssSelector, Using = submitButtonCSSSelector)]
        private IWebElement submitButton;

        private const string IsValidSedolCheckboxCSSSelector = "#div1 input";
        private const string IsUserDefinedCheckboxCSSSelector = "#div1 p:nth-of-type(2) input";
        private const string validationDetailsTextCSSSelector = ".loader";
        private const string testSEDOLInputBoxCSSSelector = "#inputBox";
        private const string submitButtonCSSSelector = "#submitSedol";

        public void NavigateToURL(string URL)
        {
            driver.Navigate().GoToUrl(URL);
        }

        internal bool CheckValidationMessagePresent()
        {
            // Poll the UI for 1 second to check if a validation message has appeared
            var validationMessageExists = false;

            for (int count = 0; count < 4; count++)
            {
                validationMessageExists = driver.FindElements(By.CssSelector(validationDetailsTextCSSSelector)).Count != 0;
                if (validationMessageExists)
                    break;
                Thread.Sleep(250);
            }            

            return validationMessageExists;
        }

        internal void SetIsValidSedolCheckbox(bool toBeCheckboxSetting)
        {      
            if (CheckboxCommonRoutine(IsValidSedolCheckboxCSSSelector, toBeCheckboxSetting))
                return;
            isValidSedolCheckbox.Click();
        }

        internal void SetIsUserDefinedCheckbox(bool toBeCheckboxSetting)
        {     
            if (CheckboxCommonRoutine(IsUserDefinedCheckboxCSSSelector, toBeCheckboxSetting))
                return;
            isUserDefinedCheckbox.Click();
        }

        private bool CheckboxCommonRoutine(string CSSSelector, bool toBeCheckboxSetting)
        {
            commonUtilities.WaitForElementVisibilityTakesCSSSelector(driver, CSSSelector);
            bool currentCheckboxSetting = driver.FindElement(By.CssSelector(CSSSelector)).Selected;
            if (currentCheckboxSetting == toBeCheckboxSetting)
                return true;
            return false;
        }

        internal void PressSubmit()
        {
            submitButton.Click();
        }

        internal void EnterTestSEDOLValue(string testSEDOL)
        {
            testSEDOLInputBox.SendKeys(testSEDOL);
        }

        internal string GetValidationDetailsText()
        {
            commonUtilities.WaitForElementVisibilityTakesCSSSelector(driver, validationDetailsTextCSSSelector);
            return validationDetailsText.Text;
        }
    }
}
