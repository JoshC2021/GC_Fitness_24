using System;
using System.Collections.Generic;
using System.Text;

namespace GC_Fitness_24
{
    class MultiClub : Members
    {
        public int Points { get; set; }
        //membership type 
        public MultiClub(string id, string name, int points = 100) : base(id, name)
        {
            this.Points = points;
        }

        // Multi-Club Members: a variable that stores their membership points.        
        public override void CheckIn(Club club)
        {
            this.Points += 100;
        }

        // The CheckIn method adds to their membership points.
        public override string ToString()
        {
            string output = "";
            output += $"Name: {this.Name}\n";
            output += $"Id: {this.Id}\n";
            output += $"Balance: {this.Points} Points\n";
            return output;
        }
    }
}
