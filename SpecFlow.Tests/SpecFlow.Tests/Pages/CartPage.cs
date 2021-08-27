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
        const string ExpectedColorAndSizeOfBlouse = "White, L";
        const string ExpectedColorAndSizeOfDress =  "Orange, M";


        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        #region LOCATORS(FirstScenario)

        [FindsBy(How = How.XPath, Using = "//a[.='Printed Summer Dress']")]
        [CacheLookup]
        private IWebElement NameOfProfuctInCart { get; set; }
        [FindsBy(How = How.XPath, Using = "//span[@id='total_product_price_5_19_0']")]
        [CacheLookup]
        private IWebElement PriceOfProductInCart { get; set; }
        #endregion

        #region LOCATORS(SecondScenario)
        [FindsBy(How = How.XPath, Using = "//span[@id='product_price_2_12_0']/span")]
        private IWebElement BlousePriceInCart { get; set; }
        [FindsBy(How = How.XPath, Using = "//p/a[.='Blouse']")] //
        private IWebElement BlouseNameInCart { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@name='quantity_2_12_0_0']")]
        private IWebElement BlouseQuantityInCart { get; set; }
        [FindsBy(How = How.XPath, Using = "//span[@id='total_product_price_2_12_0']")]
        private IWebElement BlouseTotalPriceInCart { get; set; }


        [FindsBy(How = How.XPath, Using = "//span[@id='product_price_5_25_0']/span[1]")]
        private IWebElement DressPriceInCart { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[.='Printed Summer Dress']")] 
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
        public List<string> ActualNameAndPrice()
        {
            return new List<string> { NameOfProfuctInCart.Text, PriceOfProductInCart.Text };
        }

        public List<string> BlouseDetailsList() // Returns List that contains EXPECTED details of the Blouse.(In Cart)
        {
            return new List<string> { BlousePriceInCart.Text, BlouseNameInCart.Text, ExpectedColorAndSizeOfBlouse, BlouseQuantityInCart.GetAttribute("value"), BlouseTotalPriceInCart.Text };
        }

        public List<string> DressDetailsList() // Returns List that contains EXPECTED details of the Dress.(In Cart)
        { 
            return new List<string> { DressPriceInCart.Text, DressNameInCart.Text, ExpectedColorAndSizeOfDress, DressQuantityInCart.GetAttribute("value"), DressTotalPriceInCart.Text };
        }

        public CartPage ClickOnDeleteDress() 
        {
            DeleteDressFromCart.Click();
            return this;
        }

        public bool DressIsInTheCart() // The function returns true if the total price of products == total price of Blouse and returns false they aren't equal.
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(7));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//tr[@id='product_5_25_0_0']")));
            if (TotalProductPrice.Text == BlouseTotalPriceInCart.Text)
                return true;

            return false;
        }
        #endregion


    }
}

