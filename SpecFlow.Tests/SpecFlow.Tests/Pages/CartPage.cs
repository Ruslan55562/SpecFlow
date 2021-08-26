using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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
        [FindsBy(How = How.XPath, Using = "//span[@id='product_price_2_12_0']/span")]
        private IWebElement BlousePriceInCart { get; set; }
        [FindsBy(How = How.XPath, Using = "//tr[@id='product_2_12_0_0']/td[2]/p")]
        private IWebElement BlouseNameInCart { get; set; }
        [FindsBy(How = How.XPath, Using = "//tr[@id='product_2_10_0_0']/td[2]/small[2]/a")]
        private IWebElement BlouseColorAndSizeInCart { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@name='quantity_2_12_0_0']")]
        private IWebElement BlouseQuantityInCart { get; set; }
        [FindsBy(How = How.XPath, Using = "//span[@id='total_product_price_2_12_0']")]
        private IWebElement BlouseTotalPriceInCart { get; set; }


        [FindsBy(How = How.XPath, Using = "//span[@id='product_price_5_25_0']/span[1]")]
        private IWebElement DressPriceInCart { get; set; }
        [FindsBy(How = How.XPath, Using = "//tr[@id='product_5_25_0_0']/td[2]/small[2]/a")]
        private IWebElement DressColorAndSizeInCart { get; set; }
        [FindsBy(How = How.XPath, Using = "//tr[@id='product_5_25_0_0']/td[2]/p/a")]
        private IWebElement DressNameInCart { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@name='quantity_5_25_0_0']")]
        private IWebElement DressQuantityInCart { get; set; }
        [FindsBy(How = How.XPath, Using = "//span[@id='total_product_price_5_25_0']")]
        private IWebElement DressTotalPriceInCart { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[@id='5_25_0_0']")]
        private IWebElement DeleteDressFromCart { get; set; }

        [FindsBy(How = How.XPath, Using = "//td[@id='total_product']")]
        private IWebElement TotalProductPrice { get; set; }

        #endregion


        #region FUNCTIONS
        public List<string> ActualNameAndPrice() // The function returns the List<string> that contains actual values of product name and it's price.(First Scenario)
        {
            List<string> tmp = new List<string> { NameOfProfuctInCart.Text, PriceOfProductInCart.Text };
            return tmp;
        }

        public List<string> BlouseDetailsList() // Returns List that contains expected details of the Blouse.(In Cart)
        {
            List<string> tmp = new List<string> { BlousePriceInCart.Text, BlouseNameInCart.Text, "White, L", BlouseQuantityInCart.GetAttribute("value"), BlouseTotalPriceInCart.Text };
            return tmp;
        }

        public List<string> DressDetailsList() // Returns List that contains expected details of the Dress.(In Cart)
        {
            List<string> tmp = new List<string> { DressPriceInCart.Text, DressNameInCart.Text, "Orange, M", DressQuantityInCart.GetAttribute("value"), DressTotalPriceInCart.Text };
            return tmp;
        }

        public CartPage ClickOnDeleteDress() // Clicks on Delete from cart button(for dress)
        {
            DeleteDressFromCart.Click();
            return this;
        }


        public bool DressIsInTheCart() // The function returns true if the total price of products == total price of Blouse and returns false they aren't equal.
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//tr[@id='product_5_25_0_0']")));
            if (TotalProductPrice.Text == BlouseTotalPriceInCart.Text)
                return true;

            return false;
        }
        #endregion


    }
}

