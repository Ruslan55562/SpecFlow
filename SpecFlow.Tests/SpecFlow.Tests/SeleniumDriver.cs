using OpenQA.Selenium;
using SpecFlow.Tests.Pages;
using SpecFlow.Tests.Steps;


namespace SpecFlow.Drivers
{
   
    public class SeleniumDriver
    {
        public IWebDriver _webDriver; 
        public SearchResultsPage page;

        private readonly CompareGoodsPricesSteps _CompareProducts;

        public SeleniumDriver(CompareGoodsPricesSteps CompareProducts) => this._CompareProducts = CompareProducts;

        public IWebDriver Setup() // посмотреть как реализовывать в желтом видео.
        {

        }

    }
}