using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;

namespace AutomationTestIntegral.Tools
{
    class Helper
    {
        static readonly string _filePath = "D:\\Automation\\AutomationTestIntegral\\AutomationTestIntegral\\Screenshots\\";
        static readonly string _dateFormat = "_dd-MM-yyyy_hhmmss";
        readonly static string _fileExtension = ".png";

        public static void TakeScreenshot(IWebDriver driver, string filename)
        {
            ITakesScreenshot _screenshotDriver = driver as OpenQA.Selenium.ITakesScreenshot;
            Screenshot screenshot = _screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile(_filePath + filename + DateTime.Now.ToString(_dateFormat) + _fileExtension);
        }
        public static void Wait(IWebDriver driver, int seconds) => driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        public static void Wait(IWebDriver driver, string condicion, By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            if(condicion == "Exists") wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
            if(condicion == "Visible") wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            if(condicion == "Clickable") wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
            if(condicion == "Selected") wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeSelected(locator));
            if(condicion == "Alert") wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
        }
        public static void Wait(IWebDriver driver, By locator)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.IgnoreExceptionTypes(typeof(NoAlertPresentException));
            fluentWait.Until(x => x.FindElement(locator));
        }
    }
}
