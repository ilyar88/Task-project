using Conftest;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using PageObjects;
using WebActions;
using System;

namespace Workflows
{
    public class WebFlows
    {
        private IWebDriver _driver;
        private MainPage mainPage;

        // Constructor initializes the WebDriver and MainPage
        public WebFlows(IWebDriver driver)
        {
            _driver = driver;
            mainPage = new MainPage(driver);
        }

        // Performs a YouTube search with filters and sorting
        public void SearchFlow()
        {
            UiActions.EnterText(mainPage.search_text(), "I Will Survive - Alien song");
            UiActions.Click(mainPage.search_icon());    
            UiActions.Click(mainPage.filters());         
            UiActions.Click(mainPage.video());           
            UiActions.Click(mainPage.filters());         
            UiActions.Click(mainPage.view_count());      
        }

        // Finds a specific video by its ID, prints the channel name, and clicks the video
        public void FindVideoFlow(string targetVideoId)
        {
            var videoCards = mainPage.video_cards(); // Get all video cards from results

            foreach (var card in videoCards)
            {
                try
                {
                    var videoLink = card.FindElement(By.CssSelector("a#video-title"));
                    var href = videoLink.GetAttribute("href");

                    // Check if the video link contains the target video ID
                    if (!string.IsNullOrEmpty(href) && href.Contains($"watch?v={targetVideoId}"))
                    {
                        var channelElement = card.FindElement(By.CssSelector("ytd-channel-name a"));
                        string channelName = channelElement.GetAttribute("title");

                        // Fallback: get inner text if 'title' attribute is empty
                        if (string.IsNullOrEmpty(channelName))
                        {
                            channelName = ((IJavaScriptExecutor)_driver)
                                .ExecuteScript("return arguments[0].innerText;", channelElement)
                                .ToString();
                        }

                        Console.WriteLine($"Found target video: {href}");
                        Console.WriteLine($"user/channel: {channelName}");

                        // Scroll into view and click the video using JavaScript
                        IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
                        js.ExecuteScript("arguments[0].scrollIntoView(true);", videoLink);
                        js.ExecuteScript("arguments[0].click();", videoLink);
                        break; // Stop looping once found
                    }
                }
                catch (NoSuchElementException)
                {
                    continue; // Skip this card if elements are missing
                }
            }
        }

         public void FindArtistNameFlow()
        {
            UiActions.Click(mainPage.more()); 
            string artistName = mainPage.artist_name().Text;
            Console.WriteLine($"The artist name is: {artistName}");
        }

        public void SkipAds()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(mainPage.skip_ads()));
                UiActions.Click(mainPage.skip_ads()); 
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Skip button not found."); 
            }
        }
    }
}
