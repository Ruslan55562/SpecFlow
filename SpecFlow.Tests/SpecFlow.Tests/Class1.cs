using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlow.Tests.Pages;
using System;
using System.Collections.Generic;
using System.Text;


namespace SpecFlow.Tests
{
    //class Test
    //{
    //    protected IWebDriver _webDriver;
    //    SearchResultsPage page;

    //    [OneTimeSetUp]
    //    protected void Setup()
    //    {
    //        _webDriver = new ChromeDriver();
    //        _webDriver.Manage().Window.Maximize();
    //        _webDriver.Navigate().GoToUrl(@"http://automationpractice.com/index.php?controller=search&search_query=summer&submit_search=&orderby=price&orderway=desc");
    //        page = new SearchResultsPage(_webDriver);

    //    }

    //    [Test]
    //    public void Test1()
    //    {
    //        Assert.IsTrue(page.IsCorrectPricesSort(),"Is not true");
    //    }

    //    [Test]

    //    public void Test2()
    //    {
    //        Assert.AreEqual("\"SUMMER\"", page.IsSearchRequestHere(), "There is not such message");
    //    }


    //    [OneTimeTearDown]
    //    protected void TearDown()
    //    {
    //        if (_webDriver != null)
    //            _webDriver.Quit();
    //    }
    
}
