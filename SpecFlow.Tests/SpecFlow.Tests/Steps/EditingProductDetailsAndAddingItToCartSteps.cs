using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlow.Drivers;
using SpecFlow.Tests.Pages;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlow.Tests.Steps
{
    [Binding]
    public class EditingProductDetailsAndAddingItToCartSteps
    {
        protected IWebDriver driver;
        public SearchResultsPage SearchPage;
        public CartPage Cartpage;
        public HomePage Homepage;
        public BlouseProductPage BlousePage;
        public SummerDressProductPage DressPage;
        private readonly ScenarioContext _scenarioContext;
        public EditingProductDetailsAndAddingItToCartSteps(ScenarioContext _scenario) => _scenarioContext = _scenario;
        List<string> SavedDetailsBlouse;
        List<string> SavedDetailsDress;


        public void InitPages()
        {
            SearchPage = new SearchResultsPage(driver);
            Homepage = new HomePage(driver);
            Cartpage = new CartPage(driver);
            BlousePage = new BlouseProductPage(driver);
            DressPage = new SummerDressProductPage(driver);

        }

        [Given(@"User choose browser and move to the Home Page")]
        public void GivenUserChooseBrowserAndMoveToTheHomePage()
        {
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup("chrome"); //options: "chrome","firefox","edge".
            driver.Navigate().GoToUrl(HomePage.SiteUrl);
            InitPages();
        }
        
        [Given(@"Enter the '(.*)' keyword and click on Search icon")]
        public void GivenEnterTheKeywordAndClickOnSearchIcon(string BlouseKeyword)
        {
            Homepage.HomePageSearch(BlouseKeyword);
        }
        
        [Given(@"Click on the More button of the first product")]
        public void GivenClickOnTheMoreButtonOfTheFirstProduct()
        {
            SearchPage.ClickOnMoreButton();
        }
        
        [Given(@"Set the Quantity = '(.*)', Size = L , Color = white, details")]
        public void GivenSetTheQuantitySizeLColorWhiteDetails(int QuantityOfBlouses)
        {
            BlousePage.ChooseDetailsBlouse(QuantityOfBlouses);
            BlousePage.OneBlousePrice();
        }
        
        [Given(@"Click on Add to Cart button")]
        public void GivenClickOnAddToCartButton()
        {
            BlousePage.ClickOnAddToCart();
        }
        
        [When(@"The ""(.*)"" modal window appears")]
        public void WhenTheModalWindowAppears(string ProductAddedMsg)
        {
            Assert.AreEqual(ProductAddedMsg, BlousePage.InscriptionContain(), "The actual inscription isn't such as expected");
            SavedDetailsBlouse = BlousePage.ActualDetailsBlouse();
        }
        
        [When(@"Click on Continue Shopping button")]
        public void WhenClickOnContinueShoppingButton()
        {
            BlousePage.ClickOnContinueShopping();
        }
        
        [When(@"Enter the '(.*)' keyword and click on Search icon")]
        public void WhenEnterTheKeywordAndClickOnSearchIcon(string PrintedSummerDress)
        {
            driver.FindElement(By.XPath("//input[@id='search_query_top']")).Clear();
            Homepage.HomePageSearch(PrintedSummerDress);
        }
        
        [When(@"Click on the More button of the first product")]
        public void WhenClickOnTheMoreButtonOfTheFirstProduct()
        {
            SearchPage.ClickOnMoreButtonDress();
        }
        
        [When(@"Set the Quantity = '(.*)', Size = M, Color = Orange, details")]
        public void WhenSetTheQuantitySizeMColorOrangeDetails(int QuntityOfDresses)
        {
            DressPage.ChooseDetailsDress(QuntityOfDresses);
            DressPage.OneDressPrice();
        }
        
        [When(@"Click on Add to Cart button")]
        public void WhenClickOnAddToCartButton()
        {
            DressPage.ClickOnAddToCart();
        }
        
        [When(@"The ""(.*)"" modal window appear")]
        public void WhenTheModalWindowAppear(string ProductAddedMsg)
        {
            Assert.AreEqual(ProductAddedMsg, DressPage.InscriptionContain(), "The actual inscription isn't such as expected");
            SavedDetailsDress = DressPage.ActualDressDetails();
        }
        
        [When(@"Click on Proceed to checkout button")]
        public void WhenClickOnProceedToCheckoutButton()
        {
            DressPage.ClickOnProceedButton();
        }
        
        [When(@"Verify the actual details with the expected")]
        public void WhenVerifyTheActualDetailsWithTheExpected()
        {
            Assert.AreEqual(Cartpage.DressDetailsList(), SavedDetailsDress, "The lists aren't equal");
            Assert.AreEqual(Cartpage.BlouseDetailsList(), SavedDetailsBlouse, "The lists aren't equal");
        }
        
        [When(@"Click on Delete button opposite Printed summer dress")]
        public void WhenClickOnDeleteButtonOppositePrintedSummerDress()
        {
            Cartpage.ClickOnDeleteDress();
        }
        
        [Then(@"Only Blouse product displays")]
        public void ThenOnlyBlouseProductDisplays()
        {
            Assert.IsTrue(Cartpage.OnlyDressIsInTheCart());
        }
    }
}
