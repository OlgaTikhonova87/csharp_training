using System;
namespace WebAddressbookTests
{
  public class AddressData : IEquatable<AddressData>, IComparable<AddressData>
    {
        
        public string firstname;
        public string middlename;
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

        public AddressData(string firstname, string lastname) 
        {
            this.firstname= firstname;
            this.lastname = lastname;
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


        public int CompareTo(AddressData other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return 1;
            }

            return FirstName.CompareTo(other.FirstName) & LastName.CompareTo(other.LastName);
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
            return FirstName == other.FirstName && lastname == other.lastname;
        }
    }
}

