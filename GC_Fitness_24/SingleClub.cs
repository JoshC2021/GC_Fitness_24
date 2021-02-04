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
        public string HomeClub { get; set; }
        // I feel like we don't need a membershiptype bool. The different classes tell the membership type. 
        //the abstract checkin method allows different checkin methods to be used for each class
        //

        public SingleClub(string Id, string Name, string HomeClub) : base(Id, Name)
        {
            this.HomeClub = HomeClub;
        }


        public override void CheckIn(Club club)
        {
            
            try
            {
                if (club.Name == HomeClub)
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
