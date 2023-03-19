using System;
using System.Collections.Generic;
using System.IO;
using static Midterm_Fitness_Center.Methods;

namespace Midterm_Fitness_Center
{
    class Program
    {
        static void Main(string[] args)
        {
            //Calling the login method from login class
             Login.LoginStaff(Login.StaffLogin);

            //reading in a list of clubs from a text file and adding them to a list of clubs
            #region club list import 
            List<Club> ClubList = new List<Club>();

            StreamReader reader = new StreamReader("../../../../Clubs.txt");
            string line = reader.ReadLine();

            while (line != null)
            {
                string[] clubArray = line.Split('|');
                Club club = new Club(clubArray[0], clubArray[1]);
                ClubList.Add(club);
                line = reader.ReadLine();
            }
            #endregion 

            //reading in a list of single members from a text file and adding them to a list of Members
            #region single member list import
            List<Member> MemberListSingle = new List<Member>();

            StreamReader readerMemberSingle = new StreamReader("../../../../SingleMembers.txt");
            string lineMemberSingle = readerMemberSingle.ReadLine();

            while (lineMemberSingle != null)
            {
                string[] memberArraySingle = lineMemberSingle.Split('|');
                Member newMemberSingle = new SingleClubClass(int.Parse(memberArraySingle[0]), memberArraySingle[1], memberArraySingle[2],
                    memberArraySingle[3], double.Parse(memberArraySingle[4]));
                MemberListSingle.Add(newMemberSingle);
                lineMemberSingle = readerMemberSingle.ReadLine();
            }
            readerMemberSingle.Close();
            #endregion

            //reading in a list of Multi members from a text file and adding them to a list of Members
            #region multi member list import
            List<Member> MemberListMulti = new List<Member>();

            StreamReader readerMemberMulti = new StreamReader("../../../../MultiMembers.txt");
            string lineMemberMulti = readerMemberMulti.ReadLine();

            while (lineMemberMulti != null)
            {
                string[] memberArrayMulti = lineMemberMulti.Split('|');
                Member newMemberMulti = new Multi_Club(int.Parse(memberArrayMulti[0]), memberArrayMulti[1], memberArrayMulti[2],
                    double.Parse(memberArrayMulti[3]), int.Parse(memberArrayMulti[4]));
                MemberListMulti.Add(newMemberMulti);
                lineMemberMulti = readerMemberMulti.ReadLine();
            }
            readerMemberMulti.Close();
            #endregion

            //loop condition to ask staff user if they would like to perform another task
            bool userContinue = true;
            while (userContinue)
            {

                int input = SelectFromLoginMenu(ClubList, MemberListSingle, MemberListMulti);
                if(input == 6)
                {
                    break;
                }

                userContinue = UserSelection("\nWould you like to perform another task? (y/n)", "y", "n");
            }

            Console.WriteLine("\nYou have successfully logged out!");
        }

        //methods


        public static int SelectFromLoginMenu(List<Club> clubList, List<Member> membersSingle, List<Member> membersMulti)
        {
            try
            {
                int select = UserChoice($"\nPlease select from the following options: \n1. Check-in a member \n2. Register a new member " +
                $"\n3. Cancel a membership \n4. Display member information \n5. Generate a bill \n6. Logout", "Invalid input! Please select between 1-6", 6);

                if (select == 1)
                {
                    Member currentMember = DisplayMember.FindMember(membersSingle, membersMulti);
                    if (currentMember == null)
                    {
                        Console.WriteLine("Member does not exist. Cannot display info.");
                    }
                    else
                    {
                        if (currentMember.HomeClub != "")
                        {
                            //send to singleClub.CheckIN
                            currentMember.CheckIn(clubList[0], currentMember);
                            StreamWriter writer = new StreamWriter("../../../../SingleMembers.txt");
                            foreach (SingleClubClass person in membersSingle)
                            {
                                writer.WriteLine($"{person.Id}|{person.FirstName}|{person.LastName}|{person.HomeClub}|{person.Fees}");
                            }
                            writer.Close();

                        }
                        else
                        {
                            //send to multiClub.checkIn
                            currentMember.CheckIn(clubList[0], currentMember);//same here will only accept a datatype Club
                            StreamWriter writer = new StreamWriter("../../../../MultiMembers.txt");
                            foreach (Multi_Club person in membersMulti)
                            {
                                writer.WriteLine($"{person.Id}|{person.FirstName}|{person.LastName}|{person.Fees}|{person.Points}");
                            }
                            writer.Close();

                        }
                    }
                }
                else if (select == 2)
                {
                    //send to Add a member abstract method in each child class
                    Console.Clear();
                    Club.DisplayClubs(clubList);
                    if (SingleOrMultiSelection() == "single")
                    {
                        Member newSingle = new SingleClubClass();
                        newSingle.AddMember(clubList, membersSingle);
                        membersSingle.Add(newSingle);
                        //write to file with the added member
                        StreamWriter writer = new StreamWriter("../../../../SingleMembers.txt");
                        foreach (SingleClubClass person in membersSingle)
                        {
                            writer.WriteLine($"{person.Id}|{person.FirstName}|{person.LastName}|{person.HomeClub}|{person.Fees}");
                        }
                        writer.Close();
                    }
                    else
                    {
                        Member newMulti = new Multi_Club();
                        newMulti.AddMember(clubList, membersMulti);
                        membersMulti.Add(newMulti);
                        //write to file with the added member
                        StreamWriter writer = new StreamWriter("../../../../MultiMembers.txt");
                        foreach (Multi_Club person in membersMulti)
                        {
                            writer.WriteLine($"{person.Id}|{person.FirstName}|{person.LastName}|{person.Fees}|{person.Points}");
                        }
                        writer.Close();
                    }
                }
                else if (select == 3)
                {
                    //send to remove a member both lists
                    RemoveMember.RmvMember(membersSingle, membersMulti);
                }
                else if (select == 4)
                {
                    //send to Display member info 
                   DisplayMember.DispMember(membersSingle, membersMulti);
                }
                else if (select == 5)
                {
                    //send to generate a bill
                    Bill.GenerateBill(membersSingle, membersMulti);
                }
                return select;//will return the int the user selects. This is important if they select 6 then it logs them out
            }
            catch
            {
                return SelectFromLoginMenu(clubList, membersSingle, membersMulti);
            }

        }
        //adding points based on if it's a checkIn or referral
        public int AddPoints()
        {
            bool select = UserSelection("Please select one to add: \n1. Check-In points \t2. Referral points", "1", "2");

            if (select == true)
            {
                return 5;
            }
            else
            {
                return 10;
            }
        }
    }
}

    

