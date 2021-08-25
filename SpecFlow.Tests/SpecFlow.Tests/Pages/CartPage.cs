using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlow.Tests.Pages
{
    public class CartPage
    {
        private IWebDriver driver;
        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        #region LOCATORS(FirstScenario)
        //[FindsBy(How = How.XPath, Using = "//span[@title='Close window']")]
        //[CacheLookup]
        //private IWebElement CloseCartPopUp { get; set; }

        [FindsBy(How = How.XPath, Using = "//tr[@id='product_5_19_0_0']/td[2]/p/a")]
        [CacheLookup]
        private IWebElement NameOfProfuctInCart { get; set; }
        [FindsBy(How = How.XPath, Using = "//span[@id='total_product_price_5_19_0']")]
        [CacheLookup]
        private IWebElement PriceOfProductInCart { get; set; }
        #endregion

        #region LOCATORS(SecondScenario)
        [FindsBy(How = How.XPath, Using = "//span[@id='product_price_2_12_0']/span")] [CacheLookup]
        private IWebElement BlousePriceInCart{get;set;}
        [FindsBy(How=How.XPath,Using = "//tr[@id='product_2_12_0_0']/td[2]/p/a")][CacheLookup]
        private IWebElement BlouseNameInCart { get; set; }
        [FindsBy(How=How.XPath,Using = "//tr[@id='product_2_12_0_0']/td[2]/small[2]/a")][CacheLookup]
        private IWebElement BlouseColorAndSizeInCart { get; set; }
        [FindsBy(How=How.XPath,Using = "//input[@name='quantity_2_12_0_0']")][CacheLookup]
        private IWebElement BlouseQuantityInCart { get; set; }
        [FindsBy(How=How.XPath,Using = "//span[@id='total_product_price_2_12_0']")][CacheLookup]
        private IWebElement BlouseTotalPriceInCart { get; set; }


        [FindsBy(How=How.XPath,Using = "//span[@id='product_price_5_25_0']/span[1]")][CacheLookup]
        private IWebElement DressPriceInCart { get; set; }
        [FindsBy(How=How.XPath,Using = "//tr[@id='product_5_25_0_0']/td[2]/small[2]/a")][CacheLookup]
        private IWebElement DressColorAndSizeInCart { get; set; }
        [FindsBy(How=How.XPath,Using = "//tr[@id='product_5_25_0_0']/td[2]/p/a")][CacheLookup]
        private IWebElement DressNameInCart { get; set; }
        [FindsBy(How=How.XPath,Using = "//input[@name='quantity_5_25_0_0']")][CacheLookup]
        private IWebElement DressQuantityInCart { get; set; }
        [FindsBy(How=How.XPath,Using = "//span[@id='total_product_price_5_25_0']")][CacheLookup]
        private IWebElement DressTotalPriceInCart { get; set; }
        [FindsBy(How=How.XPath,Using = "//a[@id='5_25_0_0']")][CacheLookup]
        private IWebElement DeleteDressFromCart { get; set; }


        #endregion


        public List<string> ActualNameAndPrice() // The function returns the List<string> that contains actual values of product name and it's price.(First Scenario)
        {
            List<string> tmp = new List<string> { NameOfProfuctInCart.Text, PriceOfProductInCart.Text };
            return tmp;
        }


    }
}
