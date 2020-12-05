using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class Developer
    {
        public string Name { get; set; }
        public string IDNumber { get; set; }
        public bool PluralsightAccess { get; set; }


        public Developer() { }

        public Developer(string name, string idNumber, bool pluralsightAccess)
        {
            Name = name;
            IDNumber = idNumber;
            PluralsightAccess = pluralsightAccess;
        }





    }
}
