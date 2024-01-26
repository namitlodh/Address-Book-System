using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_System
{
    class Contact
    {
        public string firstname;
        public string lastname;
        public long phonenumber;
        public string email;
    }
    class AddressBook: Contact
    {
        public string address;
        public string cityname;
        public string state;
        public long zipcode;
        public AddressBook(string fname, string lname, string add, string city, string st, long pnumber, long zip, string eml)
        {
            firstname = fname;
            lastname = lname;
            address = add;
            cityname = city;
            state = st;
            phonenumber = pnumber;
            zipcode = zip;
            email = eml;

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program");


            Console.Write("Enter First Name: ");
            string firstname = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            string lastname = Console.ReadLine();

            Console.Write("Enter Address: ");
            string address = Console.ReadLine();

            Console.Write("Enter City: ");
            string cityname = Console.ReadLine();

            Console.Write("Enter State: ");
            string state = Console.ReadLine();

            Console.Write("Enter Phone Number: ");
            long  phonenumber = Convert.ToInt64(Console.ReadLine());

            Console.Write("Enter Zip Code: ");
            long zipcode = Convert.ToInt64(Console.ReadLine());

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            AddressBook obj1 = new AddressBook (firstname, lastname, address, cityname, state, phonenumber, zipcode, email);

            Console.WriteLine("\nEntered Details:");
            Console.WriteLine("First Name: " + obj1.firstname);
            Console.WriteLine("Last Name: " + obj1.lastname);
            Console.WriteLine("Address: " + obj1.address);
            Console.WriteLine("City: " + obj1.cityname);
            Console.WriteLine("State: " + obj1.state);
            Console.WriteLine("Phone Number: " + obj1.phonenumber);
            Console.WriteLine("Zip Code: " + obj1.zipcode);
            Console.WriteLine("Email: " + obj1.email);

            Console.ReadLine();
        }
    }
}

