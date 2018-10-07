using MandG_Test.PageObjects;
using MandG_Test.Utilities;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace MandG_Test.StepDefinitions
{
    [Binding]
    public sealed class SpecflowStepDefinitions
    {       
        private CommonUtilities commonUtilities = new CommonUtilities();
        SeleniumPageObjects seleniumPageObjects = new SeleniumPageObjects();
   

        [Given(@"I am on the SEDOL validation test page")]
        public void GivenIAmOnTheSedolValidationTestPage()
        {
            seleniumPageObjects.NavigateToURL("http://sedolcheckerwebapp.azurewebsites.net/");
        } 

        /////////////////////////////////////////////////////////////////////////////////////
        // Set checkboxes
        /////////////////////////////////////////////////////////////////////////////////////

        [When(@"I set the IsValidSedol checkbox to '(.*)'")]
        public void WhenISetTheIsValidSedolCheckboxTo(string isValidSedolBooleanString)
        {
            bool isValidSedolBoolean = isValidSedolBooleanString == "True";
            seleniumPageObjects.SetIsValidSedolCheckbox(isValidSedolBoolean);
        }

        [When(@"I set the IsUserDefined checkbox to '(.*)'")]
        public void WhenISetTheIsUserDefinedCheckboxTo(string isUserDefinedBooleanString)
        {
            bool isUserDefinedBoolean = isUserDefinedBooleanString == "True";
            seleniumPageObjects.SetIsUserDefinedCheckbox(isUserDefinedBoolean);
        }

        ///////////////////////////////////////////////////////////////////////////////////////
        //// SEDOL submission and check
        ///////////////////////////////////////////////////////////////////////////////////////         

        [Then(@"the validation details shown are '(.*)'")]
        public void ThenTheValidationDetailsShownAreChecksumDigitDoesNotAgreeWithTheRestOfTheInput(string expectedMessage)
        {
            if (!expectedMessage.Equals("Null"))
            {
                Assert.AreEqual(expectedMessage, seleniumPageObjects.GetValidationDetailsText());
                return;
            }
                        
            Assert.False(seleniumPageObjects.CheckValidationMessagePresent(), "A validation message has been displayed when there should be none");
        }        
        
        [When(@"submit the test SEDOL '(.*)'")]
        public void WhenSubmitTheTestSEDOL(string testSEDOL)
        {
            if (testSEDOL.Equals("Null"))
                testSEDOL = "";
            seleniumPageObjects.EnterTestSEDOLValue(testSEDOL);
            seleniumPageObjects.PressSubmit();
        }
    }
}
