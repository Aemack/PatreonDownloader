using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatreonDownloader
{
    public class DriverSettings
    {

        public static IWebDriver driver = new ChromeDriver();
        public static string emailAddress = "adamjmcgrane@gmail.com";
        public static string password = "Scalped12";


        public DriverSettings()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }

    }
}
