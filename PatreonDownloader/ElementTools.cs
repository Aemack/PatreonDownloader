using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatreonDownloader
{
    public class ElementTools
    {
        public static void WaitForElementVisibile(By locator)
        {
            WebDriverWait wait = new WebDriverWait(DriverSettings.driver, TimeSpan.FromSeconds(10));
            IWebElement el = wait.Until(ExpectedConditions.ElementExists(locator));
        }

        public static void Wait(int secs)
        {
            DriverSettings.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(secs);

        }

        public static void MoveTo(IWebElement element)
        {
            Actions actions = new Actions(DriverSettings.driver);
            actions.MoveToElement(element);
            actions.Perform();
        }

        public static void ClickElement(IWebElement element)
        {
            MoveTo(element);
            element.Click();
        }
    }
}
