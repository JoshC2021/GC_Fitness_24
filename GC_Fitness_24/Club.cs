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

    }
}
