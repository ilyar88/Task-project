using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using System.Xml.Linq;
using System.Linq;

namespace Conftest
{
    public class BaseTest
    {
        protected static IWebDriver driver { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            driver = InitDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(int.Parse(GetConfig("WaitTime")));
            driver.Navigate().GoToUrl(GetConfig("Url"));
        }

        public IWebDriver InitDriver()
        {
            string browser = GetConfig("Browser").ToLower();

            switch (browser)
            {
                case "chrome":
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    return new ChromeDriver();

                case "firefox":
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    return new FirefoxDriver();

                case "edge":
                    new DriverManager().SetUpDriver(new EdgeConfig());
                    return new EdgeDriver();

                default:
                    throw new ArgumentException($"Unsupported browser: {browser}");
            }
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            System.Threading.Thread.Sleep(2000);
            driver?.Quit();
            driver?.Dispose();
        }

        protected string GetConfig(string key)
        {
            var path = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../..", "configuration", "data.xml"));

            if (!File.Exists(path))
                throw new FileNotFoundException($"Configuration file not found at path: {path}");

                var doc = XElement.Load(path);
                var value = doc.Element(key)?.Value;

            return value;
        }
    }
}

