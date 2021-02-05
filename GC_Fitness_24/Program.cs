﻿using System;
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
            new MultiClub("876543", "Evan Evanston"),
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
                    bool go1 = true;
                    while (go1)
                    {
                        Console.WriteLine("Which member would you like to checkout?");
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

                // SEARCH FOR MEMBER AND DISPLAY INFO
                if (choice == "2")
                {
                    bool go2 = true;
                    while (go2)
                    {// find by search

                    }
                }

                // GENERATE BILL FOR USER
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

                // CREATE AND ADD A NEW MEMBER TO THE CLUB/LIST
                if (choice == "4")
                {
                    Console.WriteLine("Membership Options:\n" +
                        "1. Single-Club Member\n" +
                        "2. Multi-Club Member");
                    Console.Write("\nWhat kind of member is this (1-2): ");
                    int num = int.Parse(Console.ReadLine());
                    if (num == 1)
                    {
                        Console.Write("\nPlease enter the member's name that you would like to add: ");
                        string name = Console.ReadLine();
                        Console.Write("\nPlease enter the member's id: ");
                        string id = Console.ReadLine();
                        membersList.Add(new SingleClub(id, name, establishment.Name));
                    }
                    if (num == 2)
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
                    Console.WriteLine("Please enter the member's name that you would like to delete :");
                    string input = Console.ReadLine();
                    for(int i = 0; i < membersList.Count; i++)
                    {
                        if (membersList.ElementAt(i).Name.Equals(input))
                        {
                            membersList.RemoveAt(i);
                        }
                    }
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
        public static void RemoveMember()
        {
            string name = Console.ReadLine().Trim().ToLower();

            //for (int i = 0; i < Member.Count; i++)
            //{
            //Member t = MemberList[i];

            //if (t.OwnerName.ToLower() == name)
            //{
            // MemberList.RemoveAt(i);
            //i--;
            //}
            //}
        }
        public static void FindMember()
        {
            string name = Console.ReadLine().Trim().ToLower();

            //for (int i = 0; i < Member.Count; i++)
            //{
            // Member t = MemberList[i];

            //if (t.ListOfMembers.ToLower() == name)
            //{
            //MemberList.ForEach(Member=>Console.Write((i)); 
            // i--;
            //}
            //}
        }

        ///***********************EXTERNAL METHODS*****************************///

    }
}