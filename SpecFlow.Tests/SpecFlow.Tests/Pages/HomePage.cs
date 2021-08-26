using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace SpecFlow.Tests.Pages
{
    public class HomePage
    {
        private IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        #region LOCATORS 

        [FindsBy(How = How.XPath, Using = "//input[@id='search_query_top']")]
        
        private IWebElement SearchField { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@id='searchbox']/button")]
       
        private IWebElement SearchButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='header_logo']/a")]
        [CacheLookup]
        private IWebElement LogoHomeLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='shopping_cart']/a")]
        [CacheLookup]
        private IWebElement ShoppingCartLink { get; set; }


        #endregion


        public HomePage HomePageSearch(string word) // The function send the  word into searchfield and clicks on the "Search" icon.
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='search_query_top']")));
           // SearchField.Clear();
            SearchField.SendKeys(word);
            SearchButton.Click();
            return this;
        }
        
    }
}
