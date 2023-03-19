using System;
using System.Collections.Generic;
using System.Text;
using static Midterm_Fitness_Center.Club;
using static Midterm_Fitness_Center.Methods;

namespace Midterm_Fitness_Center
{
    abstract class Member
    {

        //Properties
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public double Fees { get; set; }
        public string CheckedInto { get; set; }
        public string HomeClub { get; set; }

        //abstract method will be defined by child classes
        public abstract void CheckIn(Club club, Member member);

        //AddMember will have an override in each child class
        virtual public void AddMember(List<Club> clubList, List<Member> members)
        {
            {
                FirstName = GetUserInput("\nEnter new member's First Name: ");
                LastName = GetUserInput("\nEnter new member's Last Name: ");
                DisplayClubs(clubList);
            }
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"\n\nMember ID: {Id} \nName: {FirstName} {LastName} \nFees: ${Fees}");
        }
    }
}
