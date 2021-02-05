using System;
using System.Collections.Generic;
using System.Text;

namespace GC_Fitness_24
{
    abstract class Members
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Members(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public abstract void CheckIn(Club club);

        public override string ToString()
        {
            string output = "";
            output += $"Name: {this.Name}\n";
            output += $"Id: {this.Id}\n";
            return output;
        }
    }

     
}
