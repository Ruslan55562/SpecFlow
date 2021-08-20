using System;
using TechTalk.SpecFlow;
using SpecFlow.Drivers;
using OpenQA.Selenium.Chrome;
using SpecFlow.Tests.Pages;

namespace SpecFlow.Tests.Steps
{
    [Binding]
    public class CompareGoodsPricesSteps
    {
        SeleniumDriver driver;
        [Given(@"User is at the Home Page")]
        public void GivenUserIsAtTheHomePage()
        {
            driver._webDriver = new ChromeDriver();
            driver._webDriver.Manage().Window.Maximize();
            driver._webDriver.Navigate().GoToUrl(@"http://automationpractice.com/index.php");
            driver.page = new SearchResultsPage(driver._webDriver);
        }

        [When(@"Enter the Summer keyword")]
        public void WhenEnterTheSummerKeyword()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Click on Search icon\.")]
        public void WhenClickOnSearchIcon_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"The SUMMER inscription displays above the list of products")]
        public void WhenTheSUMMERInscriptionDisplaysAboveTheListOfProducts()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Choose the dropdown option Price: Highest first")]
        public void WhenChooseTheDropdownOptionPriceHighestFirst()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Elements sorts with the choosen option")]
        public void WhenElementsSortsWithTheChoosenOption()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Save full name and price  of the first product")]
        public void WhenSaveFullNameAndPriceOfTheFirstProduct()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Add it to cart")]
        public void WhenAddItToCart()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Compare the saved values with the Price and Name in the Total column")]
        public void ThenCompareTheSavedValuesWithThePriceAndNameInTheTotalColumn()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
