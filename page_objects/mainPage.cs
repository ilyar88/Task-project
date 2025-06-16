using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PageObjects
{
    public class MainPage
    {
        private IWebDriver _driver;

        public MainPage(IWebDriver driver)
        {
            _driver = driver;
        }
        // Elements
        public IWebElement search_text()
        {
            return _driver.FindElement(By.CssSelector("input[role='combobox']"));
        }
        public IWebElement search_icon()
        {
            return _driver.FindElement(By.CssSelector("yt-searchbox[role='search'] > button[title='Search']"));
        }

        public IWebElement filters()
        {
            return _driver.FindElement(By.CssSelector("#filter-button .yt-spec-touch-feedback-shape__fill"));
        }

        public IWebElement video()
        {
            return _driver.FindElement(By.CssSelector("[title='Search for Video'] yt-formatted-string"));
        }

        public IWebElement view_count()
        {
            return _driver.FindElement(By.CssSelector("[title='Sort by view count'] yt-formatted-string"));
        }

        public IReadOnlyCollection<IWebElement> video_cards()
        {
            return _driver.FindElements(By.CssSelector("ytd-video-renderer"));
        } 

        public IWebElement skip_ads()
        {
            return _driver.FindElement(By.Id("skip-button:2"));
        } 

        public IWebElement more()
        {
            return _driver.FindElement(By.Id("expand"));
        }

        public IWebElement artist_name()
        {
            return _driver.FindElement(By.CssSelector("#description-inner .yt-video-attribute-view-model__subtitle span"));
        }
    }
}
