using HotelManagement_Test.BaseClass;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace HotelManagement_Test
{
    class AddStaff : BaseTest
    {
        IWebElement ele;
        IWebElement txtStaffId, txtName, txtPhone, txtIdentityId, txtAddress, scPosition, scGender, txtSalary, btnSave;
        string str;

        public void Nagative()
        {
            ele = webDriver.FindElement(By.XPath("/html/body/app-root/div/div[1]/app-navbar/p-slidemenu/div/div/div[1]/p-slidemenusub/ul/li[6]"));
            ele.Click();
            Thread.Sleep(200);
            ele = webDriver.FindElement(By.XPath("/html/body/app-root/div/div[1]/app-navbar/p-slidemenu/div/div/div[1]/p-slidemenusub/ul/li[6]/p-slidemenusub/ul/li[1]"));
            ele.Click();
        }

        public void GetElement()
        {
            txtStaffId = webDriver.FindElement(By.XPath("/html/body/app-root/div/div[2]/app-them-nhan-vien/div/div[1]/input"));
            txtName = webDriver.FindElement(By.XPath("/html/body/app-root/div/div[2]/app-them-nhan-vien/div/div[2]/input"));
            txtPhone = webDriver.FindElement(By.XPath("/html/body/app-root/div/div[2]/app-them-nhan-vien/div/div[4]/input"));
            txtIdentityId = webDriver.FindElement(By.XPath("/html/body/app-root/div/div[2]/app-them-nhan-vien/div/div[6]/div[1]/input"));
            txtAddress = webDriver.FindElement(By.XPath("/html/body/app-root/div/div[2]/app-them-nhan-vien/div/div[6]/div[2]/textarea"));
            scPosition = webDriver.FindElement(By.XPath("/html/body/app-root/div/div[2]/app-them-nhan-vien/div/div[6]/div[3]/div[2]/p-radiobutton"));
            txtSalary = webDriver.FindElement(By.XPath("/html/body/app-root/div/div[2]/app-them-nhan-vien/div/div[6]/div[4]/p-inputnumber/span/input"));
            scGender = webDriver.FindElement(By.XPath("/html/body/app-root/div/div[2]/app-them-nhan-vien/div/div[3]/div[2]/div[2]/p-radiobutton"));
            btnSave = webDriver.FindElement(By.XPath("/html/body/app-root/div/div[2]/app-them-nhan-vien/div/div[6]/div[5]/p-button"));
        }

        [Test, Category("AddStaff"), Order(1)]
        public void txtStaffId_IsNotNull()
        {
            Nagative();
            Thread.Sleep(200);
            GetElement();
            str = txtStaffId.Text;
            Assert.IsNotNull(str);
        }

        [Test, Category("AddStaff"), Order(2)]
        public void txtName_ValidValue()
        {
            txtName.SendKeys("Sample");
            str = txtName.GetAttribute("value");
            Assert.AreEqual("Sample", str);
        }

        [Test, Category("AddStaff"), Order(3)]
        public void txtPhone_ValidValue()
        {
            txtPhone.Clear();
            txtPhone.SendKeys("0987654321");
            str = txtPhone.GetAttribute("value");
            Assert.AreEqual("0987654321", str);
        }

        [Test, Category("AddStaff"), Order(4)]
        public void txtIdentityId_InvalidValue()
        {
            txtIdentityId.Clear();
            txtIdentityId.SendKeys("GI456789");
            str = txtIdentityId.GetAttribute("value");
            Assert.AreEqual("456789", str);
        }

        [Test, Category("AddStaff"), Order(5)]
        public void txtIdentityId_ValidValue()
        {
            txtIdentityId.Clear();
            txtIdentityId.SendKeys("0987654321");
            str = txtIdentityId.GetAttribute("value");
            Assert.AreEqual("0987654321", str);
        }

        [Test, Category("AddStaff"), Order(6)]
        public void scGender_ValidValue()
        {
            scGender.Click();
            Assert.IsNotNull(scGender);
        }

        [Test, Category("AddStaff"), Order(7)]
        public void txtAddress_ValidValue()
        {
            txtAddress.SendKeys("Sample address");
            str = txtAddress.GetAttribute("value");
            Assert.AreEqual("Sample address", str);
        }

        [Test, Category("AddStaff"), Order(8)]
        public void scPosotion_ValidValue()
        {
            scPosition.Click();
            Thread.Sleep(200);
            ele = webDriver.FindElement(By.XPath("/html/body/app-root/div/div[2]/app-them-nhan-vien/div/div[5]/p-card/div/div[2]/div[2]"));
            str = ele.Text;
            Assert.AreEqual("Nhân viên quản lý", str);            
        }

        [Test, Category("AddStaff"), Order(9)]
        public void txtSalary_InvalidValue()
        {
            txtSalary.Clear();
            txtSalary.SendKeys("GI5000000");
            str = txtSalary.GetAttribute("value");
            Assert.AreEqual("₫5,000,000", str);
        }

        [Test, Category("AddStaff"), Order(10)]
        public void txtSalary_ValidValue()
        {
            txtSalary.Clear();
            txtSalary.SendKeys("4000000");
            str = txtSalary.GetAttribute("value");
            Assert.AreEqual("₫4,000,000", str);
        }

    }
}
