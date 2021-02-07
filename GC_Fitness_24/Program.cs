using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GC_Fitness_24
{
    class Program
    {
        // LIST OF SAMPLE CLUBS
        public static List<Club> Clubs = new List<Club>()
        {
            new Club("Oregon", "35645 Somewhere", 10),
            new Club("Livonia","54735 Newburgh", 10),
            new Club("Livonia", "46756 Merriman", 12),
            new Club("Detroit", "97425 Jefferson", 19),
            new Club("Detroit","53662 Main", 25),
            new Club("Detroit", "97595 Main", 25),
            new Club("New Center", "42345 Baltimore", 21)
        };


        // LIST OF SAMPLE MEMBERS
        public static List<Members> membersList = new List<Members>()
        {
            new SingleClub("893644", "Jessica Rabbit", "Detroit"),
            new MultiClub("936420", "Donovan Bridges", 200),
            new SingleClub("324230", "Cassidy Kramer", "Livonia"),
            new SingleClub("424678", "Logan Brown", "New Center"),
            new MultiClub("876543", "Evan Evanston", 321),
            new MultiClub("660832", "Wendi Magee", 200)
        };

        static void Main(string[] args)
        {
            // INTRO
            Console.WriteLine("Welcome to GC Fitness 24. Hard bodies, sharp minds!");

            // HAVE USER SELECT WHICH CLUB THEY WOULD LIKE ACCESS TO
            Console.WriteLine("\nList of establishments: ");
            for (int i = 0; i < Clubs.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Clubs.ElementAt(i).Name}, {Clubs.ElementAt(i).Address}");
            }
            Console.Write("\nWhich club are you in (1-7):   ");
            int chooseClub = int.Parse(Console.ReadLine());
            Club establishment = Clubs.ElementAt(chooseClub - 1);
            Console.WriteLine($"\nEstablishment set to:   {establishment.Name}, {establishment.Address}");

            //MENU
            bool go = true;
            while (go)
            {
                // HAVE USER ENTER A NUMBER FOR OPTION
                Console.WriteLine("\nWhat would you like to do today?");
                Console.WriteLine("1) Check in a member.");
                Console.WriteLine("2) Search for a member");
                Console.WriteLine("3) Print out an invoice.");
                Console.WriteLine("4) Add member.");
                Console.WriteLine("5) Delete member.");
                Console.WriteLine("6) Quit");
                Console.Write("\nPlease press the number of your selection (1-6): ");

                string choice = Console.ReadLine();
                // CHECK FOR VALID INPUT
                if (CheckNum(choice, 6))
                {
                    go = true;
                }
                else
                {
                    Console.WriteLine("Unavailable option. Try again.");
                }

                // CHECK IN A MEMBER
                if (choice == "1")
                {
                    int member1 = FindMember(establishment); // return -1 if no member found
                    // validation(FindMember() == -1)
                    while (member1 == -1)
                    {
                        Console.WriteLine("\nNo member found with that name. Try again.");
                        member1 = FindMember(establishment);
                    }  
                    membersList[member1].CheckIn(establishment);
                    Console.WriteLine($"{membersList[member1].Name} checked in!");
                }

                // SEARCH FOR MEMBER AND DISPLAY INFO
                if (choice == "2")
                {
                    int member2 = FindMember(establishment); // return -1 if no member found
                    // validation(FindMember() == -1)
                    while (member2 == -1)
                    {
                        Console.WriteLine("\nNo member found with that name. Try again.");
                        member2 = FindMember(establishment);
                    }
                    Console.WriteLine();
                    Console.WriteLine(membersList[member2]);
                }

                // GENERATE BILL FOR USER
                if (choice == "3")
                {
                    int member3 = FindMember(establishment);
                    // validation(FindMember() == -1)
                    while (member3 == -1)
                    {
                        Console.WriteLine("\nNo member found with that name. Try again.");
                        member3 = FindMember(establishment);
                    }
                    string bill = $"{membersList[member3].Name} Amount Dues: $";
                    if (membersList[member3] is MultiClub) // membership have $40 for monthly fee
                    {
                        MultiClub temp = (MultiClub)membersList[member3];
                        bill += $"40\nMembership Points: {temp.Points}"; // need to cast
                    }
                    else
                    {
                        bill += $"{establishment.MonthlyDue}";
                    }
                    Console.WriteLine(bill);
                }

                // CREATE AND ADD A NEW MEMBER TO THE CLUB/LIST
                if (choice == "4")
                {
                    Console.WriteLine("Membership Options:\n" +
                        "1. Single-Club Member\n" +
                        "2. Multi-Club Member");
                    Console.Write("\nWhat kind of member is this (1-2): ");
                    string input = Console.ReadLine();
                    while((CheckNum(input, 2)) == false)
                    {
                        Console.WriteLine("\nMembership Options:\n" +
                        "1. Single-Club Member\n" +
                        "2. Multi-Club Member");
                        Console.Write("\nWhat kind of member is this (1-2): ");
                        input = Console.ReadLine();
                    }
                    if (input == "1")
                    {
                        Console.Write("\nPlease enter the member's name that you would like to add: ");
                        string name = Console.ReadLine();
                        Console.Write("\nPlease enter the member's id: ");
                        string id = Console.ReadLine();
                        membersList.Add(new SingleClub(id, name, establishment.Name));
                    }
                    if (input == "2")
                    {
                        Console.Write("\nPlease enter the member's name that you would like to add:  ");
                        string name = Console.ReadLine();
                        Console.Write("\nPlease enter the member's id:  ");
                        string id = Console.ReadLine();
                        membersList.Add(new MultiClub(id, name));
                    }
                }

                // FIND MEMBER IN CLUB THEN DELETE FROM LIST
                if (choice == "5")
                {
                    int member5 = FindMember(establishment);
                    // validation(FindMember() == -1)
                    while (member5 == -1)
                    {
                        Console.WriteLine("\nNo member found with that name. Try again.");
                        member5 = FindMember(establishment);
                    }
                    membersList.RemoveAt(member5);

                }
                // QUIT PROGRAM
                if (choice == "6")
                {
                    Console.WriteLine("Quitting program...");
                    go = false;
                }
            }
        }


        ///***********************EXTERNAL METHODS*****************************///

        // VALIDATE THE NUMBER USER INPUTTED
        static bool CheckNum(string choice, int max)
        {// validates int is a valid input 

            if (String.IsNullOrEmpty(choice))
            {
                Console.WriteLine("Please enter a valid input!");
                return false;
            }
            else
            {
                int b;
                bool valid = Int32.TryParse(choice, out b);
                if (valid && (int.Parse(choice) > 0) && (int.Parse(choice) <= max))
                {

                    return true;

                }
                else
                {
                    Console.WriteLine("Please enter a valid input!");
                    return false;
                }
            }
        }

        public static int FindMember(Club chosenClub)
        {
            Console.Write("Please enter the full name of the member:   ");
            string name = Console.ReadLine().Trim().ToLower();
            int memberIndex = -1;
            for (int i = 0; i < membersList.Count; i++)
            {
                bool isInList = (name == membersList[i].Name.ToLower());
                if (membersList[i] is SingleClub) // check to see if belongs to spefic club
                {
                    if (((SingleClub)membersList[i]).HomeClub == chosenClub.Name && isInList)
                    {
                        memberIndex = i;
                    }
                }
                else
                {
                    if(isInList)
                    {
                        memberIndex = i;
                    }
                }
            }
            return memberIndex;
        }
        static bool CheckName(string name)
        {// validates name is a valid input - Must be first and last, properly capitalized.


            if (String.IsNullOrEmpty(name))
            {
                Console.WriteLine("Please enter a valid input!");
                return false;
            }
            else
            {
                if (Regex.Match(name, "^([A-Z][a-z]+([ ]?[a-z]?['-]?[A-Z][a-z]+)*)*$").Success)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid input!");
                    return false;
                }
            }

        }

        ///***********************EXTERNAL METHODS*****************************///

    }
}