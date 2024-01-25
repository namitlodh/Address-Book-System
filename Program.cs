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

            AddressBook obj1 = new AddressBook();

            Console.Write("Enter First Name: ");
            obj1.firstname = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            obj1.lastname = Console.ReadLine();

            Console.Write("Enter Address: ");
            obj1.address = Console.ReadLine();

            Console.Write("Enter City: ");
            obj1.cityname = Console.ReadLine();

            Console.Write("Enter State: ");
            obj1.state = Console.ReadLine();

            Console.Write("Enter Phone Number: ");
            obj1.phonenumber = Console.ReadLine();

            Console.Write("Enter Zip Code: ");
            obj1.zipcode = Console.ReadLine();

            Console.Write("Enter Email: ");
            obj1.email = Console.ReadLine();

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
            

        }
    }
}
