using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using Etherscan_Assigment.Common;
using Etherscan_Assigment.JSONObjects;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using Etherscan_Assigment.Pages;

namespace Etherscan_Assigment
{
    [TestClass]
    public class EdgeDriverTest : CommonActions
    {
        // In order to run the below test(s), 
        // please follow the instructions from http://go.microsoft.com/fwlink/?LinkId=619687
        // to install Microsoft WebDriver.

        private EdgeDriver _driver;
        
     

        public static IEnumerable<object[]> Data
        {
            get
            {
                SDataTable test = new SDataTable();

                test = JsonConvert.DeserializeObject<SDataTable>(File.ReadAllText(Directory.GetCurrentDirectory() + @"\TestData\TestData1.json"));
                //for (int i = 0; i <= 3; i++)
                //{
                //    yield return new object[] { test.TestData[i].UserName, test.TestData[i].Email, test.TestData[i].Password, test.TestData[i].ConfirmPassword, test.TestData[i].ExpectedValidationMessage };

                //}
                yield return new object[] { test.TestData[0].UserName, test.TestData[0].Email, test.TestData[0].Password, test.TestData[0].ConfirmPassword, test.TestData[0].ExpectedValidationMessage, test.TestData[0].TestNo };
                yield return new object[] { test.TestData[1].UserName, test.TestData[1].Email, test.TestData[1].Password, test.TestData[1].ConfirmPassword, test.TestData[1].ExpectedValidationMessage, test.TestData[1].TestNo };
                yield return new object[] { test.TestData[2].UserName, test.TestData[2].Email, test.TestData[2].Password, test.TestData[2].ConfirmPassword, test.TestData[2].ExpectedValidationMessage, test.TestData[2].TestNo };
                yield return new object[] { test.TestData[3].UserName, test.TestData[3].Email, test.TestData[3].Password, test.TestData[3].ConfirmPassword, test.TestData[3].ExpectedValidationMessage, test.TestData[3].TestNo };
            }
        }


        [TestInitialize]
        public void EdgeDriverInitialize()
        {

            Utility.SetUp();
           

          

            // Initialize edge driver 

        }

        [DataTestMethod]
        [DynamicData(nameof(Data), DynamicDataSourceType.Property)]
        
        public void VerifyPageValidations(string name,string email,string password,string confirm,string expected,string TestNo)
        {
            PageNewRegistration oPage = new PageNewRegistration();
           
            SendText(oPage.txtUserName, name) ;
            SendText(oPage.txtEmail, email);
            SendText(oPage.txtPassword, password);
            SendText(oPage.txtConfirmPassword, confirm);
            Click(oPage.ChkSubcription);
            Click(oPage.ChkTermsandCondition);
            Utility.executeScript("scrollTo(500,500);");
            Click(oPage.btnCreateAccount);

            switch (TestNo)
            {
                case "1":
                    Assert.AreEqual(getElement(oPage.lblConfirmPasswordValidation).Text, expected);
                    break;
                case "2":
                    Assert.AreEqual(getElement(oPage.lblConfirmPasswordValidation).Text, expected);
                    Assert.AreEqual(getElement(oPage.lblPasswordValidation).Text, expected);
                    break;
                case "3":
                    Assert.AreEqual(getElement(oPage.lblEmailValidation).Text, expected);
                   
                    break;
                case "4":
                    Assert.AreEqual(getElement(oPage.lblUserNameValidation).Text, expected);

                    break;


            }
            //  ClickCaptcha("recaptcha-anchor");
            System.Threading.Thread.Sleep(3000);
        }

        [TestCleanup]
        public void EdgeDriverCleanup()
        {
            Utility.TearDown();
        }
        



            

                 

    }
}
