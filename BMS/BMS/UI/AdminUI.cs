using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMS.BL;
using BMS.DL;
using BMS.UI;
using System.IO;

namespace BMS.UI
{
    class AdminUI
    {


        static string parseRecord(string record,int field)
        {
            int commaCount = 0;
            string item = "";
            for(int i = 0;i < record.Length; i++)
            {
                if(record[i] == ',')
                {
                    commaCount = commaCount + 1;
                }
                else if(commaCount == field)
                {
                    item = item + record[i];
                }
            }
            return item;
        }
        //Enter Phone No Again..................................

        private static long phoneNo_Again()
        {
            long phoneNo;
            Console.Write("Phone No(1--->11 Digits) and First digit must be \"0\" as you are living in \"Pakistan\" \nEnter Phone No(1--->11 Digts) again :");
            phoneNo = Convert.ToInt64(Console.ReadLine());
            return phoneNo;
        }

        //Enter Phone No Again If Already Existed.....................

        private static long phoneNo_AlreadyExisted()
        {
            long phoneNo;
            Console.Write("Enter Phone No again this \"Phone No\" is already in used :");
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

        //Enter CNIC Again IF ALready Existed............................

        private static long cnic_AlreadyExisted()
        {
            long cnic;
            Console.Write("Enter CNIC again this \"CNIC\" is already in used :");
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

        //Email Existing..................................................

        private static string existing_Email()
        {
            string emailOfUser;
            Console.Write("Enter Email Again this email already existed :");
            emailOfUser = Console.ReadLine();
            return emailOfUser;
        }

        // Email if Empty...................................................

        private static string enterEmptyString(string thing)
        {
            string email;
            Console.Write(thing + " Can Not be Empty \n" + "Enter " + thing + " Again :");
            email = Console.ReadLine();
            return email;
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

        // Display Border............................
        public static void displayBorder()
        {
            string projectName = "Bank Management System";

            Console.SetCursorPosition(49, 1);
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

        //Admin Menu....................................

        public static int adminMenu()
        {
            displayBorder();
            Console.WriteLine("1.  Add Employee");

            Console.WriteLine("2.  Display All Users Of System ");

            Console.WriteLine("3.  Update Employee Detail ");

            Console.WriteLine("4.  Remove Specific Employee ");

            Console.WriteLine("5.  Remove Specific Customer ");

            Console.WriteLine("6.  Search Specific Employee ");

            Console.WriteLine("7.  Search Specific Customer ");

            Console.WriteLine("8.  Update Personal Detail ");

            Console.WriteLine("9.  Display Personal Detail ");

            Console.WriteLine("10. Add Bank Presonal Details ");

            Console.WriteLine("11. Display Bank Details ");

            Console.WriteLine("12. Update Bank Details ");

            Console.WriteLine("13. Return To Main Screen ");

            Console.Write("Enter Option --->");
            int optionOfAdminMenu = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            return optionOfAdminMenu;
        }

        /* option 1 .........
                            ....................................*/



        // Add User by Admin..................................


        public static EmployeeBL addUserByAdmin()
        {
            displayBorder();

            Console.Write("Enter Name :");
            string name = Console.ReadLine();
            bool flag_EmptyString = empty_String(name);
            while (flag_EmptyString != true)
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
            bool flagPNoLength = EmployeeDL.checkPhoneNo(phoneNo);
            while (flagPNoLength != true)
            {
                phoneNo = phoneNo_Again();
                flagPNoLength = ListsDLUser.checkPhoneNo(phoneNo);
            }
            bool pNoFlag = ListsDLUser.checkPhonNoAlreadyExisted(phoneNo);

            while (pNoFlag != true)
            {

                phoneNo = phoneNo_AlreadyExisted();
                flagPNoLength = ListsDLUser.checkPhoneNo(phoneNo);
                while (flagPNoLength != true)
                {
                    phoneNo = phoneNo_Again();
                    flagPNoLength = ListsDLUser.checkPhoneNo(phoneNo);
                }
                pNoFlag = ListsDLUser.checkPhonNoAlreadyExisted(phoneNo);
            }

            Console.Write("Enter CNIC (1-->13 Digits) :");
            long cnic = Convert.ToInt64(Console.ReadLine());
            bool flagCNICLength = ListsDLUser.checkCNIC(cnic);
            while (flagCNICLength != true)
            {
                cnic = CNIC_Again();
                flagCNICLength = ListsDLUser.checkCNIC(cnic);
            }

            bool cnicFlag = ListsDLUser.checkCNICAlreadyExisted(cnic);

            while (cnicFlag != true)
            {

                cnic = cnic_AlreadyExisted();
                flagCNICLength = ListsDLUser.checkCNIC(cnic);
                while (flagCNICLength != true)
                {
                    cnic = CNIC_Again();
                    flagCNICLength =ListsDLUser.checkCNIC(cnic);
                }
                cnicFlag = ListsDLUser.checkCNICAlreadyExisted(cnic);
            }

            string emailOfUser = enterEmail("Employee");
            flag_EmptyString = empty_String(emailOfUser);
            while (flag_EmptyString != true)
            {
                emailOfUser = enterEmptyString("Email");
                flag_EmptyString = empty_String(emailOfUser);
            }
            bool flag = ListsDLUser.checkEmail(emailOfUser);
            while (flag != true)
            {
                emailOfUser = emailCorrectFormat();
                flag_EmptyString = empty_String(emailOfUser);
                while (flag_EmptyString != true)
                {
                    emailOfUser = enterEmptyString("Email");
                    flag_EmptyString = empty_String(emailOfUser);
                }
                flag = ListsDLUser.checkEmail(emailOfUser);
            }

            bool flag2 = ListsDLUser.checkUserAlreadyExisted(emailOfUser);
            while (flag2 != true)
            {
                emailOfUser = existing_Email();
                flag_EmptyString = empty_String(emailOfUser);
                while (flag_EmptyString != true)
                {
                    emailOfUser = enterEmptyString("Email");
                    flag_EmptyString = empty_String(emailOfUser);
                }
                flag = ListsDLUser.checkEmail(emailOfUser);
                while (flag != true)
                {
                    emailOfUser = emailCorrectFormat();
                    flag_EmptyString = empty_String(emailOfUser);
                    while (flag_EmptyString != true)
                    {
                        emailOfUser = enterEmptyString("Email");
                        flag_EmptyString = empty_String(emailOfUser);
                    }
                    flag = ListsDLUser.checkEmail(emailOfUser);

                }
                flag2 = ListsDLUser.checkUserAlreadyExisted(emailOfUser);
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
                flag_EmptyString = empty_String(password);
                while (flag_EmptyString != true)
                {
                    password = enterEmptyString("Password");
                    flag_EmptyString = empty_String(password);
                }
            }

            Console.Write("Enter Employee Id(1-->3 Characters) :");
            string employeeId = Console.ReadLine();
            flag_EmptyString = empty_String(employeeId);
            while (flag_EmptyString != true)
            {
                employeeId = enterEmptyString("Employee ID");
                flag_EmptyString = empty_String(employeeId);
            }
            while ((employeeId.Length > 3 || employeeId.Length < 1))
            {
                Console.Write("Enter Employee Id(1-->3 Characters) Again :");
                employeeId = Console.ReadLine();
                flag_EmptyString = empty_String(employeeId);
                while (flag_EmptyString != true)
                {
                    employeeId = enterEmptyString("Employee ID");
                    flag_EmptyString = empty_String(employeeId);
                }
            }
            bool flag3 = ListsDLUser.checkIdExisted(employeeId);
            while (flag3 == false)
            {
                Console.Write("Enter Employee Id(1-->3 Characters) Again:");
                employeeId = Console.ReadLine();
                flag_EmptyString = empty_String(employeeId);
                while (flag_EmptyString != true)
                {
                    employeeId = enterEmptyString("Employee ID");
                    flag_EmptyString = empty_String(employeeId);
                }
                while ((employeeId.Length > 3 || employeeId.Length < 1))
                {
                    Console.Write("Enter Employee Id(1-->3 Characters) Again :");
                    employeeId = Console.ReadLine();
                    flag_EmptyString = empty_String(employeeId);
                    while (flag_EmptyString != true)
                    {
                        employeeId = enterEmptyString("Employee ID");
                        flag_EmptyString = empty_String(employeeId);
                    }
                }
                flag3 = ListsDLUser.checkIdExisted(employeeId);
            }

            bool flag4 = ListsDLUser.checkEmployeeId(employeeId);
            while (flag4 != true)
            {
                Console.WriteLine("Employee Id Existed ");
                Console.Write("Enter New Employee Id(1-->3 Characters) Again :");
                employeeId = Console.ReadLine();
                flag_EmptyString = empty_String(employeeId);
                while (flag_EmptyString != true)
                {
                    employeeId = enterEmptyString("Employee ID");
                    flag_EmptyString = empty_String(employeeId);
                }


                while ((employeeId.Length > 3 || employeeId.Length < 1))
                {
                    Console.Write("Enter Employee Id(1-->3 Characters) Again :");
                    employeeId = Console.ReadLine();
                    flag_EmptyString = empty_String(employeeId);
                    while (flag_EmptyString != true)
                    {
                        employeeId = enterEmptyString("Employee ID");
                        flag_EmptyString = empty_String(employeeId);
                    }
                }
                flag4 = ListsDLUser.checkEmployeeId(employeeId);
            }
            Console.Write("Enter Employee Salary(15,000 ---> 60,000 Range) :");
            long employeeSalary = Convert.ToInt64(Console.ReadLine());
            while ((employeeSalary < 15000 || employeeSalary > 60000))
            {
                Console.Write("Enter Employee Salary(15,000 ---> 60,000 Range) :");
                employeeSalary = Convert.ToInt64(Console.ReadLine());
            }

            Console.WriteLine("Employee Join Date ");
            Console.Write("Enter the date in the format DDMMYY: ");
            string input = Console.ReadLine();
            flag_EmptyString = empty_String(input);
            while (flag_EmptyString != true)
            {
                input = enterEmptyString("Date");
                flag_EmptyString = empty_String(input);
            }
            bool flag6 = ListsDLUser.DOJ(input);
            if (flag6 == false)
            {

                while (flag6 == false)
                {
                    Console.Write("Invalid Date Plzz Enter Correct Date :");
                    input = Console.ReadLine();
                    flag_EmptyString = empty_String(input);
                    while (flag_EmptyString != true)
                    {
                        input = enterEmptyString("Date");
                        flag_EmptyString = empty_String(input);
                    }
                    flag6 = ListsDLUser.DOJ(input);
                }
            }


            EmployeeBL a1 = new EmployeeBL(emailOfUser, password, cnic, address, phoneNo, name, "EMPLOYEE");

            a1.setExtraEmployeeInformation(employeeId, employeeSalary, input);
            string path = "Employee.txt";
            EmployeeDL.add_EmployeesInTo_file(path,emailOfUser,password,name,address,phoneNo,cnic,employeeId,employeeSalary,input);
            Console.WriteLine("Added Successfully!!!");
            clearFn();
            return a1;

        }




        /* 2nd option of Admin Menu.....
                                       ...............*/
        public static void displayAllUsers()
        {
            Console.WriteLine("------------------------------->");

            Console.WriteLine("             Manager            ");

            Console.WriteLine("<-------------------------------");
            int i = 1;
            int j = 1;
            foreach (var a in ListsDLUser.getListOfAdminandManager())
            {
                Console.WriteLine(i + " User------------------------->\n");

                Console.WriteLine("Name :" + a.Name);
                Console.WriteLine("Email :" + a.Email);
                Console.WriteLine("Password :" + a.Password);
                Console.WriteLine("CNIC :" + a.CNIC);
                Console.WriteLine("Phone No :0" + a.PhoneNo);
                Console.WriteLine("Address :" + a.Address);

                Console.WriteLine("------------------------------->\n");
                j = i++;

            }
            Console.WriteLine("------------------------------->");

            Console.WriteLine("           Employees            ");

            Console.WriteLine("<-------------------------------\n");
            int l = 0;
            foreach (var a in EmployeeDL.getListofEmloyee())
            {
                Console.WriteLine(j + " User------------------------->\n");

                Console.WriteLine("Name :" + a.Name);
                Console.WriteLine("Email :" + a.Email);
                Console.WriteLine("Password :" + a.Password);
                Console.WriteLine("CNIC :" + a.CNIC);
                Console.WriteLine("Phone No :0" + a.PhoneNo);
                Console.WriteLine("Address :" + a.Address);
                Console.WriteLine("Employee Id :" + a.EmployeeId);
                Console.WriteLine("Emplyee Salary :" + a.Salary);
                Console.WriteLine("Employee Date Of Joining :" + a.JoinDate);

                Console.WriteLine("------------------------------->\n");

                l = j++;

            }
            Console.WriteLine("------------------------------->");

            Console.WriteLine("           Customers            ");

            Console.WriteLine("<-------------------------------\n");
            foreach (var a in CustomerDL.getListofCustomer())
            {
                Console.WriteLine(j + " User------------------------->\n");

                Console.WriteLine("Name :" + a.Name);
                Console.WriteLine("Email :" + a.Email);
                Console.WriteLine("Password :" + a.Password);
                Console.WriteLine("CNIC :" + a.CNIC);
                Console.WriteLine("Phone No :0" + a.PhoneNo);
                Console.WriteLine("Address :" + a.Address);
                Console.WriteLine("Atm Id :" + a.AtmId);
                Console.WriteLine("Atm Password :" + a.AtmPassword);
                Console.WriteLine("Bank Account Type :" + a.AccountType);
                Console.WriteLine("Total Amount :" + a.Amount);

                Console.WriteLine("------------------------------->\n");
                l++;
            }
            clearFn();
        }   
        
        private static void showEmployeeAfterUpdate(EmployeeBL a)
        {
            Console.WriteLine("------------------------------->");
            Console.WriteLine("Name :" + a.Name);
            Console.WriteLine("Email :" + a.Email);
            Console.WriteLine("Password :" + a.Password);
            Console.WriteLine("Phone No :0" + a.PhoneNo);
            Console.WriteLine("Address :" + a.Address);
            Console.WriteLine("CNIC :" + a.CNIC);
            Console.WriteLine("Employee Id :" + a.EmployeeId);
            Console.WriteLine("Emplyee Salary :" + a.Salary);
            Console.WriteLine("Employee Date Of Joining :" + a.JoinDate);
            Console.WriteLine("<-------------------------------");
        }
        public static void updateEmployeePersonnelDetails()
        {
            int option;
            Console.Write("Enter Email Of Employee You Want To Update :");
            string emailEmployee = Console.ReadLine();
            EmployeeBL a = new EmployeeBL();
            a = ListsDLUser.indexOfUser(emailEmployee);
            Console.Clear(); ;
            if (a != null)
            {
                showEmployeeAfterUpdate(a);
                do
                {
                    Console.WriteLine("1.Update Name ");
                    Console.WriteLine("2.Update Email ");
                    Console.WriteLine("3.Update Email Password ");
                    Console.WriteLine("4.Update Address ");
                    Console.WriteLine("5.Update CNIC ");
                    Console.WriteLine("6.Update Phone NO ");
                    Console.WriteLine("7.Update Employee Id (1-->3 Characters)");
                    Console.WriteLine("8.Update Customer Salray(15,000 ---> 60,000) ");
                    Console.WriteLine("9.Update Customer Date Of Joining ");
                    Console.WriteLine("10. Return To Main Screen");
                    Console.Write("Enter Choice :");
                    option = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    if (option == 1)
                    {
                        Console.Write("Enter Name :");
                        string name = Console.ReadLine();
                        bool flag_EmptyString = empty_String(name);
                        while (flag_EmptyString != true)
                        {
                            name = enterEmptyString("Name");
                            flag_EmptyString = empty_String(name);
                        }
                        a.Name = name;
                        Console.WriteLine("Information Updated Successfully!!!");
                        showEmployeeAfterUpdate(a);
                    }
                    else if (option == 2)
                    {
                        string emailOfUser = enterEmail("EMPLOYEE");
                        bool flag_EmptyString = empty_String(emailOfUser);
                        while (flag_EmptyString != true)
                        {
                            emailOfUser = enterEmptyString("Email");
                            flag_EmptyString = empty_String(emailOfUser);
                        }
                        bool flag = ListsDLUser.checkEmail(emailOfUser);
                        while (flag != true)
                        {
                            emailOfUser = emailCorrectFormat();
                            flag_EmptyString = empty_String(emailOfUser);
                            while (flag_EmptyString != true)
                            {
                                emailOfUser = enterEmptyString("Email");
                                flag_EmptyString = empty_String(emailOfUser);
                            }
                            flag = ListsDLUser.checkEmail(emailOfUser);
                        }

                        bool flag2 = ListsDLUser.checkUserAlreadyExisted(emailOfUser);
                        while (flag2 != true)
                        {
                            emailOfUser = existing_Email();
                            flag_EmptyString = empty_String(emailOfUser);
                            while (flag_EmptyString != true)
                            {
                                emailOfUser = enterEmptyString("Email");
                                flag_EmptyString = empty_String(emailOfUser);
                            }
                            flag = ListsDLUser.checkEmail(emailOfUser);
                            while (flag != true)
                            {
                                emailOfUser = emailCorrectFormat();
                                flag_EmptyString = empty_String(emailOfUser);
                                while (flag_EmptyString != true)
                                {
                                    emailOfUser = enterEmptyString("Email");
                                    flag_EmptyString = empty_String(emailOfUser);
                                }
                                flag = ListsDLUser.checkEmail(emailOfUser);

                            }
                            flag2 = ListsDLUser.checkUserAlreadyExisted(emailOfUser);
                        }
                        a.Email = emailOfUser;
                        Console.WriteLine("Information Updated Successfully!!!");
                        showEmployeeAfterUpdate(a);
                    }
                    else if (option == 3)
                    {
                        Console.Write("Enter Password (max 1--->7 characters):");
                        string password = Console.ReadLine();
                        bool flag_EmptyString = empty_String(password);
                        while (flag_EmptyString != true)
                        {
                            password = enterEmptyString("Password");
                            flag_EmptyString = empty_String(password);
                        }
                        while (password.Length > 7)
                        {

                            Console.Write("Enter Password (max 1--->7 characters) Again :");
                            password = Console.ReadLine();
                            flag_EmptyString = empty_String(password);
                            while (flag_EmptyString != true)
                            {
                                password = enterEmptyString("Password");
                                flag_EmptyString = empty_String(password);
                            }
                        }
                        a.Password = password;
                        Console.WriteLine("Information Updated Successfully!!!");
                        showEmployeeAfterUpdate(a);
                    }

                    else if (option == 4)
                    {

                        Console.Write("Enter Address :");
                        string address = Console.ReadLine();
                        bool flag_EmptyString = empty_String(address);
                        while (flag_EmptyString != true)
                        {
                            address = enterEmptyString("Address");
                            flag_EmptyString = empty_String(address);
                        }
                        a.Address = address;
                        Console.WriteLine("Information Updated Successfully!!!");
                        showEmployeeAfterUpdate(a);
                        clearFn();
                    }
                    else if (option == 5)
                    {
                        Console.Write("Enter CNIC (1-->13 Digits) :");
                        long cnic = Convert.ToInt64(Console.ReadLine());
                        bool flagCNICLength = ListsDLUser.checkCNIC(cnic);
                        while (flagCNICLength != true)
                        {
                            cnic = CNIC_Again();
                            flagCNICLength = ListsDLUser.checkCNIC(cnic);
                        }
                        bool cnicFlag = ListsDLUser.checkCNICAlreadyExisted(cnic);

                        while (cnicFlag != true)
                        {

                            cnic = cnic_AlreadyExisted();
                            flagCNICLength = ListsDLUser.checkCNIC(cnic);
                            while (flagCNICLength != true)
                            {
                                cnic = CNIC_Again();
                                flagCNICLength = ListsDLUser.checkCNIC(cnic);
                            }
                            cnicFlag = ListsDLUser.checkCNICAlreadyExisted(cnic);
                        }
                        a.CNIC = cnic;
                        Console.WriteLine("Information Updated Successfully!!!");
                        showEmployeeAfterUpdate(a);
                    }
                    else if (option == 6)
                    {

                        Console.Write("Enter Phone No(1-->11 Digits) :");
                        long phoneNo = Convert.ToInt64(Console.ReadLine());
                        bool flagPNoLength = ListsDLUser.checkPhoneNo(phoneNo);
                        while (flagPNoLength != true)
                        {
                            phoneNo = phoneNo_Again();
                            flagPNoLength = ListsDLUser.checkPhoneNo(phoneNo);
                        }
                        bool pNoFlag = ListsDLUser.checkPhonNoAlreadyExisted(phoneNo);

                        while (pNoFlag != true)
                        {

                            phoneNo = phoneNo_AlreadyExisted();
                            flagPNoLength = ListsDLUser.checkPhoneNo(phoneNo);
                            while (flagPNoLength != true)
                            {
                                phoneNo = phoneNo_Again();
                                flagPNoLength = ListsDLUser.checkPhoneNo(phoneNo);
                            }
                            pNoFlag = ListsDLUser.checkPhonNoAlreadyExisted(phoneNo);
                        }
                        a.PhoneNo = phoneNo;
                        Console.WriteLine("Information Updated Successfully!!!");
                        showEmployeeAfterUpdate(a);
                    }


                    else if (option == 7)
                    {
                        Console.Write("Enter Employee Id(1-->3 Characters) :");
                        string employeeId = Console.ReadLine();
                        bool flag_EmptyString = empty_String(employeeId);
                        while (flag_EmptyString != true)
                        {
                            employeeId = enterEmptyString("Employee ID");
                            flag_EmptyString = empty_String(employeeId);
                        }
                        while ((employeeId.Length > 3 || employeeId.Length < 1))
                        {
                            Console.Write("Enter Employee Id(1-->3 Characters) Again :");
                            employeeId = Console.ReadLine();
                            flag_EmptyString = empty_String(employeeId);
                            while (flag_EmptyString != true)
                            {
                                employeeId = enterEmptyString("Employee ID");
                                flag_EmptyString = empty_String(employeeId);
                            }
                        }
                        bool flag3 = ListsDLUser.checkIdExisted(employeeId);
                        while (flag3 == false)
                        {
                            Console.Write("Enter Employee Id(1-->3 Characters) Again:");
                            employeeId = Console.ReadLine();
                            flag_EmptyString = empty_String(employeeId);
                            while (flag_EmptyString != true)
                            {
                                employeeId = enterEmptyString("Employee ID");
                                flag_EmptyString = empty_String(employeeId);
                            }
                            while ((employeeId.Length > 3 || employeeId.Length < 1))
                            {
                                Console.Write("Enter Employee Id(1-->3 Characters) Again :");
                                employeeId = Console.ReadLine();
                                flag_EmptyString = empty_String(employeeId);
                                while (flag_EmptyString != true)
                                {
                                    employeeId = enterEmptyString("Employee ID");
                                    flag_EmptyString = empty_String(employeeId);
                                }
                            }
                            flag3 = ListsDLUser.checkIdExisted(employeeId);
                        }

                        bool flag4 = ListsDLUser.checkEmployeeId(employeeId);
                        while (flag4 != true)
                        {
                            Console.WriteLine("Employee Id Existed ");
                            Console.Write("Enter New Employee Id(1-->3 Characters) Again :");
                            employeeId = Console.ReadLine();
                            flag_EmptyString = empty_String(employeeId);
                            while (flag_EmptyString != true)
                            {
                                employeeId = enterEmptyString("Employee ID");
                                flag_EmptyString = empty_String(employeeId);
                            }


                            while ((employeeId.Length > 3 || employeeId.Length < 1))
                            {
                                Console.Write("Enter Employee Id(1-->3 Characters) Again :");
                                employeeId = Console.ReadLine();
                                flag_EmptyString = empty_String(employeeId);
                                while (flag_EmptyString != true)
                                {
                                    employeeId = enterEmptyString("Employee ID");
                                    flag_EmptyString = empty_String(employeeId);
                                }
                            }
                            flag4 = ListsDLUser.checkEmployeeId(employeeId);
                        }
                        a.EmployeeId = employeeId;
                        Console.WriteLine("Information Updated Successfully!!!");
                        showEmployeeAfterUpdate(a);
                        clearFn();
                    }
                    else if (option == 8)
                    {
                        Console.Write("Enter New Customer Salary(15,000 ---> 60,000) ");
                        long salary = Convert.ToInt64(Console.ReadLine());
                        while (salary < 15000 || salary > 60000)
                        {
                            Console.Write("Enter New Customer Salary(15,000 ---> 60,000) ");
                            salary = Convert.ToInt64(Console.ReadLine());
                        }
                        a.Salary = salary;
                        Console.WriteLine("Information Updated Successfully!!!");
                        showEmployeeAfterUpdate(a);
                    }
                    else if (option == 9)
                    {
                        Console.WriteLine("Employee Join Date ");
                        Console.Write("Enter the date in the format DDMMYY: ");
                        string input = Console.ReadLine();
                        bool flag_EmptyString = empty_String(input);
                        while (flag_EmptyString != true)
                        {
                            input = enterEmptyString("Date");
                            flag_EmptyString = empty_String(input);
                        }
                        bool flag6 = ListsDLUser.DOJ(input);
                        if (flag6 == false)
                        {

                            while (flag6 == false)
                            {
                                Console.Write("Invalid Date Plzz Enter Correct Date :");
                                input = Console.ReadLine();
                                flag_EmptyString = empty_String(input);
                                while (flag_EmptyString != true)
                                {
                                    input = enterEmptyString("Date");
                                    flag_EmptyString = empty_String(input);
                                }
                                flag6 = ListsDLUser.DOJ(input);
                            }
                        }
                        a.JoinDate = input;
                        Console.WriteLine("Information Updated Successfully!!!");
                        showEmployeeAfterUpdate(a);
                    }
                    else if (option < 7 || option > 10)
                    {
                        Console.Write("Invalid Option ");
                        Console.WriteLine("Press Any Key To Continue again");
                        Console.ReadKey();
                    }
                    clearFn();
                } while (option != 10);
            }
            else
            {
                Console.WriteLine("Employee Not Found In the System ");
                clearFn();
            }
        }
         static void displaySpecificDetailsOfEmploye(int index)
         {
                Console.WriteLine("------------------------------->");
                Console.WriteLine("Name :" + EmployeeDL.getListofEmloyee()[index].Name);
                Console.WriteLine("Email :" + EmployeeDL.getListofEmloyee()[index].Email);
                Console.WriteLine("Password :" + EmployeeDL.getListofEmloyee()[index].Password);
                Console.WriteLine("Phone No :" + EmployeeDL.getListofEmloyee()[index].PhoneNo);
                Console.WriteLine("Address :" + EmployeeDL.getListofEmloyee()[index].Address);
                Console.WriteLine("CNIC :" + EmployeeDL.getListofEmloyee()[index].CNIC);
                Console.WriteLine("Employee Id :" + EmployeeDL.getListofEmloyee()[index].EmployeeId);
                Console.WriteLine("Date Of Joining :" + EmployeeDL.getListofEmloyee()[index].JoinDate);
                Console.WriteLine("Salary :" + EmployeeDL.getListofEmloyee()[index].Salary);
                Console.WriteLine("<-------------------------------");
         }
            /*4th Option ......................
                                         .....................*/





            /* 4th Option Deletion of Employees.....
                                                .................*/

            static public void EmployeeToRemove()
        {
            Console.Write("Enter Email Of Employee You Want To Remove :");
            string email = Console.ReadLine();
            bool flag = EmployeeDL.employeeToRemove(email);
            if (flag == true)
            {
                Console.Write("Employee Deleted Successfully!!!");
            }
            else
            {
                Console.Write("Employee Not Found In System!!!");
            }
        }


        /* 5th Option Deletion of Customer.....
                                            .................*/

        static public void CustomerToRemove()
        {
            Console.Write("Enter Email Of Customer That You Want To Remove :");
            string email = Console.ReadLine();
            bool flag = CustomerDL.customerToRemove(email);
            if (flag == true)
            {
                Console.WriteLine("Customer Deleted Successfully !!!");
                clearFn();
            }
            else
            {
                Console.WriteLine("Customer Not Found In System ");
                clearFn();
            }
        }


        /*6th option search specific Employee....
                                               ............*/

        public static void searchEmployee()
        {
            Console.Write("Enter email of Emplpoyee you want To Find :");
            string email = Console.ReadLine();
            EmployeeBL a = new EmployeeBL();
            a = ListsDLUser.indexOfUser(email);

            if (a != null)
            {
                Console.WriteLine("------------------------------->");
                Console.WriteLine("Name :" + a.Name);
                Console.WriteLine("Email :" + a.Email);
                Console.WriteLine("Password :" + a.Password);
                Console.WriteLine("Phone No :0" + a.PhoneNo);
                Console.WriteLine("Address :" + a.Address);
                Console.WriteLine("CNIC :" + a.CNIC);
                Console.WriteLine("Employee Id :" + a.EmployeeId);
                Console.WriteLine("Emplyee Salary :" + a.Salary);
                Console.WriteLine("Employee Date Of Joining :" + a.JoinDate);
                Console.WriteLine("<-------------------------------");
            }
            else
            {
                Console.WriteLine("Employee Not Found In the System ");
            }
            clearFn();
        }


        /* Search Specific Customer...............
                                                 ...............*/

        public static void searchCustomer()
        {
            Console.Write("Enter email of Customer you want To Find :");
            string email = Console.ReadLine();
            CustomerBL a = ListsDLUser.indexOfUser(email, "");

            if (a != null)
            {
                Console.WriteLine("------------------------------->");
                Console.WriteLine("Name :" + a.Name);
                Console.WriteLine("Email :" + a.Email);
                Console.WriteLine("Password :" + a.Password);
                Console.WriteLine("Phone No :0" + a.PhoneNo);
                Console.WriteLine("Address :" + a.Address);
                Console.WriteLine("CNIC :" + a.CNIC);
                Console.WriteLine("ATM Password :" + a.AtmPassword);
                Console.WriteLine("Bank Account Type :" + a.AccountType);
                Console.WriteLine("Total Amount :" + a.Amount);
                Console.WriteLine("<-------------------------------");
            }
            else
            {
                Console.WriteLine("Customer Not Found In the System ");
            }
            clearFn();
        }

        /*Update Personal Details .............
                                               ............*/

        public void displaySpecificDetailsOfAdmin()
        {
            Console.WriteLine("------------------------------->");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Name :" + ListsDLUser.getListOfAdminandManager()[0].Name);
            Console.WriteLine("Email :" + ListsDLUser.getListOfAdminandManager()[0].Email);
            Console.WriteLine("Password :" + ListsDLUser.getListOfAdminandManager()[0].Password);
            Console.WriteLine("Phone No :" + ListsDLUser.getListOfAdminandManager()[0].PhoneNo);
            Console.WriteLine("Address :" + ListsDLUser.getListOfAdminandManager()[0].Address);
            Console.WriteLine("CNIC :" + ListsDLUser.getListOfAdminandManager()[0].CNIC);
            Console.WriteLine("\n--------------------------------");
            Console.WriteLine("<-------------------------------");
        }



        public void updatePersonnelDetails()
        {
            int option;
            do
            {
                Console.WriteLine("1.Update Name ");
                Console.WriteLine("2.Update Email ");
                Console.WriteLine("3.Update Email Password ");
                Console.WriteLine("4.Update Address ");
                Console.WriteLine("5.Update CNIC ");
                Console.WriteLine("6.Update Phone NO ");
                Console.WriteLine("7.Back To Main Menu ");
                Console.Write("Enter Choice :");
                option = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (option == 1)
                {
                    Console.Write("Enter Name :");
                    string name = Console.ReadLine();
                    bool flag_EmptyString = empty_String(name);
                    while (flag_EmptyString != true)
                    {
                        name = enterEmptyString("Name");
                        flag_EmptyString = empty_String(name);
                    }
                    User u = new User();
                    ListsDLUser.getListOfAdminandManager()[0].Name = name;

                    Console.WriteLine("Information Updated Successfully!!!");
                    displaySpecificDetailsOfAdmin();

                    clearFn();
                }
                else if (option == 2)
                {
                    string emailOfUser = enterEmail("ADMIN");
                    bool flag_EmptyString = empty_String(emailOfUser);
                    while (flag_EmptyString != true)
                    {
                        emailOfUser = enterEmptyString("Email");
                        flag_EmptyString = empty_String(emailOfUser);
                    }
                    bool flag = ListsDLUser.checkEmail(emailOfUser);
                    while (flag != true)
                    {
                        emailOfUser = emailCorrectFormat();
                        flag_EmptyString = empty_String(emailOfUser);
                        while (flag_EmptyString != true)
                        {
                            emailOfUser = enterEmptyString("Email");
                            flag_EmptyString = empty_String(emailOfUser);
                        }
                        flag = ListsDLUser.checkEmail(emailOfUser);
                    }

                    bool flag2 = ListsDLUser.checkUserAlreadyExisted(emailOfUser);
                    while (flag2 != true)
                    {
                        emailOfUser = existing_Email();
                        flag_EmptyString = empty_String(emailOfUser);
                        while (flag_EmptyString != true)
                        {
                            emailOfUser = enterEmptyString("Email");
                            flag_EmptyString = empty_String(emailOfUser);
                        }
                        flag = ListsDLUser.checkEmail(emailOfUser);
                        while (flag != true)
                        {
                            emailOfUser = emailCorrectFormat();
                            flag_EmptyString = empty_String(emailOfUser);
                            while (flag_EmptyString != true)
                            {
                                emailOfUser = enterEmptyString("Email");
                                flag_EmptyString = empty_String(emailOfUser);
                            }
                            flag = ListsDLUser.checkEmail(emailOfUser);

                        }
                        flag2 = ListsDLUser.checkUserAlreadyExisted(emailOfUser);
                    }
                    ListsDLUser.getListOfAdminandManager()[0].Email = emailOfUser;
                    Console.WriteLine("Information Updated Successfully!!!");
                    displaySpecificDetailsOfAdmin();
                    clearFn();
                }
                else if (option == 3)
                {
                    Console.Write("Enter Password (max 1--->7 characters):");
                    string password = Console.ReadLine();
                    bool flag_EmptyString = empty_String(password);
                    while (flag_EmptyString != true)
                    {
                        password = enterEmptyString("Password");
                        flag_EmptyString = empty_String(password);
                    }
                    while (password.Length > 7)
                    {

                        Console.Write("Enter Password (max 1--->7 characters) Again :");
                        password = Console.ReadLine();
                        flag_EmptyString = empty_String(password);
                        while (flag_EmptyString != true)
                        {
                            password = enterEmptyString("Password");
                            flag_EmptyString = empty_String(password);
                        }
                    }
                    ListsDLUser.getListOfAdminandManager()[0].Password = password;
                    Console.WriteLine("Information Updated Successfully!!!");
                    displaySpecificDetailsOfAdmin();

                    clearFn();
                }

                else if (option == 4)
                {

                    Console.Write("Enter Address :");
                    string address = Console.ReadLine();
                    bool flag_EmptyString = empty_String(address);
                    while (flag_EmptyString != true)
                    {
                        address = enterEmptyString("Address");
                        flag_EmptyString = empty_String(address);
                    }
                    ListsDLUser.getListOfAdminandManager()[0].Address = address;
                    Console.WriteLine("Information Updated Successfully!!!");
                    displaySpecificDetailsOfAdmin();
                    clearFn();
                }
                else if (option == 5)
                {
                    Console.Write("Enter CNIC (1-->13 Digits) :");
                    long cnic = Convert.ToInt64(Console.ReadLine());
                    bool flagCNICLength = ListsDLUser.checkCNIC(cnic);
                    while (flagCNICLength != true)
                    {
                        cnic = CNIC_Again();
                        flagCNICLength = ListsDLUser.checkCNIC(cnic);
                    }

                    bool cnicFlag = ListsDLUser.checkCNICAlreadyExisted(cnic);

                    while (cnicFlag != true)
                    {

                        cnic = cnic_AlreadyExisted();
                        flagCNICLength = ListsDLUser.checkCNIC(cnic);
                        while (flagCNICLength != true)
                        {
                            cnic = CNIC_Again();
                            flagCNICLength = ListsDLUser.checkCNIC(cnic);
                        }
                        cnicFlag = ListsDLUser.checkCNICAlreadyExisted(cnic);
                    }
                    ListsDLUser.getListOfAdminandManager()[0].CNIC = cnic;
                    Console.WriteLine("Information Updated Successfully!!!");
                    displaySpecificDetailsOfAdmin();
                    clearFn();
                }
                else if (option == 6)
                {
                    Console.Write("Enter Phone No(1-->11 Digits) :");
                    long phoneNo = Convert.ToInt64(Console.ReadLine());
                    bool flagPNoLength = ListsDLUser.checkPhoneNo(phoneNo);
                    while (flagPNoLength != true)
                    {
                        phoneNo = phoneNo_Again();
                        flagPNoLength = ListsDLUser.checkPhoneNo(phoneNo);
                    }
                    bool pNoFlag = ListsDLUser.checkPhonNoAlreadyExisted(phoneNo);

                    while (pNoFlag != true)
                    {

                        phoneNo = phoneNo_AlreadyExisted();
                        flagPNoLength = ListsDLUser.checkPhoneNo(phoneNo);
                        while (flagPNoLength != true)
                        {
                            phoneNo = phoneNo_Again();
                            flagPNoLength = ListsDLUser.checkPhoneNo(phoneNo);
                        }
                        pNoFlag = ListsDLUser.checkPhonNoAlreadyExisted(phoneNo);
                    }
                    ListsDLUser.getListOfAdminandManager()[0].PhoneNo = phoneNo;
                    Console.WriteLine("Information Updated Successfully!!!");
                    displaySpecificDetailsOfAdmin();
                    clearFn();
                }
                else if (option < 1 || option > 7)
                {
                    Console.WriteLine("Option Is Incorrect Try Again");
                    clearFn();
                }
            } while (option != 7);
        }
        //Enter Phone NO for Bank Again.........................

        private static long phoneNo_BankAgain()
        {
            long phoneNo;
            Console.Write("Enter Bank Phone No(1--->11 Digits) again :");
            phoneNo = Convert.ToInt64(Console.ReadLine());
            return phoneNo;
        }
        /* 10th Option Add Bank Details.....
                                            .................*/

        public static void addBankDetails()
        {
            Console.Write("Enter Bank Name :");
            string name = Console.ReadLine();
            bool flag_EmptyString = empty_String(name);
            while (flag_EmptyString != true)
            {
                name = enterEmptyString("Bank Name");
                flag_EmptyString = empty_String(name);
            }

            string emailOfBank = enterEmail("BANK");
            flag_EmptyString = empty_String(emailOfBank);
            while (flag_EmptyString != true)
            {
                emailOfBank = enterEmptyString("Bank Email");
                flag_EmptyString = empty_String(emailOfBank);
            }
            bool flag = ListsDLUser.checkEmail(emailOfBank);
            while (flag != true)
            {
                emailOfBank = emailCorrectFormat();
                flag_EmptyString = empty_String(emailOfBank);
                while (flag_EmptyString != true)
                {
                    emailOfBank = enterEmptyString("Bank Email");
                    flag_EmptyString = empty_String(emailOfBank);
                }
                flag = ListsDLUser.checkEmail(emailOfBank);
            }

            bool flag2 = ListsDLUser.checkUserAlreadyExisted(emailOfBank);
            while (flag2 != true)
            {
                emailOfBank = existing_Email();
                flag_EmptyString = empty_String(emailOfBank);
                while (flag_EmptyString != true)
                {
                    emailOfBank = enterEmptyString("Bank Email");
                    flag_EmptyString = empty_String(emailOfBank);
                }
                flag = ListsDLUser.checkEmail(emailOfBank);
                while (flag != true)
                {
                    emailOfBank = emailCorrectFormat();
                    flag_EmptyString = empty_String(emailOfBank);
                    while (flag_EmptyString != true)
                    {
                        emailOfBank = enterEmptyString("Bank Email");
                        flag_EmptyString = empty_String(emailOfBank);
                    }
                    flag = ListsDLUser.checkEmail(emailOfBank);

                }
                flag2 = ListsDLUser.checkUserAlreadyExisted(emailOfBank);
            }
            Console.Write("Enter Bank Branch Id(1-->5 characters) :");
            string bankBranchId = Console.ReadLine();
            flag_EmptyString = empty_String(bankBranchId);
            while (flag_EmptyString != true)
            {
                bankBranchId = enterEmptyString("Bank Branch Id");
                flag_EmptyString = empty_String(bankBranchId);
            }
            while (bankBranchId.Length > 5)
            {
                Console.Write("Enter Bank Branch Id(1-->5 characters) Again:");
                bankBranchId = Console.ReadLine();
                flag_EmptyString = empty_String(bankBranchId);
                while (flag_EmptyString != true)
                {
                    bankBranchId = enterEmptyString("Bank Branch Id");
                    flag_EmptyString = empty_String(bankBranchId);
                }
            }
            Console.Write("Enter Bank Address :");
            string address = Console.ReadLine();
            flag_EmptyString = empty_String(address);
            while (flag_EmptyString != true)
            {
                address = enterEmptyString("Bank Address");
                flag_EmptyString = empty_String(address);
            }

            Console.Write("Enter Bank Phone No(1-->10 Digits) :");
            long bankPhoneNo = Convert.ToInt64(Console.ReadLine());
            bool bankPNFlag = ListsDLUser.checkPhoneNoForBank(bankPhoneNo);
            while (bankPNFlag != true)
            {
                bankPhoneNo = phoneNo_BankAgain();
                bankPNFlag = ListsDLUser.checkPhoneNoForBank(bankPhoneNo);
            }
            AdminBL.setBankDetails(name, emailOfBank, bankBranchId, address, bankPhoneNo);
            Console.WriteLine("Bank Details Successfully!!!");
            clearFn();
        }

        //Not Access Bank Option..................................

        static public void notAccessForBank()
        {
            Console.WriteLine("Sorry You Already Add the Bank Details \nYou can Now Only Update Bank Details ");
            Console.Write("Press Any Key To Continue ");
            Console.ReadLine();
            clearFn();
        }

        /* 11th Option Display Bank Details.....
                                            .................*/

        public static void DisplayBankDetails()
        {
            displaybankDetailsSpecific();
            clearFn();
        }

        /* 12th Option Display Bank Details.....
                                            .................*/


        private static void displaybankDetailsSpecific()
        {
            Console.WriteLine("--------------------------->");
            Console.WriteLine("----------------------------\n");
            Console.WriteLine("Bank Name :" + AdminBL.BankName);
            Console.WriteLine("Bank Email :" + AdminBL.BankEmail);
            Console.WriteLine("Bank Branch Id :" + AdminBL.BankBranchID);
            Console.WriteLine("Bank Phone No :" + AdminBL.BankNo);
            Console.WriteLine("Bank Address :" + AdminBL.BankAdddress);
            Console.WriteLine("Updated Successfully!!!");
            Console.WriteLine("\n----------------------------");
            Console.WriteLine("--------------------------->");
        }

        public static void updateBank()
        {
            int option;
            do
            {
                Console.WriteLine("1. Update Bank Name ");
                Console.WriteLine("2. Update Bank Email ");
                Console.WriteLine("3. Update Bank Branch Id ");
                Console.WriteLine("4. Update Bank Phone No ");
                Console.WriteLine("5. Update Bank Address ");
                Console.WriteLine("6. Return To Main Screen ");
                Console.Write("Enter Option :");
                option = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (option == 1)
                {
                    Console.Write("Enter Bank Name :");
                    string name = Console.ReadLine();
                    bool flag_EmptyString = empty_String(name);
                    while (flag_EmptyString != true)
                    {
                        name = enterEmptyString("Bank Name");
                        flag_EmptyString = empty_String(name);
                    }

                    AdminBL.BankName = name;
                    displaybankDetailsSpecific();
                    clearFn();
                }
                else if (option == 2)
                {

                    string emailOfBank = enterEmail("BANK");
                    bool flag_EmptyString = empty_String(emailOfBank);
                    while (flag_EmptyString != true)
                    {
                        emailOfBank = enterEmptyString("Bank Email");
                        flag_EmptyString = empty_String(emailOfBank);
                    }
                    bool flag = ListsDLUser.checkEmail(emailOfBank);
                    while (flag != true)
                    {
                        emailOfBank = emailCorrectFormat();
                        flag_EmptyString = empty_String(emailOfBank);
                        while (flag_EmptyString != true)
                        {
                            emailOfBank = enterEmptyString("Bank Email");
                            flag_EmptyString = empty_String(emailOfBank);
                        }
                        flag = ListsDLUser.checkEmail(emailOfBank);
                    }

                    bool flag2 = ListsDLUser.checkUserAlreadyExisted(emailOfBank);
                    while (flag2 != true)
                    {
                        emailOfBank = existing_Email();
                        flag_EmptyString = empty_String(emailOfBank);
                        while (flag_EmptyString != true)
                        {
                            emailOfBank = enterEmptyString("Bank Email");
                            flag_EmptyString = empty_String(emailOfBank);
                        }
                        flag = ListsDLUser.checkEmail(emailOfBank);
                        while (flag != true)
                        {
                            emailOfBank = emailCorrectFormat();
                            flag_EmptyString = empty_String(emailOfBank);
                            while (flag_EmptyString != true)
                            {
                                emailOfBank = enterEmptyString("Bank Email");
                                flag_EmptyString = empty_String(emailOfBank);
                            }
                            flag = ListsDLUser.checkEmail(emailOfBank);

                        }
                        flag2 = ListsDLUser.checkUserAlreadyExisted(emailOfBank);
                    }
                    AdminBL.BankEmail = emailOfBank;
                    displaybankDetailsSpecific();
                    clearFn();
                }
                else if (option == 3)
                {
                    Console.Write("Enter Bank Branch Id(1-->5 characters) :");
                    string bankBranchId = Console.ReadLine();
                    bool flag_EmptyString = empty_String(bankBranchId);
                    while (flag_EmptyString != true)
                    {
                        bankBranchId = enterEmptyString("Bank Branch Id");
                        flag_EmptyString = empty_String(bankBranchId);
                    }
                    while (bankBranchId.Length > 5)
                    {
                        Console.Write("Enter Bank Branch Id(1-->5 characters) Again:");
                        bankBranchId = Console.ReadLine();
                        flag_EmptyString = empty_String(bankBranchId);
                        while (flag_EmptyString != true)
                        {
                            bankBranchId = enterEmptyString("Bank Branch Id");
                            flag_EmptyString = empty_String(bankBranchId);
                        }
                    }
                    displaybankDetailsSpecific();
                    clearFn();
                }
                else if (option == 4)
                {
                    Console.Write("Enter Bank Phone No(1-->10 Digits) :");
                    long bankPhoneNo = Convert.ToInt64(Console.ReadLine());
                    bool bankPNFlag = ListsDLUser.checkPhoneNoForBank(bankPhoneNo);
                    while (bankPNFlag != true)
                    {
                        bankPhoneNo = phoneNo_BankAgain();
                        bankPNFlag = ListsDLUser.checkPhoneNoForBank(bankPhoneNo);
                    }
                    while (bankPhoneNo == AdminBL.BankNo)
                    {
                        Console.WriteLine("Are You Kidding This Phone No Already Existed ");
                        bankPhoneNo = phoneNo_BankAgain();
                        bankPNFlag = ListsDLUser.checkPhoneNoForBank(bankPhoneNo);
                        while (bankPNFlag != true)
                        {
                            bankPhoneNo = phoneNo_BankAgain();
                            bankPNFlag = ListsDLUser.checkPhoneNoForBank(bankPhoneNo);
                        }
                    }
                    AdminBL.BankNo = bankPhoneNo;
                    displaybankDetailsSpecific();
                    clearFn();
                }
                else if (option == 5)
                {
                    Console.Write("Enter Bank Address :");
                    string address = Console.ReadLine();
                    bool flag_EmptyString = empty_String(address);
                    while (flag_EmptyString != true)
                    {
                        address = enterEmptyString("Bank Address");
                        flag_EmptyString = empty_String(address);
                    }
                    AdminBL.BankAdddress = address;
                    displaybankDetailsSpecific();
                    clearFn();
                }
            } while (option != 6);

        }

        // Correct Option Fn..........................

        public static void correctOption()
        {
            Console.WriteLine("Option Is Not Correct ");
            Console.ReadLine();
            clearFn();
        }

        //Clear Function ................
        private static void clearFn()
        {
            Console.Write("Press Any Key To Continue ");
            Console.ReadKey();
            Console.Clear();
        }


    }
}
