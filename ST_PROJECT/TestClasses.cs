using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ST_PROJECT
{
    class TestClasses
    {
        public class Logout
        {
            #region logout from system
            public void logoutsystem()
            {
                BasePage.driver.FindElement(By.Id("welcome")).Click();
                Thread.Sleep(1000);

                BasePage.driver.FindElement(By.LinkText("Logout")).Click();
                Thread.Sleep(2000);
            }
            #endregion
        }

        public class Login : BasePage
        {
            #region login function

            public void LoginFunction(string url, string user, string pass)
            {
                driver.Url = url;
                driver.Manage().Window.Maximize();

                driver.FindElement(By.Id("txtUsername")).SendKeys(user);
                driver.FindElement(By.Id("txtPassword")).SendKeys(pass);

                driver.FindElement(By.ClassName("button")).Click();
            }
            #endregion
        }

        public class BasePage
        {
            #region Driverfunction
            public static IWebDriver driver;
            public void SeleniumInit()
            {
                var myDriver = new ChromeDriver();
                driver = myDriver;
            }
            #endregion
        }

        public class SearchPage
        {
            #region search function
            public void Search(string user, string role, string employee, string status)
            {
                BasePage.driver.FindElement(By.Id("menu_admin_viewAdminModule")).Click();

                BasePage.driver.FindElement(By.Id("searchSystemUser_userName")).SendKeys(user);
                BasePage.driver.FindElement(By.Id("searchSystemUser_userType")).SendKeys(role);
                BasePage.driver.FindElement(By.Id("searchSystemUser_employeeName_empName")).SendKeys(employee);
                BasePage.driver.FindElement(By.Id("searchSystemUser_status")).SendKeys(status);
            }
            #endregion
        }

        public class AddRecordClass
        {
            #region Addrecord function
            public void AddRecord(string role, string employee, string user, String status, string pass, string confpass)
            {
                BasePage.driver.FindElement(By.Id("menu_admin_viewAdminModule")).Click();

                BasePage.driver.FindElement(By.Id("btnAdd")).Click();

                BasePage.driver.FindElement(By.Id("systemUser_userType")).SendKeys(role);
                BasePage.driver.FindElement(By.Id("systemUser_employeeName_empName")).SendKeys(employee);
                BasePage.driver.FindElement(By.Id("systemUser_userName")).SendKeys(user);
                BasePage.driver.FindElement(By.Id("systemUser_status")).SendKeys(status);
                BasePage.driver.FindElement(By.Id("systemUser_password")).SendKeys(pass);
                BasePage.driver.FindElement(By.Id("systemUser_confirmPassword")).SendKeys(confpass);
            }
            #endregion

            #region Delete Record function
            public void DeleteRecord(string record)
            {
                BasePage.driver.FindElement(By.Id("menu_admin_viewAdminModule")).Click();

                BasePage.driver.FindElement(By.Id(record)).Click();
                BasePage.driver.FindElement(By.Id("btnDelete")).Click();
                BasePage.driver.FindElement(By.Id("dialogDeleteBtn")).Click();
            }
            #endregion
        }

        public class Job
        {
            #region Add job detail
            public void addjobrecord(string title, string JobDescrip, string addfile, string note)
            {
                BasePage.driver.FindElement(By.Id("menu_admin_viewAdminModule")).Click();
                BasePage.driver.FindElement(By.Id("menu_admin_Job")).Click();
                BasePage.driver.FindElement(By.Id("menu_admin_viewJobTitleList")).Click();
                BasePage.driver.FindElement(By.Id("btnAdd")).Click();

                BasePage.driver.FindElement(By.Id("jobTitle_jobTitle")).SendKeys(title);
                BasePage.driver.FindElement(By.Id("jobTitle_jobDescription")).SendKeys(JobDescrip);
                BasePage.driver.FindElement(By.Id("jobTitle_jobSpec")).SendKeys(addfile);
                BasePage.driver.FindElement(By.Id("jobTitle_note")).SendKeys(note);
            }
            #endregion

            #region Delete job detail
            public void deletejobrecord(string record)
            {
                BasePage.driver.FindElement(By.Id("menu_admin_viewAdminModule")).Click();
                BasePage.driver.FindElement(By.Id("menu_admin_Job")).Click();
                BasePage.driver.FindElement(By.Id("menu_admin_viewJobTitleList")).Click();

                BasePage.driver.FindElement(By.Id(record)).Click();
                BasePage.driver.FindElement(By.Id("btnDelete")).Click();
                BasePage.driver.FindElement(By.Id("dialogDeleteBtn")).Click();
            }
            #endregion
        }

        public class SearchDirectory
        {
            #region search record in directory
            public void search(string employeeName, string jobTitle, string location)
            {
                BasePage.driver.FindElement(By.Id("menu_directory_viewDirectory")).Click();

                BasePage.driver.FindElement(By.Id("searchDirectory_emp_name_empName")).SendKeys(employeeName);
                BasePage.driver.FindElement(By.Id("searchDirectory_job_title")).SendKeys(jobTitle);
                BasePage.driver.FindElement(By.Id("searchDirectory_location")).SendKeys(location);
            }
            #endregion
        }

        public class Buzz
        {
            #region update buzz status and press post
            public void updateBuzzStatus(string content)
            {
                BasePage.driver.FindElement(By.Id("menu_buzz_viewBuzz")).Click();
                BasePage.driver.FindElement(By.Id("tabLink1")).Click();
                BasePage.driver.FindElement(By.Id("createPost_content")).SendKeys(content);
            }
            #endregion
        }

    }

}
