using System;
using System.Collections.Generic;

namespace GC_Fitness_24
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Club> Clubs = new List<Club>()
            {
                new Club("Oregon", "35645 Somewhere", 10),
                new Club("Livonia,","54735 Newburgh", 10),
                new Club("Livonia", "46756 Merriman", 12),
                new Club("Detroit", "97425 Jefferson", 19),
                new Club("Detroit","53662 Main", 25),
                new Club("Detroit", "97595 Main", 25),
                new Club("New Center", "42345 Baltimore", 21)
            };

            List<Members> membersList = new List<Members>();
            Members a = new SingleClub("893644", "Jessica Rabbit", "Detroit");
            Members b = new MultiClub("936420", "Donovan Bridges", 200);
            Members c = new SingleClub("324230", "Cassidy Kramer", "Livonia");
            Members d = new SingleClub("424678", "Logan Brown", "New Center");
            Members e = new MultiClub("876543", "Evan Evanston");
            Members w = new MultiClub("660832", "Wendi Magee", 200);


            Console.WriteLine("Welcome to GC Fitness 24. Hard bodies, sharp minds!");
            bool go = true;
            while (go)
            {
                Console.WriteLine("What would you like to do today?");
                Console.WriteLine("1) Check in a member.");
                Console.WriteLine("2) Search for a member");
                Console.WriteLine("3) Print out an invoice.");
                Console.WriteLine("4) Add member.");
                Console.WriteLine("5) Delete member.");
                Console.WriteLine("Please press the number of your selection.");
                string choice = Console.ReadLine();
                if (CheckNum(choice, 5))
                {
                    go = false;
                }
                else
                {
                    go = true;
                }

                if (choice == "1")
                {
                    bool go1 = true;
                    while (go1)
                    {

                        string choice1 = Console.ReadLine();
                        if (CheckNum(choice1, 5)) //CHANGE TO LIST.COUNT
                        {
                            go1 = false;
                            //CheckIn()
                        }
                        else
                        {
                            go1 = true;
                        }
                    }
                }
                if (choice == "2")
                {
                    bool go2 = true;
                    while (go2)
                    {
                        FindMember(club);
                    }
                    if (choice == "3")
                    {
                        bool go3 = true;
                        while (go3)
                        {
                            //Clubs[0].GenerateBill() a;
                            Console.WriteLine("Please enter the full name for the invoice you would like to print.");
                            string mem3 = Console.ReadLine();
                            CheckNum(mem3, 10); // CHANGE TO LIST.COUNT 
                            int member3 = int.Parse(mem3);
                            Console.WriteLine($"You have selected member {member3}. Is this correct? Y/N");
                            if (Console.ReadLine() == "y" || (Console.ReadLine() == "Y"))
                            {
                                Console.WriteLine("WHATEVER NAME AND POINTS");
                            }
                            else
                            {
                                Console.WriteLine("Sorry, I didn't get that.");
                                go = false;
                            }
                        }

                    }
                    if (choice == "4")
                    {
                        bool go4 = true;
                        while (go4)
                        {
                            Console.WriteLine("Will this member be a single or multi club member? Enter 1 for single and 2 for multi.");
                            //if (CheckNum(Console.ReadLine(), 2) = false) ;
                            Console.WriteLine("Please enter the new member's first and last name.");
                            string name = Console.ReadLine();
                            Console.WriteLine("Please enter the member number.");
                            string memNumber = Console.ReadLine();
                            Console.WriteLine("Which location are you at?");
                        }

                    }
                    if (choice == "5")
                    {
                        Console.Write("Please enter the club name: ");
                        string input = Console.ReadLine();
                        foreach (Club cl in Clubs)
                        {
                            if (cl.Name.Equals(input))
                            {
                                Console.WriteLine("Please enter the member's name that you would like to delete :");
                                input = Console.ReadLine();
                                foreach (Members m in cl.MembersList)
                                {
                                    if (m.Name.Equals(input))
                                    {
                                        cl.RemoveMember(m);
                                        Console.WriteLine("Member found and deleted.");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {

                    }

                }
            }

            static bool CheckNum(string choice, int max)
            {// validates int is a valid input 

                if (String.IsNullOrEmpty(choice))
                {
                    Console.WriteLine("Please enter a valid input!");
                    return true;
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
            public static Members FindMember(Club club)
            {
                Console.Write("Please enter the club name: ");
                string input = Console.ReadLine();
                //search club list for input
                foreach (Club cl in Clubs)
                {
                    if (cl.Name.Equals(input))
                    {
                        Console.WriteLine("Please enter the member's name that you would like to search for: ");
                        input = Console.ReadLine();
                        foreach (Members m in cl.MembersList)
                        {
                            if (m.Name.Equals(input))
                            {
                                return m;
                            }
                            else
                            {
                                Console.WriteLine("That person is not a member at this club");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("That is not a valid club location. Try again.");
                    }
                }
            }
        }





        }
    }
}
