using Etherscan_Assigment.JSONObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Etherscan_Assigment.Common
{
    public static class Dataobjects
    {


        public static SDataTable RTestData
        {
            get
            {
               

              return   JsonConvert.DeserializeObject<SDataTable>(File.ReadAllText(Directory.GetCurrentDirectory() + @"\TestData\TestData1.json"));
            }
        }
        public static RegistrationSuccessAlert RSussessAlert
        {
            get
            {
               

                return  JsonConvert.DeserializeObject<RegistrationSuccessAlert>(File.ReadAllText(Directory.GetCurrentDirectory() + @"\TestData\RegistrationSuccessAlert.json"));
            }
        }

        public static TestSetup AppConfig
        {
            get { return JsonConvert.DeserializeObject<TestSetup>(File.ReadAllText(Directory.GetCurrentDirectory() + @"\TestData\AppConfig.json")); }
        }

    }
}
