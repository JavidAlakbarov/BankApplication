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

            BranchService branchService = new BranchService();
            EmployeeService employeeService = new EmployeeService();

            while (true)
            {
                try
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
                                        employeeService.Create(employee);
                                        foreach (Employee employee1 in employeeService.employees.DataBase)
                                        {
                                            Console.WriteLine($"Name: {employee1.Name} Surname: {employee1.Surname}  Salary: {employee1.Salary} Profession: {employee1.Profession}");
                                        }
                                        Console.ReadKey();
                                        goto Menu;
                                        
                                    case 2:
                                        employeeService.Delete(employee);
                                        Console.ReadKey();
                                        goto Menu;
                                        
                                    case 3:
                                        employeeService.Update();
                                        goto Menu;
                                        
                                    case 4:
                                        foreach(Employee employee1 in employeeService.employees.DataBase)
                                        {
                                            Console.WriteLine($"Name: {employee1.Name} Surname: {employee1.Surname}  Salary: {employee1.Salary} Profession: {employee1.Profession}");
                                        }
                                        Console.ReadKey();
                                        goto Menu;
                                        
                                    case 5:
                                        employeeService.Get(employee.Name);
                                        goto Menu;
                                        
                                    case 6:
                                        employeeService.GetAll();
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
                                        branchService.Create(branch);
                                        Console.ReadKey();
                                        goto Menu;
                                       
                                    case 2:
                                        branchService.Delete(branch);
                                        Console.ReadKey();
                                        goto Menu;
                                       
                                    case 3:
                                        branchService.TransferMoney();
                                        Console.ReadKey();
                                        goto Menu;
                                        
                                    case 4:
                                        branchService.TransferEmployee(branch);
                                        Console.ReadKey();
                                        goto Menu;
                                        
                                    case 5:
                                        branchService.HireEmployee(branch);
                                        Console.ReadKey();
                                        goto Menu;
                                       
                                    case 6:
                                        branchService.Get(branch.Name);
                                        Console.ReadKey();
                                        goto Menu;
                                       
                                    case 7:
                                        branchService.GetAll();
                                        Console.ReadKey();
                                        goto Menu;
                                        
                                    case 8:
                                        branchService.Update();
                                        Console.ReadKey();
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
                catch (FormatException)
                {
                    Console.WriteLine("Wrong username or password");
                }
                
            }
}
        public static void ManagerMenu()
        {
            Console.WriteLine("1 for Branch");
            Console.WriteLine("2 for Employee");
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
            Console.WriteLine("Press 6 for GetProfit Operation");
            Console.WriteLine("Press 7 for GetAll Operation");
            Console.WriteLine("Press 8 for Update Operation");
            Console.WriteLine("Press 9 for GetProfit Operation");
        }
    }
}
      

