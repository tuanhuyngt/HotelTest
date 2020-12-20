using HotelManagement_Test.BaseClass;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace HotelManagement_Test
{
    class AddRoom : BaseTest
    {
        IWebElement ele;
        IWebElement txtRoomId, txtRoomNumber, txtFloorNumber, txtNumberOfBed, cbRoomCategory, txtPricePerHour, txtPricePerDay, btnSave;
        string str;


        public void Nagative()
        {
            ele = webDriver.FindElement(By.XPath("/html/body/app-root/div/div[1]/app-navbar/p-slidemenu/div/div/div[1]/p-slidemenusub/ul/li[6]"));
            ele.Click();
            Thread.Sleep(200);
            ele = webDriver.FindElement(By.XPath("/html/body/app-root/div/div[1]/app-navbar/p-slidemenu/div/div/div[1]/p-slidemenusub/ul/li[6]/p-slidemenusub/ul/li[4]"));
            ele.Click();
        }

        public void GetElement()
        {
            txtRoomId = webDriver.FindElement(By.XPath("/html/body/app-root/div/div[2]/app-them-phong/div/div[2]/div[1]/input"));
            txtRoomNumber = webDriver.FindElement(By.XPath("/html/body/app-root/div/div[2]/app-them-phong/div/div[2]/div[2]/input"));
            txtFloorNumber = webDriver.FindElement(By.XPath("/html/body/app-root/div/div[2]/app-them-phong/div/div[2]/div[3]/p-inputnumber/span/input"));
            txtNumberOfBed = webDriver.FindElement(By.XPath("/html/body/app-root/div/div[2]/app-them-phong/div/div[2]/div[4]/p-inputnumber/span/input"));
            cbRoomCategory = webDriver.FindElement(By.XPath("/html/body/app-root/div/div[2]/app-them-phong/div/div[2]/div[5]/p-dropdown"));
            txtPricePerHour = webDriver.FindElement(By.XPath("/html/body/app-root/div/div[2]/app-them-phong/div/div[2]/div[6]/p-inputnumber/span/input"));
            txtPricePerDay = webDriver.FindElement(By.XPath("/html/body/app-root/div/div[2]/app-them-phong/div/div[2]/div[7]/p-inputnumber/span/input"));
            btnSave = webDriver.FindElement(By.XPath("/html/body/app-root/div/div[2]/app-them-phong/div/div[2]/div[8]/p-button/button"));
        }


        [Test, Category("AddRoom"), Order(1)]
        public void txtRoomId_IsNotNull()
        {
            Nagative();
            Thread.Sleep(200);
            GetElement();
            str = txtRoomId.Text;
            Assert.IsNotNull(str);
        }

        [Test, Category("AddRoom"), Order(2)]
        public void txtRoomNumber_ValidValue()
        {
            txtRoomNumber.SendKeys("C304");
            str = txtRoomNumber.GetAttribute("value");
            Assert.AreEqual("C304", str);
        }

        [Test, Category("AddRoom"), Order(3)]
        public void txtFloornumber_InValidValue()
        {
            txtFloorNumber.SendKeys("ABGI4");
            str = txtFloorNumber.GetAttribute("value");
            Assert.AreEqual("4", str);
        }

        [Test, Category("AddRoom"), Order(4)]
        public void txtFloornumber_ValidValue()
        {
            txtFloorNumber.Clear();
            txtFloorNumber.SendKeys("6");
            str = txtFloorNumber.GetAttribute("value");
            Assert.AreEqual("6", str);
        }

        [Test, Category("AddRoom"), Order(5)]
        public void txtNumberOfBed_InvalidValue()
        {
            txtNumberOfBed.SendKeys("ABGI4");
            str = txtNumberOfBed.GetAttribute("value");
            Assert.AreEqual("4", str);
        }

        [Test, Category("AddRoom"), Order(6)]
        public void txtNumberOfBed_validValue()
        {
            txtNumberOfBed.Clear();
            txtNumberOfBed.SendKeys("6");
            str = txtNumberOfBed.GetAttribute("value");
            Assert.AreEqual("6", str);
        }

        [Test, Category("AddRoom"), Order(7)]
        public void cbRoomCategorySelect()
        {
            cbRoomCategory.Click();
            Thread.Sleep(200);
            ele = webDriver.FindElement(By.XPath("/html/body/app-root/div/div[2]/app-them-phong/div/div[2]/div[5]/p-dropdown/div/div[3]/div/ul/p-dropdownitem[2]/li"));
            ele.Click();
            ele = webDriver.FindElement(By.XPath("/html/body/app-root/div/div[2]/app-them-phong/div/div[2]/div[5]/p-dropdown/div/span"));
            str = ele.Text;
            Assert.AreEqual("Thương gia", str);
        }

        [Test, Category("AddRoom"), Order(8)]
        public void txtPricePerHour_InvalidValue()
        {
            txtPricePerHour.SendKeys("ABGI400000");
            str = txtPricePerHour.GetAttribute("value");
            Assert.AreEqual("₫400,000", str);
        }

        [Test, Category("AddRoom"), Order(9)]
        public void txtPricePerHour_validValue()
        {
            txtPricePerHour.Clear();
            txtPricePerHour.SendKeys("600000");
            str = txtPricePerHour.GetAttribute("value");
            Assert.AreEqual("₫600,000", str);
        }

        [Test, Category("AddRoom"), Order(10)]
        public void txtPricePerDay_InvalidValue()
        {
            txtPricePerDay.SendKeys("ABGI400000");
            str = txtPricePerDay.GetAttribute("value");
            Assert.AreEqual("₫400,000", str);
        }

        [Test, Category("AddRoom"), Order(11)]
        public void txtPricePerDay_validValue()
        {
            txtPricePerDay.Clear();
            txtPricePerDay.SendKeys("600000");
            str = txtPricePerDay.GetAttribute("value");
            Assert.AreEqual("₫600,000", str);
        }

       


    }
}
