using System;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{
    public class ContactHelper : HelperBase
    {
        public static string CONTACTWINTITLE = "Contact editor";
        public ContactHelper(ApplicationManager manager) : base(manager) { }

        public List<ContactData> GetContactList()
        {
            List<ContactData> list = new List<ContactData>();

            return list;
        
        }

    }
}