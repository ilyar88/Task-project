using Conftest;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Workflows;
using System;

namespace SeleniumTests
{
    public class testWeb : BaseTest
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
            webFlows.SkipAds();
        }

        [Test, Order(3)]
        public void FindArtistName()
        {
            webFlows.FindArtistNameFlow();
        }
    }
}
