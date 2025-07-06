using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Allure.Net.Commons;
using Allure.NUnit.Attributes;

namespace WebActions
{
    public static class UiActions
    {
        public static void Click(IWebElement elem, IWebDriver driver = null)
        {
            if (driver != null)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.Until(ExpectedConditions.ElementToBeClickable(elem));
            }
             elem.Click();
        }

        public static void EnterText(IWebElement elem, string value)
        {
            elem.Clear();
            elem.SendKeys(value);
        }
    }
}
