using System;
using System.Collections.Generic;
using System.Text;

namespace Etherscan_Assigment.JSONObjects
{
    public class TestData
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string ExpectedValidationMessage { get; set; }
        public string TestNo { get; set; }
    }
    public class SDataTable
    {
        public List<TestData> TestData { get; set; }
    }
}
