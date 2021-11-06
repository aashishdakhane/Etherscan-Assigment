using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Newtonsoft.Json;
using OpenQA.Selenium.Edge;
using Etherscan_Assigment.JSONObjects;
using System.IO;
using System.Diagnostics;

namespace Etherscan_Assigment.Common
{
    public class Utility
    {
        #region "Properties"
        public static IWebDriver Driver { get; set; }
        private static string Browser { get; set; }
        #endregion
        #region "Common Methods"
        /// <summary>
        /// This method initialized the webdriver. 
        /// </summary>
        public static void SetUp()
        {
            try
            {
              

                Browser =Dataobjects.AppConfig.TestBrowserName.ToLower();
                KillDriverProcess(Browser);
                
                string path = Directory.GetCurrentDirectory() + @"\DriverExecutables\";
              

                switch (Dataobjects.AppConfig.TestBrowserName.ToLower())
                {
                    case "chrome":


                        ChromeOptions ObjOption = new ChromeOptions
                        {
                            
                            PageLoadStrategy = PageLoadStrategy.Normal
                        };

                        Driver = new ChromeDriver(path, ObjOption);
                        Driver.Manage().Window.Maximize();
                        Driver.Navigate().GoToUrl(Dataobjects.AppConfig.TestUrl);
                        Loggers.logger.Info("Open Chrome Browser");

                        break;
                    case "edgechromium":
                        EdgeOptions edgeOptions = new EdgeOptions
                        {
                            PageLoadStrategy = PageLoadStrategy.Normal
                           

                        };
                        Driver = new EdgeDriver(path, edgeOptions);
                        Driver.Manage().Window.Maximize();
                        Driver.Navigate().GoToUrl(Dataobjects.AppConfig.TestUrl);
                        Loggers.logger.Info("Open Edge Chromim Browser");

                        break;
                    case "firefox":
                        FirefoxOptions firefoxOptions = new FirefoxOptions
                        {
                            PageLoadStrategy = PageLoadStrategy.Normal,
                            
                        };
                        Driver = new FirefoxDriver(path, firefoxOptions);
                        Driver.Manage().Window.Maximize();
                        Driver.Navigate().GoToUrl(Dataobjects.AppConfig.TestUrl);
                        Loggers.logger.Info("Open Fire fox  Browser");
                        break;


                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Loggers.logger.Info(ex.ToString());
            }

        }

        /// <summary>
        /// This method is used to close driver and kill the executable process in task manager
        /// </summary>
        public static  void TearDown()
        {
            
            try 
            {
                Utility.Driver.Quit();
            } 
            catch (Exception ex)
            { Console.WriteLine(ex.ToString()); } 
            finally
            {
                KillDriverProcess(Browser);
               
               

            }
        }
        public static void executeScript(string Script)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            executor.ExecuteScript(Script);
        }
        #endregion
        public Boolean IsElementIsPresent(By Element)
        {
            try
            {
             Driver.FindElement(Element);
                return true;
            }
            catch (Exception Ex)
            {
                
                return false;
            }
        }

        public static void KillDriverProcess(string browser)
        {
            string processname = "";
            switch (Browser)
            {
                case "chrome":
                    processname = "chromedriver.exe";
                    break;
                case "edgechromium":
                    processname = "msedgedriver.exe";
                    break;
                case "firefox":
                    processname = "geckodriver.exe";
                    break;
            }
            if (processname != String.Empty)
            {
                foreach (var process in Process.GetProcessesByName(processname))
                {
                    process.Kill();
                }
            }

        }
    }
}
