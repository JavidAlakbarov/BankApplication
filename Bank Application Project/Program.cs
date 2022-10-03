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
            string username = "Javid";
            string password = "Javid023";
            Console.Write("Enter your username : ");
            string username1 = Console.ReadLine();
            Console.Write("Enter your password : ");
            string password1 = Console.ReadLine();

            //int choose = int.Parse(Console.ReadLine());
            //switch (choose)
            //{
            //    case 1:
            //        EmployeeMenu();
            //        break;
            //    case 2:
            //        BranchMenu();
            //        break;
            //}

            BranchService branchService = new BranchService();
            EmployeeService employeeService = new EmployeeService();
            Employee employee = new Employee();

            
          

            if (username == username1 && password == password1)
            {
                Console.WriteLine("Make your choice :");
                Console.WriteLine("Press 1 for Employee Operations");
                Console.WriteLine("Press 2 for Branch Operations");
                int choose = int.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        EmployeeMenu();
                        break;
                    case 2:
                        BranchMenu();
                        break;
                }
                EmployeeMenu();                        
                int operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        EmployeeMenu();
                        int empMenu = int.Parse(Console.ReadLine());
                        switch (empMenu)
                        {
                            case 1:
                                //Employee emp1 = new Employee("Javid", "Alakbarov", 5000, "Frontend developer");
                                //employeeService.Create(emp1);
                                //Console.WriteLine(emp1.Name+" "+emp1.Surname+" "+emp1.Salary+" "+emp1.Profession);
                                employeeService.Create(employee);
                             
                                break;
                            case 2:
                                employeeService.Delete("");
                                break;
                            case 3:
                                employeeService.Update("",1,"");
                                break;
                            case 4:
                                employeeService.Get("");
                                break;
                            case 5:
                                employeeService.GetAll();
                                break;
                        }
                        BranchMenu();
                        int brMenu = int.Parse(Console.ReadLine());
                        switch (brMenu)
                        {
                            case 1:
                                Branch br1 = new Branch("Khatai", "Demirchi Plaza", 100000);
                                branchService.Create(br1);
                                Console.WriteLine(br1.Name+" "+br1.Address+" "+br1.Budget);
                                break;
                            case 2:

                                break;
                            case 3:

                                break;
                            case 4:

                                break;
                            case 5:

                                break;
                            case 6:

                                break;
                            case 7:

                                break;
                            case 8:

                                break;
                            case 9:

                                break;
                        }
                        break;
                }
            }
            else { Console.WriteLine("Uncorrect username or password"); }
        }
        public static void SeedDataBase()
        {
            Employee employee1 = new Employee();
            Employee employee2 = new Employee();
            Employee employee3 = new Employee();
            Employee employee4 = new Employee();
            Employee employee5 = new Employee();

            Branch branch1 = new Branch("Khatai", "Demirchi Plaza", 100000);
            Branch branch2 = new Branch("Narimanov", "Babek Plaza", 90000);
            Branch branch3 = new Branch("Yasamal", "Caspian Plaza", 80000);
            Branch branch4 = new Branch("Ganjlik", "Ganjlik Plaza", 70000);
            Branch branch5 = new Branch("Sabayil", "City Point Plaza", 60000);

            //List<Employee> employees = new List<Employee>();

            EmployeeService employeeService = new EmployeeService();
           
            employeeService.employees.DataBase.Add(employee1);
            employeeService.employees.DataBase.Add(employee2);
            employeeService.employees.DataBase.Add(employee3);
            employeeService.employees.DataBase.Add(employee4);
            employeeService.employees.DataBase.Add(employee5);

            BranchService branchService = new BranchService();
            branchService.branches.DataBase.Add(branch1);
            branchService.branches.DataBase.Add(branch2);
            branchService.branches.DataBase.Add(branch3);
            branchService.branches.DataBase.Add(branch4);
            branchService.branches.DataBase.Add(branch5);

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
            Console.WriteLine("Press 3 for Update Operation");
            Console.WriteLine("Press 4 for Get Operation");
            Console.WriteLine("Press 5 for GetAll Operation");
            Console.WriteLine("Press 6 for Get Profit Operation");
            Console.WriteLine("Press 7 for Hire Employee Operation");
            Console.WriteLine("Press 8 for Transfer Employee Operation");
            Console.WriteLine("Press 9 for Transfer Money Operation");
        }
    }
}
      

