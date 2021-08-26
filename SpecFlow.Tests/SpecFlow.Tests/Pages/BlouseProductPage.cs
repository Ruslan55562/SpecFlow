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

        [FindsBy(How=How.XPath,Using = "//select[@id='group_1']/option[3]")][CacheLookup]
        private IWebElement SelectedSize { get; set; }

        [FindsBy(How=How.XPath,Using = "//a[@id='color_8']")][CacheLookup]
        private IWebElement SelectedColor { get; set; }
        [FindsBy(How=How.XPath,Using = "//button[@class='exclusive']")][CacheLookup]
        private IWebElement AddToCartButton { get; set; }

        [FindsBy(How=How.XPath,Using = "//div[@class='clearfix']/div[1]/h2")][CacheLookup]
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
        #endregion






        public BlouseProductPage ChooseDetailsBlouse(int quantity) // Choose quantity,color and size of the blouse.
        { 
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//select[@id='group_1']")));
            QuantityInputField.Clear();
            QuantityInputField.SendKeys(quantity.ToString());
            SelectedSize.Click();
            wait.Until(ExpectedConditions.ElementToBeSelected(By.XPath("//select[@id='group_1']/option[3]")));
            SelectedColor.Click();
           // wait.Until(ExpectedConditions.ElementToBeSelected(By.XPath("//a[@id='color_8']")));
            return this;
        }
        public BlouseProductPage ClickOnAddToCart() //Click on add to cart button in the BlouseProductPage
        {
            AddToCartButton.Click();
            return this;
        }
        public string InscriptionContain() //Return the inscription that appears after the successful adding the blouse to the cart.
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='clearfix']/div[1]/h2")));
           
            return ProductAddedInscription.Text;
        }
        public BlouseProductPage ClickOnContinueShopping() //Click on the continue shopping button after the successful adding the blouse to the cart.
        {
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
           // wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@title='Continue shopping']")));
            ContinueShoppingButton.Click();
            return this;
        }

        public List<string> ActualDetailsBlouse() // Returns List that contains actual details about the Blouse.
        {
            List<string> tmp = new List<string> {"$27.00", BlouseName.Text, BlouseColorAndSize.Text, BlouseQuantity.Text, BlouseTotalPrice.Text};
            return tmp;
        }

    }
}
