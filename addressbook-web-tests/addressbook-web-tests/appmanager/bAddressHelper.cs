﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebAddressbookTests
{
    public class bAddressHelper : HelperBase
    {
         public bAddressHelper(mApplicationManager manager) : base(manager)
         {

         }

        //CREATION
        public bAddressHelper CreateAddress(AddressData address)
        {
            InitCreation();
            FillAddressForm(address);
            manager.Groups.Submit();
            return this;
        }
        public bAddressHelper InitCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        //MODIFICATION
        public bAddressHelper ModifyAddress(AddressData address)
        {
            AddressModificationInitiation();
            FillAddressForm(address);
            SubmitAddressModification();
            return this;
        }
        public bAddressHelper AddressModificationInitiation()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }
        public bAddressHelper SubmitAddressModification()
        {
            driver.FindElement(By.XPath("/html/body/div/div[4]/form/input[21]")).Click();
            return this;
        }
        //REMOVE
        public bAddressHelper RemoveAddress()
        {
            driver.FindElement(By.XPath("/html/body/div/div[2]/a/img")).Click();
            driver.FindElement(By.Name("selected[]")).Click();

            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        //ADDITIONAL
        public bAddressHelper FillAddressForm(AddressData address)
        {
            //Fill address form
            Type(By.Name("firstname"), address.firstname);
            Type(By.Name("middlename"), address.middlename);
            Type(By.Name("lastname"), address.lastname);
            Type(By.Name("nickname"), address.nickname);

            Type(By.Name("title"), address.title);
            Type(By.Name("company"), address.company);
            Type(By.Name("address"), address.address);

            Type(By.Name("mobile"), address.mobilephone);
            Type(By.Name("work"), address.workphone);
            Type(By.Name("fax"), address.fax);

            Type(By.Name("email"), address.mail1);
            Type(By.Name("email2"), address.mail2);
            Type(By.Name("email3"), address.mail3);

            Type(By.Name("homepage"), address.homepage);
            Type(By.Name("address2"), address.address2);
            Type(By.Name("phone2"), address.phone2);
            Type(By.Name("notes"), address.notes);
            Type(By.Name("byear"), address.byear);
            Type(By.Name("ayear"), address.ayear);

            return this;
        }
        public bool IsAddressExist(string lastname, string firstname)
        {
            string gg;
            gg = driver.FindElement(By.Name("selected[]")).GetAttribute("title");
            return driver.FindElement(By.Name("selected[]")).GetAttribute("title") == "Select ("+lastname+" "+ firstname+")";
        }
    }
}