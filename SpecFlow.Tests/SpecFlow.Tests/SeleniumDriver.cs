using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
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

        public IWebDriver Setup(string BrowserName) // посмотреть как реализовывать в желтом видео.
        {
            if (BrowserName == "chrome")
                _webDriver = new ChromeDriver();
            if (BrowserName == "edge")
            {
                EdgeOptions op = new EdgeOptions();
                _webDriver = new EdgeDriver(EdgeDriverService.CreateDefaultService(@"C:\Users\kleimonov.r\.nuget\packages\selenium.webdriver.msedgedriver\92.0.902.73\driver\win64", "msedgedriver.exe"), op);
            }

            if (BrowserName == "firefox")
            {
                FirefoxDriverService geckoService = FirefoxDriverService.CreateDefaultService(@"C:\Users\\kleimonov.r\.nuget\\packages\selenium.firefox.webdriver\0.27.0\\driver");
                geckoService.Host = "::1";
                var firefoxOptions = new FirefoxOptions();
                _webDriver = new FirefoxDriver(geckoService , firefoxOptions);
            }

            _webDriver.Manage().Window.Maximize();
            scenarioContext.Set(_webDriver, "WebDriver");
           
            return _webDriver;
        }

        public IWebDriver TearDown()
        {
            if (_webDriver != null)
                _webDriver.Quit();

            return _webDriver;
        }


    }
}