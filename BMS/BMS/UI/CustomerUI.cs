using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMS.UI;
using BMS.DL;
using BMS.BL;

namespace BMS.UI
{
    class CustomerUI
    {
        //For ATM Password Update Message Dispaly...............
        public static void atmMessage_forPassword()
        {
            Console.WriteLine("Plzz Change Your ATM Password So that Employee can not Access it \nYou can change ATM Password From 4th Option");
            Console.Write("Now Press Any Key To Continue ");
            Console.ReadKey();
            Console.Clear();
        }
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

        // Email Of User.................................................

        private static string enterEmail(string role)
        {
            string email;
            Console.Write("Enter Email Of " + role + " :");
            email = Console.ReadLine();
            return email;
        }

        // Email if Empty...................................................

        private static string enterEmptyString(string thing)
        {
            string email;
            Console.Write(thing + " Can Not be Empty \n" + "Enter " + thing + " Again :");
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

        //Enter Password Of ATM ...............................

        private static int ATM_PasswordInput()
        {
            int password;
            Console.Write("Enter ATM Password (1--->4 Digits) again :");
            password = Convert.ToInt32(Console.ReadLine());
            return password;
        }

        // Customer Menu..........................................

        public static int customerMenu()
        {
            int customerOption;
            Console.WriteLine("1. Display Personal Details");
            Console.WriteLine("2. Update Personal Details");
            Console.WriteLine("3. Transactions Operation");
            Console.WriteLine("4. ATM Settings");
            Console.WriteLine("5. Display Bank Details");
            Console.WriteLine("6. Return To Main Screen");
            Console.Write("Enter Option :");
            customerOption = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            return customerOption;
        }

        // Display Personal Details..................................

        // private fn for diplay detail of customer ........................

        static private void displaycustomerSpecificDetails(int index)
        {
            Console.WriteLine("------------------------------->");
            Console.WriteLine("-------------------------------- \n");

            Console.WriteLine("Name :" + CustomerDL.getListofCustomer()[index].Name);
            Console.WriteLine("Email : " + CustomerDL.getListofCustomer()[index].Email);
            Console.WriteLine("Password : " + CustomerDL.getListofCustomer()[index].Password);
            Console.WriteLine("Role : " + CustomerDL.getListofCustomer()[index].Role);
            Console.WriteLine("Address : " + CustomerDL.getListofCustomer()[index].Address);
            Console.WriteLine("Phone No :" + CustomerDL.getListofCustomer()[index].PhoneNo);
            Console.WriteLine("CNIC : " + CustomerDL.getListofCustomer()[index].CNIC);
            Console.WriteLine("Account Type : " + CustomerDL.getListofCustomer()[index].AccountType);
            Console.WriteLine("ATM Id :" + CustomerDL.getListofCustomer()[index].AtmId);
            Console.WriteLine("ATM Password :" + CustomerDL.getListofCustomer()[index].AtmPassword);
            Console.WriteLine("Amount :" + CustomerDL.getListofCustomer()[index].Amount);

            Console.WriteLine("\n--------------------------------");
            Console.WriteLine("<-------------------------------");
        }
        static public void displayCustomerPersonalDetails()
        {
            int i = 0;

            foreach (var a in CustomerDL.getListofCustomer())
            {
                if (i == CustomerDL.specificIndexForCustomer)
                {
                    displaycustomerSpecificDetails(i);
                }
                i++;
            }
            clearFn();
        }

        //Update Details of Customer.......................................

        public void updateCustomerPersonnelDetails()
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
                Console.WriteLine("7.Return To Main Screen"); ;
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
                    bool flag = CustomerDL.updateNameOfCustomer(name);
                    if (flag == true)
                    {
                        Console.WriteLine("Information Updated Successfully!!!");
                        int i = 0;

                        foreach (var a in CustomerDL.getListofCustomer())
                        {
                            if (CustomerDL.specificIndexForCustomer == i)
                            {
                                displaycustomerSpecificDetails(i);
                            }
                            i++;
                        }
                    }
                    
                }
                else if (option == 2)
                {
                    string emailOfUser = enterEmail("CUSTOMER");
                    bool flag_EmptyString = empty_String(emailOfUser);
                    while (flag_EmptyString != true)
                    {
                        emailOfUser = enterEmptyString("Email");
                        flag_EmptyString = empty_String(emailOfUser);
                    }
                    bool flag = CustomerDL.checkEmail(emailOfUser);
                    while (flag != true)
                    {
                        emailOfUser = emailCorrectFormat();
                        flag_EmptyString = empty_String(emailOfUser);
                        while (flag_EmptyString != true)
                        {
                            emailOfUser = enterEmptyString("Email");
                            flag_EmptyString = empty_String(emailOfUser);
                        }
                        flag = CustomerDL.checkEmail(emailOfUser);
                    }

                    bool flag2 = CustomerDL.checkUserAlreadyExisted(emailOfUser);
                    while (flag2 != true)
                    {
                        emailOfUser = existing_Email();
                        flag_EmptyString = empty_String(emailOfUser);
                        while (flag_EmptyString != true)
                        {
                            emailOfUser = enterEmptyString("Email");
                            flag_EmptyString = empty_String(emailOfUser);
                        }
                        flag = CustomerDL.checkEmail(emailOfUser);
                        while (flag != true)
                        {
                            emailOfUser = emailCorrectFormat();
                            flag_EmptyString = empty_String(emailOfUser);
                            while (flag_EmptyString != true)
                            {
                                emailOfUser = enterEmptyString("Email");
                                flag_EmptyString = empty_String(emailOfUser);
                            }
                            flag = CustomerDL.checkEmail(emailOfUser);

                        }
                        flag2 = CustomerDL.checkUserAlreadyExisted(emailOfUser);
                    }
                    CustomerDL.updateEmailOfCustomer(emailOfUser);
                    Console.WriteLine("Information Updated Successfully!!!");
                    int i = 0;

                    foreach (var a in CustomerDL.getListofCustomer())
                    {
                        if (CustomerDL.specificIndexForCustomer == i)
                        {
                            displaycustomerSpecificDetails(i);
                        }
                        i++;
                    }
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
                    CustomerDL.updatePasswordForCustomer(password);
                    Console.WriteLine("Information Updated Successfully!!!");
                    int i = 0;

                    foreach (var a in CustomerDL.getListofCustomer())
                    {
                        if (CustomerDL.specificIndexForCustomer == i)
                        {
                            displaycustomerSpecificDetails(i);
                        }
                        i++;
                    }
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
                    CustomerDL.updateAddressofCustomer(address);
                    Console.WriteLine("Information Updated Successfully!!!");
                    int i = 0;

                    foreach (var a in CustomerDL.getListofCustomer())
                    {
                        if (CustomerDL.specificIndexForCustomer == i)
                        {
                            displaycustomerSpecificDetails(i);
                        }
                        i++;
                    }
                }
                else if (option == 5)
                {
                    Console.Write("Enter CNIC (1-->13 Digits) :");
                    long cnic = Convert.ToInt64(Console.ReadLine());
                    bool flagCNICLength = CustomerDL.checkCNIC(cnic);
                    while (flagCNICLength != true)
                    {
                        cnic = CNIC_Again();
                        flagCNICLength = CustomerDL.checkCNIC(cnic);
                    }

                    bool cnicFlag = CustomerDL.checkCNICAlreadyExisted(cnic);

                    while (cnicFlag != true)
                    {

                        cnic = cnic_AlreadyExisted();
                        flagCNICLength = CustomerDL.checkCNIC(cnic);
                        while (flagCNICLength != true)
                        {
                            cnic = CNIC_Again();
                            flagCNICLength = CustomerDL.checkCNIC(cnic);
                        }
                        cnicFlag = CustomerDL.checkCNICAlreadyExisted(cnic);
                    }
                    CustomerDL.updateCNICForCustomer(cnic);
                    Console.WriteLine("Information Updated Successfully!!!");
                    int i = 0;

                    foreach (var a in CustomerDL.getListofCustomer())
                    {
                        if (CustomerDL.specificIndexForCustomer == i)
                        {
                            displaycustomerSpecificDetails(i);
                        }
                        i++;
                    }

                }
                else if (option == 6)
                {
                    Console.Write("Enter Phone No(1-->11 Digits) :");
                    long phoneNo = Convert.ToInt64(Console.ReadLine());
                    bool flagPNoLength = CustomerDL.checkPhoneNo(phoneNo);
                    while (flagPNoLength != true)
                    {
                        phoneNo = phoneNo_Again();
                        flagPNoLength = CustomerDL.checkPhoneNo(phoneNo);
                    }
                    bool pNoFlag = CustomerDL.checkPhonNoAlreadyExisted(phoneNo);

                    while (pNoFlag != true)
                    {

                        phoneNo = phoneNo_AlreadyExisted();
                        flagPNoLength = CustomerDL.checkPhoneNo(phoneNo);
                        while (flagPNoLength != true)
                        {
                            phoneNo = phoneNo_Again();
                            flagPNoLength = CustomerDL.checkPhoneNo(phoneNo);
                        }
                        pNoFlag = CustomerDL.checkPhonNoAlreadyExisted(phoneNo);
                    }
                    CustomerDL.updatePhnoNoForCustomer(phoneNo);
                    Console.WriteLine("Information Updated Successfully!!!");
                    int i = 0;

                    foreach (var a in CustomerDL.getListofCustomer())
                    {
                        if (CustomerDL.specificIndexForCustomer == i)
                        {
                            displaycustomerSpecificDetails(i);
                        }
                        i++;
                    }

                }


                else if (option < 1 || option > 6)
                {
                    Console.WriteLine("Option Is Incorrect Try Again");
                    
                }
                clearFn();
            } while (option != 7);
        }

        //Update Atm Settings...........................................

        public void updateCustomerAtm()
        {
            int option;
            do
            {
                Console.WriteLine("1.Update ATM ID");
                Console.WriteLine("2.Update ATM Password");
                Console.WriteLine("3.Update Account Type");
                Console.WriteLine("4.Return To Main Screen");
                Console.Write("Enter Choice :");
                option = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (option == 1)
                {
                    Console.Write("Enter ATM ID (****-****-*) :");
                    string ATMID = Console.ReadLine();
                    bool flag_EmptyString = empty_String(ATMID);
                    while (flag_EmptyString != true)
                    {
                        ATMID = enterEmptyString("ATM ID");
                        flag_EmptyString = empty_String(ATMID);
                    }
                    bool flag_AtmIdFormat = CustomerDL.atmIDFormat(ATMID);
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
                        flag_AtmIdFormat = CustomerDL.atmIDFormat(ATMID);
                    }
                    bool flag_ = CustomerDL.checkATMIdAlreadyExisted(ATMID);
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
                            flag_AtmIdFormat = CustomerDL.atmIDFormat(ATMID);
                        }
                        CustomerDL.atmIDFormat(ATMID);
                        flag_ = CustomerDL.checkATMIdAlreadyExisted(ATMID);
                    }


                    CustomerDL.updateATMIDOfCustomer(ATMID);
                    Console.WriteLine("Information Updated Successfully!!!");
                    int i = 0;

                    foreach (var a in CustomerDL.getListofCustomer())
                    {
                        if (CustomerDL.specificIndexForCustomer == i)
                        {
                            displaycustomerSpecificDetails(i);
                        }
                        i++;
                    }

                    clearFn();
                }
                else if (option == 2)
                {
                    Console.Write("Enter Password(1--->4 Digits) :");
                    int ATMPassword = Convert.ToInt32(Console.ReadLine());

                    bool flag_AtmPassword = CustomerDL.atmPasswordLength(ATMPassword);

                    while (flag_AtmPassword != true)
                    {
                        ATMPassword = ATM_PasswordInput();
                        flag_AtmPassword = CustomerDL.atmPasswordLength(ATMPassword);
                    }

                    CustomerDL.updateATMPasswordForCustomer(ATMPassword);
                    Console.WriteLine("Information Updated Successfully!!!");
                    int i = 0;

                    foreach (var a in CustomerDL.getListofCustomer())
                    {
                        if (CustomerDL.specificIndexForCustomer == i)
                        {
                            displaycustomerSpecificDetails(i);
                        }
                        i++;
                    }
                    clearFn();
                }
                else if (option == 3)
                {
                    string accountType;
                    Console.WriteLine("There Are Two Account In Bank First Saving Account and second Current Account \n Current Account : You can deposit or can Transfer Money \n Saving Account : You can only Save Money ");
                    Console.Write("Enter Account Type :");
                    accountType = Console.ReadLine();
                    bool flag_EmptyString = empty_String(accountType);
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

                    CustomerDL.updateAccountOfCustomer(accountType);
                    Console.WriteLine("Information Updated Successfully!!!");

                    int i = 0;

                    foreach (var a in CustomerDL.getListofCustomer())
                    {
                        if (CustomerDL.specificIndexForCustomer == i)
                        {
                            displaycustomerSpecificDetails(i);
                        }
                        i++;
                    }
                    clearFn();
                }
                else if (option < 1 || option > 4)
                {
                    Console.WriteLine("Option Is Incorrect Try Again");
                    clearFn();
                }

            } while (option != 4);
        }

        // 3rd Options.....................................


        static public void transactions()
        {
            displayBorder();
            Console.Write("Enter ATM ID(****-****-*) :");
            string atmId = Console.ReadLine();
            Console.Write("Enter ATM Password :");
            int atmPassword = Convert.ToInt32(Console.ReadLine());
            string accountType = CustomerDL.atmTransactions(atmId,atmPassword);
            
            if (accountType != null)
            {
                
                if (accountType == "SAVING")
                {
                    long amount = CustomerDL.atmTransactions(atmPassword, atmId);
                    Console.WriteLine("You Have Current Amount = " + amount);
                    Console.WriteLine("As You are account is Saving You can Only save Amount but You can Not Withdraw it");
                    Console.Write("Enter Amount You Want To Add In your current Amount :");
                    long amount1 = Convert.ToInt64(Console.ReadLine());
                    while (amount1 < 0)
                    {
                        Console.Write("Amount Can not Be Less than \"zero\"  Enter Amount Again :");
                        amount1 = Convert.ToInt64(Console.ReadLine());
                    }
                    CustomerDL.atmTransactions(atmPassword, atmId, amount1);
                    Console.WriteLine("Amount Added Successfully");
                    int i = 0;

                    foreach (var a in CustomerDL.getListofCustomer())
                    {
                        if (CustomerDL.specificIndexForCustomer == i)
                        {
                            displaycustomerSpecificDetails(i);
                        }
                        i++;
                    }
                    clearFn();
                }
                else if(accountType == "CURRENT")
                {
                    
                                      
                    Console.WriteLine("As You are account is Current You can Only save Amount but You can also Withdraw it");
                    Console.WriteLine("1. Add Amount to Your Account ");
                    Console.WriteLine("2. WithDraw Amount");
                    Console.Write("Enter Your Choice :");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    if(choice == 1)
                    {
                        long amount = CustomerDL.atmTransactions(atmPassword, atmId);
                        Console.WriteLine("You Have Current Amount = " + amount);
                        Console.Write("Enter Amount You Want To Add In your current Amount :");
                        long amount1 = Convert.ToInt64(Console.ReadLine());
                        while (amount1 < 0)
                        {
                            Console.Write("Amount Can not Be Less than \"zero\"  Enter Amount Again :");
                            amount1 = Convert.ToInt64(Console.ReadLine());
                        }
                        CustomerDL.atmTransactions(atmPassword, atmId, amount1);
                        Console.WriteLine("Amount Added Successfully");
                        int i = 0;

                        foreach (var a in CustomerDL.getListofCustomer())
                        {
                            if (CustomerDL.specificIndexForCustomer == i)
                            {
                                displaycustomerSpecificDetails(i);
                            }
                            i++;
                        }
                        clearFn();
                    }
                    else if(choice == 2)
                    {
                        long amount = CustomerDL.atmTransactions(atmPassword, atmId);
                        Console.WriteLine("You Have Current Amount = " + amount);
                        Console.Write("Enter Amount You Want To WithDraw :");
                        long amount1 = Convert.ToInt64(Console.ReadLine());
                        while (amount1 < 0)
                        {
                            Console.Write("Amount Can not Be Less than \"zero\"  Enter Amount Again :");
                            amount1 = Convert.ToInt64(Console.ReadLine());
                        }
                        while(amount1 > amount)
                        {
                            Console.Write("Enter Amount Again :");
                            amount1 = Convert.ToInt64(Console.ReadLine());
                        }
                        CustomerDL.atmTransactions(amount1, atmPassword, atmId);
                        Console.WriteLine("Amount WithDraw Successfully");
                        int i = 0;

                        foreach (var a in CustomerDL.getListofCustomer())
                        {
                            if (CustomerDL.specificIndexForCustomer == i)
                            {
                                displaycustomerSpecificDetails(i);
                            }
                            i++;
                        }
                        clearFn();
                    }
                }
                else
                {
                    Console.WriteLine("Option is not a correct");
                    clearFn();
                }
            }
            else
            {
                Console.WriteLine("Not Found!!!");
                clearFn();
            }
        }
        //static private long amonut()
        //{

        //}
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
    }
}
