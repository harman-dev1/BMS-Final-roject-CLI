//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using BMS.BL;
//using BMS.UI;
//using BMS.DL;

//namespace BMS.UI
//{
//        class employeeUpdate : InputOutput
//        {
//            public new void updateEmployeePersonnelDetails()
//            {

//                base.updateEmployeePersonnelDetails();
//                void displaySpecificDetailsOfEmploye(int index)
//                {
//                    Console.WriteLine("------------------------------->");
//                    Console.WriteLine("Name :" + EmployeeDL.getListofEmloyee()[index].Name);
//                    Console.WriteLine("Email :" + EmployeeDL.getListofEmloyee()[index].Email);
//                    Console.WriteLine("Password :" + EmployeeDL.getListofEmloyee()[index].Password);
//                    Console.WriteLine("Phone No :" + EmployeeDL.getListofEmloyee()[index].PhoneNo);
//                    Console.WriteLine("Address :" + EmployeeDL.getListofEmloyee()[index].Address);
//                    Console.WriteLine("CNIC :" + EmployeeDL.getListofEmloyee()[index].CNIC);
//                    Console.WriteLine("Employee Id :" + EmployeeDL.getListofEmloyee()[index].EmployeeId);
//                    Console.WriteLine("Date Of Joining :" + EmployeeDL.getListofEmloyee()[index].JoinDate);
//                    Console.WriteLine("Salary :" + EmployeeDL.getListofEmloyee()[index].Salary);
//                    Console.WriteLine("<-------------------------------");
//                }
//                int update;
//                do
//                {
                    

//                } while (update != 10);


//            }


//            // ClearFN............................


//            private void clearfn()
//            {
//                Console.WriteLine("Updated Successfully!!!");
//                Console.Write("Press Any Key To Continue");

//                Console.ReadKey();
//                Console.Clear();
//            }

//            // String is Empty Or Not
//            private static bool empty_String(string checkString)
//            {
//                if (checkString == "")
//                {
//                    return false;
//                }
//                else
//                {
//                    return true;
//                }
//            }

//            private static string enterEmptyString(string thing)
//            {
//                string email;
//                Console.Write(thing + " Can Not be Empty \n" + "Enter " + thing + " Again :");
//                email = Console.ReadLine();
//                return email;
//            }
//        }
//}
