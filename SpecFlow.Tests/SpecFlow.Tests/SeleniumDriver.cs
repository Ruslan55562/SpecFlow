using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlow.Tests.Pages;
using SpecFlow.Tests.Steps;
using TechTalk.SpecFlow;

namespace SpecFlow.Drivers
{
   
    public class SeleniumDriver
    {
        public IWebDriver _webDriver; 
        
        private ScenarioContext scenarioContext;
        private readonly CompareGoodsPricesAndNamesSteps _CompareProducts;

        public SeleniumDriver(CompareGoodsPricesAndNamesSteps CompareProducts) => _CompareProducts = CompareProducts;

        public SeleniumDriver(ScenarioContext scenarioContext) => this.scenarioContext = scenarioContext;

        public IWebDriver Setup() // посмотреть как реализовывать в желтом видео.
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Window.Maximize();
            scenarioContext.Set(_webDriver, "WebDriver");
           
            return _webDriver;
        }

    }
}