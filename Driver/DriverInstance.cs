﻿using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;


namespace AutomatedTestsBaskino.Driver
{
    static class DriverInstance
    {
        private static IWebDriver driver;

        public static IWebDriver GetInstance()
        {
            if (driver == null)
            {
                driver = new ChromeDriver();
                driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public static void CloseBrowser()
        {
            driver.Quit();
            driver = null;

            foreach (var process in Process.GetProcessesByName("chromedriver"))
            {
                process.Kill();
            }
        }
    }
}
