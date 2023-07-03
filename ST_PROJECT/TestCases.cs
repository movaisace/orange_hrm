using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Threading;

namespace ST_PROJECT
{
    [TestClass]
    public class TestCases
    {
        TestClasses test = new TestClasses();

        TestClasses.BasePage basePage = new TestClasses.BasePage();
        TestClasses.Login login = new TestClasses.Login();
        TestClasses.SearchPage searchPage = new TestClasses.SearchPage();
        TestClasses.AddRecordClass addRecordClass = new TestClasses.AddRecordClass();
        TestClasses.Job job = new TestClasses.Job();
        TestClasses.Buzz buzz = new TestClasses.Buzz();
        TestClasses.SearchDirectory searchDirectory = new TestClasses.SearchDirectory();
        TestClasses.Logout logout = new TestClasses.Logout();

        [TestMethod]
        public void Testcase_01()
        {
            #region valid login
            basePage.SeleniumInit();
            login.LoginFunction("https://opensource-demo.orangehrmlive.com/", "Admin", "admin123");
            Thread.Sleep(2000);
            TestClasses.BasePage.driver.Close();
            #endregion
        }

        [TestMethod]
        public void Testcase_02()
        {
            #region invalid login (without username)
            basePage.SeleniumInit();
            login.LoginFunction("https://opensource-demo.orangehrmlive.com/", "", "admin123");
            Thread.Sleep(2000);
            TestClasses.BasePage.driver.Close();
            TestClasses.BasePage.driver.Quit();
            #endregion
        }

        [TestMethod]
        public void Testcase_03()
        {
            #region invalid login (without password)
            basePage.SeleniumInit();
            login.LoginFunction("https://opensource-demo.orangehrmlive.com/", "Admin", "");
            string actualText = TestClasses.BasePage.driver.FindElement(By.Id("spanMessage")).Text;
            Assert.AreEqual("Password cannot be empty", actualText);
            Thread.Sleep(2000);
            TestClasses.BasePage.driver.Close();
            TestClasses.BasePage.driver.Quit();
            #endregion
        }

        [TestMethod]
        public void Testcase_04()
        {
            #region invalid login with wrong username
            basePage.SeleniumInit();
            login.LoginFunction("https://opensource-demo.orangehrmlive.com/", "khan10", "admin123");
            Thread.Sleep(2000);
            TestClasses.BasePage.driver.Close();
            #endregion
        }

        [TestMethod]
        public void Testcase_05()
        {
            #region add user record and press save
            basePage.SeleniumInit();
            login.LoginFunction("https://opensource-demo.orangehrmlive.com/", "khan10", "admin123");
            addRecordClass.AddRecord("ESS", "Alice Duval", "Alice", "Enabled", "alice123", "alice123");
            TestClasses.BasePage.driver.FindElement(By.Id("btnSave")).Click();
            Thread.Sleep(2000);
            TestClasses.BasePage.driver.Close();
            TestClasses.BasePage.driver.Quit();
            #endregion
        }

        [TestMethod]
        public void Testcase_06()
        {
            #region add user record and press delete
            basePage.SeleniumInit();
            login.LoginFunction("https://opensource-demo.orangehrmlive.com/", "Admin", "admin123");
            addRecordClass.DeleteRecord("ohrmList_chkSelectRecord_56");
            Thread.Sleep(2000);
            TestClasses.BasePage.driver.Close();
            TestClasses.BasePage.driver.Quit();
            #endregion 
        }

        [TestMethod]
        public void Testcase_07()
        {
            #region add user record without password
            basePage.SeleniumInit();
            login.LoginFunction("https://opensource-demo.orangehrmlive.com/", "Admin", "admin123");
            TestClasses.BasePage.driver.FindElement(By.Id("menu_admin_viewAdminModule")).Click();
            addRecordClass.AddRecord("ESS", "Alice Duval", "Alice", "Enabled", "", "alice123");
            TestClasses.BasePage.driver.FindElement(By.Id("btnSave")).Click();
            Thread.Sleep(2000);
            TestClasses.BasePage.driver.Close();
            TestClasses.BasePage.driver.Quit();
            #endregion 
        }

        [TestMethod]
        public void Testcase_08()
        {
            #region add user record with wrong confirm password
            basePage.SeleniumInit();
            login.LoginFunction("https://opensource-demo.orangehrmlive.com/", "Admin", "admin123");
            TestClasses.BasePage.driver.FindElement(By.Id("menu_admin_viewAdminModule")).Click();
            addRecordClass.AddRecord("ESS", "Alice Duval", "Alice", "Enabled", "alice123", "alice1234");
            TestClasses.BasePage.driver.FindElement(By.Id("btnSave")).Click();
            Thread.Sleep(2000);
            TestClasses.BasePage.driver.Close();
            TestClasses.BasePage.driver.Quit();
            #endregion 
        }

        [TestMethod]
        public void Testcase_09()
        {
            #region fill add user record then cancel
            basePage.SeleniumInit();
            login.LoginFunction("https://opensource-demo.orangehrmlive.com/", "Admin", "admin123");
            TestClasses.BasePage.driver.FindElement(By.Id("menu_admin_viewAdminModule")).Click();
            addRecordClass.AddRecord("ESS", "Alice Duval", "Alice", "Enabled", "alice123", "alice1234");
            TestClasses.BasePage.driver.FindElement(By.Id("btnCancel")).Click();
            Thread.Sleep(2000);
            TestClasses.BasePage.driver.Close();
            TestClasses.BasePage.driver.Quit();
            #endregion 
        }

        [TestMethod]
        public void Testcase_10()
        {
            #region fill search user record and then press search
            basePage.SeleniumInit();
            login.LoginFunction("https://opensource-demo.orangehrmlive.com/", "Admin", "admin123");
            TestClasses.BasePage.driver.FindElement(By.Id("menu_admin_viewAdminModule")).Click();
            searchPage.Search("	Aaliyah.Haq", "ESS", "Aaliyah Haq", "Enabled");
            TestClasses.BasePage.driver.FindElement(By.Id("searchBtn")).Click();
            Thread.Sleep(2000);
            TestClasses.BasePage.driver.Close();
            TestClasses.BasePage.driver.Quit();
            #endregion
        }

        [TestMethod]
        public void Testcase_11()
        {
            #region  fill Search record details and then reset
            basePage.SeleniumInit();
            login.LoginFunction("https://opensource-demo.orangehrmlive.com/", "Admin", "admin123");
            TestClasses.BasePage.driver.FindElement(By.Id("menu_admin_viewAdminModule")).Click();
            searchPage.Search("	Aaliyah.Haq", "ESS", "Aaliyah Haq", "Enabled");
            TestClasses.BasePage.driver.FindElement(By.Id("resetBtn")).Click();
            Thread.Sleep(2000);
            TestClasses.BasePage.driver.Close();
            TestClasses.BasePage.driver.Quit();
            #endregion 
        }

        [TestMethod]
        public void Testcase_12()
        {
            #region  Delete any job title record
            basePage.SeleniumInit();
            login.LoginFunction("https://opensource-demo.orangehrmlive.com/", "Admin", "admin123");
            job.deletejobrecord("ohrmList_chkSelectRecord_26");

            Thread.Sleep(2000);
            TestClasses.BasePage.driver.Close();
            TestClasses.BasePage.driver.Quit();
            #endregion
        }

        [TestMethod]
        public void Testcase_13()
        {
            #region search record in directory and press search
            basePage.SeleniumInit();
            login.LoginFunction("https://opensource-demo.orangehrmlive.com/", "Admin", "admin123");
            searchDirectory.search("Odis Adalwin", "Chief Technical Officer", "HQ - CA, USA");
            TestClasses.BasePage.driver.FindElement(By.Id("searchBtn")).Click();

            Thread.Sleep(2000);
            TestClasses.BasePage.driver.Close();
            TestClasses.BasePage.driver.Quit();
            #endregion
        }

        [TestMethod]
        public void Testcase_14()
        {
            #region search record in directory and press reset 
            basePage.SeleniumInit();
            login.LoginFunction("https://opensource-demo.orangehrmlive.com/", "Admin", "admin123");
            searchDirectory.search("Odis Adalwin", "Chief Technical Officer", "HQ - CA, USA");
            TestClasses.BasePage.driver.FindElement(By.Id("resetBtn")).Click();

            Thread.Sleep(2000);
            TestClasses.BasePage.driver.Close();
            TestClasses.BasePage.driver.Quit();
            #endregion
        }

        [TestMethod]
        public void Testcase_15()
        {
            #region update buzz status and press post
            basePage.SeleniumInit();
            login.LoginFunction("https://opensource-demo.orangehrmlive.com/", "Admin", "admin123");
            buzz.updateBuzzStatus("Salam, We are Testers ,Please Subscribe Our Youtube Channel");
            TestClasses.BasePage.driver.FindElement(By.Id("postSubmitBtn")).Click();

            Thread.Sleep(2000);
            TestClasses.BasePage.driver.Close();
            TestClasses.BasePage.driver.Quit();
            #endregion
        }

        [TestMethod]
        public void Testcase_16()
        {
            #region verify password and add employee name and press delete
            basePage.SeleniumInit();
            login.LoginFunction("https://opensource-demo.orangehrmlive.com/", "Admin", "admin123");

            TestClasses.BasePage.driver.FindElement(By.Id("menu_pim_viewPimModule")).Click();
            TestClasses.BasePage.driver.FindElement(By.Id("btnDelete")).Click();

            //Thread.Sleep(2000);
            ////TestClasses.BasePage.driver.Close();
            TestClasses.BasePage.driver.Quit();
            #endregion
        }

        [TestMethod]
        public void Testcase_17()
        {
            #region  login with number in username
            basePage.SeleniumInit();
            login.LoginFunction("https://opensource-demo.orangehrmlive.com/", "Admin456766777777", "admin123");
            Thread.Sleep(2000);
            TestClasses.BasePage.driver.Close();
            TestClasses.BasePage.driver.Quit();
            #endregion
        }

        [TestMethod]
        public void Testcase_18()
        {
            #region  logout from site
            basePage.SeleniumInit();
            login.LoginFunction("https://opensource-demo.orangehrmlive.com/", "Admin", "admin123");
            logout.logoutsystem();
            Thread.Sleep(2000);
            TestClasses.BasePage.driver.Close();
            TestClasses.BasePage.driver.Quit();
            #endregion
        }

    }
}
