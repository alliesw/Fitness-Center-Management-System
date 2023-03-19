using System;
using System.Collections.Generic;
using System.Text;
using static Midterm_Fitness_Center.Methods;

namespace Midterm_Fitness_Center
{
    class DisplayMember
    {
        public static void DispMember(List<Member> scMemberList, List<Member> mcMemberList)
        {
            
            // Uses FindMember. Displays user info if Member is found.  If passed a null because
            // a member was NOT found, inform user.
            try
            {
                FindMember(scMemberList, mcMemberList).DisplayInfo();
            }
            catch
            {
                Console.WriteLine("Member does not exist. Cannot display info.");
            }
        }

        public static Member FindMember(List<Member> scMemberList, List<Member> mcMemberList)
        {
            // Interactive search for any kind of member.  Calls either IDsearch or NameSearch.
            // Returns a Member if found or a null if not.
            Console.Clear();
            int userSelection = UserChoice("\nWould you like to look for a member by ID number or name? \n1. ID number \n2. Name", "Invalid input! Please enter a 1 or 2.", 2);
            if (userSelection == 1)     // ID search selected by user;
            {
                int idSearch = UserChoice("\nPlease enter the ID number:", "Please enter a valid whole number", int.MaxValue);
                try
                {
                    return IDSearch(idSearch, scMemberList, mcMemberList);
                }
                catch
                {
                    Console.WriteLine($"{idSearch} was not found in the system.\n");
                }
            }
            else   // name search selected by user;
            {
                Console.WriteLine("Please enter member's first name");
                string fName = Console.ReadLine();
                Console.WriteLine("Please enter member's last name");
                string lName = Console.ReadLine();
                try
                {
                    return NameSearch(fName, lName, scMemberList, mcMemberList);
                }
                catch
                {
                    Console.WriteLine($"{fName} {lName} could not be found in the system.");
                }
            }
            return null;
        }

        public static Member IDSearch(int idSearch, List<Member> scMemberList, List<Member> mcMemberList)
        {
            // non-interactive search for any kind of member given the ID of the member.  Returns the member
            // if found.  Returns a null if not.
            int foundIt = -1;

            for (int i = 0; i < scMemberList.Count; i++)  // Search systen for ID entered
            {
                if (idSearch == scMemberList[i].Id)
                {
                    foundIt = i;    // Store index for later
                    return scMemberList[foundIt];
                }
            }
            if (foundIt == -1)  // ID not found
            {
                for (int i = 0; i < mcMemberList.Count; i++)  // Search systen for ID entered
                {
                    if (idSearch == mcMemberList[i].Id)
                    {
                        foundIt = i;    // Store index for later
                        return mcMemberList[foundIt];
                    }
                }
            }
            return null;    // ID not found on either single or multi club lists
        }

        public static Member NameSearch(string fnameSearch, string lnameSearch, List<Member> scMemberList, List<Member> mcMemberList)
        {
            // non-interactive search for any kind of member given the name of the member.  Returns the member
            // if found.  Returns a null if not.
            int foundIt = -1;

            for (int i = 0; i < scMemberList.Count; i++)  // Search systen for name entered
            {
                if (lnameSearch.Trim().ToLower() == scMemberList[i].LastName.Trim().ToLower())
                {
                    if (fnameSearch.Trim().ToLower() == scMemberList[i].FirstName.Trim().ToLower())
                    {
                        foundIt = i;    // Store index for later
                        return scMemberList[i];
                    }
                }
            }
            if (foundIt == -1)  // name not found
            {
                for (int i = 0; i < scMemberList.Count; i++)  // Search systen for name entered
                {
                    if (lnameSearch.Trim().ToLower() == mcMemberList[i].LastName.Trim().ToLower())
                    {
                        if (fnameSearch.Trim().ToLower() == mcMemberList[i].FirstName.Trim().ToLower())
                        {
                            foundIt = i;    // Store index for later
                            return mcMemberList[i];
                        }
                    }
                }
            }
            return null;    // Name not found on either list
        }
    }
}
