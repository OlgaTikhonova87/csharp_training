using System;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
  public class AddressData : IEquatable<AddressData>, IComparable<AddressData>
    {

        public string firstname;
        public string middlename = "";
        public string lastname = "";
        public string nickname = "";
        public string title = "";
        public string company = "";
        public string address = "";
        public string homephone = "";
        public string mobilephone = "";
        public string workphone = "";
        public string fax = "";
        public string mail1 = "";
        public string mail2 = "";
        public string mail3 = "";
        public string homepage = "";
        public string address2 = "";
        public string phone2 = "";
        public string notes = "";
        public string bday = "";
        public string bmonth = "";
        public string byear = "";
        public string aday = "";
        public string amonth = "";
        public string ayear = "";
        public string group = "";
        public string photo = "";
        public string allPhones;
        public string allInformation;
        public string allMails;

        public AddressData(string firstname, string lastname) 
        {
            FirstName = firstname;
            LastName = lastname;
        }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Fax { get; set; }
        public string Mail1 { get; set; }
        public string Mail2 { get; set; }
        public string Mail3 { get; set; }
        public string HomePage { get; set; }
        public string Notes { get; set; }
        public string Phone2 { get; set; }
        public string Address2 { get; set; }
        public string BDay { get; set; }
        public string BMonth { get; set; }
        public string BYear { get; set; }
        public string ADay { get; set; }
        public string AMonth { get; set; }
        public string AYear { get; set; }
        public string Group { get; set; }
        public string Photo { get; set; }
        public string Home { get; set; }

        public string AllPhones {
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
        public string AllInformation
        {
            get
            {
                return (FirstName  + " "
                        + (MiddleName) 
                        + LastName
                        + NickName
                        + Title 
                        + Company
                        + Address
                        + (!string.IsNullOrEmpty(HomePhone) ? $"H: {HomePhone}" : string.Empty)
                        + (!string.IsNullOrEmpty(MobilePhone) ? $"M: {MobilePhone}" : string.Empty)
                        + (!string.IsNullOrEmpty(WorkPhone) ? $"W: {WorkPhone}" : string.Empty)
                        + (!string.IsNullOrEmpty(Fax) ? $"F: {Fax}" : string.Empty)
                        + Mail1 
                        + Mail2 
                        + Mail3
                        + (!string.IsNullOrEmpty(HomePage) ? $"F: {HomePage}" : string.Empty)
                        + Address2
                        + (!string.IsNullOrEmpty(Phone2) ? $"P: {Phone2}" : string.Empty)
                        + Notes).Trim().Replace("\r\n", "");
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
    }
}

