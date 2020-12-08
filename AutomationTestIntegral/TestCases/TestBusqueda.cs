using NUnit.Framework;
using OpenQA.Selenium;
using AutomationTestIntegral.Pages.Methods;
using AutomationTestIntegral.Tools;

namespace AutomationTestIntegral.TestCases
{
    public class TestBusqueda
    {
        IWebDriver driver;
        GoogleSearch googleSearch;
        GoogleResult googleResult;
        string testName;

        [SetUp]
        public void Setup()
        {
            driver = Initializer.Initialize_WebDriver(1, "https://www.google.com/");
            googleSearch = new GoogleSearch(driver);
            googleResult = new GoogleResult(driver);
        }
        [Test]
        public void NormalSearch()
        {
            string searchValue = "Disney World";
            Assert.IsTrue(googleSearch.Search(searchValue,false));
            testName = "NormalSearch";
            Helper.Wait(driver, "Exists", Helper.GenerateLocatorElement("Partial", "Walt Disney World Resort in Orlando, Florida"));
        }
        [Test]
        public void LuckySearch()
        {
            string searchValue = "Disney World";
            Assert.IsTrue(googleSearch.Search(searchValue, true));
            testName = "LuckySearch";
            Helper.Wait(driver, 10);
        }
        [Test]
        public void PressEnterSearch()
        {
            string searchValue = "Disney World";
            Assert.IsTrue(googleSearch.Search(searchValue));
            testName = "PressEnterSearch";
            Helper.Wait(driver, Helper.GenerateLocatorElement("Partial", "Walt Disney World Resort in Orlando, Florida"));
        }
        [Test]
        public void SelectOneResult()
        {
            string result = "Walt Disney World en Florida - Vacaciones en familia";
            string searchValue = "Disney World";
            googleSearch.Search(searchValue);
            Assert.IsTrue(googleResult.SelectResult(result));
            testName = "SelectOneResult";
            Helper.Wait(driver, Helper.GenerateLocatorElement("Id", "findPricesButton"));
        }

        [TearDown]
        public void TearDown()
        {
            Helper.TakeScreenshot(driver, testName);
            driver.Close();
        }
    }
}
