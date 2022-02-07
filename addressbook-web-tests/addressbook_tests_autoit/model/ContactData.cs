using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace addressbook_tests_autoit
{
    public class ContactData : IComparable<ContactData>, IEquatable<ContactData>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public int CompareTo(ContactData other)
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



        public bool Equals(ContactData other)
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
    }
}
