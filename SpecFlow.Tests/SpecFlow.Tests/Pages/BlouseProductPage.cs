using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SpecFlow.Tests.Pages
{
    public class BlouseProductPage
    {
        private IWebDriver driver;
        public BlouseProductPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        #region LOCATORS
        [FindsBy(How=How.XPath,Using = "//input[@id='quantity_wanted']")][CacheLookup]
        private IWebElement QuantityInputField { get; set; }

        [FindsBy(How=How.XPath,Using = "//select[@id='group_1']/option[.='L']")][CacheLookup] 
        private IWebElement SelectedSize { get; set; }

        [FindsBy(How=How.XPath,Using = "//a[@id='color_8']")][CacheLookup]
        private IWebElement SelectedColor { get; set; }
        [FindsBy(How=How.XPath,Using = "//button[@class='exclusive']")][CacheLookup]
        private IWebElement AddToCartButton { get; set; }

        [FindsBy(How=How.XPath,Using = "//h2[contains(.,'Product successfully added to your shopping cart')]")][CacheLookup] 
        private IWebElement ProductAddedInscription { get; set; }

        [FindsBy(How=How.XPath,Using = "//span[@title='Continue shopping']")][CacheLookup]
        private IWebElement ContinueShoppingButton { get; set; }

        #endregion

        #region ActualDetails(LOCATORS)
        [FindsBy(How = How.XPath, Using = "//span[@id='layer_cart_product_title']")]
        private IWebElement BlouseName { get; set; }
        [FindsBy(How = How.XPath, Using = "//span[@id='layer_cart_product_attributes']")]
        private IWebElement BlouseColorAndSize { get; set; }
        [FindsBy(How = How.XPath, Using = "//span[@id='layer_cart_product_quantity']")]
        private IWebElement BlouseQuantity { get; set; }
        [FindsBy(How = How.XPath, Using = "//span[@id='layer_cart_product_price']")]
        private IWebElement BlouseTotalPrice { get; set; }
        [FindsBy(How = How.XPath, Using = " //span[@id='our_price_display']")]
        private IWebElement BlousePrice { get; set; }
        #endregion

       




        public BlouseProductPage ChooseDetailsBlouse(int quantityOfBlouses) 
        { 
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//select[@id='group_1']")));
            QuantityInputField.Clear();
            QuantityInputField.SendKeys(quantityOfBlouses.ToString());
            SelectedSize.Click();
            wait.Until(ExpectedConditions.ElementToBeSelected(By.XPath("//select[@id='group_1']/option[.='L']"))); 
            SelectedColor.Click();
            return this;
        }
        public BlouseProductPage ClickOnAddToCart()
        {
            AddToCartButton.Click();
            return this;
        }
        public string InscriptionContain() //Return the inscription that appears after the successful adding the blouse to the cart.
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h2[contains(.,'Product successfully added to your shopping cart')]"))); 
            return ProductAddedInscription.Text;
        }
        public BlouseProductPage ClickOnContinueShopping() 
        {
            ContinueShoppingButton.Click();
            return this;
        }

        public List<string> ActualDetailsBlouse() // Returns List that contains ACTUAL details about the Blouse.
        {  
            return new List<string> { OneBlousePrice(), BlouseName.Text, BlouseColorAndSize.Text, BlouseQuantity.Text, BlouseTotalPrice.Text }; ;
        }
        public string OneBlousePrice()
        {
            return BlousePrice.Text;
        }

    }
}
