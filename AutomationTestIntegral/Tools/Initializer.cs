using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium;

namespace AutomationTestIntegral.Tools
{
    static class Initializer
    {
        private static IWebDriver _driver;
        private static string path = "D:\\Automation\\AutomationTestIntegral\\AutomationTestIntegral\\Drivers";
        public static IWebDriver Initialize_WebDriver(int browser, string url)
        {
            if (browser == 1)
            {
                _driver = new FirefoxDriver(path);
                StarterDriver(url);
                return _driver;
            }

            if (browser == 2)
            {
                _driver = new ChromeDriver(path);
                StarterDriver(url);
                return _driver;
            }

            if (browser == 3)
            {
                _driver = new EdgeDriver(path);
                StarterDriver(url);
                return _driver;
            }

            if (browser == 4)
            {
                _driver = new SafariDriver(path);
                StarterDriver(url);
                return _driver;
            }
            else
            {
                return _driver;
            }
        }
        private static void StarterDriver(string url)
        {
            _driver.Url = url;
            _driver.Manage().Window.Maximize();
        }
    }
}
