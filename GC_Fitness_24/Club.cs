using System;
using System.Collections.Generic;
using System.Text;

namespace GC_Fitness_24
{
    class Club
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public int MonthlyDue { get; set; }


        public List<Members>  MembersList { get; set; }

        public Club(string Name, string Address, int MonthlyDue)
        {
            this.Name = Name;
            this.Address = Address;
            this.MonthlyDue = MonthlyDue;
        }

        // adds a member to the list of registered members, might need to check for dupes
        public void AddMember(Members m)
        {
            MembersList.Add(m);
            if(m is SingleClub)
            {
                SingleClub temp = (SingleClub)m;
                temp.HomeClub = Name;
                //temp.ClubAddress = Address;
            }
            Console.WriteLine("Member Added");
        }

        // removes a given member from the List of members
        public void RemoveMember(Members m)
        {
            if(MembersList.Contains(m))
            {
                MembersList.Remove(m);
                Console.WriteLine("Member Removed");
            }
            {
                Console.WriteLine("Member Not Found");
            }
        }

        // prints out a given members info to the console
        public void DisplayMemberInfo(Members m)
        {
            if (MembersList.Contains(m))
            {
                Console.WriteLine($"{m}"); // need to workout what ToString override looks like
            }
            {
                Console.WriteLine("Member Not Found");
            }
        }

        // returns monthly fees due and membership points if any in a string
        public string GenerateBill(Members m)
        {

            string bill = $"{m.Name} Amount Dues: $";
            if(m is MultiClub) // membership have $40 for monthly fee
            {
                MultiClub temp = (MultiClub)m;

                bill += $"40\nMembership Points: {temp.Points}"; // need to cast
            }
            else
            {
                bill += $"{MonthlyDue.ToString()}";
            }
            return bill;
        }
    }
}
