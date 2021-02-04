using System;
using System.Collections.Generic;
using System.Text;

namespace GC_Fitness_24
{
    class SingleClub : Members
    {

        public string HomeClub { get; set; }
 
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
                    throw new Exception("This is not your club, you cannot check in here. Please Leave.");
                }
            }

            catch
            {
                Console.WriteLine("Something went wrong. Try again.");
                
            }
        }

}
}
