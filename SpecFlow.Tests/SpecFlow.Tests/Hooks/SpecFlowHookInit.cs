using OpenQA.Selenium;
using SpecFlow.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlow.Tests.Hooks
{
    [Binding]
    public sealed class SpecFlowHookInit
    {

        private readonly ScenarioContext _ScenarioContext;
        public SpecFlowHookInit(ScenarioContext scenario) => _ScenarioContext = scenario;
        [BeforeScenario]
        public void BeforeScenario()
        {
            SeleniumDriver seleniumDriver = new SeleniumDriver(_ScenarioContext);
            _ScenarioContext.Set(seleniumDriver, "SeleniumDriver");

        }

        [AfterScenario]
        public void AfterScenario()
        {
            _ScenarioContext.Get<IWebDriver>("WebDriver").Quit();
        }
    }
}
