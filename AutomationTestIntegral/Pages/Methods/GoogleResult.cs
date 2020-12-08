using OpenQA.Selenium;
using AutomationTestIntegral.Pages.Elements;
using AutomationTestIntegral.Tools;

namespace AutomationTestIntegral.Pages.Methods
{
    class GoogleResult
    {
        private IWebDriver _driver;
        private string _searchValue;
        private Elements.GoogleResult google = new Elements.GoogleResult();

        public GoogleResult(IWebDriver driver) => _driver = driver;
        private void EnterSearchValue() => _driver.FindElement(google.searchBar).SendKeys(_searchValue);
        private void PressEnterKey() => _driver.FindElement(google.searchBar).SendKeys(Keys.Enter);
        //private void ClickResult() => _driver.FindElement(google.result).Click();
        private void ClickResult()
        {
            IWebElement element = _driver.FindElement(google.result);
            element.Click();
        }
        public bool NewSearch(string searchValue)
        {
            _searchValue = searchValue;
            try
            {
                EnterSearchValue();
                PressEnterKey();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SelectResult(string result)
        {
            try
            {
                google.result = Helper.GenerateLocatorElement(null, "/html/body/div[7]/div[2]/div[10]/div[1]/div[2]/div/div[2]/div[2]/div/div/div[1]/div/div[1]/a/h3/span");
                ClickResult();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}