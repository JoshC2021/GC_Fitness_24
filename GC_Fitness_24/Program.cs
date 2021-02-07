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
            int numberOfClubs = Clubs.Count;
            for (int i = 0; i < numberOfClubs; i++)
            {
                Console.WriteLine($"{i + 1}. {Clubs.ElementAt(i).Name}, {Clubs.ElementAt(i).Address}");
            }
            Console.Write($"\nWhich club are you in (1-{numberOfClubs}):   ");
            int chooseClub = GetNumberInRange(1,numberOfClubs);
            Club establishment = Clubs.ElementAt(chooseClub - 1);
            Console.WriteLine($"\nEstablishment set to:   {establishment.Name}, {establishment.Address}");

            //MENU
            bool isGoing = true;
            while (isGoing)
            {
                // HAVE USER ENTER A NUMBER FOR OPTION
                PrintPrompt();
                string input;
                int menuChoice = GetNumberInRange(1,6);
                
                // EXECUTING SELECTED MENU OPTION
                if (menuChoice < 6 && menuChoice >= 1)
                {
                    do
                    {
                        switch (menuChoice)
                        {
                            case 1: //Check in a user
                                Console.WriteLine("Checking in: ");
                                int member1 = FindMember(establishment); // return -1 if no member found
                                if (member1 != -1)
                                {
                                    membersList[member1].CheckIn(establishment);
                                    Console.WriteLine("Checked in");
                                }
                                else
                                {
                                    Console.WriteLine("No member found to check in");
                                }
                                Console.Write("Do you want to continue checking in members(Y/N)?");
                                break;
                            case 2: // SEARCH FOR MEMBER AND DISPLAY INFO
                                Console.WriteLine("Searching for member: ");
                                int member2 = FindMember(establishment); // return -1 if no member found
                                if (member2 == -1)
                                {
                                    Console.WriteLine("No member found with that name");
                                }
                                else
                                {
                                    Console.WriteLine(membersList[member2]);
                                }
                                Console.Write("Do you want to continue searching for members(Y/N)?");
                                break;
                            case 3: // GENERATE BILL FOR USER
                                Console.WriteLine("Generating invoice: ");
                                int member3 = FindMember(establishment);
                                if (member3 == -1)
                                {
                                    Console.WriteLine("No member found with that name");
                                }
                                else
                                {
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
                                Console.Write("Do you want to continue Printing out invoices(Y/N)?");
                                break;
                            case 4:// CREATE AND ADD A NEW MEMBER TO THE CLUB/LIST
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
                                    Console.WriteLine("New Single-Club Member added");
                                }
                                if (num == 2)
                                {
                                    Console.Write("\nPlease enter the member's name that you would like to add:  ");
                                    string name = Console.ReadLine();
                                    Console.Write("\nPlease enter the member's id:  ");
                                    string id = Console.ReadLine();
                                    membersList.Add(new MultiClub(id, name));
                                    Console.WriteLine("New Multi-Club Member added");
                                }
                                Console.Write("Do you want to continue Adding members(Y/N)?");
                                break;
                            case 5: // FIND MEMBER IN CLUB THEN DELETE FROM LIST
                                Console.WriteLine("Removing Member: ");
                                int removeIdnex = FindMember(establishment);
                                if (removeIdnex == -1)
                                {
                                    Console.WriteLine("No member found");
                                }
                                else
                                {
                                    membersList.RemoveAt(removeIdnex);
                                    Console.WriteLine("Member Removed");
                                }
                                Console.Write("Do you want to continue removing members(Y/N)?");
                                break;
                        }

                        input = Console.ReadLine();
                    } while (ConfirmSelection(input));
                }
                else// QUIT PROGRAM
                {
                    Console.WriteLine("Quitting program...");
                    isGoing = false;
                }

            }
        }


        ///***********************EXTERNAL METHODS*****************************///

        // VALIDATE THE NUMBER USER INPUTTED IN RANGE
        public static int GetNumberInRange(int x, int y)
        {
            int userNum;
            while (!int.TryParse(Console.ReadLine(), out userNum) || userNum < x || userNum > y)
            {
                Console.WriteLine($"Sorry, I need the number between {x} and {y} inclusive\n");
                Console.Write($"Please enter again: ");
            }
            return userNum;
        }

        public static int FindMember(Club chosenClub)
        {
            Console.WriteLine("Please enter the full name of the member");
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
                    if (isInList)
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

        // directs user to enter a number
        public static void PrintPrompt()
        {
            Console.WriteLine("\nWhat would you like to do today?");
            Console.WriteLine("1) Check in a member.");
            Console.WriteLine("2) Search for a member");
            Console.WriteLine("3) Print out an invoice.");
            Console.WriteLine("4) Add member.");
            Console.WriteLine("5) Delete member.");
            Console.WriteLine("6) Quit");
            Console.Write("\nPlease press the number of your selection (1-6): ");
        }

        public static bool ConfirmSelection(string s)
        {
            if (s.ToUpper().Trim() == "Y")
            {
                return true;
            }
            else if (s.ToUpper().Trim() == "N")
            {
                return false;
            }
            else
            {
                Console.Write("\nInvalid response, Please Enter Y or N: ");
                ConfirmSelection(Console.ReadLine());
            }
            return true;
        }
        ///***********************EXTERNAL METHODS*****************************///

    }
}
