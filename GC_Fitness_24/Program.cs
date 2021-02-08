using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;

namespace GC_Fitness_24
{
    class Program
    {
        private const string clubFilePath = @"../../../Clubs.txt";
        private const string memberFilePath = @"../../../Members.txt";

        // LIST OF SAMPLE CLUBS
        public static List<Club> Clubs = new List<Club>();


        // LIST OF SAMPLE MEMBERS
        public static List<Members> membersList = new List<Members>();

        static void Main(string[] args)
        {
            // Populating tables
            ReadClubs();
            ReadMembers();
            // INTRO
            Console.WriteLine("Welcome to GC Fitness 24. Hard bodies, sharp minds!");

            // HAVE USER SELECT WHICH CLUB THEY WOULD LIKE ACCESS TO
            Club establishment = SelectClub();

            //MENU
            bool isGoing = true;
            while (isGoing)
            {
                // HAVE USER ENTER A NUMBER FOR OPTION
                PrintPrompt(establishment);
                string input;

                int menuChoice = -1;
                do
                {
                    input = Console.ReadLine();

                    menuChoice = CheckNum(input, 8);
                } while (menuChoice == -1);

                // EXECUTING SELECTED MENU OPTION
                if (menuChoice < 8 && menuChoice >= 1)
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
                                    if (membersList[member3] is MultiClub mc) // membership have $40 for monthly fee
                                    {


                                        bill += $"40\nMembership Points: {mc.Points}"; // need to cast
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
                                string pickNum = Console.ReadLine();
                                int num = CheckNum(pickNum, 2);
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
                            case 6: // DISPLAY ALL MEMBERS
                                Console.WriteLine("Active Members:");
                                Console.WriteLine("___________________________________");
                                foreach (Members m in membersList)
                                {
                                    if (m is SingleClub sc)
                                    {

                                        if (sc.HomeClub == establishment.Name)
                                        {
                                            Console.WriteLine(m);
                                        }
                                    }
                                    if (m is MultiClub)
                                    {
                                        Console.WriteLine(m);
                                    }
                                }
                                Console.Write("Do you want to display members again(Y/N)?");
                                break;
                            case 7: // 
                                establishment = SelectClub();
                                Console.Write($"Changing clubs... Would you like to select another club(Y/N)?");
                                break;
                        }

                        input = Console.ReadLine();
                    } while (ConfirmSelection(input));
                }
                else// QUIT PROGRAM
                {
                    Console.WriteLine("Quitting program...");
                    WriteMembers();
                    isGoing = false;
                }

            }
        }

        ///***********************EXTERNAL METHODS*****************************///
        public static Club SelectClub()
        {
            Console.WriteLine("\nList of establishments: ");
            int numberOfClubs = Clubs.Count;
            for (int i = 0; i < numberOfClubs; i++)
            {
                Console.WriteLine($"{i + 1}. {Clubs.ElementAt(i).Name}, {Clubs.ElementAt(i).Address}");
            }
            Console.Write($"\nWhich club are you in (1-{numberOfClubs}):   ");
            string userSelection;
            int chooseClub = -1;
            do
            {
                userSelection = Console.ReadLine();
                chooseClub = CheckNum(userSelection, numberOfClubs);
            } while (chooseClub == -1);

            Club establishment = Clubs.ElementAt(chooseClub - 1);
            Console.WriteLine($"\nEstablishment set to:   {establishment.Name}, {establishment.Address}");
            return establishment;
        }

        static int CheckNum(string choice, int max)
        {// validates int is a valid input 

            if (String.IsNullOrEmpty(choice))
            {
                Console.WriteLine($"Please enter a number between 1 and {max}!");
                return -1;
            }
            else
            {
                int b;
                bool valid = Int32.TryParse(choice, out b);
                if (valid && (int.Parse(choice) > 0) && (int.Parse(choice) <= max))
                {
                    return b;
                }
                else
                {
                    Console.WriteLine($"Please enter a number between 1 and {max}!");
                    return -1;
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
                if (membersList[i] is SingleClub sc) // check to see if belongs to spefic club
                {
                    if (sc.HomeClub == chosenClub.Name && isInList)
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
        public static void PrintPrompt(Club club)
        {            
            Console.WriteLine($"\nCLUB: {club.Name}");
            Console.WriteLine("\nWhat would you like to do today?");
            Console.WriteLine("1) Check in a member.");
            Console.WriteLine("2) Search for a member");
            Console.WriteLine("3) Print out an invoice.");
            Console.WriteLine("4) Add member.");
            Console.WriteLine("5) Delete member.");
            Console.WriteLine("6) Display all active members in club");
            Console.WriteLine("7) Change establishments");
            Console.WriteLine("8) Quit");
            Console.Write("\nPlease press the number of your selection (1-8): ");
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

        // read from Clubs  textfile into list
        public static void ReadClubs()
        {
            //exact amount of ../ depends on bin folder location
            string filePath = clubFilePath; 
            StreamReader reader;
            try
            {
                reader = new StreamReader(filePath);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] clubInfo = line.Split(',');
                    Clubs.Add(new Club(clubInfo[0], clubInfo[1], int.Parse(clubInfo[2])));
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }

        // read from members textfile into list
        public static void ReadMembers()
        {
            //exact amount of ../ depends on bin folder location
            string filePath = memberFilePath;
            StreamReader reader;
            try
            {
                reader = new StreamReader(filePath);
                string line;
                int count = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] memberInfo = line.Split(',');
                    if (memberInfo[3] == "s") // check if given record a single or multi club
                    {
                        membersList.Add(new SingleClub(memberInfo[0], memberInfo[1], memberInfo[2]));
                    }
                    else
                    {
                        membersList.Add(new MultiClub(memberInfo[0], memberInfo[1], int.Parse(memberInfo[4])));
                    }
                    count++;
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }

        // wrtie updates to members textfile from list
        public static void WriteMembers()
        {
            string filePath = memberFilePath;
            StreamWriter writer;
            StreamWriter append;
            //stops compiler complaining
            try
            {
                append = new StreamWriter(filePath, true);
                append.Close();
                writer = new StreamWriter(filePath);
                for (int i = 0; i < membersList.Count; i++)
                {
                    string addition = "";
                    if (membersList[i] is SingleClub)
                    {
                        SingleClub single = (SingleClub)membersList[i];
                        addition += $"{single.Id},{single.Name},{single.HomeClub},s,0";
                    }
                    else
                    {
                        MultiClub multi = (MultiClub)membersList[i];
                        addition += $"{multi.Id},{multi.Name},All,m,{multi.Points}";
                    }

                    if (i == 0)
                    {
                        writer.WriteLine(addition);
                        writer.Close();
                        append = new StreamWriter(filePath, true);
                    }
                    else
                    {
                        append.WriteLine(addition);
                    }
                }
                if (membersList.Count <= 0) // makes sure to close file if no members in List
                {
                    writer.Close();
                }
                else
                {
                    append.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }

        ///***********************EXTERNAL METHODS*****************************///

    }
    }
