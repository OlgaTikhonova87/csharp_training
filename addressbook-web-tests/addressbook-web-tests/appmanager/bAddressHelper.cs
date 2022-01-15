using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    public class bAddressHelper : HelperBase
    {
         public bAddressHelper(mApplicationManager manager) : base(manager)
         {

         }

        public AddressData GetContractInformationFromTable(int index)
        {
            manager.Navigator.OpenHomePage();
           IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;
            return new AddressData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones
            };

        }

        public AddressData GetContractInformationFromForm(int index)
        {
            manager.Navigator.OpenHomePage();
            AddressModificationInitiation(index);

            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            return new AddressData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone
            };

        }

        //CREATION
        public bAddressHelper CreateAddress(AddressData address)
        {
            InitCreation();
            FillAddressForm(address);
            manager.Groups.Submit();
            OpenAddressBook();
            return this;
        }
        public bAddressHelper InitCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            addressCache = null;
            return this;
        }
        //MODIFICATION
        public bAddressHelper ModifyAddress(AddressData address)
        {
            AddressModificationInitiation(1);
            FillAddressForm(address);
            SubmitAddressModification();
            OpenAddressBook();
            return this;
        }
        public bAddressHelper AddressModificationInitiation(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            //driver.FindElements(By.Name("entry"))[index]
            //                .FindElements(By.TagName("td"));
            return this;
        }
        public bAddressHelper SubmitAddressModification()
        {
            driver.FindElement(By.Name("update")).Click();
            addressCache = null;
            return this;
        }
        //REMOVE
        public bAddressHelper RemoveAddress()
        {
            driver.FindElement(By.XPath("/html/body/div/div[2]/a/img")).Click();
            driver.FindElement(By.Name("selected[]")).Click();
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            addressCache = null;
            driver.SwitchTo().Alert().Accept();
            OpenAddressBook();
            return this;
        }

        //ADDITIONAL
        public bAddressHelper FillAddressForm(AddressData address)
        {
            //Fill address form
            Type(By.Name("firstname"), address.FirstName);
            Type(By.Name("middlename"), address.MiddleName);
            Type(By.Name("lastname"), address.LastName);
            Type(By.Name("nickname"), address.NickName);

            Type(By.Name("title"), address.Title);
            Type(By.Name("company"), address.Company);
            Type(By.Name("address"), address.Address);

            Type(By.Name("mobile"), address.MobilePhone);
            Type(By.Name("work"), address.WorkPhone);
            Type(By.Name("fax"), address.Fax);

            Type(By.Name("email"), address.Mail1);
            Type(By.Name("email2"), address.Mail2);
            Type(By.Name("email3"), address.Mail3);

            Type(By.Name("homepage"), address.HomePage);
            Type(By.Name("address2"), address.Address2);
            Type(By.Name("phone2"), address.Phone2);
            Type(By.Name("notes"), address.Notes);
            Type(By.Name("byear"), address.BYear);
            Type(By.Name("ayear"), address.AYear);

            return this;
        }
        public bool IsAddressExist(string lastname, string firstname)
        {
            string gg;
            gg = driver.FindElement(By.Name("selected[]")).GetAttribute("title");
            return driver.FindElement(By.Name("selected[]")).GetAttribute("title") == "Select ("+lastname+" "+ firstname+")";
        }
        public bAddressHelper OpenAddressBook()
        {
            driver.FindElement(By.XPath("/html/body/div/div[2]/a/img")).Click();
            return this;
        }

        public int GetAddressCount()
        {
            int i = driver.FindElements(By.CssSelector("tr[name='entry']")).Count;
            return i;
        }

        private List<AddressData> addressCache = null;
        public List<AddressData> GetAddressList()
        {
            if (addressCache == null)
            {
                addressCache = new List<AddressData>();
                OpenAddressBook();
                List<AddressData> address = new List<AddressData>();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name='entry']"));

                foreach (IWebElement element in elements)
                {
                    IWebElement First = element.FindElement(By.CssSelector("td:nth-child(3)"));
                    IWebElement Last = element.FindElement(By.CssSelector("td:nth-child(2)"));

                    addressCache.Add(new AddressData(First.Text, Last.Text));
                }
            }
            return new List<AddressData>(addressCache);
        }
    }
}
