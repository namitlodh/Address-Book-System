﻿using Address_Book_System;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration.Attributes;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Address_Book_System.Contact;

namespace Address_Book_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program");
            Users user = new Users();
            int f = 0;
            do
            {
                Console.WriteLine("Enter an Option to perform : ");
                Console.WriteLine("1. Add a person\n2. DisplayPerson\n3. Add person details in address book\n4. Search by Name\n5. Search by City\n6. Search by State\n7. Sort according to your choice\n8. Read\n9. Write\n10. Read csv\n11. Write csv\n12. Exit");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Add the person name");
                        string name = Console.ReadLine();
                        user.AddPerson(name);
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Display the person name");
                        user.DisplayPerson();
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Enter the name of the person: ");
                        string personname = Console.ReadLine();
                        int flag = 0;
                        do
                        {
                            if (user.GetPersons().ContainsKey(personname))
                            {
                                AddressBook address = user.getAddressBook(personname);
                                Console.WriteLine("Enter an Option to perform : ");
                                Console.WriteLine("1. Add Details\n2. Display Details\n3. Edit a Contact\n4. Delete a Contact\n5. Exit");
                                int option = Convert.ToInt32(Console.ReadLine());
                                switch (option)
                                {
                                    case 1:
                                        Console.Clear();
                                        Console.WriteLine("Add details:\n");
                                        address.Add_details();
                                        Console.Clear();
                                        break;
                                    case 2:
                                        Console.Clear();
                                        Console.WriteLine("Display Details\n");
                                        address.Display_details();
                                        Thread.Sleep(8000);
                                        break;
                                    case 3:
                                        Console.Clear();
                                        Console.WriteLine("Enter name for edit the details\n");
                                        string name1 = Console.ReadLine();
                                        address.Editted_Contact(name1);
                                        break;
                                    case 4:
                                        Console.Clear();
                                        Console.WriteLine("Enter name for deleting the contact\n");
                                        string deleteName = Console.ReadLine();
                                        address.Delete(deleteName);
                                        break;
                                    case 5:
                                        Console.Clear();
                                        Console.WriteLine("Exited");
                                        flag = 1;
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("person is not listed");
                                Thread.Sleep(4000);
                                Console.Clear();
                                break;
                            }

                            Console.Clear();
                        } while (flag == 0);
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Enter the name to search");
                        string searchname = Console.ReadLine();
                        var nameResults = user.SearchPersonsInName(searchname);
                        DisplayPersonCityAndState(nameResults);
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Enter the city to search: ");
                        string searchCity = Console.ReadLine();
                        var cityResults = user.SearchPersonsInCity(searchCity);
                        DisplaySearchResults(cityResults);
                        Console.WriteLine($"Number of contacts in {searchCity}: {user.GetContactCountByCity(searchCity)}");
                        Thread.Sleep(4000);
                        Console.Clear();
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Enter the state to search: ");
                        string searchState = Console.ReadLine();
                        var stateResults = user.SearchPersonsInState(searchState);
                        DisplaySearchResults(stateResults);
                        Console.WriteLine($"Number of contacts in {searchState}: {user.GetContactCountByState(searchState)}");
                        Thread.Sleep(4000);
                        Console.Clear();
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine("Enter an option to sort contacts: ");
                        Console.WriteLine("1. Sort by Name\n2. Sort by City\n3. Sort by State\n4. Sort by Zip\n5. Exit");
                        int sortChoice = Convert.ToInt32(Console.ReadLine());
                        switch (sortChoice)
                        {
                            case 1:
                                Console.Clear();
                                var sortedByName = user.SortAllContactsByName();
                                DisplaySearchResults(sortedByName);
                                Thread.Sleep(4000);
                                Console.Clear();
                                break;
                            case 2:
                                Console.Clear();
                                var sortedbyCity= user.SortAllContactsByCity();
                                DisplaySearchResults(sortedbyCity);
                                Thread.Sleep(4000);
                                Console.Clear();
                                break;
                            case 3:
                                Console.Clear();
                                var sortedbyState= user.SortAllContactsByState();
                                DisplaySearchResults(sortedbyState);
                                Thread.Sleep(4000);
                                Console.Clear();
                                break;
                            case 4:
                                Console.Clear();
                                var sortedbyZip= user.SortAllContactsByZip();
                                DisplaySearchResults(sortedbyZip);
                                Thread.Sleep(4000);
                                Console.Clear();
                                break;
                            case 5:
                                Console.Clear();
                                Console.WriteLine("Invalid Choice! Exit");
                                Thread.Sleep(4000);
                                Console.Clear();
                                break;
                        }
                        break;
                    case 8:
                        Console.Clear();
                        LoadAddressBook();
                        Thread.Sleep(4000);
                        Console.Clear();
                        break;
                    case 9:
                        Console.Clear();
                        SaveAddressBook(user.GetPersons());
                        Thread.Sleep(4000);
                        Console.Clear();
                        break;
                    case 10:
                        Console.Clear();
                        LoadAddressBookcsv();
                        Thread.Sleep(4000);
                        Console.Clear();
                        break;
                    case 11:
                        Console.Clear();
                        SaveAddressBookcsv(user.GetPersons());
                        Thread.Sleep(4000);
                        Console.Clear();
                        break;
                    case 12:
                        Console.Clear();
                        Console.WriteLine("Exited");
                        f = 1;
                        break;
                }
            } while (f == 0);
        }

        static void DisplayPersonCityAndState(List<Contact> results)
        {
            if (results.Any())
            {
                Console.WriteLine("Search Results:");
                foreach (var contact in results)
                { 
                    Console.WriteLine($"City: {contact.City}");
                    Console.WriteLine($"State: {contact.State}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No matching contacts found.");
            }
        }
        static void DisplaySearchResults(List<Contact> results)
        {
            if (results.Any())
            {
                Console.WriteLine("Search Results:");
                foreach (var contact in results)
                {
                    Console.WriteLine($"First Name: {contact.Firstname}");
                    Console.WriteLine($"Last Name: {contact.Lastname}");
                    Console.WriteLine($"Address: {contact.Address}");
                    Console.WriteLine($"City: {contact.City}");
                    Console.WriteLine($"State: {contact.State}");
                    Console.WriteLine($"Phone: {contact.Phonenumber}");
                    Console.WriteLine($"Email: {contact.Email}");
                    Console.WriteLine($"Zipcode: {contact.Zipcode}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No matching contacts found.");
            }
        }
        static void SaveAddressBook(Dictionary<string, AddressBook> addressBooks)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Users\dell\source\repos\Address Book System\Address Book System\contacts.txt"))
                {
                    foreach (var entry in addressBooks)
                    {
                        writer.WriteLine($"Address Book for: {entry.Key}");
                        foreach (var contact in entry.Value.GetAllContacts())
                        {
                            writer.WriteLine($"First Name: {contact.Firstname}");
                            writer.WriteLine($"Last Name: {contact.Lastname}");
                            writer.WriteLine($"Address: {contact.Address}");
                            writer.WriteLine($"City: {contact.City}");
                            writer.WriteLine($"State: {contact.State}");
                            writer.WriteLine($"Phone: {contact.Phonenumber}");
                            writer.WriteLine($"Email: {contact.Email}");
                            writer.WriteLine($"Zipcode: {contact.Zipcode}");
                            writer.WriteLine();
                        }
                        writer.WriteLine();
                    }
                }
                Console.WriteLine("Address book data has been saved to 'contacts.txt'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while saving address book data: {ex.Message}");
            }
        }
        static Dictionary<string, AddressBook> LoadAddressBook()
        {
            Dictionary<string, AddressBook> addressBooks = new Dictionary<string, AddressBook>();
            try
            {
                using (StreamReader reader = new StreamReader(@"C:\Users\dell\source\repos\Address Book System\Address Book System\contacts.txt"))
                {
                    string line;
                    string currentName = "";
                    AddressBook currentAddressBook = null;

                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] data = line.Split(' '); 
                        if (data.Length >= 8)
                        {
                            Contact contact = new Contact
                            {
                                Firstname = data[0],
                                Lastname = data[1],
                                Address = data[2],
                                City = data[3],
                                State = data[4],
                                Zipcode = Convert.ToInt64(data[5]),
                                Phonenumber = data[6],
                                Email = data[7]
                            };
                        }
                        Console.WriteLine(line);
                    }
                    if (currentAddressBook != null)
                    {
                        addressBooks.Add(currentName, currentAddressBook);
                    }
                }
                Console.WriteLine("Address book data has been loaded from 'contacts.txt'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while loading address book data: {ex.Message}");
            }
            return addressBooks;
        }
        static void SaveAddressBookcsv(Dictionary<string, AddressBook> addressBooks)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Users\dell\source\repos\Address Book System\Address Book System\contacts.csv"))
                using (CsvWriter csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    foreach (var entry in addressBooks)
                    {
                        csv.WriteField($"Address Book for: {entry.Key}");
                        csv.NextRecord();
                        csv.WriteRecords(entry.Value.GetAllContacts());
                        csv.NextRecord();
                    }
                }
                Console.WriteLine("Address book data has been saved to 'contacts.csv'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while saving address book data: {ex.Message}");
            }
        }
        static public void LoadAddressBookcsv()
        {
            try
            {
                using (StreamReader reader = new StreamReader(@"C:\Users\dell\source\repos\Address Book System\Address Book System\contacts.csv"))
                using (CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    while (csv.Read())
                    {
                        string firstField = csv.GetField(0);
                        if (firstField.StartsWith("Address Book for:"))
                        {
                            string addressBookName = firstField.Replace("Address Book for: ", "");
                            Console.WriteLine($"Address Book: {addressBookName}");
                            continue; 
                        }
                        var record = csv.GetRecord<Contact>();
                        Console.WriteLine(record.Firstname + " " + record.Lastname + " " + record.Phonenumber + " " + record.Address + " " + record.City + " " + record.State + " " + record.Email + " " + record.Zipcode);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while loading address book data: {ex.Message}");
            }
        }


    }
}
