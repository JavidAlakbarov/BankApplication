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

        public BranchService()  //Dependency Injection (Data-Bank classini gormek ucun)
        {
            branches = new Bank<Branch>();
        }
        public void Create()
        {
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
        public void Delete(Branch branch1)
        {
            Branch branch = branches.DataBase.Find(x => x.Name.ToLower().Trim() == branch1.Name.ToLower().Trim());
            branch.SoftDelete = false;
            GetAll();
        }
        public void Get(string entity)
        {
            try
            {
                Console.Write("Enter the branch name :");
                string entity1 = Console.ReadLine();
                Branch branch = branches.DataBase.Find(m => m.Name.Contains(entity.ToLower().Trim()));
                Console.WriteLine(branch.Name);
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
                Console.WriteLine(branch.Name +" "+ branch.Address);
            }
        }
        public void GetProfit(string name)
        {
            Branch branch = branches.DataBase.Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault();
            Console.Write("Calculate profit and loss: ");
            Console.Write("Input Cost Price: ");
            Console.Write("Input Selling Price: ");
            double sellprice = 0;
            branch.employees.ForEach(c => sellprice += c.Salary);
            double getprofit = branch.Budget - sellprice;
            Console.WriteLine($"Profit of the {branch.Name}  branch in {getprofit}");
        }
        public void HireEmployee(Branch branch)
        {
            Employee employee = new Employee();
            if (branch.Budget > employee.Salary)
            {
                branch.employees.Add(employee);
                branch.Budget -= employee.Salary;
                Console.WriteLine($"Employee {employee.Name} surname {employee.Surname} was successfully hired. ");
            }
        }
        public void TransferEmployee(Branch branch)
        {
            Employee employee = new Employee();
            if (branch.Budget > employee.Salary)
            {
                branch.employees.Remove(employee);
                branch.employees.Add(employee);
                branch.Budget -= employee.Salary;
                Console.WriteLine($"Employee {employee.Name} {employee.Surname} transtfer from {branch.Address}");
            }
        }
        public void TransferMoney()
        {
            Console.WriteLine("---Trasfer Money---");
            Console.Write("Please enter your Name: ");
            string yourname = Console.ReadLine();
            Console.Write("Please enter the Name of the person you would like to tranfer funds to: ");
            string name = Console.ReadLine();
            Console.Write("Enter the amount of funds you would like to transfer: ");
            string amount = Console.ReadLine();
            Branch branch = new Branch();
            foreach (Branch Transfer in branches.DataBase)
            {
                if (Transfer.Name == name)
                {
                    Transfer.Budget -= branch.Budget;
                    break;
                }
            }
            foreach (Branch Transfer in branches.DataBase)
            {
                if (Transfer.Name == name)
                {
                    branch.Budget += Transfer.Budget;
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
