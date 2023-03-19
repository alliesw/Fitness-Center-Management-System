using System;
using System.Collections.Generic;
using System.Text;
using static Midterm_Fitness_Center.Methods;

namespace Midterm_Fitness_Center
{
    class SingleClubClass : Member
    {
        //default constructor
        public SingleClubClass() { }

        public int OtherGymFees { get; set; }

        //overloaded constructor
        public SingleClubClass(int id, string firstName, string lastName, string homeClub, double monthlyFees)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            HomeClub = homeClub;
            Fees = monthlyFees;
        }

        public override void CheckIn(Club club, Member toCheckIn) //sending in club and specific single member
        {
                if (club.Name == toCheckIn.HomeClub)
                {
                    toCheckIn.CheckedInto = club.Name;
                    Console.WriteLine($"\nSingle club Member {toCheckIn.FirstName} is checked in!");
                }
                else
                {
                    Console.WriteLine($"{toCheckIn.FirstName} is not a member of this club, but can drop in for $5 today!");
                    bool userContinue = UserSelection("Does the member want to pay (y/n)?", "y", "n");//userSelection utilizes an exception catch
                    if (userContinue)
                    {
                        toCheckIn.CheckedInto = club.Name;
                        Console.WriteLine($"Single club Member {toCheckIn.FirstName} is checked in!");
                        toCheckIn.Fees += 5;
                        Console.WriteLine($"$5 has been added to the {toCheckIn.FirstName}'s monthly fees. Their total for this month is ${toCheckIn.Fees}");
                    }
                }
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Home club: {HomeClub}");
        }

        public override void AddMember(List<Club> clubList, List<Member> members)
        {
            base.AddMember(clubList, members);

            int selectHomeClub = UserChoice("\nEnter the number of the club to set as the home club.", $"Please enter a number between 1-{clubList.Count}", clubList.Count);

            HomeClub = clubList[selectHomeClub - 1].Name;

            Console.WriteLine($"\n{HomeClub}, has been set as the members home club.");

            int genId = 0;
            bool duplicateFound = true;

            Random random = new Random();

            while (duplicateFound)
            {

                genId = random.Next(0, 5000);

                for (int i = 0; i < members.Count; i++)
                {
                    if (genId == members[i].Id)
                    {
                        duplicateFound = true;
                        break;
                    }
                    else
                    {
                        duplicateFound = false;
                    }
                }
            }
            Id = genId;

            Console.WriteLine($"\nThe new single member ID is: {genId}");
            Fees = 20;
        }
    }
}
