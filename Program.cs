using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_System
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program");
            AddressBook obj1= new AddressBook();
            
            Console.ReadLine();
        }
        class AddressBook
        {
            public string firstname;
            public string lastname;
            public string address;
            public string cityname;
            public string state;
            public string phonenumber;
            public string zipcode;
            public string email;
            public AddressBook(string fname, string lname, string addr, string city, string st, string pnumber, string zip, string eml)
            {
                firstname = fname;
                lastname = lname;
                address = addr;
                cityname = city;
                state = st;
                phonenumber = pnumber;
                zipcode= zip;
                email= eml;
            }

        }
    }
}
