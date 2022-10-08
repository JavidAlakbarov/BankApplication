using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_Application_Project.Models;
using Bank_Application_Project.Services.Implementations;
using Bank_Application_Project.Services.Interfaces;

namespace Bank_Application_Project
{
    public class Program
    {
        static void Main(string[] args)
        {
            Branch branch = new Branch();
            Employee employee = new Employee();
            Manager manager = new Manager();
            EmployeeService employeeService = new EmployeeService();
            BranchService branchService = new BranchService(employeeService);

            while (true)
            {
                    string username = "Javid";
                    string password = "Javid023";
                    Console.Write("Enter your username : ");
                    string username1 = Console.ReadLine();
                    Console.Write("Enter your password : ");
                    string password1 = Console.ReadLine();
                    if (username == username1 && password == password1)
                    {
                        Console.WriteLine("Press Enter");
                        Menu: ManagerMenu();
                        int operation = int.Parse(Console.ReadLine());

                        switch (operation)
                        {
                            case 1:
                                EmployeeMenu();
                                int empMenu = int.Parse(Console.ReadLine());
                                switch (empMenu)
                                {
                                    case 1:
                                        employeeService.Create();                                                                          
                                        goto Menu;
                                        
                                    case 2:
                                        employeeService.Delete();                                       
                                        goto Menu;
                                        
                                    case 3:
                                        employeeService.Update();
                                        goto Menu;
                                        
                                    case 4:
                                        employeeService.Get(employee.Name);
                                     
                                        goto Menu;

                                    case 5:
                                        employeeService.GetAll();
                                    Console.WriteLine(employee.Name);
                                        goto Menu;
                                        
                                    default: Console.WriteLine("No more operations");
                                        break;
                                }
                                break;
                            case 2:
                                BranchMenu();
                                int branchMenu = int.Parse(Console.ReadLine());
                                switch (branchMenu)
                                {
                                    case 1:
                                        branchService.Create();
                                        goto Menu;
                                       
                                    case 2:
                                        branchService.Delete();
                                        goto Menu;
                                       
                                    case 3:
                                        branchService.TransferMoney();
                                        goto Menu;
                                        
                                    case 4:
                                        branchService.TransferEmployee(branch);
                                        goto Menu;
                                        
                                    case 5:
                                        branchService.HireEmployee();
                                        Console.ReadKey();
                                        goto Menu;
                                       
                                    case 6:
                                        branchService.Get(branch.Name);
                                        goto Menu;
                                       
                                    case 7:
                                        branchService.GetAll();
                                        goto Menu;
                                        
                                    case 8:
                                        branchService.Update();
                                        goto Menu;

                                    case 9:
                                        branchService.GetProfit();
                                        Console.Write("Enter branch name :");
                                        string branchName = Console.ReadLine().Trim();
                                        branchService.GetProfit();
                                        
                                        goto Menu;
                                    default: Console.WriteLine("No more operations");
                                        break;
                                }                              
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong username or password");
                    }                             
            }
        }
        public static void ManagerMenu()
        {
            Console.WriteLine("1 for Employee");
            Console.WriteLine("2 for Branch");
        }
        public static void EmployeeMenu()
        {
            Console.WriteLine("Select your operation :");
            Console.WriteLine("Press 1 for Create Operation");
            Console.WriteLine("Press 2 for Delete Operation");
            Console.WriteLine("Press 3 for Update Operation");
            Console.WriteLine("Press 4 for Get Operation");
            Console.WriteLine("Press 5 for GetAll Operation");
        }
        public static void BranchMenu()
        {
            Console.WriteLine("Select your operation :");
            Console.WriteLine("Press 1 for Create Operation");
            Console.WriteLine("Press 2 for Delete Operation");
            Console.WriteLine("Press 3 for TransferMoney Operation");
            Console.WriteLine("Press 4 for TransferEmployee Operation");
            Console.WriteLine("Press 5 for HireEmployee Operation");
            Console.WriteLine("Press 6 for Get Operation");
            Console.WriteLine("Press 7 for GetAll Operation");
            Console.WriteLine("Press 8 for Update Operation");
            Console.WriteLine("Press 9 for GetProfit Operation");
        }
    }
}
      

