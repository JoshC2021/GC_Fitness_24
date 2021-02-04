using System;
using System.Collections.Generic;
using System.Text;

namespace GC_Fitness_24
{
    class MultiClub : Members
    {
        public int points { get; set; }
        public MultiClub(string Name, string Id, int Points) : base(Name, Id)
        {
            this.points = Points;
        }

        // Multi-Club Members: a variable that stores their membership points.        
        public override void CheckIn(Club club)
        {
            this.points += 100;
        }

        // The CheckIn method adds to their membership points.
        public override string ToString()
        {
            string output = "";
            output += $"Name: {this.name}\n";
            output += $"Id: {this.id}\n";
            output += $"Balance: {this.points} Points\n";
            return output;
        }
    }
}
