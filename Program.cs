﻿using System;
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
            obj1.firstname = "Namit";
            obj1.lastname = "Lodh";
            obj1.address = "room no-624 malligai";
            obj1.cityname = "chennai";
            obj1.state = "Tamil Nadu";
            obj1.phonenumber = "2513290657";
            obj1.zipcode = "123456";
            obj1.email = "abc@gmail.com";

            Console.WriteLine(obj1.firstname);
            Console.WriteLine(obj1.lastname);
            Console.WriteLine(obj1.address);
            Console.WriteLine(obj1.cityname);
            Console.WriteLine(obj1.state);
            Console.WriteLine(obj1.phonenumber);
            Console.WriteLine(obj1.zipcode);
            Console.WriteLine(obj1.email);
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
            public void Address(string fname, string lname, string add, string city, string st, string pnumber, string zip, string eml)
            {
                firstname = fname;
                lastname = lname;
                address = add;
                cityname = city;
                state = st;
                phonenumber = pnumber;
                zipcode= zip;
                email= eml;
            }

        }
    }
}
