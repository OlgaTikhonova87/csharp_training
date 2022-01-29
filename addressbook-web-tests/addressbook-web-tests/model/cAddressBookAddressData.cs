using System;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;
using System.Linq;
using System.Collections.Generic;


namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class AddressData : IEquatable<AddressData>, IComparable<AddressData>
    {
        public string allPhones;
        public string allInformation;
        public string allMails;
        public string allFio;
        public string detmails;
        public string detgeneral;
        public string detphones;

        public AddressData(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }
        public AddressData()
        {

        }
        [Column(Name = "firstname")]
        public string FirstName { get; set; }
        [Column(Name = "middlename")]
        public string MiddleName { get; set; }
        [Column(Name = "lastname")]
        public string LastName { get; set; }
        [Column(Name = "nickname")]
        public string NickName { get; set; }
        [Column(Name = "title")]
        public string Title { get; set; }
        [Column(Name = "company")]
        public string Company { get; set; }
        [Column(Name = "address")]
        public string Address { get; set; }
        [Column(Name = "home")]
        public string HomePhone { get; set; }
        [Column(Name = "mobile")]
        public string MobilePhone { get; set; }
        [Column(Name = "work")]
        public string WorkPhone { get; set; }
        [Column(Name = "fax")]
        public string Fax { get; set; }
        [Column(Name = "email")]
        public string Mail1 { get; set; }
        [Column(Name = "email2")]
        public string Mail2 { get; set; }
        [Column(Name = "email3")]
        public string Mail3 { get; set; }
        [Column(Name = "homepage")]
        public string HomePage { get; set; }
        [Column(Name = "notes")]
        public string Notes { get; set; }
        [Column(Name = "phone2")]
        public string Phone2 { get; set; }
        [Column(Name = "address2")]
        public string Address2 { get; set; }
        [Column(Name = "bday")]
        public string BDay { get; set; }
        [Column(Name = "bmonth")]
        public string BMonth { get; set; }
        [Column(Name = "byear")]
        public string BYear { get; set; }
        [Column(Name = "aday")]
        public string ADay { get; set; }
        [Column(Name = "amonth")]
        public string AMonth { get; set; }
        [Column(Name = "ayear")]
        public string AYear { get; set; }
        public string Group { get; set; }
        [Column(Name = "photo")]
        public string Photo { get; set; }
        public string Home { get; set; }
        [Column(Name = "id"), PrimaryKey, Identity]
        public string ID { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {

                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone) + CleanUp(Phone2)).Trim();

                }
            }
            set
            {
                allPhones = value;
            }
        }
        public string AllMails
        {
            get
            {
                if (allMails != null)
                {
                    return allMails;
                }
                else
                {
                    return (AddSequenses(Mail1) + AddSequenses(Mail2) + AddSequenses(Mail3)).Trim();

                }
            }
            set
            {
                allMails = value;
            }
        }
        public string AllFIO
        {
            get
            {
                if (allFio != null)
                {
                    return allFio;
                }
                else
                {
                    return (!string.IsNullOrEmpty(FirstName) ? $"{FirstName}" : string.Empty)
                        + (!string.IsNullOrEmpty(MiddleName) ? $" {MiddleName} " : " ")
                        + (!string.IsNullOrEmpty(LastName) ? $"{LastName}" : string.Empty);

                }
            }
            set
            {
                allFio = value;
            }
        }
        public string DetGen
        {
            get
            {
                if (detgeneral != null)
                {
                    return detgeneral;
                }
                else
                {
                    return (!string.IsNullOrEmpty(NickName) ? $"{NickName}\r\n" : string.Empty)
                        + (!string.IsNullOrEmpty(Title) ? $"{Title}\r\n" : string.Empty)
                        + (!string.IsNullOrEmpty(Company) ? $"{Company}\r\n" : string.Empty)
                        + (!string.IsNullOrEmpty(Address) ? $"{Address}\r\n" : string.Empty);
                    ;
                }
            }
            set
            {
                detgeneral = value;
            }
        }
        public string DetPhones
        {
            get
            {
                if (detphones != null)
                {
                    return detphones;
                }
                else
                {
                    return (!string.IsNullOrEmpty(HomePhone) ? $"H: {HomePhone}\r\n" : string.Empty)
                        + (!string.IsNullOrEmpty(MobilePhone) ? $"M: {MobilePhone}\r\n" : string.Empty)
                        + (!string.IsNullOrEmpty(WorkPhone) ? $"W: {WorkPhone}\r\n" : string.Empty)
                        + (!string.IsNullOrEmpty(Fax) ? $"F: {Fax}\r\n" : string.Empty);

                }
            }
            set
            {
                detphones = value;
            }
        }
        public string DetMails
        {
            get
            {
                if (detmails != null)
                {
                    return detmails;
                }
                else
                {
                    return (!string.IsNullOrEmpty(Mail1) ? $"{Mail1}\r\n" : string.Empty)
                        + (!string.IsNullOrEmpty(Mail2) ? $"{Mail2}\r\n" : string.Empty)
                        + (!string.IsNullOrEmpty(Mail3) ? $"{Mail3}\r\n" : string.Empty)
                        + (!string.IsNullOrEmpty(HomePage) ? $"Homepage:\r\n{HomePage}\r\n\r\n" : "\r\n");

                }
            }
            set
            {
                detmails = value;
            }
        }
        public string AllInformation
        {
            get
            {
                return ((!string.IsNullOrEmpty(AllFIO) ? $"{AllFIO}" : string.Empty).Trim() + "\r\n"
                    + (!string.IsNullOrEmpty(DetGen) ? $"{DetGen}\r\n" : string.Empty)
                    + (!string.IsNullOrEmpty(DetPhones) ? $"{DetPhones}\r\n" : string.Empty)
                    + (!string.IsNullOrEmpty(DetMails) ? $"{DetMails}\r\n" : string.Empty)
                    + (!string.IsNullOrEmpty(Address2) ? $"{Address2}\r\n\r\n" : string.Empty)
                    + (!string.IsNullOrEmpty(Phone2) ? $"P: {Phone2}\r\n\r\n" : string.Empty)
                    + Notes).Trim();

            }
            set
            {
                allInformation = value;
            }
        }
        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ ()-]", "") + "\r\n";
        }

        private string AddSequenses(string inputstring)
        {
            if (inputstring == null || inputstring == "")
            {
                return "";
            }
            return inputstring + "\r\n";
        }
        public int CompareTo(AddressData other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return 1;
            }
            if (this.FirstName != other.FirstName)
            {
                return FirstName.CompareTo(other.FirstName);
            }
            else
            if (this.LastName != other.LastName)
            {
                return LastName.CompareTo(other.LastName);
            }

            return 0;
        }

        public bool Equals(AddressData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(other, this))
            {
                return true;
            }
            return FirstName == other.FirstName && LastName == other.LastName;
        }
        public override int GetHashCode()
        {
            return 0;
        }
        public override string ToString()
        {
            return "name=" + FirstName + " " + LastName;
        }
        public static List<AddressData> GetAllContacts()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Contacts select g).ToList();
            }
        }

    }
}

