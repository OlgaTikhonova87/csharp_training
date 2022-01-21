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

        public GroupData(string groupname)
        {
            GroupName = groupname;
        }

        public string GroupName { get; set; }
       
        public string GroupHeader { get; set; }

        public string GroupFooter { get; set; }
        public string ID { get; set; }
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
            return "name = " + GroupName+ "\nheader = " + GroupHeader +"\nfooter = " + GroupFooter;
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
