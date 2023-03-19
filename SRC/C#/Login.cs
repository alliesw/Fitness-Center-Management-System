using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm_Fitness_Center
{
    class Login
    {//properties
        public string UserName { get; set; }
        public string PassWord { get; set; }

        public string StaffMemberName { get; set; }


        //default constructor
        public Login() { }

        //overloaded constructor
        public Login(string staffMemberName, string userName, string passWord)
        {
            UserName = userName;
            PassWord = passWord;
            StaffMemberName = staffMemberName;
        }


        //list of staff members username and passwrod
        public static List<Login> StaffLogin = new List<Login>
        {
            new Login ("Khyati","KhyatiPatel", "Abcd@1234"),
            new Login ("Mina","MinaStanton", "Efgh@5678"),
            new Login ("Erwin", "ErwinCoronel", "Opqr@2345"),
            new Login ("Kyle", "KyleVaughn", "Stuv@6789"),
            new Login ("John", "JohnSmith", "Hijk@3456"),
            new Login ("Test", "test", "test"),
            new Login ("Guest", "guest", "guest"),
        };


        //method for staffmember login in to system
        public static bool LoginStaff(List<Login> StaffLogin)
        {
            Console.WriteLine("Welcome to the GC Fit Login System!\n");


            bool validLogin = false;

            while (!validLogin)
            {
                Console.WriteLine("\nPlease enter your Username:");
                string userName = Console.ReadLine();
                Console.WriteLine();


                foreach (Login staff in StaffLogin)
                {
                    if (userName == staff.UserName)
                    {
                        while (!validLogin)
                        {
                            Console.WriteLine("Please enter your Password:");
                            string passWord = Console.ReadLine();
                            Console.WriteLine();
                            if (passWord == staff.PassWord)
                            {
                                Console.WriteLine($"\n{staff.StaffMemberName}, You are successfully logged in!\n");
                                validLogin = true;
                            }
                            else
                            {
                                Console.Write("\nInvalid Password \n");
                            }
                        }
                    }
                }

                if (!validLogin)
                {
                    Console.Write("\nInvalid Username \n");
                }
            }
            return validLogin;
        }
    }
}
