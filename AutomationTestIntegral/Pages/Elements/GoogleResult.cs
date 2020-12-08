using OpenQA.Selenium;

namespace AutomationTestIntegral.Pages.Elements
{
    class GoogleResult
    {
        public readonly By searchBar = By.Name("q");
        public By result;
    }
}
