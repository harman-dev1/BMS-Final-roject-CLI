using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using BMS.UI;
using BMS.BL;

namespace BMS.DL
{
    //Admin List.....................................................


    class ListsDLUser
    {
        //Sign Up File Handling ...........................

        public static void signUp_File(string path, string aEmail, string aPassword, string aName, string aAddress, long aPhoneNo, long aCnic)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(aEmail + "," + aPassword + "," + aName + "," + aAddress + "," + aPhoneNo + "," + aCnic + "," + "ADMIN");
            file.Flush();
            file.Close();
        }
        //File Load Data...........................................
        static public void loadAdminData()
        {
            User u1 = new User();
            string path = "SignIn_SignUp.txt";
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
                    ListsDLUser.setList(u1);
                }
                fileVariable.Close();
            }
        }
        private static List<User> listofAdminandManager = new List<User>();
        public static List<User> getListOfAdminandManager()
        {
            return listofAdminandManager;
        }

        public static int getListCount()
        {
            return listofAdminandManager.Count();
        }
        public static void setList(User U)
        {
            listofAdminandManager.Add(U);
        }

        public static bool updateDateofJoining(string DOJ)
        {
            int i = 0;
            foreach (var a in EmployeeDL.getListofEmloyee())
            {
                if (EmployeeDL.specificIndexForEmployee == i)
                {
                    a.JoinDate = DOJ;
                    return true;
                }
                i++;
            }
            return false;
        }

        public static bool updateEmployeeId(string aEmployeeId)
        {
            int i = 0;
            foreach (var a in EmployeeDL.getListofEmloyee())
            {
                if (EmployeeDL.specificIndexForEmployee == i)
                {
                    a.EmployeeId = aEmployeeId;
                    return true;
                }
                i++;
            }
            return false;
        }

        public static bool updateEmployeeSalary(long aSalary)
        {
            int i = 0;
            foreach (var a in EmployeeDL.getListofEmloyee())
            {
                if (EmployeeDL.specificIndexForEmployee == i)
                {
                    a.Salary = aSalary;
                    return true;
                }
                i++;
            }
            return false;
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
        //Check Bank Phone No  ...................................

        public static bool checkPhoneNoForBank(long aPhoneNo)
        {
            long pNo = aPhoneNo, b = 0;
            while (pNo != 0)
            {
                pNo = pNo / 10;
                b++;
                if (pNo == 0)
                {
                    if (b != 9)
                    {

                        return false;
                    }
                    else if (b == 9)
                    {
                        return true;
                    }
                }
            }
            return false;
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

        // Finding Index function to reomve manager ............

        public static EmployeeBL indexOfUser(string eMail)
        {
            foreach (var user in EmployeeDL.getListofEmloyee())
            {
                if (eMail == user.Email)
                {
                    return user;
                }
            }
            return null;
        }
        //Finding Customer Specific...................................
        public static CustomerBL indexOfUser(string eMail, string extra)
        {
            foreach (var user in CustomerDL.getListofCustomer())
            {
                if (eMail == user.Email)
                {
                    return user;
                }
            }
            return null;
        }
        //
        public static string checkUser(string aEmail, string aPassword)
        {

            foreach (var a in ListsDLUser.getListOfAdminandManager())
            {
                if (a.Email == aEmail && a.Password == aPassword)
                {
                    return a.Role;
                }

            }
            foreach (var a in EmployeeDL.getListofEmloyee())
            {
                if (a.Email == aEmail && a.Password == aPassword)
                {
                    return a.Role;
                }
                EmployeeDL.specificIndexForEmployee++;
            }
            foreach (var a in CustomerDL.getListofCustomer())
            {
                if (a.Email == aEmail && a.Password == aPassword)
                {
                    return a.Role;
                }
                CustomerDL.specificIndexForCustomer++;
            }
            return " ";
        }
        public static bool checkEmployeeId(string aEmployeeId)
        {
            foreach (var a in EmployeeDL.getListofEmloyee())
            {
                if (a.EmployeeId == aEmployeeId)
                {
                    return false;
                }
            }
            return true;
        }


        // date of joining .............
        static public bool DOJ(string input)
        {
            DateTime date;
            if (DateTime.TryParseExact(input, "ddMMyy", null, System.Globalization.DateTimeStyles.None, out date))
            {
                int day = date.Day;
                int month = date.Month;
                int year = date.Year;

                //Console.WriteLine($"Day: {day}");
                //Console.WriteLine($"Month: {month}");
                //Console.WriteLine($"Year: {year}");

                return true;
            }
            else
            {
                return false;
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
        // Check ID already Existed......................

        public static bool checkIdExisted(string aId)
        {
            foreach (var a in EmployeeDL.getListofEmloyee())
            {
                if (aId == a.EmployeeId)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
