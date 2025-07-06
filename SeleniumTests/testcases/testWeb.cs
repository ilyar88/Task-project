using Conftest;
using NUnit.Framework;
using OpenQA.Selenium;
using Conftest;
using Workflows;
using System;

namespace SeleniumTests
{
    public class TestWeb : BaseTest
    {
        private WebFlows webFlows;

        [SetUp]
        public void SetUpTest()
        {
            webFlows = new WebFlows(driver);
        }

        [Test, Order(1)]
        public void SearchForSong()
        {
            webFlows.SearchFlow();
        }

        [Test, Order(2)]
        public void FindAndPlaySpecificVideo()
        {
            webFlows.FindVideoFlow("ybXrrTX3LuI");
            try
            {
                webFlows.SkipAds();
            }
            catch (NoSuchElementException)
            {
                TestContext.WriteLine("Skip Ad element not found.");
            }
        }

        [Test, Order(3)]
        public void FindArtistName()
        {
            webFlows.FindArtistNameFlow();
        }
    }
}
