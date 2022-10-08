using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_Application_Project.Data;
using Bank_Application_Project.Models;
using Bank_Application_Project.Services.Interfaces;

namespace Bank_Application_Project.Services.Implementations
{
    public class BranchService : IBranchService, IBankService<Branch>
    {
        public Bank<Branch> branches;
        public EmployeeService employeeService;

        public BranchService(EmployeeService employees)  
        {
            employeeService=employees;
            branches = new Bank<Branch>();
        }
        public void Create()
        {
            //creating
                Console.Write("Enter the branch name :");
                string name = Console.ReadLine();
                Console.Write("Enter the branch budget :");             
                double budget = double.Parse(Console.ReadLine());
                Console.Write("Enter the branch address :");
                string address = Console.ReadLine();
                Branch branch = new Branch();
                branch.Name = name;
                branch.Budget = budget;
                branch.Address = address;
                branches.DataBase.Add(branch);
                Console.WriteLine($"Name:{name},Budget:{budget},Address:{address}");           
        }
        public void Delete()
        {
            Console.WriteLine("Enter the branch name : ");
            string name = Console.ReadLine();
            Branch branch = branches.DataBase.Find(x => x.Name.ToLower().Trim() == name.ToLower().Trim());
            branch.SoftDelete = true;
        }
        public void Get(string entity)
        {
            try
            {
                Branch branch = branches.DataBase.Find(m => m.Name.Contains(entity.ToLower().Trim()));
                if (branch.SoftDelete == true)
                {
                    Console.WriteLine(branch.Name);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Branch not found");
            }                     
        }
        public void GetAll()
        {
            foreach (var branch in branches.DataBase.Where(m => m.SoftDelete == false))
            {
                Console.WriteLine(branch.Name +" "+ branch.Address+" "+branch.Budget);
            }
        }
        public void GetProfit()
        {
            Branch branch = new Branch();
            string name = Console.ReadLine();
            Branch branch1 = branches.DataBase.Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault();
            Console.Write("Calculate profit and loss: ");
            Console.Write("Input sell price: ");
            double sellPrice = double.Parse(Console.ReadLine());
            branch.employees.ForEach(c => sellPrice += c.Salary);
            double getProfit = branch.Budget - sellPrice;
            Console.WriteLine($"Profit of the {branch.Name}  branch is {getProfit}");
        }
        public void HireEmployee()
        {
            Console.Write("Name of branch : ");
            string brName = Console.ReadLine();
            Console.Write("Name of employee : ");
            string empName = Console.ReadLine();
            Branch branch = branches.DataBase.Where(s => s.Name == brName).FirstOrDefault();
            Employee employee = employeeService.employees.DataBase.Where(x=>x.Name == empName).FirstOrDefault();
            branch.employees.Add(employee);
            employee.branch = branch;
            foreach(var item in branch.employees)
            {
                Console.WriteLine("Employee + " + item.Name);
            }
            
        }
        public void TransferEmployee(Branch branch)
        {
            Employee employee = new Employee();
            if (branch.Budget > employee.Salary)
            {
                Console.Write("Enter the name of employee : ");
                string name = Console.ReadLine();
                Console.WriteLine();
                branch.employees.Remove(employee);
                branch.employees.Add(employee);
                branch.Budget -= employee.Salary;
                Console.WriteLine($"Employee {employee.Name}, {employee.Surname} transfer from {branch.Address}");
            }

        }
        public void TransferMoney()
        {           
            Console.Write("Enter branch name: ");
            string yourName = Console.ReadLine();
            Console.Write("Enter the name of the receivable branch : ");
            string name = Console.ReadLine();
            Console.Write("Enter the amount : ");
            double amount = double.Parse(Console.ReadLine());
            Branch branch = new Branch();
            foreach (Branch Transfer in branches.DataBase)
            {
                if (Transfer.Name == yourName)
                {
                    Transfer.Budget -= amount;
                    
                }
            }
            foreach (Branch Transfer in branches.DataBase)
            {
                if (Transfer.Name == name)
                {
                    Transfer.Budget += amount;
                    break;
                }
            }
        }
        public void Update()
        {
            Console.Write("Enter the branch name :");
            string Name = Console.ReadLine();
            Branch branch = branches.DataBase.Find(z => z.Name.Trim().ToLower() == Name.Trim().ToLower());
            Console.Write("Enter the branch budget :");
            branch.Budget = double.Parse(Console.ReadLine());
            Console.Write("Enter the branch address :");
            branch.Address = Console.ReadLine();
        }
    }
}
