using System;
using System.Collections.Generic;
using System.IO;

namespace GC_Fitness_24
{
    class Program
    {
        public static List<Club> Clubs = new List<Club>();

        public static List<Members> membersList = new List<Members>();
        static void Main(string[] args)
        {
            ReadClubs();
            ReadMembers();
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
                Console.WriteLine("6) Quit");
                Console.WriteLine("Please press the number of your selection.");
                string choice = Console.ReadLine();
                if (CheckNum(choice, 6))
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
                    Console.Write("Enter the name of the memebr you want to Search for: ");
                    bool go2 = true;
                    string name;
                    while (go2)
                    {// find by search
                        name = Console.ReadLine();
                        go2 = true;
                    }
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
                    Console.Write("Please enter the club name: ");
                    string input = Console.ReadLine();
                    foreach (Club cl in Clubs)
                    {
                        if (cl.Name.Equals(input))
                        {
                            Console.WriteLine("Is this member:\n" +
                                "1. Single-Club Member" +
                                "2. Multi-Club Member");
                            int num = int.Parse(Console.ReadLine());
                            if (num == 0)
                            {
                                Console.WriteLine("Please enter the member's name that you would like to add: ");
                                string name = Console.ReadLine();
                                Console.WriteLine("Please enter the member's id: ");
                                string id = Console.ReadLine();
                                cl.AddMember(new SingleClub(name, id, cl.Name));
                            }
                            if (num == 1)
                            {
                                Console.WriteLine("Please enter the member's name that you would like to add: ");
                                string name = Console.ReadLine();
                                Console.WriteLine("Please enter the member's id: ");
                                string id = Console.ReadLine();
                                cl.AddMember(new MultiClub(name, id));
                            }                        
                        }
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
                                }                                
                            }
                        }
                    }
                }
                if (choice == "6")                
                {
                    Console.WriteLine("Quitting program.");
                    go = false;
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

        // read from members textfile into list
        public static void ReadMembers()
        {
            string filePath = @"Members.txt";
            StreamReader reader;
            reader = new StreamReader(filePath);
            try
            {
                string line;
                int count = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] memberInfo = line.Split(',');
                    if(memberInfo[3] == "s") // check if given record a single or multi club
                    {
                        membersList.Add(new SingleClub(memberInfo[0],memberInfo[1],memberInfo[2]));
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
            string filePath = @"Members.txt";
            StreamWriter writer;
        }

        // read from Clubs  textfile into list
        public static void ReadClubs()
        {
            string filePath = @"Clubs.txt";
            StreamReader reader;
            reader = new StreamReader(filePath);
            try
            {
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

        // mighn not be needed
        public static void WriteClubs()
        {
            string filePath = @"Clubss.txt";
            StreamWriter writer;
        }



    }
}