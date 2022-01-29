using LinqToDB;

namespace WebAddressbookTests 
{
    public class AddressBookDB : LinqToDB.Data.DataConnection
    {
        public AddressBookDB() : base("AddressBook") { }

        public ITable<GroupData> Groups { get { return GetTable<GroupData>(); } }
        public ITable<AddressData> Contacts { get { return GetTable<AddressData>(); } }

    }
}
