using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm_Fitness_Center
{
    class Club
    {

        //properties
        public string Name { get; set; }
        public string Address { get; set; }

        //Default constructor
        public Club() { }

        //overloaded constructor
        public Club(string name, string address)
        {
            Name = name;
            Address = address;
        }

        //Display Club method

        public static void DisplayClubs(List<Club> clubList)
        {
            for (int i = 0; i < clubList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {clubList[i].Name}, {clubList[i].Address}");
            }
        }
    }
}
