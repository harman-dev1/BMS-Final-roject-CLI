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
    

    // List Of Employee .....................


    class EmployeeDL
    {
        public static void add_EmployeesInTo_file(string path, string aEmail, string aPassword, string aName, string aAddress, long aPhoneNo, long aCnic,string aEmployeeID,long employeeSalary,string aInput)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(aEmail + "," + aPassword + "," + aName + "," + aAddress + "," + aPhoneNo + "," + aCnic + "," + "EMPLOYEE" + "," +aEmployeeID + "," + employeeSalary + "," + aInput);
            file.Flush();
            file.Close();
        }
        static public void loadEmployeeData()
        {
            EmployeeBL u1 = new EmployeeBL();
            string path = "Employee.txt";
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
                    u1.EmployeeId = spiltRecord[7];
                    u1.Salary = long.Parse(spiltRecord[8]);
                    u1.JoinDate = spiltRecord[9];
                    setListOfEmployee(u1);
                }
                fileVariable.Close();
            }
        }
        public static int specificIndexForEmployee = 0;
        private static List<EmployeeBL> listOfEmployee = new List<EmployeeBL>();

        public static List<EmployeeBL> getListofEmloyee()
        {
            return listOfEmployee;
        }
        public static void setListOfEmployee(EmployeeBL U)
        {
            listOfEmployee.Add(U);
        }

        static public bool employeeToRemove(string email)
        {
            foreach (var employee in getListofEmloyee())
            {
                if (email == employee.Email)
                {
                    EmployeeDL.getListofEmloyee().Remove(employee);
                    return true;
                }
            }
            return false;
        }

        static public void updateName(string aName)
        {

            int i = 0;
            foreach (var a in EmployeeDL.getListofEmloyee())
            {
                if (specificIndexForEmployee == i)
                {
                    a.Name = aName;

                }
                i++;
            }

        }

        static public void updateEmail(string aEmail)
        {
            int i = 0;
            foreach (var a in EmployeeDL.getListofEmloyee())
            {
                if (specificIndexForEmployee == i)
                {
                    a.Email = aEmail;
                }
                i++;
            }
        }

        static public void updateCNIC(long aCNIC)
        {
            int i = 0;
            foreach (var a in EmployeeDL.getListofEmloyee())
            {
                if (specificIndexForEmployee == i)
                {
                    a.CNIC = aCNIC;
                }
                i++;
            }
        }

        static public void updatePhnoNo(long aPhoneNo)
        {
            int i = 0;
            foreach (var a in EmployeeDL.getListofEmloyee())
            {
                if (specificIndexForEmployee == i)
                {
                    a.PhoneNo = aPhoneNo;
                }
                i++;
            }
        }

        static public void updateAddress(string aAddress)
        {
            int i = 0;
            foreach (var a in EmployeeDL.getListofEmloyee())
            {
                if (specificIndexForEmployee == i)
                {
                    a.Address = aAddress;
                }
                i++;
            }
        }

        static public void updatePassword(string aPassword)
        {
            int i = 0;
            foreach (var a in EmployeeDL.getListofEmloyee())
            {
                if (specificIndexForEmployee == i)
                {
                    a.Password = aPassword;
                }
                i++;
            }
        }

        public static long transactionReport()
        {
            long total = 0;
            foreach (var a in CustomerDL.getListofCustomer())
            {
                total = a.Amount + total;
            }
            return total;
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

        //Finding Customer Specific...................................

        public static CustomerBL indexOfUser(string eMail)
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
    }
}
