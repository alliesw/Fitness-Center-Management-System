using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static Midterm_Fitness_Center.DisplayMember;
using static Midterm_Fitness_Center.Methods;

namespace Midterm_Fitness_Center
{
    class RemoveMember
    {
        public static void RmvMember(List<Member> scMemberList, List<Member> mcMemberList)
        {
            // Uses FindMember. Deletes user info (with user confirmation) if Member is found.  If passed a null because
            // a member was NOT found, inform user.  Removing a member also updates its respective listing on the member storage text file.
            try
            {
                int idFound = FindMember(scMemberList, mcMemberList).Id;    // get ID of member found
                bool isMultiClub = false;
                int foundMember = -1;
                // Find ID on the specific member list. Find out if Member is a Single or Multi Club member.
                for (int i = 0; i < scMemberList.Count; i++)    // Go through entire single club member list
                {
                    if (idFound == scMemberList[i].Id)  // Try to match ID on Single Club member list
                    {
                        isMultiClub = false;
                        foundMember = i;
                        break;
                    }
                }
                if (foundMember == -1)  // if ID was not found in single club member list
                {
                    for (int i = 0; i < mcMemberList.Count; i++)    // Go through entire multi club member list
                    {
                        if (idFound == mcMemberList[i].Id)
                        {
                            isMultiClub = true;                     // Member belongs to Multi Club member list
                            foundMember = i;
                            break;
                        }
                    }
                }
                if (isMultiClub)    // If member is a multi club member
                {
                    mcMemberList[foundMember].DisplayInfo();
                    if (UserSelection($"\n\nAre you sure you want to remove {mcMemberList[foundMember].FirstName} {mcMemberList[foundMember].LastName} from the system? [y/n]", "y", "n"))
                    {
                        // Confirms, deletes member and updates the Multi Club member list file.
                        mcMemberList.Remove(mcMemberList[foundMember]);
                        StreamWriter writer = new StreamWriter("../../../../MultiMembers.txt");
                        foreach (Multi_Club person in mcMemberList)
                        {
                            writer.WriteLine($"{person.Id}|{person.FirstName}|{person.LastName}|{person.Fees}|{person.Points}");
                        }
                        writer.Close();
                        Console.WriteLine("Member has been removed from the system");
                    }
                    else
                    {
                        Console.WriteLine("Member remove option cancelled");
                    }
                }
                else // if not a multi club member (single club)
                {
                    // Confirms, deletes member and updates the Single Member list file.
                    scMemberList[foundMember].DisplayInfo();
                    if (UserSelection($"\n\nAre you sure you want to remove {scMemberList[foundMember].FirstName} {scMemberList[foundMember].LastName} from the system? [y/n]", "y", "n"))
                    {
                        scMemberList.Remove(scMemberList[foundMember]);
                        StreamWriter writer = new StreamWriter("../../../../SingleMembers.txt");
                        foreach (SingleClubClass person in scMemberList)
                        {
                            writer.WriteLine($"{person.Id}|{person.FirstName}|{person.LastName}|{person.HomeClub}|{person.Fees}");
                        }
                        writer.Close();

                        Console.WriteLine("Member has been removed from the system");
                    }
                    else
                    {
                        Console.WriteLine("Member remove option cancelled");
                    }

                }
            }
            catch
            {
                Console.WriteLine("Member does not exist. Delete operation failed.");
            }
        }
    }
}