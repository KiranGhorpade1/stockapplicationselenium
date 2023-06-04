using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;

namespace Stock_application
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.nseindia.com/get-quotes/equity?symbol=RELIANCE");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
            driver.Manage().Window.Maximize();
            Console.WriteLine("Visited page");
           var historicElement = driver.FindElement(By.Id("historic_data"));
            historicElement.Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            
            js.ExecuteScript("window.scrollBy(0,100)", "");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            driver.FindElement(By.Id("oneY")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            //Actions action = new Actions(driver);
            IWebElement element = driver.FindElement(By.XPath("//button[@title='None selected']"));
            js.ExecuteScript("arguments[0].click();", element);
            //js.ExecuteScript("arguments[0].click();", element);
            //driver.FindElement(By.XPath("//button[@title='None selected']/b")).Click();
            Thread.Sleep(2);
            //action.ClickAndHold(driver.FindElement(By.XPath("//button[@title='None selected']")))
              //  .Click(driver.FindElement(By.XPath("//input[@value='EQ']"))).Build().Perform();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            var downloadButton = driver.FindElement(By.Id("dwldcsv"));
            downloadButton.Click();
            downloadButton.Click();
        }
    }
}
