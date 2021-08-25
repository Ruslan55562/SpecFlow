using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlow.Tests.Pages
{
    class BlouseProductPage
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
        private IWebElement SelectedColor { get; set; 
        }
        [FindsBy(How=How.XPath,Using = "//button[@class='exclusive']")][CacheLookup]
        private IWebElement AddToCartButton { get; set; }

        [FindsBy(How=How.XPath,Using = "//div[@class='clearfix']/div[1]/h2")][CacheLookup]
        private IWebElement ProductAddedInscription { get; set; }

        [FindsBy(How=How.XPath,Using = "//span[@title='Continue shopping']")][CacheLookup]
        private IWebElement ContinueShoppingButton { get; set; }

        [FindsBy(How=How.XPath,Using = "//div/div[1]/span[@itemprop='price']")][CacheLookup]
        private IWebElement BlousePrice { get; set; }
        [FindsBy(How=How.XPath,Using = "//div[@class='right-block']/h5/a")][CacheLookup]
        private IWebElement BlouseName { get; set; }

        #endregion

    }
}
