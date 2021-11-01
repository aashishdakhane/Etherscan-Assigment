using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NLog;




namespace Etherscan_Assigment.Common
{
    public  class CommonActions 
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// This method Wait and click on element
        /// </summary>
        /// <param name="Element">By</param>
        public  void Click(By Element)
        {
            
            try
            {
                WebDriverWait webDriverWait = new WebDriverWait(Utility.Driver, TimeSpan.FromSeconds(30))
                {
                    PollingInterval=TimeSpan.FromSeconds(3),
                    
                };
                //bool    WebElementStatus=   webDriverWait.Until(driver=> driver.FindElement(Element).Displayed==true);
               // logger.Info("Is Element enabled and displayed : "+WebElementStatus.ToString());
                //if (WebElementStatus == true)
                //{

                    IWebElement Ele = Utility.Driver.FindElement(Element);
                    Actions OAction = new Actions(Utility.Driver);
                    OAction.Click(Ele).Build().Perform();
                    logger.Info("Clicked on Element" + Ele.GetAttribute("Name"));
                 

                //}

               
            }
            catch (Exception Ex) 
            {
                Console.WriteLine(Ex.ToString());
                logger.Error(Ex.ToString(),"Error In Click Action Method");
            }
            

        
          


        }


        public void SendText(By Element,string text)
        {
            try
            {
                WebDriverWait webDriverWait = new WebDriverWait(Utility.Driver, TimeSpan.FromSeconds(5))
                {
                    PollingInterval = TimeSpan.FromSeconds(3),

                };
                bool WebElementStatus = webDriverWait.Until(driver => driver.FindElement(Element).Enabled == true && driver.FindElement(Element).Displayed == true);
                logger.Info("Is Element enabled and displayed : " + WebElementStatus.ToString());
                if (WebElementStatus == true)
                {

                    IWebElement Ele = Utility.Driver.FindElement(Element);
                    Actions OAction = new Actions(Utility.Driver);
                    OAction.Click(Ele).SendKeys(text).Build().Perform();
                    logger.Info("Send Keys : "+ text + " in Element" + Ele.GetAttribute("Name"));


                }


            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
                logger.Error(Ex.ToString(), "Error In Send Keys Action Method");
            }

        }
        public IWebElement getElement(By Element)
        { 
        IWebElement Ele = null;
            try
            {
                WebDriverWait webDriverWait = new WebDriverWait(Utility.Driver, TimeSpan.FromSeconds(5))
                {
                    PollingInterval = TimeSpan.FromSeconds(3),

                };
                //bool WebElementStatus = webDriverWait.Until(driver => driver.FindElement(Element).Displayed == true);
                //logger.Info("Is Element enabled and displayed : " + WebElementStatus.ToString());
                //if (WebElementStatus == true)
                //{

                    Ele = Utility.Driver.FindElement(Element);

                    logger.Info("  Element" + Ele.GetAttribute("Name"));


                //}


            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
                logger.Error(Ex.ToString(), "Get Element No Such element found");
            }
            return Ele;

        }
        public void ClickCaptcha(string ElementName)
        {
            string Script = @"async function SelectCaptch(){";
            Script += @"await document.getElementById('" + ElementName + "').className='recaptcha-checkbox goog-inline-block recaptcha-checkbox-checked rc-anchor-checkbox';";
            Script += @" await document.getElementById('" + ElementName + "')"+".setAttribute('aria-checked','true');";
            Script += @" await document.getElementById('" + ElementName + "')" + ".setAttribute('aria-check','true');";
            Script += @" }; SelectCaptch();";

            System.Threading.Thread.Sleep(10000);
            int i = 0;
            foreach (IWebElement x in Utility.Driver.FindElements(By.TagName("iframe")))
                {
                if (x.GetAttribute("title" ) == "reCAPTCHA")
                {
                    Utility.Driver.SwitchTo().Frame(i);
              
                    break;
                }
                i = i + 1;
            }
            
           IWebElement elem = Utility.Driver.FindElement(By.CssSelector("#recaptcha-anchor"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Utility.Driver;


            executor.ExecuteScript(Script, elem);
        }
    }
}
