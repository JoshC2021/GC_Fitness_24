using System;
using System.Collections.Generic;
using System.Text;

namespace GC_Fitness_24
{
    class SingleClub : Members
    {
        /*A minimum of two child classes that represent a Single Club Member and Multi-Club Members(these members can visit various locations using the same membership).
         * The classes should have the following:
        Single Club Members: a variable that assigns them to a club.The CheckIn method throws an exception if it’s not their club.*/
        public string ClubName { get; set; }
        public bool MembershipType { get; set; }

        public SingleClub(string Id, string Name, string ClubName) : base(Id, Name)
        {
            this.ClubName = ClubName;
            this.MembershipType = false;

        }


        public override void CheckIn(Club club)
        {
            string currentClub = "";
            try
            {
                if (club.Name == currentClub)
                {
                    Console.WriteLine("You are successfully checked in");
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                Console.WriteLine("This is not your club, you cannot check in here. Please Leave.");
            }
        }

}
}
