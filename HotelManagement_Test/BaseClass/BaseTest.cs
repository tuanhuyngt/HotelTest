using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;

namespace HotelManagement_Test.BaseClass
{
    class BaseTest
    {
        public string strUrl = "http://localhost:4200";
        static public IWebDriver webDriver;
        IWebElement ele;
        IWebElement txtStaffEmail, txtPassword, btnLogin, liLogin;
        public void GetAllElement()
        {
            txtStaffEmail = webDriver.FindElement(By.XPath("/html/body/app-root/div/div[2]/app-dang-nhap/div[1]/div[1]/input"));
            txtPassword = webDriver.FindElement(By.XPath("/html/body/app-root/div/div[2]/app-dang-nhap/div[1]/div[2]/input"));
            btnLogin = webDriver.FindElement(By.XPath("/html/body/app-root/div/div[2]/app-dang-nhap/div[2]/p-button"));
        }

        [OneTimeSetUp]
        public void Open()
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Size = new Size(1470, 1030);
            webDriver.Url = strUrl;
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);

            liLogin = webDriver.FindElement(By.XPath("/html/body/app-root/div/div[1]/app-navbar/p-slidemenu/div/div/div[1]/p-slidemenusub/ul/li[1]"));
            liLogin.Click();

            GetAllElement();
            Login();
        }

        public void Login()
        {
            //Login
            txtStaffEmail.SendKeys("lh164@yahoo.com");
            txtPassword.SendKeys("123456");
            btnLogin.Click();
            Thread.Sleep(3000);

            ele = webDriver.FindElement(By.XPath("/html/body/app-root/div/div[1]/app-navbar/p-slidemenu/div/div/div[1]/p-slidemenusub/ul/li[1]"));
            ele.Click();

            Thread.Sleep(500);
        }

        public void NagativeToManagement()
        {
            ele = webDriver.FindElement(By.XPath("/html/body/app-root/ng-component/div/div/div[1]/side-bar-menu/nav/div[1]/div/ul/li[6]"));
            ele.Click();
            Thread.Sleep(400);
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [OneTimeTearDown]
        public void Close()
        {
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            webDriver.Close();
        }
    }
}
