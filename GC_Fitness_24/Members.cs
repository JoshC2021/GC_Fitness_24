using System;
using System.Collections.Generic;
using System.Text;

namespace GC_Fitness_24
{
    abstract class Members
    {
        public string id { get; set; }
        public string name { get; set; }

        public Members(string Id, string Name)
        {
            this.id = Id;
            this.name = Name;
        }

        public abstract void CheckIn(Club club);

        public override string ToString()
        {
            string output = "";
            output += $"Name: {this.name}\n";
            output += $"Id: {this.id}\n";
            return output;
        }
    }

     
}
