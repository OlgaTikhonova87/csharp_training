using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    class AccountData
    {
        // перменные в классе
        public string username; 
        public string password;

        //конструктор класса. Позволит создавать объект по этому классу
        public AccountData(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        //свойство под названием Username, для переменной username. Эти свойства позволят нам получать и присваивать данные в переменные
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
    }
}
