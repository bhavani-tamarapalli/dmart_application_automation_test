//using OpenQA.Selenium;
//using System.Configuration;

//namespace Amazon_Application_Auto.Utilities
//{
//    public static class ConfigReader
//    {
//        public static string Get(string key)
//        {
//            return ConfigurationManager.AppSettings[key];
//        }


//        public static By GetLocator(string key)
//        {
//            string locator = ConfigurationManager.AppSettings[key];
//            if (locator == null)
//                throw new Exception($"Locator for key '{key}' not found in App.config");

//            string[] parts = locator.Split('=');
//            string strategy = parts[0].Trim();
//            string value = parts[1].Trim();

//            return strategy.ToLower() switch
//            {
//                "id" => By.Id(value),
//                "name" => By.Name(value),
//                "xpath" => By.XPath(value),
//                "css" => By.CssSelector(value),
//                "classname" => By.ClassName(value),
//                "linktext" => By.LinkText(value),
//                _ => throw new Exception($"Locator strategy '{strategy}' not supported.")
//            };
//        }
//    }
//}


using System;
using System.Configuration;
using System.Reflection;

namespace Amazon_Application.Utilities
{
    public static class ConfigReader
    {
        private static Configuration _config;

        static ConfigReader()
        {
            // Get the path of the executing assembly (DLL)
            string exePath = Assembly.GetExecutingAssembly().Location;
            _config = ConfigurationManager.OpenExeConfiguration(exePath);
        }

        public static string GetLocator(string key)
        {
            string value = _config.AppSettings.Settings[key]?.Value;
            if (string.IsNullOrEmpty(value))
                throw new Exception($"Locator key '{key}' not found in App.config. Check spelling or output config file.");
            return value;
        }

        public static string GetTestData(string key)
        {
            string value = _config.AppSettings.Settings[key]?.Value;
            if (string.IsNullOrEmpty(value))
                throw new Exception($"TestData key '{key}' not found in App.config. Check spelling or output config file.");
            return value;
        }
    }
}
