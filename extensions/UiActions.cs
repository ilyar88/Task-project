using OpenQA.Selenium;

namespace WebActions
{
    public static class UiActions
    {
        public static void Click(IWebElement elem)
        {
            elem.Click();
        }

        public static void EnterText(IWebElement elem, string value)
        {
            elem.Clear();
            elem.SendKeys(value);
        }
    }
}
