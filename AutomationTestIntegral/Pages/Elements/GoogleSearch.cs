using OpenQA.Selenium;

namespace AutomationTestIntegral.Pages.Elements
{
    class GoogleSearch
    {
        public readonly By searchBar = By.Name("q");
        public readonly By searchButton = By.Name("btnK");
        public readonly By luckyButton = By.Name("btnI");
        public readonly By moreOptionLink = By.XPath("/html/body/div[1]/div[1]/div/div/div/div[2]/div[1]/div/div/a/svg");
        public readonly By googleDriveIcon = By.ClassName("MrEfLc");
    }
}
