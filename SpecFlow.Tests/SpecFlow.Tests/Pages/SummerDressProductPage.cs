using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlow.Tests.Pages
{
    class SummerDressProductPage
    {
        private IWebDriver driver;
        public SummerDressProductPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        #region LOCATORS
        [FindsBy(How = How.XPath, Using = "//input[@id='quantity_wanted']")] [CacheLookup]
        private IWebElement DressQuntity { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@id='group_1']/option[2]")] [CacheLookup]
        private IWebElement DressSize { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@id='color_13']")] [CacheLookup]
        private IWebElement DressColor { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='exclusive']")] [CacheLookup]
        private IWebElement AddToCartButtonDressPage { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='clearfix']/div[1]/h2")] [CacheLookup]
        private IWebElement SuccessfulAddInscription { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[@title='Proceed to checkout']")] [CacheLookup]
        private IWebElement ProceedToCheckoutButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='center_column']/ul/li[1]/div/div[2]/h5/a")] [CacheLookup]
        private IWebElement DressName { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul/li[1]/div/div[2][@class='right-block']/div[1]/span[1]")] [CacheLookup]
        private IWebElement DressPrice { get; set; }

        #endregion

    
    }
}
