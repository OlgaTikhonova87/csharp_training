using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
  public class AddressData
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

        public AddressData(string firstname)
        {
            this.firstname= firstname;
        }

        public string FirstName
        {
            set
            {
                firstname = value;
            }
            get
            {
                return firstname;
            }
        }
        public string MiddleName
        {
            set
            {
                middlename = value;
            }
            get
            {
                return middlename;
            }
        }
        public string LastName
        {
            set
            {
                lastname = value;
            }
            get
            {
                return lastname;
            }
        }
        public string NickName
        {
            set
            {
                nickname = value;
            }
            get
            {
                return nickname;
            }
        }
        public string Title
        {
            set
            {
                title = value;
            }
            get
            {
                return title;
            }
        }
        public string Company
        {
            set
            {
                company = value;
            }
            get
            {
                return company;
            }
        }
        public string Address
        {
            set
            {
                address = value;
            }
            get
            {
                return address;
            }
        }
        public string HomePhone
        {
            set
            {
                homephone = value;
            }
            get
            {
                return homephone;
            }
        }
        public string MobilePhone
        {
            set
            {
                mobilephone = value;
            }
            get
            {
                return mobilephone;
            }
        }
        public string WorkPhone
        {
            set
            {
                workphone = value;
            }
            get
            {
                return workphone;
            }
        }
        public string Fax
        {
            set
            {
                fax = value;
            }
            get
            {
                return fax;
            }
        }
        public string Mail1
        {
            set
            {
                mail1 = value;
            }
            get
            {
                return mail1;
            }
        }
        public string Mail2
        {
            set
            {
                mail2 = value;
            }
            get
            {
                return mail2;
            }
        }
        public string Mail3
        {
            set
            {
                mail3 = value;
            }
            get
            {
                return mail3;
            }
        }
        public string HomePage
        {
            set
            {
                homepage = value;
            }
            get
            {
                return homepage;
            }
        }
        public string Notes
        {
            set
            {
                notes = value;
            }
            get
            {
                return notes;
            }
        }
        public string Phone2
        {
            set
            {
                phone2 = value;
            }
            get
            {
                return phone2;
            }
        }
        public string Address2
        {
            set
            {
                address2 = value;
            }
            get
            {
                return address2;
            }
        }
        public string BDay
        {
            set
            {
                bday = value;
            }
            get
            {
                return bday;
            }
        }
        public string BMonth
        {
            set
            {
                bmonth = value;
            }
            get
            {
                return bmonth;
            }
        }
        public string BYear
        {
            set
            {
                byear = value;
            }
            get
            {
                return byear;
            }
        }
        public string ADay
        {
            set
            {
                aday = value;
            }
            get
            {
                return aday;
            }
        }
        public string AMonth
        {
            set
            {
                amonth = value;
            }
            get
            {
                return amonth;
            }
        }
        public string AYear
        {
            set
            {
                ayear = value;
            }
            get
            {
                return ayear;
            }
        }
        public string Group
        {
            set
            {
                group = value;
            }
            get
            {
                return group;
            }
        }
        public string Photo
        {
            set
            {
                photo = value;
            }
            get
            {
                return photo;
            }
        }
    }
}

