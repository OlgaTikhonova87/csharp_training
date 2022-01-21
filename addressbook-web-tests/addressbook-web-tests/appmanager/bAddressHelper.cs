using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Runtime;

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
            string allMails = cells[4].Text;
            string allPhones = cells[5].Text;
            AddressData test = new AddressData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllMails = allMails
            };
            return test;

        }
        public string GetContractInformationFromDetails(int index)
        {
            manager.Navigator.OpenHomePage();
            OpenDetails(index);
            return GetDetailInformation();
        }

        private string GetDetailInformation()
        {
            string DetailText = driver.FindElement(By.XPath("//div[@id = 'content']")).Text;
            return DetailText.Replace("\r\n", "");
        }

        private bAddressHelper OpenDetails(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
            .FindElements(By.TagName("td"))[6]
            .FindElement(By.TagName("a")).Click();
            return this;
        }
        public AddressData GetContractInformationFromForm(int index)
        {
            manager.Navigator.OpenHomePage();
            AddressModificationInitiation(index);

            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string mail1 = driver.FindElement(By.Name("email")).GetAttribute("value");
            string mail2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string mail3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            string phone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string address2 = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");

            AddressData addre = new AddressData(firstName, lastName)
            {
                Address = address,
                MiddleName = middleName,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                NickName = nickName,
                Title = title,
                Company = company,
                Fax = fax,
                Mail1 = mail1,
                Mail2 = mail2,
                Mail3 = mail3,
                HomePage = homepage,
                Phone2 = phone2,
                Address2 = address2,
                Notes = notes
            };
           

            return addre;
        }

        //CREATION
        public bAddressHelper CreateAddress(AddressData address)
        {
            InitCreation();
            FillAddressForm(address);
            Enter();
            OpenAddressBook();
            return this;
        }
        public bAddressHelper InitCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
         //   addressCache = null;
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
            driver.FindElement(By.Name("selected[]")).Click();
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            addressCache = null;
            driver.SwitchTo().Alert().Accept();
            OpenAddressBook();
            return this;
        }

        //ADDITIONAL
        public bAddressHelper Enter()
        {
            driver.FindElement(By.Name("submit")).Click();
            addressCache = null;
            return this;
        }
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
          //  string gg = driver.FindElement(By.Name("selected[]")).GetAttribute("title");
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
               // List<AddressData> address = new List<AddressData>();
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
        public int GetNumberOfSearchResults()
        {
            manager.Navigator.OpenHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }
    }
}
