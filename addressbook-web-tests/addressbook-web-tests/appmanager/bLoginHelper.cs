﻿using OpenQA.Selenium;
using System;

namespace WebAddressbookTests
{
    public class bLoginHelper : HelperBase
    {
        public bLoginHelper(mApplicationManager manager) : base(manager)
        {

        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }

        }
        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }
                Logout();
            }
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);

            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text
                    == "(" + account.Username + ")";
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }
    }
}