using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMS.BL;
using BMS.DL;
using BMS.UI;

namespace BMS
{
    class Program
    {  
        static void Main(string[] args)
        {
            
            int option;
            int count = 0;
            int bankCount = 0;
            do
            {
                ListsDLUser.loadAdminData();
                EmployeeDL.loadEmployeeData();
                CustomerDL.loadCustomersData();
                InputOutput.displayBorder();
                option = InputOutput.Menu();
                if(option == 1)
                {
                    CustomerDL.specificIndexForCustomer = 0;
                    EmployeeDL.specificIndexForEmployee = 0;
                    string role = InputOutput.signIn();

                    //Admin Menu + Options.....................
                    if (role == "ADMIN")
                    {
                        
                        int adminMenuOption;
                        do
                        {
                            adminMenuOption = AdminUI.adminMenu();
                            if (adminMenuOption == 1)
                            {
                                EmployeeDL.setListOfEmployee(AdminUI.addUserByAdmin());                                
                            }
                            else if (adminMenuOption == 2)
                            {
                                AdminUI.displayAllUsers();
                            }
                            else if (adminMenuOption == 3)
                            {
                                AdminUI.updateEmployeePersonnelDetails();
                            }
                            else if (adminMenuOption == 4)
                            {
                                AdminUI.EmployeeToRemove();
                            }
                            else if (adminMenuOption == 5)
                            {
                                AdminUI.CustomerToRemove();
                            }
                            else if (adminMenuOption == 6)
                            {
                                AdminUI.searchEmployee();
                            }
                            else if (adminMenuOption == 7)
                            {
                                AdminUI.searchCustomer();
                            }
                            else if (adminMenuOption == 8)
                            {
                                AdminUI i1 = new AdminUI();
                                i1.updatePersonnelDetails();
                            }
                            else if (adminMenuOption == 9)
                            {
                                AdminUI i1 = new AdminUI();
                                i1.displaySpecificDetailsOfAdmin();
                            }
                            else if (adminMenuOption == 10)
                            {
                                if(bankCount == 0)
                                {
                                    AdminUI.addBankDetails();
                                    bankCount++;
                                }
                                else
                                {
                                    AdminUI.notAccessForBank();
                                }
                                
                            }
                            else if (adminMenuOption == 11)
                            {
                                AdminUI.DisplayBankDetails();
                            }
                            else if(adminMenuOption == 12)
                            {
                                AdminUI.updateBank();
                            }
                            else if(adminMenuOption > 13 || adminMenuOption <1)
                            {
                                AdminUI.correctOption();
                            }
                        } while (adminMenuOption != 13);
                    }


                    //Teller Menu + Options.....................

                    
                    else if(role == "EMPLOYEE")
                    {
                        int employeeMenuOption;
                        do
                        {
                            employeeMenuOption = EmployeeUI.employeeMenu();
                            if(employeeMenuOption == 1)
                            {
                                CustomerDL.setListOfCustomer(EmployeeUI.addCustomer());
                            }
                            else if(employeeMenuOption == 2)
                            {
                                EmployeeUI.searchCustomer();
                            }
                            else if (employeeMenuOption == 3)
                            {
                                EmployeeUI.transactionReport();
                            }
                            else if (employeeMenuOption == 4)
                            {
                                EmployeeUI.displayEmpolyeePersonalDetails();
                            }
                            else if (employeeMenuOption == 5)
                            {
                                EmployeeUI.updateEmployeePersonnelDetails();
                            }
                            else if(employeeMenuOption == 6)
                            {
                                AdminUI.DisplayBankDetails();
                            }
                            else if(employeeMenuOption > 7 || employeeMenuOption <1)
                            {
                                EmployeeUI.correctOption();
                            }
                        } while (employeeMenuOption != 7);
                        
                    }


                    
                    //Customer Menu + Options.....................
                    
                    
                    else if(role == "CUSTOMER")
                    {

                        CustomerUI.atmMessage_forPassword();
                        int customerOption;
                        do
                        {
                            customerOption = CustomerUI.customerMenu();
                            if(customerOption == 1)
                            {
                                CustomerUI.displayCustomerPersonalDetails();
                            }
                            else if(customerOption == 2)
                            {
                                CustomerUI i2 = new CustomerUI(); 
                                i2.updateCustomerPersonnelDetails();
                            }
                            else if(customerOption == 3)
                            {
                                CustomerUI.transactions();
                            }
                            else if(customerOption == 4)
                            {
                                CustomerUI i2 = new CustomerUI();
                                i2.updateCustomerAtm();
                            }
                            else if(customerOption == 5)
                            {
                                AdminUI.DisplayBankDetails();
                            }

                            else if(customerOption > 6 || customerOption < 0)
                            {

                                CustomerUI.correctOption();

                            }
                        } while (customerOption != 6);
                    }

                }
                else if(option == 2)
                {
                    if (ListsDLUser.getListCount() == 0)
                    {
                        ListsDLUser.setList(InputOutput.signUp());
                        

                    }
                    else
                    {
                        InputOutput.notAccessFn();
                    }
                }
                else if(option > 3 || option <1)
                {
                    InputOutput.correctOption();
                }
            } while (option != 3);
            
        }
    }
}
