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

        [FindsBy(How=How.XPath,Using = "//span[@title='Close window']")][CacheLookup]
        private IWebElement CloseCartPopUp { get; set; }

        [FindsBy(How=How.XPath,Using = "//tr[@id='product_5_19_0_0']/td[2]/p/a")][CacheLookup]
        private IWebElement NameOfProfuctInCart { get; set; }
        [FindsBy(How=How.XPath,Using = "//span[@id='total_product_price_5_19_0']")] [CacheLookup]
        private IWebElement PriceOfProductInCart { get; set; }


        public List<string> ActualNameAndPrice()
        {
            List<string> tmp = new List<string> { NameOfProfuctInCart.Text, PriceOfProductInCart.Text };
            return tmp;
        }


    }
}
