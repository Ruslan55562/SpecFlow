using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SpecFlow.Tests.Pages
{
    public class SearchResultsPage
    {
        private IWebDriver driver;
        const string FirstProductBlockXPath = "//ul[@class='product_list grid row']/li[1]";



        public SearchResultsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        #region LOCATORS

        [FindsBy(How = How.XPath, Using = "//span[@class='lighter']")]
        [CacheLookup]
        private IWebElement SearchResult { get; set; }

        [FindsBy(How = How.XPath, Using = "//option[.='Price: Highest first']")]
        [CacheLookup]
        private IWebElement SortByHighestPrice { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Printed Summer Dress')]/ancestor::div[@class='right-block']/div[@class='button-container']//a[@data-id-product='5']")]
        [CacheLookup]
        private IWebElement AddToCartLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[@class='product_list grid row']/li[1]/descendant::a[@class='product-name']")] 
        [CacheLookup]
        private IWebElement TheProductName { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[@title='Proceed to checkout']")]
        [CacheLookup]
        private IWebElement ProceedToCheckOutButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@title='View']")]
        [CacheLookup]
        private IWebElement MoreButtonBlouse { get; set; }
        [FindsBy(How=How.XPath,Using = "//ul[@class='product_list grid row']/li[1]/descendant::a[@title='View']")][CacheLookup]
         private IWebElement MoreButtonDress { get; set; }



        #region PricesOfProducts
        [FindsBy(How = How.XPath, Using = "//div[@class='right-block']/descendant::span[contains(text(),'$28.98')]")] 
        [CacheLookup]
        private IWebElement PriceOfFirstProductWithDiscount { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='right-block']/descendant::span[contains(text(),'$30.51')]")] 
        [CacheLookup]
        private IWebElement PriceOfFirstProduct { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@class='right-block']/descendant::span[contains(text(),'$30.50')]")] 
        [CacheLookup]
        private IWebElement PriceOfSecondProduct { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@class='right-block']/descendant::span[contains(text(),'$20.50')]")] 
        [CacheLookup]
        private IWebElement PriceOfThirdProduct { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@class='right-block']/descendant::span[contains(text(),'$16.51')]")] 
        [CacheLookup]
        private IWebElement PriceOfFourthProduct { get; set; }

        #endregion
        #endregion


        #region FUNCTIONS
        public List<string> PricesSort() // The function returns List<string> that contains ACTUAL prices of products without discount.(first Scenario)
        {
            return new List<string> { PriceOfFirstProduct.Text, PriceOfSecondProduct.Text, PriceOfThirdProduct.Text, PriceOfFourthProduct.Text }; ;
        }

        public string IsSearchRequestHere()
        {
            return SearchResult.Text;
        }

        public SearchResultsPage SelectHighestOptionSearch()
        {
            SortByHighestPrice.Click();
            return this;
        }
        public List<string> PriceAndNameofFirstProduct() // The function returns the List<string> that contains the name and price of the first product(after the sort)
        {
            return new List<string> { TheProductName.Text, PriceOfFirstProductWithDiscount.Text }; 
        }

        public SearchResultsPage AddTheProductToCart() // The function hovers over the first product(after sort) and clicks on the "Add to Cart" button.
        {
            Actions action = new Actions(driver);
            IWebElement ProductBlock = driver.FindElement(By.XPath(FirstProductBlockXPath)); 
            action.MoveToElement(ProductBlock).Build().Perform();
           var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(FirstProductBlockXPath))); 
            AddToCartLink.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@title='Proceed to checkout']"))); 
            ProceedToCheckOutButton.Click();
            return this;
        }

        public SearchResultsPage ClickOnMoreButton()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(FirstProductBlockXPath))); 
            Actions action = new Actions(driver);
            IWebElement ProductBlock = driver.FindElement(By.XPath(FirstProductBlockXPath)); 
            action.MoveToElement(ProductBlock).Build().Perform();
          
            MoreButtonBlouse.Click();
            return this;
        } 
        public SearchResultsPage ClickOnMoreButtonDress() 
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(FirstProductBlockXPath))); 
            Actions action = new Actions(driver);
            IWebElement ProductBlock = driver.FindElement(By.XPath(FirstProductBlockXPath)); 
            action.MoveToElement(ProductBlock).Build().Perform();


            MoreButtonDress.Click();
            return this;
        } 

        #endregion
    }

}
