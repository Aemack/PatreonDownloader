using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace PatreonDownloader
{
    class Program
    {
        static IWebElement EmailInput => DriverSettings.driver.FindElement(By.XPath("//*[@aria-label='Email']"));
        static IWebElement PasswordInput => DriverSettings.driver.FindElement(By.XPath("//*[@aria-label='Password']"));
        static IWebElement ContinueButton => DriverSettings.driver.FindElement(By.XPath("//*[text()='Continue']/.././.."));
        static IList<IWebElement> LoadMoreButton => DriverSettings.driver.FindElements(By.XPath("//*[text()='Load more']/../.."));
        static IList<IWebElement> LoadMoreSpinner => DriverSettings.driver.FindElements(By.XPath("//*[@aria-label='loading more posts']"));
        static IList<IWebElement> LoadingSpinner => DriverSettings.driver.FindElements(By.XPath("//*[@aria-label='Loading']"));
        static IList<IWebElement> MembershipLinks => DriverSettings.driver.FindElements(By.XPath("//*[@aria-label='Memberships']/li/a"));

        static IList<IWebElement> MoreActionButtons => DriverSettings.driver.FindElements(By.XPath("//*[@aria-label='More actions']"));
        static IList<IWebElement> DownloadLinks => DriverSettings.driver.FindElements(By.XPath("//a[text()='Download']"));


        static string DownloadPath = @"C:\Users\Adam\Downloads\PatreonSongs";    


        static string website = "https://www.patreon.com/login";
        static DriverSettings ds;

        static void Main(string[] args)
        {
            ds = new DriverSettings();

            DriverSettings.driver.Navigate().GoToUrl(website);

            Login();
            GoToMembershipPage(0);
            DownloadSongs();

            DriverSettings.driver.Close();

            FixFileNames();
        }

        private static void FixFileNames()
        {
            
        }

        private static void GoToMembershipPage(int membershipNo)
        {
            MembershipLinks[membershipNo].Click();
            while (LoadingSpinner.Count > 0)
            {
                Thread.Sleep(1000);
            }
        }

        static void Login()
        {
            EmailInput.SendKeys(DriverSettings.emailAddress);
            ContinueButton.Click();
            PasswordInput.SendKeys(DriverSettings.password);
            ContinueButton.Click();

        }

        static void DownloadSongs()
        {
            while (LoadMoreButton.Count > 0 || LoadMoreSpinner.Count > 0)
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)DriverSettings.driver;

                // Scroll to the bottom of the page
                js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");

                LoadMoreButton[0].Click();
                Thread.Sleep(1000);
            }

            for (int i = 0; i < MoreActionButtons.Count; i++)
            {
                MoreActionButtons[i].Click();
                if (DownloadLinks.Count > 0)
                    DownloadLinks[0].Click();
            }
        }
    }
}
