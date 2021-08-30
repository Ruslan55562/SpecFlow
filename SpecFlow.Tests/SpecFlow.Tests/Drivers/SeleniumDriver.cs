using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using SpecFlow.Tests.Pages;
using SpecFlow.Tests.Steps;
using TechTalk.SpecFlow;
using Microsoft.Edge.SeleniumTools;



namespace SpecFlow.Drivers
{
    
    public class SeleniumDriver
    {
       
        public IWebDriver _webDriver;

        private ScenarioContext scenarioContext;
        private readonly CompareGoodsPricesAndNamesSteps _CompareProducts;

        public SeleniumDriver(CompareGoodsPricesAndNamesSteps CompareProducts) => _CompareProducts = CompareProducts;

        public SeleniumDriver(ScenarioContext scenarioContext) => this.scenarioContext = scenarioContext;
     

        public IWebDriver Setup(string BrowserName) // The function takes 1 string param(name of browser) and returns the WebDriver with a specific behaviour.
        {
      
            switch (BrowserName)
            {
                case "chrome":
                _webDriver = new ChromeDriver();
                    break;
                case "edge":
                    var edgeDriverService = Microsoft.Edge.SeleniumTools.EdgeDriverService.CreateChromiumService();
                    var edgeOptions = new Microsoft.Edge.SeleniumTools.EdgeOptions();
                    edgeOptions.UseChromium = true;
                   _webDriver = new Microsoft.Edge.SeleniumTools.EdgeDriver(edgeDriverService, edgeOptions);
                    break;
                case "firefox":
                    FirefoxDriverService geckoService = FirefoxDriverService.CreateDefaultService();
                    geckoService.Host = "::1";
                    _webDriver = new FirefoxDriver(geckoService, new FirefoxOptions());
                    break;
                default:
                    break;
            }

            _webDriver.Manage().Window.Maximize();
             scenarioContext.Set(_webDriver, "WebDriver");

            return _webDriver;
        }

    }
}