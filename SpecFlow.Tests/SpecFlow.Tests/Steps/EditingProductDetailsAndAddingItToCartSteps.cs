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
        [Given(@"User is in the Home Page")]
        public void GivenUserIsInTheHomePage()
        {
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup("edge"); //options: "chrome","firefox","edge".(You can copy and paste it)
            driver.Navigate().GoToUrl(@"http://automationpractice.com/index.php");
            InitPages();
        }

        [Given(@"Enter the '(.*)' keyword and click on Search icon")]
        public void GivenEnterTheKeywordAndClickOnSearchIcon(string p0)
        {
            Homepage.HomePageSearch(p0);
        }

        [Given(@"Click on the More button of the first product")]
        public void GivenClickOnTheMoreButtonOfTheFirstProduct()
        {
            SearchPage.ClickOnMoreButton();
        }

        [Given(@"Set the Quantity = '(.*)', Size = '(.*)', Color = '(.*)' details")]
        public void GivenSetTheQuantitySizeColorDetails(int p0, string p1, string p2)
        {
            BlousePage.ChooseDetailsBlouse(p0);
        }

        [Given(@"Click on Add to Cart button")]
        public void GivenClickOnAddToCartButton()
        {
            BlousePage.ClickOnAddToCart();
        }

        [When(@"The ""(.*)"" modal window appears")]
        public void WhenTheModalWindowAppears(string p0)
        {
            Assert.AreEqual(p0, BlousePage.InscriptionContain(), "The actual inscription isn't such as expected");
            SavedDetailsBlouse = BlousePage.ActualDetailsBlouse();
        }

        [When(@"Click on Continue Shopping button")]
        public void WhenClickOnContinueShoppingButton()
        {
            BlousePage.ClickOnContinueShopping();
        }

        [When(@"Enter the '(.*)' keyword and click on Search icon")]
        public void WhenEnterTheKeywordAndClickOnSearchIcon(string p0)
        {
            driver.FindElement(By.XPath("//input[@id='search_query_top']")).Clear();
            Homepage.HomePageSearch(p0);
        }

        [When(@"Click on the More button of the first product")]
        public void WhenClickOnTheMoreButtonOfTheFirstProduct()
        {
            SearchPage.ClickOnMoreButtonDress();
        }

        [When(@"Set the Quantity = '(.*)', Size = '(.*)', Color = '(.*)' details")]
        public void WhenSetTheQuantitySizeColorDetails(int p0, string p1, string p2)
        {
            DressPage.ChooseDetailsDress(p0);
        }

        [When(@"Click on Add to Cart button")]
        public void WhenClickOnAddToCartButton()
        {
            DressPage.ClickOnAddToCart();
        }


        [When(@"The ""(.*)"" modal window appear")]
        public void WhenTheModalWindowAppear(string p0)
        {
            Assert.AreEqual(p0, DressPage.InscriptionContain(), "The actual inscription isn't such as expected");
            SavedDetailsDress = DressPage.ActualDressDetails();
        }

        [When(@"Click on ""(.*)"" button")]
        public void WhenClickOnButton(string p0)
        {
            DressPage.ClickOnProceedButton();
            
        }
        
        [When(@"Verify the actual details with the expected")]
        public void WhenVerifyTheActualDetailsWithTheExpected()
        {
            Assert.AreEqual(Cartpage.DressDetailsList(), SavedDetailsDress, "The lists aren't equal");
            Assert.AreEqual(Cartpage.BlouseDetailsList(), SavedDetailsBlouse, "The lists aren't equal");
        }
        
        [When(@"Click on Delete button opposite '(.*)'")]
        public void WhenClickOnDeleteButtonOpposite(string p0)
        {
            Cartpage.ClickOnDeleteDress();
        }
        
        [Then(@"Only '(.*)' product displays")]
        public void ThenOnlyProductDisplays(string p0)
        {
            Assert.IsTrue(Cartpage.DressIsInTheCart());
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").TearDown();
        }
    }
}
