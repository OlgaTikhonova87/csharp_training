using System.Collections.Generic;
using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;
namespace WebAddressbookTests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        public string groupheader = "";
        public string groupname;
        public string groupfooter;

        public GroupData(string groupname)
        {
            this.groupname = groupname;
        }

        public string GroupName
        {
            set
            {
                groupname = value;
            }
            get
            {
                return groupname;
            }
        }
        public string GroupHeader
        {
            set
            {
                groupheader = value;
            }
            get
            {
                return groupheader;
            }
        }
        public string GroupFooter
        {
            set
            {
                groupfooter = value;
            }
            get
            {
                return groupfooter;
            }
        }
        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(other, this))
            {
                return true;
            }
            return GroupName == other.GroupName;
        }
        public override int GetHashCode()
        {
            return GroupName.GetHashCode();
        }
        public override string ToString()
        {
            return "name = " + GroupName;
        }
        public int CompareTo(GroupData other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return 1;
            }

            return GroupName.CompareTo(other.GroupName);
        }

    }
}
