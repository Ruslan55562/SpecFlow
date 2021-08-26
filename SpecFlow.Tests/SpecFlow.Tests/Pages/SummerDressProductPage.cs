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

        [FindsBy(How = How.XPath, Using = "//select[@id='group_1']/option[2]")]
        [CacheLookup]
        private IWebElement DressSize { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@id='color_13']")]
        [CacheLookup]
        private IWebElement DressColor { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='exclusive']")]
        [CacheLookup]
        private IWebElement AddToCartButtonDressPage { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='clearfix']/div[1]/h2")]
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


        #endregion

        #region FUNCTIONS
        public SummerDressProductPage ChooseDetailsDress(int quantity) // Choose quantity,color and size of the dress.
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//select[@id='group_1']")));
            DressQuntity.Clear();
            DressQuntity.SendKeys(quantity.ToString());
            DressSize.Click();
            wait.Until(ExpectedConditions.ElementToBeSelected(By.XPath("//select[@id='group_1']/option[2]")));
            DressColor.Click();
            // wait.Until(ExpectedConditions.ElementToBeSelected(By.XPath("//a[@id='color_8']")));
            return this;
        }

        public SummerDressProductPage ClickOnAddToCart() //Click on add to cart button in the DressPage.
        {
            AddToCartButtonDressPage.Click();
            return this;
        }

        public string InscriptionContain() //Return the inscription that appears after the successful adding the blouse to the cart.
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='clearfix']/div[1]/h2")));

            return SuccessfulAddInscription.Text;
        }

        public SummerDressProductPage ClickOnProceedButton() //Click on the Proceed  button after the successful adding the blouse to the cart.
        {
            ProceedToCheckoutButton.Click();
            return this;
        }

        public List<string> ActualDressDetails() //Returns the List that contains actual details of the product.
        {
            List<string> tmp = new List<string> { "$28.98", DressName.Text, ColorAndSizeAfterAdding.Text, QuantityOfProduct.Text, TotalProductPrice.Text };
            return tmp;

        }

        #endregion
    }
}
