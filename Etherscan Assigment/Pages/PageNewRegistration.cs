using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Etherscan_Assigment.Pages
{
   public class  PageNewRegistration
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
    }
}
