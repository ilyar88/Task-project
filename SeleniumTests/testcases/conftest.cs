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

        // Method that runs once before all tests in the test class
        [OneTimeSetUp]
        public void Setup()
        {
            // Initialize the browser driver
            driver = InitDriver();

            // Maximize the browser window
            driver.Manage().Window.Maximize();

            // Set implicit wait timeout using value from configuration
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(int.Parse(GetConfig("WaitTime")));

            // Navigate to the URL defined in configuration
            driver.Navigate().GoToUrl(GetConfig("Url"));
        }

        // Method to initialize the appropriate browser driver based on config
        public IWebDriver InitDriver()
        {
            // Get the browser name from XML config and convert it to lowercase
            string browser = GetConfig("Browser").ToLower();

            // Choose the driver setup based on the browser name
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
                    // Throw an exception if the browser is not supported
                    throw new ArgumentException($"Unsupported browser: {browser}");
            }
        }

        // Method that runs once after all tests in the test class
        [OneTimeTearDown]
        public void Cleanup()
        {
            // Wait for 2 seconds before closing the browser
            System.Threading.Thread.Sleep(2000);

            // Quit and dispose the WebDriver instance
            driver?.Quit();
            driver?.Dispose();
        }

        // Helper method to read configuration values from XML
        protected string GetConfig(string key)
        {
            // Construct full path to the XML configuration file
            var path = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../..", "configuration", "data.xml"));

            // Check if the file exists
            if (!File.Exists(path))
                throw new FileNotFoundException($"Configuration file not found at path: {path}");

            // Load the XML document and retrieve the value for the given key
            var doc = XElement.Load(path);
            var value = doc.Element(key)?.Value;

            return value;
        }
    }
}
