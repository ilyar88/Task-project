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
        
        public IWebElement search_text()
        {
            return _driver.FindElement(By.CssSelector("input[role='combobox']"));
        }
        public IWebElement search_icon()
        {
            return _driver.FindElement(By.CssSelector("button[title='Search']"));
        }

        public IWebElement filters()
        {
            return _driver.FindElement(By.CssSelector("#filter-button"));
        }

        public IWebElement video()
        {
            return _driver.FindElement(By.CssSelector("[title='Search for Video']"));
        }

        public IWebElement view_count()
        {
            return _driver.FindElement(By.CssSelector("[title='Sort by view count']"));
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
