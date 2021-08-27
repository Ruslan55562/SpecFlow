using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlow.Tests.Pages
{
    public class SummerDressProductPage
    {
        private IWebDriver driver;
        public SummerDressProductPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        #region LOCATORS
        [FindsBy(How = How.XPath, Using = "//input[@id='quantity_wanted']")]
        [CacheLookup]
        private IWebElement DressQuntity { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@id='group_1']/option[.='M']")] //
        [CacheLookup]
        private IWebElement DressSize { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@id='color_13']")]
        [CacheLookup]
        private IWebElement DressColor { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='exclusive']")]
        [CacheLookup]
        private IWebElement AddToCartButtonDressPage { get; set; }

        [FindsBy(How = How.XPath, Using = "//h2[contains(.,'Product successfully added to your shopping cart')]")] //
        [CacheLookup]
        private IWebElement SuccessfulAddInscription { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[@title='Proceed to checkout']")]
        [CacheLookup]
        private IWebElement ProceedToCheckoutButton { get; set; }


        [FindsBy(How = How.XPath, Using = "//span[@id='layer_cart_product_title']")]
        private IWebElement DressName { get; set; }
        [FindsBy(How=How.XPath,Using = "//span[@id='layer_cart_product_attributes']")]
        private IWebElement ColorAndSizeAfterAdding { get; set; }
        [FindsBy(How = How.XPath, Using = "//span[@id='layer_cart_product_price']")]
        private IWebElement TotalProductPrice { get; set; }
        [FindsBy(How=How.XPath,Using = "//span[@id='layer_cart_product_quantity']")]
        private IWebElement QuantityOfProduct { get; set; }
        [FindsBy(How = How.XPath, Using = "//span[@id='our_price_display']")]
        private IWebElement DressPrice { get; set; }

        #endregion

        #region FUNCTIONS
        public SummerDressProductPage ChooseDetailsDress(int quantity)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//select[@id='group_1']")));
            DressQuntity.Clear();
            DressQuntity.SendKeys(quantity.ToString());
            DressSize.Click();
            wait.Until(ExpectedConditions.ElementToBeSelected(By.XPath("//select[@id='group_1']/option[.='M']"))); //
            DressColor.Click();
            return this;
        }

        public SummerDressProductPage ClickOnAddToCart()
        {
            AddToCartButtonDressPage.Click();
            return this;
        }

        public string InscriptionContain() //Return the inscription that appears after the successful adding the blouse to the cart.
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h2[contains(.,'Product successfully added to your shopping cart')]"))); //

            return SuccessfulAddInscription.Text;
        }

        public SummerDressProductPage ClickOnProceedButton()
        {
            ProceedToCheckoutButton.Click();
            return this;
        }

        public List<string> ActualDressDetails() //Returns the List that contains ACTUAL details of the product.
        {
          return new List<string> { OneDressPrice(), DressName.Text, ColorAndSizeAfterAdding.Text, QuantityOfProduct.Text, TotalProductPrice.Text }; 
        }
        public string OneDressPrice()
        {
            return DressPrice.Text;
        }

        #endregion
    }
}
