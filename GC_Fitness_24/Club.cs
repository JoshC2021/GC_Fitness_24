using System;
using System.Collections.Generic;
using System.Text;

namespace GC_Fitness_24
{
    class Club
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public List<Members>  MembersList { get; set; }

        public Club(string Name, string Address)
        {
            this.Name = Name;
            this.Address = Address;
        }

        // adds a member to the list of registered members, might need to check for dupes
        public void AddMember(Members m)
        {
            MembersList.Add(m);
            if(m is SingleClub)
            {
                (SingleClub)m.ClubName = Name;
                (SingleClub)m.ClubAddress = Address;
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

        // checks to see if member is on the list, returns true if they are, false if not
        /* idk if this class even needs to handle this
        public bool ClubCheckIn(Members m)
        {
            try
            {
                if(MembersList.Contains(m))
                {
                    m.CheckIn();
                    return true;
                }
                else
                {
                    throw new Exception("Not found on the List, Find a new club");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        */

        // returns monthly fees due and membership points if any in a string
        public string GenerateBill(Members m)
        {

            string bill = $"{m.Name} Amount Dues: 20";
            if(m is MultiClub) // not sure if this correct
            {
                bill += $"\nMembership Points: {(MultiClub)m.Points}"; // need to cast
            }
            return bill;
        }
    }
}
