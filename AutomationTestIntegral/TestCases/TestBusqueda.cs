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
        string searchValue;
        string testName;

        [SetUp]
        public void Setup()
        {
            driver = Initializer.Initialize_WebDriver(1, "https://www.google.com/");
            googleSearch = new GoogleSearch(driver);
        }

        [Test]
        public void NormalSearch()
        {
            searchValue = "Disney World";
            Assert.IsTrue(googleSearch.Search(searchValue,false));
            testName = "NormalSearch";
            Helper.Wait(driver, "Exists", By.PartialLinkText("Walt Disney World Resort in Orlando, Florida"));
        }
        [Test]
        public void LuckySearch()
        {
            searchValue = "Disney World";
            Assert.IsTrue(googleSearch.Search(searchValue, true));
            testName = "LuckySearch";
            Helper.Wait(driver, 10);
        }
        [Test]
        public void PressEnterSearch()
        {
            searchValue = "Disney World";
            Assert.IsTrue(googleSearch.Search(searchValue));
            testName = "PressEnterSearch";
            Helper.Wait(driver, By.PartialLinkText("Walt Disney World Resort in Orlando, Florida"));
        }

        [TearDown]
        public void TearDown()
        {
            Helper.TakeScreenshot(driver, testName);
            driver.Close();
        }
    }
}
