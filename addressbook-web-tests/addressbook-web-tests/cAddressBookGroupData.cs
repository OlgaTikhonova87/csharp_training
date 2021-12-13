using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class GroupData
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
    }
}
