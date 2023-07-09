using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMS.BL;
using BMS.DL;
using System.IO;

namespace BMS.UI
{
    class InputOutput
    {
        //Clear Function ................
        private static void clearFn()
        {
            Console.Write("Press Any Key To Continue ");
            Console.ReadKey();
            Console.Clear();
        }

        // Check String is Empty......................

        private static bool empty_String(string checkString)
        {
            if (checkString == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        // Email if Empty...................................................

        private static string enterEmptyString(string thing)
        {
            string email;
            Console.Write(thing + " Can Not be Empty \n" + "Enter " + thing + " Again :");
            email = Console.ReadLine();
            return email;
        }
        //Enter Phone No Again..................................

        private static long phoneNo_Again()
        {
            long phoneNo;
            Console.Write("Phone No(1--->11 Digits) and First digit must be \"0\" as you are living in \"Pakistan\" \nEnter Phone No(1--->11 Digts) again :");
            phoneNo = Convert.ToInt64(Console.ReadLine());
            return phoneNo;
        }
        // Enter CNIC Again......................................

        private static long CNIC_Again()
        {
            long cnic;
            Console.Write("CNIC(1--->13 Digits) and First digit must be \"3\" as you are living in \"Pakistan\" \nEnter CNIC No again(1--->13 Digits) :");
            cnic = Convert.ToInt64(Console.ReadLine());
            return cnic;
        }

        // Email Of User.................................................

        private static string enterEmail(string role)
        {
            string email;
            Console.Write("Enter Email Of " + role + " :");
            email = Console.ReadLine();
            return email;
        }

        // Email Correct Format...........................................

        private static string emailCorrectFormat()
        {
            string email;
            Console.Write("Enter Email in Correct Format(userName@gmail.com) :");
            email = Console.ReadLine();
            return email;
        }

        // Correct Option Fn..........................

        public static void correctOption()
        {
            Console.WriteLine("Option Is Not Correct ");
            Console.ReadLine();
            clearFn();
        }
        //Can Not Access Function ............................

        static public void notAccessFn()
        {
            displayBorder();
            Console.SetCursorPosition(49, 8);
            Console.WriteLine("Sorry Admin already Sign Up ");
            Console.SetCursorPosition(49, 9);
            Console.Write("Press Any Key To Continue ");
            Console.ReadKey();
            Console.Clear();
        }
        // Display Border............................
        public static void displayBorder()
        {
            string projectName = "Bank Management System";

            Console.SetCursorPosition(49,1);
            Console.WriteLine("╔════════════════════════════════╗");
            Console.SetCursorPosition(49, 2);
            Console.WriteLine("║                                ║");
            Console.SetCursorPosition(49, 3);
            Console.WriteLine("║    " + projectName + "         ║");
            Console.SetCursorPosition(49, 4);
            Console.WriteLine("║                                ║");
            Console.SetCursorPosition(49, 5);
            Console.WriteLine("╚════════════════════════════════╝");
        }                  

        //Starting Menu..........................................
        public static int Menu()
        {
            Console.SetCursorPosition(49,7);
            Console.WriteLine("1.Sign IN ");
            Console.SetCursorPosition(49, 8);
            Console.WriteLine("2.Sign UP ");
            Console.SetCursorPosition(49, 9);
            Console.WriteLine("3.Exit ");
            Console.SetCursorPosition(49, 10);
            Console.Write("Enter Option --->");
            int option = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            return option;
        }
        // SignUp Function.............................................

        public static User signUp()
        {
            Console.SetCursorPosition(49, 1);
            Console.WriteLine("---------------------- ");
            Console.SetCursorPosition(49, 2);
            Console.WriteLine("You are in as a ADMIN ");
            Console.SetCursorPosition(49, 3);
            Console.WriteLine("^--------------------^\n");
            
            Console.Write("Enter Name :");
            string name = Console.ReadLine();
            bool flag_EmptyString = empty_String(name);
            while(flag_EmptyString != true)
            {
                name = enterEmptyString("Name");
                flag_EmptyString = empty_String(name);
            }
            
            Console.Write("Enter Address :");
            string address = Console.ReadLine();
            flag_EmptyString = empty_String(address);
            while (flag_EmptyString != true)
            {
                address = enterEmptyString("Address");
                flag_EmptyString = empty_String(address);
            }

            Console.Write("Enter Phone No(1-->11 Digits) :");
            long phoneNo = Convert.ToInt64(Console.ReadLine());
            bool flag_PNo = ListsDLUser.checkPhoneNo(phoneNo);
            while(flag_PNo != true)
            {
                phoneNo = phoneNo_Again();
                flag_PNo = ListsDLUser.checkPhoneNo(phoneNo);
            }

            Console.Write("Enter CNIC (1-->13 Digits) :");
            long cnic = Convert.ToInt64(Console.ReadLine());
            bool flag_CNIC = ListsDLUser.checkCNIC(cnic);
            while(flag_CNIC != true)
            {
                cnic = CNIC_Again();
                flag_CNIC = ListsDLUser.checkCNIC(cnic);
            }

            string email = enterEmail("ADMIN");
            flag_EmptyString = empty_String(email);
            while (flag_EmptyString != true)
            {
                email = enterEmptyString("Email");
                flag_EmptyString = empty_String(email);
            }
            bool flag = ListsDLUser.checkEmail(email);

            while (flag != true)
            {
                email = emailCorrectFormat();
                flag_EmptyString = empty_String(email);
                while (flag_EmptyString != true)
                {
                    email = enterEmptyString("Email");
                    flag_EmptyString = empty_String(email);
                }
                flag = ListsDLUser.checkEmail(email);
            }

            Console.Write("Enter Password (max 1--->7 characters):");
            string password = Console.ReadLine();
            flag_EmptyString = empty_String(password);
            while (flag_EmptyString != true)
            {
                password = enterEmptyString("Password");
                flag_EmptyString = empty_String(password);
            }
            while (password.Length > 7)
            {

                Console.Write("Enter Password (max 1--->7 characters) Again :");
                password = Console.ReadLine();
            }

            User u = new User(email, password, cnic, address, phoneNo, name);
            string path = "SignIn_SignUp.txt";
            ListsDLUser.signUp_File(path,email,password,name,address,phoneNo,cnic);
            Console.WriteLine("Sign Up Successfully ");
            clearFn();
            return u;
        }
        // SignIn Function............................. 
        public static string signIn()
        {
            displayBorder();
            string email, password;
            Console.SetCursorPosition(49, 7);
            Console.Write("Enter Email :");
            email = Console.ReadLine();
            Console.SetCursorPosition(49, 8);
            Console.Write("Enter Password :");
            password = Console.ReadLine();
            string role = ListsDLUser.checkUser(email, password);
            
            role = role.ToUpper();
            if (role != " ")
            {
                Console.SetCursorPosition(49, 9);
                Console.WriteLine("Sign In Successfully As \""+ role + "\" !!!");
                Console.SetCursorPosition(49,10);
                Console.Write("Press Any Key To Continue ");
                Console.ReadKey();
                Console.Clear();
                return role;
            }
            else
            {
                Console.SetCursorPosition(49, 9);
                Console.WriteLine("User Not Present!!!");
                Console.SetCursorPosition(49, 10);
                Console.Write("Press Any Key To Continue ");
                Console.ReadKey();
                Console.Clear();
                return " ";                
            }
        }   
    }
}
