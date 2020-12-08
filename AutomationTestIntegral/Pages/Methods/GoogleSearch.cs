using OpenQA.Selenium;
using AutomationTestIntegral.Pages.Elements;

namespace AutomationTestIntegral.Pages.Methods
{
    class GoogleSearch
    {
        private IWebDriver _driver;
        private string _searchValue;
        private Elements.GoogleSearch google = new Elements.GoogleSearch();

        public GoogleSearch(IWebDriver driver) => _driver = driver;
        private void EnterSearchValue() => _driver.FindElement(google.searchBar).SendKeys(_searchValue);
        private void ClickSearchButton() => _driver.FindElement(google.searchButton).Click();
        private void PressEnterKey() => _driver.FindElement(google.searchButton).SendKeys(Keys.Enter);
        private void ClickLuckyButton() => _driver.FindElement(google.luckyButton).Click();
        private void ClickMoreOption() => _driver.FindElement(google.moreOptionLink).Click();
        private void ClickDriveIcon() => _driver.FindElement(google.googleDriveIcon).Click();
        private bool NormalSearch()
        {
            try
            {
                EnterSearchValue();
                ClickSearchButton();
                return true;
            }
            catch { return false; }
        }
        private bool LuckySearch()
        {
            try
            {
                EnterSearchValue();
                ClickLuckyButton();
                return true;
            } catch { return false; }
        }
        private bool PressEnterSearch()
        {
            try
            {
                EnterSearchValue();
                PressEnterKey();
                return true;
            }
            catch { return false; }
        }
        public bool Search(string searchValue, bool lucky)
        {
            _searchValue = searchValue;
            if (lucky != true) return NormalSearch();
            else return LuckySearch();
        }
        public bool Search(string searchValue)
        {
            _searchValue = searchValue;
            return PressEnterSearch();
        }
    }
}
