﻿using OpenQA.Selenium;
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
        public SearchResultsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        #region LOCATORS

        [FindsBy(How = How.XPath, Using = "//span[@class='lighter']")]
        [CacheLookup]
        private IWebElement SearchResult { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@id='selectProductSort']/option[3]")]
        [CacheLookup]
        private IWebElement SortByHighestPrice { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Printed Summer Dress')]/ancestor::div[@class='right-block']/div[@class='button-container']//a[@data-id-product='5']")]
        [CacheLookup]
        private IWebElement AddToCartLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[1]/div[@class='product-container']/div[2]/h5/a")]
        [CacheLookup]
        private IWebElement TheProductName { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[@id='layer_cart']/div[1]/div[2]/div[4]/a")]
        [CacheLookup]
        private IWebElement ProceedToCheckOutButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@title='View']")]
        [CacheLookup]
        private IWebElement MoreButtonBlouse { get; set; }
        [FindsBy(How=How.XPath,Using = "//div[@id='center_column']/ul/li[1]/div/div[2]/div[2]/a[2]")][CacheLookup]
         private IWebElement MoreButtonDress { get; set; }



        #region PricesOfProducts
        [FindsBy(How = How.XPath, Using = "//li[1]/div/div[2]/div[@itemprop='offers']/span[1]")]
        [CacheLookup]
        private IWebElement PriceOfFirstProductWithDiscount { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[1]/div/div[2]/div[@itemprop='offers']/span[2]")]
        [CacheLookup]
        private IWebElement PriceOfFirstProduct { get; set; }


        [FindsBy(How = How.XPath, Using = "//li[2]/div/div[2]/div[@itemprop='offers']/span")]
        [CacheLookup]
        private IWebElement PriceOfSecondProduct { get; set; }


        [FindsBy(How = How.XPath, Using = "//li[3]/div/div[2]/div[@itemprop='offers']/span[2]")]
        [CacheLookup]
        private IWebElement PriceOfThirdProduct { get; set; }


        [FindsBy(How = How.XPath, Using = "//li[4]/div/div[2]/div[@itemprop='offers']/span")]
        [CacheLookup]
        private IWebElement PriceOfFourthProduct { get; set; }

        #endregion
        #endregion


        #region FUNCTIONS
        public List<string> PricesSort() // The function returns List<string> that contains Actual prices of products without discount.
        {
            List<string> ActualSort = new List<string> { PriceOfFirstProduct.Text, PriceOfSecondProduct.Text, PriceOfThirdProduct.Text, PriceOfFourthProduct.Text };
            return ActualSort;
        }

        public string IsSearchRequestHere() // returns Text of SearchRequest
        {
            return SearchResult.Text;
        }

        public SearchResultsPage SelectHighestOptionSearch() // The function selects option "Price: Highest first"
        {
            SortByHighestPrice.Click();

            return this;
        }
        public List<string> PriceAndNameofFirstProduct() // The function returns the List<string> that contains the name and price of the first product(after the sort)
        {
            List<string> values = new List<string> { TheProductName.Text, PriceOfFirstProductWithDiscount.Text };
            return values;
        }

        public void AddTheProductToCart() // The function hovers over the first product(after sort) and clicks on the "Add to Cart" button.
        {
            Actions action = new Actions(driver);
            IWebElement tmp = driver.FindElement(By.XPath("//div[@id='center_column']/ul/li[1]/div/div[1]/div"));
            action.MoveToElement(tmp).Build().Perform();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='center_column']/ul/li[1]/div/div[1]/div")));
            AddToCartLink.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='layer_cart']/div[1]/div[2]/div[4]/a")));
            ProceedToCheckOutButton.Click();
        }

        #endregion
    }

}
