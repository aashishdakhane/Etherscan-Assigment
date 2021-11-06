using OpenQA.Selenium;
using Etherscan_Assigment.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Etherscan_Assigment.Pages
{
    public class  PageNewRegistration:Common.CommonActions
    {
        public   By Captcha = By.Id("recaptcha-anchor");
        public By ChkTermsandCondition = By.Id("ContentPlaceHolder1_MyCheckBox");
        public By ChkSubcription = By.Id("ContentPlaceHolder1_SubscribeNewsletter");
        public By btnCreateAccount = By.Id("ContentPlaceHolder1_btnRegister");
        public By lblUserNameValidation = By.Id("ContentPlaceHolder1_txtUserName-error");
        public By lblEmailValidation = By.Id("ContentPlaceHolder1_txtEmail-error");
        public By lblPasswordValidation = By.Id("ContentPlaceHolder1_txtPassword-error");
        public By lblConfirmPasswordValidation = By.Id("ContentPlaceHolder1_txtPassword2-error");
        public By txtUserName = By.Id("ContentPlaceHolder1_txtUserName");
        public By txtEmail = By.Id("ContentPlaceHolder1_txtEmail");
        public By txtPassword = By.Id("ContentPlaceHolder1_txtPassword");
        public By txtConfirmPassword = By.Id("ContentPlaceHolder1_txtPassword2");
        public By frmRegistrationSuccess = By.Id("ctl00");
        public By lblTermsValidation = By.Id("ctl00$ContentPlaceHolder1$MyCheckBox-error");
        public By lblSuccessAlert = By.CssSelector("#ctl00 > div.alert.alert-success");

        public void CreateNewRegistration(string name, string email, string password, string confirm, string expected, string TestNo,string Terms,string UnsubscribeTerm)
        {
            

            SendText(txtUserName, name);
            SendText(txtEmail, email);
            SendText(txtPassword, password);
            SendText(txtConfirmPassword, confirm);
            if(Terms=="true")
            {
                Click(ChkTermsandCondition);
            }
            if (UnsubscribeTerm == "true")
            { 
               
                Click(ChkSubcription);
            }
                
            Utility.executeScript("scrollTo(500,500);");
            Click(btnCreateAccount);

            switch (TestNo)
            {
                case "1":
                    Assert.AreEqual(getElement(lblConfirmPasswordValidation).Text, expected);
                    break;
                case "2":
                    Assert.AreEqual(getElement(lblConfirmPasswordValidation).Text, expected);
                    Assert.AreEqual(getElement(lblPasswordValidation).Text, expected);
                    break;
                case "3":
                    Assert.AreEqual(getElement(lblEmailValidation).Text, expected);

                    break;
                case "4":
                    Assert.AreEqual(getElement(lblUserNameValidation).Text, expected);

                    break;
                case "5":
                   

                    Assert.AreEqual(getElement(lblTermsValidation).Text, expected);

                    break;
                case "6":
                    Assert.AreEqual(getElement(lblTermsValidation).Text, expected);

                    break;


            }
            //  ClickCaptcha("recaptcha-anchor");
            System.Threading.Thread.Sleep(3000);
        }
        public void CreateNewRegistration()
        {


            SendText(txtUserName, Dataobjects.RTestData.TestData[5].UserName);
            SendText(txtEmail, Dataobjects.RTestData.TestData[5].Email);
            SendText(txtPassword, Dataobjects.RTestData.TestData[5].Password);
            SendText(txtConfirmPassword, Dataobjects.RTestData.TestData[5].ConfirmPassword);
            Click(ChkTermsandCondition);
            
           
                Click(ChkSubcription);
            

            Utility.executeScript("scrollTo(500,500);");
            Click(btnCreateAccount);

            
            //  ClickCaptcha("recaptcha-anchor");
            System.Threading.Thread.Sleep(3000);
        }
    }
}
