using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

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

        [FindsBy(How = How.XPath, Using = "//span[@class='lighter']")]
        [CacheLookup]
        private IWebElement SearchResult { get; set; }

        [FindsBy(How=How.XPath,Using = "//select[@id='selectProductSort']")][CacheLookup]
        private IWebElement SortByOption { get; set; }

        [FindsBy(How=How.XPath,Using = "//a[contains(text(),'Printed Summer Dress')]/ancestor::div[@class='right-block']/div[@class='button-container']//a[@data-id-product='5']")] [CacheLookup]
        private IWebElement AddToCartLink { get; set; }

        [FindsBy(How=How.XPath,Using = "//li[1]/div[@class='product-container']/div[2]/h5/a")][CacheLookup]
        private IWebElement TheProductName { get; set; }

        #region PricesOfProducts
        [FindsBy(How=How.XPath,Using = "//li[1]/div/div[2]/div[@itemprop='offers']/span[1]")][CacheLookup]
        private IWebElement PriceOfFirstProductWithDiscount { get; set; }

        [FindsBy(How =How.XPath,Using = "//li[1]/div/div[2]/div[@itemprop='offers']/span[2]")][CacheLookup]
        private IWebElement PriceOfFirstProduct { get; set; }


        [FindsBy(How = How.XPath, Using = "//li[2]/div/div[2]/div[@itemprop='offers']/span")]
        [CacheLookup]
        private IWebElement PriceOfSecondProduct { get; set; }


        [FindsBy(How = How.XPath, Using = "//li[3]/div/div[2]/div[@itemprop='offers']/span[2]")]
        [CacheLookup]
        private IWebElement  PriceOfThirdProduct{ get; set; }


        [FindsBy(How = How.XPath, Using = "//li[4]/div/div[2]/div[@itemprop='offers']/span")]
        [CacheLookup]
        private IWebElement PriceOfFourthProduct { get; set; }
        
        #endregion


        public bool IsCorrectPricesSort()
        {
            var Expected = new List<string> { "$30.51", "$30.50", "$20.50", "$16.51" };
            
            List<string> ActualSort = new List<string> { PriceOfFirstProduct.Text, PriceOfSecondProduct.Text, PriceOfThirdProduct.Text, PriceOfFourthProduct.Text };
            for(int i =0;i<ActualSort.Count;i++)
                if (ActualSort[i] != Expected[i])  return false;

            return true;
        }

        public string IsSearchRequestHere()
        {
            return SearchResult.Text;
        }

    }

}
