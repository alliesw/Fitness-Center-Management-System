using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm_Fitness_Center
{
    class Bill
    {
        public static void GenerateBill(List<Member> scMemberList, List<Member> mcMemberList)
        {
            Member currentMember = DisplayMember.FindMember(scMemberList, mcMemberList);

            if (currentMember.Fees == 20)//single club mem
            {
                Console.WriteLine($"{currentMember.FirstName}'s Balance: \nMonthly Fee: ${currentMember.Fees}.00 \nAdditional Fees: $0 \nTotal Due: $20.00");
            }
            else if (currentMember.Fees == 25)//single club mem w/ diff club checkin fee
            {
                Console.WriteLine($"{currentMember.FirstName}'s Balance: \nMonthly Fee: ${currentMember.Fees - 5.00}.00 \nCheck in to non-home club: $5 \nTotal Due: $25.00");
            }
            else if (currentMember.Fees == 30)//Multiclub mem
            {
                Console.WriteLine($"{currentMember.FirstName}'s Balance: \nMonthly Fee: ${currentMember.Fees}.00 \nAdditional Fees: $0 \nTotal Due: $30.00");
            }
            else if (currentMember.Fees == 70)//single club mem w/ massage fee
            {
                Console.WriteLine($"{currentMember.FirstName}'s Balance: \nMonthly Fee: ${currentMember.Fees - 50.00}.00 \nMassage Fee: $50 \nTotal Due: $70.00");
            }
            else if (currentMember.Fees == 75)//single club mem w/ diff club checkin fee and massage fee
            {
                Console.WriteLine($"{currentMember.FirstName}'s Balance: \nMonthly Fee: ${currentMember.Fees - 55.00}.00 \nMassage Fee: $50\nCheck in to non-home club: $5 \nTotal Due: $75.00");
            }
            else if (currentMember.Fees == 80)//multi club mem w/ massage fee
            {
                Console.WriteLine($"{currentMember.FirstName}'s Balance: \nMonthly Fee: ${currentMember.Fees - 50.00}.00 \nMassage Fee: $50 \nTotal due: $80.00");
            }
            else
            {
                Console.WriteLine($"{currentMember}'s Balance: ${currentMember.Fees}.00");
            }

        }
    }
}
