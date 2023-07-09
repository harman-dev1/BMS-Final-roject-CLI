using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMS.BL;
using BMS.DL;
using BMS.UI;

namespace BMS.UI
{
    class EmployeeUI
    {
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

        //Clear Function ................
        private static void clearFn()
        {
            Console.Write("Press Any Key To Continue ");
            Console.ReadKey();
            Console.Clear();
        }
        // Employee Functions and Menu....................


        public static int employeeMenu()
        {
            Console.WriteLine("1. Add Customer ");
            Console.WriteLine("2. Search Customer ");
            Console.WriteLine("3. Transaction Total Amount ");
            Console.WriteLine("4. Display Personal Details ");
            Console.WriteLine("5. Update Persoanal Details ");
            Console.WriteLine("6. See Bank Details ");
            Console.WriteLine("7. Return To Main Screen ");
            Console.Write("Enter Option --->");
            int employeeMenuOption = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            return employeeMenuOption;
        }

        // Add Customer By Employee................


        static public CustomerBL addCustomer()
        {
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
                flagPNoLength = EmployeeDL.checkPhoneNo(phoneNo);
            }
            bool pNoFlag = EmployeeDL.checkPhonNoAlreadyExisted(phoneNo);

            while (pNoFlag != true)
            {

                phoneNo = phoneNo_AlreadyExisted();
                flagPNoLength = EmployeeDL.checkPhoneNo(phoneNo);
                while (flagPNoLength != true)
                {
                    phoneNo = phoneNo_Again();
                    flagPNoLength = EmployeeDL.checkPhoneNo(phoneNo);
                }
                pNoFlag = EmployeeDL.checkPhonNoAlreadyExisted(phoneNo);
            }

            Console.Write("Enter CNIC (1-->13 Digits) :");
            long cnic = Convert.ToInt64(Console.ReadLine());
            bool flagCNICLength = EmployeeDL.checkCNIC(cnic);
            while (flagCNICLength != true)
            {
                cnic = CNIC_Again();
                flagCNICLength = EmployeeDL.checkCNIC(cnic);
            }

            bool cnicFlag = EmployeeDL.checkCNICAlreadyExisted(cnic);

            while (cnicFlag != true)
            {

                cnic = cnic_AlreadyExisted();
                flagCNICLength = EmployeeDL.checkCNIC(cnic);
                while (flagCNICLength != true)
                {
                    cnic = CNIC_Again();
                    flagCNICLength = EmployeeDL.checkCNIC(cnic);
                }
                cnicFlag = EmployeeDL.checkCNICAlreadyExisted(cnic);
            }

            string emailOfUser = enterEmail("CUSTOMER");
            flag_EmptyString = empty_String(emailOfUser);
            while (flag_EmptyString != true)
            {
                emailOfUser = enterEmptyString("Email");
                flag_EmptyString = empty_String(emailOfUser);
            }
            bool flag = EmployeeDL.checkEmail(emailOfUser);
            while (flag != true)
            {
                emailOfUser = emailCorrectFormat();
                flag_EmptyString = empty_String(emailOfUser);
                while (flag_EmptyString != true)
                {
                    emailOfUser = enterEmptyString("Email");
                    flag_EmptyString = empty_String(emailOfUser);
                }
                flag = EmployeeDL.checkEmail(emailOfUser);
            }

            bool flag2 = EmployeeDL.checkUserAlreadyExisted(emailOfUser);
            while (flag2 != true)
            {
                emailOfUser = existing_Email();
                flag_EmptyString = empty_String(emailOfUser);
                while (flag_EmptyString != true)
                {
                    emailOfUser = enterEmptyString("Email");
                    flag_EmptyString = empty_String(emailOfUser);
                }
                flag = EmployeeDL.checkEmail(emailOfUser);
                while (flag != true)
                {
                    emailOfUser = emailCorrectFormat();
                    flag_EmptyString = empty_String(emailOfUser);
                    while (flag_EmptyString != true)
                    {
                        emailOfUser = enterEmptyString("Email");
                        flag_EmptyString = empty_String(emailOfUser);
                    }
                    flag = EmployeeDL.checkEmail(emailOfUser);

                }
                flag2 = EmployeeDL.checkUserAlreadyExisted(emailOfUser);
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

            Console.Write("Enter ATM ID (****-****-*) :");
            string ATMID = Console.ReadLine();
            flag_EmptyString = empty_String(ATMID);
            while (flag_EmptyString != true)
            {
                ATMID = enterEmptyString("ATM ID");
                flag_EmptyString = empty_String(ATMID);
            }
            bool flag_AtmIdFormat = EmployeeDL.atmIDFormat(ATMID);
            while (flag_AtmIdFormat != true)
            {
                Console.Write("Enter ATM ID (****-****-*) again:");
                ATMID = Console.ReadLine();
                flag_EmptyString = empty_String(ATMID);
                while (flag_EmptyString != true)
                {
                    ATMID = enterEmptyString("ATM ID");
                    flag_EmptyString = empty_String(ATMID);
                }
                flag_AtmIdFormat = EmployeeDL.atmIDFormat(ATMID);
            }
            bool flag_ = EmployeeDL.checkATMIdAlreadyExisted(ATMID);
            while (flag_ == false)
            {
                Console.Write("Enter ATM ID (****-****-*) Again Previous one already existed:");
                ATMID = Console.ReadLine();
                flag_EmptyString = empty_String(ATMID);
                while (flag_EmptyString != true)
                {
                    ATMID = enterEmptyString("ATM ID");
                    flag_EmptyString = empty_String(ATMID);
                }
                flag_AtmIdFormat = EmployeeDL.atmIDFormat(ATMID);
                while (flag_AtmIdFormat != true)
                {
                    Console.Write("Enter ATM ID (****-****-*) again:");
                    ATMID = Console.ReadLine();
                    flag_EmptyString = empty_String(ATMID);
                    while (flag_EmptyString != true)
                    {
                        ATMID = enterEmptyString("ATM ID");
                        flag_EmptyString = empty_String(ATMID);
                    }
                    flag_AtmIdFormat = EmployeeDL.atmIDFormat(ATMID);
                }
                EmployeeDL.atmIDFormat(ATMID);
                flag_ = EmployeeDL.checkATMIdAlreadyExisted(ATMID);
            }
            Console.Write("Enter Password(1--->4 Digits) :");
            int ATMPassword = Convert.ToInt32(Console.ReadLine());

            bool flag_AtmPassword = EmployeeDL.atmPasswordLength(ATMPassword);

            while (flag_AtmPassword != true)
            {
                ATMPassword = ATM_PasswordInput();
                flag_AtmPassword = EmployeeDL.atmPasswordLength(ATMPassword);
            }

            string accountType;
            Console.WriteLine("There Are Two Account In Bank First Saving Account and second Current Account \n Current Account : You can deposit or can Transfer Money \n Saving Account : You can only Save Money ");
            Console.Write("Enter Account Type :");
            accountType = Console.ReadLine();
            flag_EmptyString = empty_String(accountType);
            while (flag_EmptyString != true)
            {
                accountType = enterEmptyString("Account Type");
                flag_EmptyString = empty_String(accountType);
            }
            accountType = accountType.ToUpper();
            while (accountType != "SAVING" && accountType != "CURRENT")
            {
                Console.Write("Enter Account Type(current or savings) :");
                accountType = Console.ReadLine();
                flag_EmptyString = empty_String(accountType);
                while (flag_EmptyString != true)
                {
                    accountType = enterEmptyString("Account Type");
                    flag_EmptyString = empty_String(accountType);
                }
            }
            long amount = 0;
            CustomerBL e1 = new CustomerBL(emailOfUser, password, cnic, address, phoneNo, name, "customer");
            e1.SetAtmForCustomer(ATMID, ATMPassword, accountType, amount);
            string path = "CustomerList.txt";
            CustomerDL.add_CustomersInTo_file(path,emailOfUser,password,name,address,phoneNo,cnic,ATMID,ATMPassword,accountType,amount);
            Console.WriteLine("Added Successfully!!!");
            clearFn();
            return e1;
        }

        //Enter Password Of ATM ...............................

        private static int ATM_PasswordInput()
        {
            int password;
            Console.Write("Enter ATM Password (1--->4 Digits) again :");
            password = Convert.ToInt32(Console.ReadLine());
            return password;
        }

        //Display Total Transactions...................................

        public static void transactionReport()
        {
            long total = EmployeeDL.transactionReport();
            Console.WriteLine("Total Amount in Accounts of Customers:" + total);
            clearFn();
        }

        /* Search Specific Customer...............
                                                 ...............*/

        public static void searchCustomer()
        {
            Console.Write("Enter email of Customer you want To Find :");
            string email = Console.ReadLine();
            CustomerBL a = EmployeeDL.indexOfUser(email);

            if (a != null)
            {
                Console.WriteLine("------------------------------->");
                Console.WriteLine("Name :" + a.Name);
                Console.WriteLine("Email :" + a.Email);
                Console.WriteLine("Phone No :0" + a.PhoneNo);
                Console.WriteLine("Address :" + a.Address);
                Console.WriteLine("CNIC :" + a.CNIC);
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

        //Display Employee Personnal Details...................................

        //Display Employee Personnal Details After Update....................................


        static public void displaySpecificDetailsOfEmployee(int index)
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
        static public void displayEmpolyeePersonalDetails()
        {
            int i = 0;
            foreach (var a in EmployeeDL.getListofEmloyee())
            {
                if (i == EmployeeDL.specificIndexForEmployee)
                {
                    displaySpecificDetailsOfEmployee(i);
                }
                i++;
            }
            clearFn();
        }

        public static void updateEmployeePersonnelDetails()
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
                Console.WriteLine("7.Return To Main Screen");
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

                    EmployeeDL.updateName(name);
                    Console.WriteLine("Information Updated Successfully!!!");
                    displaySpecificDetailsOfEmployee(EmployeeDL.specificIndexForEmployee);
                    
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
                    bool flag = EmployeeDL.checkEmail(emailOfUser);
                    while (flag != true)
                    {
                        emailOfUser = emailCorrectFormat();
                        flag_EmptyString = empty_String(emailOfUser);
                        while (flag_EmptyString != true)
                        {
                            emailOfUser = enterEmptyString("Email");
                            flag_EmptyString = empty_String(emailOfUser);
                        }
                        flag = EmployeeDL.checkEmail(emailOfUser);
                    }

                    bool flag2 = EmployeeDL.checkUserAlreadyExisted(emailOfUser);
                    while (flag2 != true)
                    {
                        emailOfUser = existing_Email();
                        flag_EmptyString = empty_String(emailOfUser);
                        while (flag_EmptyString != true)
                        {
                            emailOfUser = enterEmptyString("Email");
                            flag_EmptyString = empty_String(emailOfUser);
                        }
                        flag = EmployeeDL.checkEmail(emailOfUser);
                        while (flag != true)
                        {
                            emailOfUser = emailCorrectFormat();
                            flag_EmptyString = empty_String(emailOfUser);
                            while (flag_EmptyString != true)
                            {
                                emailOfUser = enterEmptyString("Email");
                                flag_EmptyString = empty_String(emailOfUser);
                            }
                            flag = EmployeeDL.checkEmail(emailOfUser);

                        }
                        flag2 = EmployeeDL.checkUserAlreadyExisted(emailOfUser);
                    }
                    EmployeeDL.updateEmail(emailOfUser);
                    Console.WriteLine("Information Updated Successfully!!!");
                    displaySpecificDetailsOfEmployee(EmployeeDL.specificIndexForEmployee);
                    
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
                    EmployeeDL.updatePassword(password);
                    Console.WriteLine("Information Updated Successfully!!!");
                    displaySpecificDetailsOfEmployee(EmployeeDL.specificIndexForEmployee);
                    
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
                    EmployeeDL.updateAddress(address);
                    Console.WriteLine("Information Updated Successfully!!!");
                    displaySpecificDetailsOfEmployee(EmployeeDL.specificIndexForEmployee);
                    
                }
                else if (option == 5)
                {
                    Console.Write("Enter CNIC (1-->13 Digits) :");
                    long cnic = Convert.ToInt64(Console.ReadLine());
                    bool flagCNICLength = EmployeeDL.checkCNIC(cnic);
                    while (flagCNICLength != true)
                    {
                        cnic = CNIC_Again();
                        flagCNICLength = EmployeeDL.checkCNIC(cnic);
                    }

                    bool cnicFlag = EmployeeDL.checkCNICAlreadyExisted(cnic);

                    while (cnicFlag != true)
                    {

                        cnic = cnic_AlreadyExisted();
                        flagCNICLength = EmployeeDL.checkCNIC(cnic);
                        while (flagCNICLength != true)
                        {
                            cnic = CNIC_Again();
                            flagCNICLength = EmployeeDL.checkCNIC(cnic);
                        }
                        cnicFlag = EmployeeDL.checkCNICAlreadyExisted(cnic);
                    }
                    EmployeeDL.updateCNIC(cnic);
                    Console.WriteLine("Information Updated Successfully!!!");
                    displaySpecificDetailsOfEmployee(EmployeeDL.specificIndexForEmployee);
                    
                }
                else if (option == 6)
                {

                    Console.Write("Enter Phone No(1-->11 Digits) :");
                    long phoneNo = Convert.ToInt64(Console.ReadLine());
                    bool flagPNoLength = EmployeeDL.checkPhoneNo(phoneNo);
                    while (flagPNoLength != true)
                    {
                        phoneNo = phoneNo_Again();
                        flagPNoLength = EmployeeDL.checkPhoneNo(phoneNo);
                    }
                    bool pNoFlag = EmployeeDL.checkPhonNoAlreadyExisted(phoneNo);

                    while (pNoFlag != true)
                    {

                        phoneNo = phoneNo_AlreadyExisted();
                        flagPNoLength = EmployeeDL.checkPhoneNo(phoneNo);
                        while (flagPNoLength != true)
                        {
                            phoneNo = phoneNo_Again();
                            flagPNoLength = EmployeeDL.checkPhoneNo(phoneNo);
                        }
                        pNoFlag = EmployeeDL.checkPhonNoAlreadyExisted(phoneNo);
                    }
                    EmployeeDL.updatePhnoNo(phoneNo);
                    Console.WriteLine("Information Updated Successfully!!!");
                    displaySpecificDetailsOfEmployee(EmployeeDL.specificIndexForEmployee);
                    
                }
                else if (option > 7 || option < 1)
                {
                    Console.Write("Invalid Option ");
                    Console.WriteLine("Press Any Key To Continue again");
                    Console.ReadKey();
                }
                clearFn();
            } while (option != 7);

        }
        // Correct Option Fn..........................

        static public void correctOption()
        {
            Console.WriteLine("Option Is Not Correct ");
            Console.ReadLine();
            clearFn();
        }
    }

    
}
