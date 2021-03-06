using System;
using TechTalk.SpecFlow;
using SpecFlow.Drivers;
using OpenQA.Selenium.Chrome;
using SpecFlow.Tests.Pages;
using OpenQA.Selenium;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;

namespace SpecFlow.Tests.Steps
{
    [Binding]
    public class CompareGoodsPricesAndNamesSteps
    {

        protected IWebDriver driver;
        public SearchResultsPage SearchPage;
        public CartPage Cartpage;
        public HomePage Homepage;
        private readonly ScenarioContext _scenarioContext;
        public CompareGoodsPricesAndNamesSteps(ScenarioContext _scenario) => _scenarioContext = _scenario;
        List<string> savedValuesOfPriceAndName;
        public void InitPages()
        {
            SearchPage = new SearchResultsPage(driver);
            Homepage = new HomePage(driver);
            Cartpage = new CartPage(driver);
        }
        [Given(@"User choose browser and move to the Main Page")]
        public void GivenUserChooseBrowserAndMoveToTheMainPage()
        {
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup("edge"); //options: "chrome","firefox","edge".
            driver.Navigate().GoToUrl(HomePage.SiteUrl);
            InitPages();
        }
        
        [When(@"Enter the '(.*)' keyword and Click on Search icon")]
        public void WhenEnterTheKeywordAndClickOnSearchIcon(string SummerKeyword)
        {
            Homepage.HomePageSearch(SummerKeyword);
        }
        
        [When(@"The SUMMER inscription displays above the list of products")]
        public void WhenTheSUMMERInscriptionDisplaysAboveTheListOfProducts()
        {
            Assert.AreEqual("\"SUMMER\"", SearchPage.IsSearchRequestHere(), "The inscription is not as requested");
        }
        
        [When(@"Choose the dropdown option Price: Highest first")]
        public void WhenChooseTheDropdownOptionPriceHighestFirst()
        {
            SearchPage.SelectHighestOptionSearch();
        }
        
        [When(@"Elements sorts with the choosen option")]
        public void WhenElementsSortsWithTheChoosenOption()
        {
            Assert.AreEqual(new List<string> { "$30.51", "$30.50", "$20.50", "$16.51" }, SearchPage.PricesSort(), "The sort isn't correct");
        }
        
        [When(@"Save full name and price  of the first product")]
        public void WhenSaveFullNameAndPriceOfTheFirstProduct()
        {
            savedValuesOfPriceAndName = SearchPage.PriceAndNameofFirstProduct();
        }
        
        [When(@"Add it to cart")]
        public void WhenAddItToCart()
        {
            SearchPage.AddTheProductToCart();
        }
        
        [Then(@"Compare the saved values with the Price and Name in the Total column")]
        public void ThenCompareTheSavedValuesWithThePriceAndNameInTheTotalColumn()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@id='layer_cart']/div[1]")));
            Assert.AreEqual(savedValuesOfPriceAndName, Cartpage.ActualNameAndPrice(), "The actual Name or Price isn't such as expected");
        }
    }
}
