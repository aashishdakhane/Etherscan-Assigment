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
    public class EdgeDriverTest : PageNewRegistration
    {
        // In order to run the below test(s), 
        // please follow the instructions from http://go.microsoft.com/fwlink/?LinkId=619687
        // to install Microsoft WebDriver.

        private EdgeDriver _driver;


        public static IEnumerable<object[]> Data
        {
            get
            {
                
                for (int i = 0; i < Dataobjects.RTestData.TestData.Count; i++)
                {


                    yield return new object[] { 
                        Dataobjects.RTestData.TestData[i].UserName, 
                        Dataobjects.RTestData.TestData[i].Email,
                        Dataobjects.RTestData.TestData[i].Password, 
                        Dataobjects.RTestData.TestData[i].ConfirmPassword,
                        Dataobjects.RTestData.TestData[i].ExpectedValidationMessage, 
                        Dataobjects.RTestData.TestData[i].TestNo,
                        Dataobjects.RTestData.TestData[i].Terms.ToLower(),
                        Dataobjects.RTestData.TestData[i].Unsbscribe.ToLower() };

                }

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
        [TestCategory("Regression"), TestCategory("New Registration"), Description("To verify Mandatory validations are working")]
        public void VerifyPageValidations(string name,string email,string password,string confirm,string expected,string TestNo,string Terms,string Unsubscribe)
        {
            Utility utility = new Utility();
            CreateNewRegistration(name, email, password, confirm, expected, TestNo, Terms, Unsubscribe);
            Assert.AreNotSame(utility.IsElementIsPresent(lblSuccessAlert),true);
            
            System.Threading.Thread.Sleep(3000);
        }

        [TestMethod]
        [TestCategory("Regression"), TestCategory("Smoke Test"), TestCategory("New Registration"), Description("To verify user can create account")]
        public void VerifyCreateAccount()
        {
            Utility utility = new Utility();
            CreateNewRegistration();
            Assert.AreEqual(utility.IsElementIsPresent(lblSuccessAlert), true);
            Assert.AreEqual(getElement(lblSuccessAlert).Text, Dataobjects.RSussessAlert.AlertSummary);

            System.Threading.Thread.Sleep(3000);
        }

        [TestCleanup]
        public void EdgeDriverCleanup()
        {
            Utility.TearDown();
        }
        



            

                 

    }
}
