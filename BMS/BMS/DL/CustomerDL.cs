using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using BMS.BL;
using BMS.UI;

namespace BMS.DL
{
    class CustomerDL
    {
        static public void loadCustomersData()
        {
            CustomerBL u1 = new CustomerBL();
            string path = "CustomerList.txt";
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    string[] spiltRecord = record.Split(',');
                    u1.Email = spiltRecord[0];
                    u1.Password = spiltRecord[1];
                    u1.Name = spiltRecord[2];
                    u1.Address = spiltRecord[3];
                    u1.PhoneNo = long.Parse(spiltRecord[4]);
                    u1.CNIC = long.Parse(spiltRecord[5]);
                    u1.Role = spiltRecord[6];
                    u1.AtmId = spiltRecord[7];
                    u1.AtmPassword = int.Parse(spiltRecord[8]);
                    u1.AccountType = spiltRecord[9];
                    u1.Amount = long.Parse(spiltRecord[10]);
                    CustomerDL.setListOfCustomer(u1);
                }
                fileVariable.Close();
            }
        }
        public static void add_CustomersInTo_file(string path, string aEmail, string aPassword, string aName, string aAddress, long aPhoneNo, long aCnic, string aATMId, int aAtmPassword, string aAccountType, long aAmount)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(aEmail + "," + aPassword + "," + aName + "," + aAddress + "," + aPhoneNo + "," + aCnic + "," + "CUSTOMER" + "," + aATMId + "," + aAtmPassword + "," + aAccountType + "," + aAmount);
            file.Flush();
            file.Close();
        }
        //Check user for sign In......................
        public static int specificIndexForCustomer = 0;
        private static List<CustomerBL> listOfCustomer = new List<CustomerBL>();

        public static List<CustomerBL> getListofCustomer()
        {
            return listOfCustomer;
        }
        public static void setListOfCustomer(CustomerBL U)
        {
            listOfCustomer.Add(U);
        }

        static public bool customerToRemove(string email)
        {
            foreach (var a in getListofCustomer())
            {
                if (email == a.Email)
                {
                    getListofCustomer().Remove(a);
                    return true;
                }
            }
            return false;
        }

        //Update Name ..........................
        static public bool updateNameOfCustomer(string aName)
        {
            int i = 0;
            foreach (var a in CustomerDL.getListofCustomer())
            {
                if (specificIndexForCustomer == i)
                {
                    a.Name = aName;
                    return true;
                }
                i++;
            }
            return false;
        }
        static public void updateEmailOfCustomer(string aEmail)
        {
            int i = 0;
            foreach (var a in CustomerDL.getListofCustomer())
            {
                if (specificIndexForCustomer == i)
                {
                    a.Email = aEmail;
                }
                i++;
            }
        }
        static public void updateCNICForCustomer(long aCNIC)
        {
            int i = 0;
            foreach (var a in CustomerDL.getListofCustomer())
            {
                if (specificIndexForCustomer == i)
                {
                    a.CNIC = aCNIC;
                }
                i++;
            }
        }



        static public void updatePhnoNoForCustomer(long aPhoneNo)
        {
            int i = 0;
            foreach (var a in CustomerDL.getListofCustomer())
            {
                if (specificIndexForCustomer == i)
                {
                    a.PhoneNo = aPhoneNo;
                }
                i++;
            }
        }
        static public void updateAddressofCustomer(string aAddress)
        {
            int i = 0;
            foreach (var a in CustomerDL.getListofCustomer())
            {
                if (specificIndexForCustomer == i)
                {
                    a.Address = aAddress;
                }
                i++;
            }
        }
        static public void updatePasswordForCustomer(string aPassword)
        {
            int i = 0;
            foreach (var a in CustomerDL.getListofCustomer())
            {
                if (specificIndexForCustomer == i)
                {
                    a.Password = aPassword;
                }
                i++;
            }
        }
        //Update ATM ID...................................

        public static bool updateATMIDOfCustomer(string aATMID)
        {
            int i = 0;
            foreach (var a in CustomerDL.getListofCustomer())
            {
                if (specificIndexForCustomer == i)
                {
                    a.AtmId = aATMID;
                    return true;
                }
                i++;
            }
            return false;
        }

        //Update ATM Password...................................
        public static bool updateATMPasswordForCustomer(int aAtmPassword)
        {
            int i = 0;
            foreach (var a in CustomerDL.getListofCustomer())
            {
                if (specificIndexForCustomer == i)
                {
                    a.AtmPassword = aAtmPassword;
                    return true;
                }
                i++;
            }
            return false;
        }
        //Update Account Type...................................
        public static bool updateAccountOfCustomer(string aAccountType)
        {
            int i = 0;
            foreach (var a in CustomerDL.getListofCustomer())
            {
                if (specificIndexForCustomer == i)
                {
                    a.AccountType = aAccountType;
                    return true;
                }
                i++;
            }
            return false;
        }
        // Check ATM ID Format........................................
        public static bool atmIDFormat(string aATMID)
        {
            if (aATMID.Substring(4, 1) != "-" || aATMID.Substring(9, 1) != "-")
            {
                return false;
            }
            return true;
        }
        //Check Atm Id and Atm Password For Transactions....................................
        public static string atmTransactions(string aAtmId, long aAtmPassword)
        {
            foreach (var a in CustomerDL.getListofCustomer())
            {
                if (aAtmId == a.AtmId && aAtmPassword == a.AtmPassword)
                {
                    return a.AccountType;
                }
            }
            return null;
        }
        public static long atmTransactions(long aAtmPassword, string aAtmId)
        {
            foreach (var a in CustomerDL.getListofCustomer())
            {
                if (aAtmId == a.AtmId && aAtmPassword == a.AtmPassword)
                {
                    return a.Amount;
                }
            }
            return 0;
        }
        public static void atmTransactions(long aAtmPassword, string aAtmId, long aAmount1)
        {
            foreach (var a in CustomerDL.getListofCustomer())
            {
                if (aAtmId == a.AtmId && aAtmPassword == a.AtmPassword)
                {
                    a.Amount = a.Amount + aAmount1;
                }
            }
        }
        public static void atmTransactions(long aAmount1, long aAtmPassword, string aAtmId)
        {
            foreach (var a in CustomerDL.getListofCustomer())
            {
                if (aAtmId == a.AtmId && aAtmPassword == a.AtmPassword)
                {
                    a.Amount = a.Amount - aAmount1;
                }
            }
        }
        //Check User That Already Exists..............
        public static bool checkUserAlreadyExisted(string eemail)
        {
            foreach (var a in EmployeeDL.getListofEmloyee())
            {
                if (eemail == a.Email)
                {
                    return false;
                }
            }
            foreach (var a in ListsDLUser.getListOfAdminandManager())
            {
                if (eemail == a.Email)
                {
                    return false;
                }
            }
            foreach (var a in CustomerDL.getListofCustomer())
            {
                if (eemail == a.Email)
                {
                    return false;
                }
            }
            return true;
        }
        // Check Email Format......................................................
        public static bool checkEmail(string email)
        {
            char[] Mail = { '@', 'g', 'm', 'a', 'i', 'l', '.', 'c', 'o', 'm' };
            int lengthOfEmail = email.Length - 11;
            int countEmail = email.Length - 1;

            int i = 9;
            bool flag = false;
            while (countEmail != lengthOfEmail)
            {
                if (email[countEmail] == Mail[i])
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                    break;
                }
                countEmail--;
                i--;
            }
            return flag;
        }
        //Check CNIC for Sign up ........................................

        public static bool checkCNIC(long aCNIC)
        {
            long firstDigit = aCNIC / 1000000000000;
            long cnic = aCNIC, b = 0;
            while (cnic != 0)
            {
                cnic = cnic / 10;
                b++;
                if (cnic == 0)
                {
                    if (b != 13 && firstDigit != 3)
                    {

                        return false;
                    }
                    else if (b == 13 && firstDigit == 3)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        //Check CNIC Already Existed..............................

        public static bool checkCNICAlreadyExisted(long aCNIC)
        {
            foreach (var a in EmployeeDL.getListofEmloyee())
            {
                if (aCNIC == a.CNIC)
                {
                    return false;
                }
            }
            foreach (var a in ListsDLUser.getListOfAdminandManager())
            {
                if (aCNIC == a.CNIC)
                {
                    return false;
                }
            }
            foreach (var a in CustomerDL.getListofCustomer())
            {
                if (aCNIC == a.CNIC)
                {
                    return false;
                }
            }
            return true;
        }
        //Check Phone No  ...................................
        public static bool checkPhoneNo(long aPhoneNo)
        {
            long firstDigit;
            firstDigit = aPhoneNo / 100000000000;
            long pNo = aPhoneNo, b = 0;
            while (pNo != 0)
            {
                pNo = pNo / 10;
                b++;
                if (pNo == 0)
                {
                    if (b != 10 && firstDigit != 0)
                    {
                        return false;
                    }
                    else if (b == 10 && firstDigit == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        //Check Phone No Already Existed.........................
        public static bool checkPhonNoAlreadyExisted(long aPhoneNo)
        {
            foreach (var a in EmployeeDL.getListofEmloyee())
            {
                if (aPhoneNo == a.PhoneNo)
                {
                    return false;
                }
            }
            foreach (var a in ListsDLUser.getListOfAdminandManager())
            {
                if (aPhoneNo == a.PhoneNo)
                {
                    return false;
                }
            }
            foreach (var a in CustomerDL.getListofCustomer())
            {
                if (aPhoneNo == a.PhoneNo)
                {
                    return false;
                }
            }
            return true;
        }
        //check IdAlready Existed....................................
        public static bool checkATMIdAlreadyExisted(string atmId)
        {
            foreach (var a in CustomerDL.getListofCustomer())
            {
                if (atmId == a.AtmId)
                {
                    return false;
                }
            }
            return true;
        }
        //Check Atm ID Password......................................
        public static bool atmPasswordLength(int aATMPassword)
        {
            int CATMpassword = aATMPassword;
            int p = 0;
            while (CATMpassword != 0)
            {
                CATMpassword = CATMpassword / 10;
                p++;
                if (CATMpassword == 0)
                {
                    if (p != 4)
                    {
                        return false;
                    }
                    else if (p == 4)
                    {
                        return true;
                    }
                }
            }
            return true;
        }
    }
}
