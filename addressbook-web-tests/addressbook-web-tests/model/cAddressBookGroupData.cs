using System;
using System.Collections.Generic;
using LinqToDB.Mapping;
using System.Linq;


namespace WebAddressbookTests

{
    [Table(Name = "group_list")]
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {

        public GroupData(string groupname)
        {
            GroupName = groupname;
        }
        public GroupData()
        {
            
        }

        [Column(Name = "group_name")]
        public string GroupName { get; set; }
        [Column(Name = "group_header")]
        public string GroupHeader { get; set; }
        [Column(Name = "group_footer")]
        public string GroupFooter { get; set; }
        [Column(Name = "group_id"), PrimaryKey, Identity]
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
        public static List<GroupData> GetAll() {
            using (AddressBookDB db = new AddressBookDB())
            {
               return  (from g in db.Groups select g).ToList();
            }
        }
    }
}
