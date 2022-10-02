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

    public class EmployeeService : IBankService<Employee>, IEmployeeService
    {
        public Bank<Employee> employees;
        public EmployeeService()  //Dependency Injection (Data-Bank classini gormek ucun)
        {
            employees=new Bank<Employee>();
        }
        public void Create(Employee employee)
        {
            try
            {               
                
                Console.WriteLine("Add new employee");
                Console.WriteLine("Name:");
                string name = Console.ReadLine();
                Console.WriteLine("Surname:");               
                string surname = Console.ReadLine();
                Console.WriteLine("Salary:");
                double salary = double.Parse(Console.ReadLine());
                Console.WriteLine("Profession:");
                string profession = Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("incorrect");
            }  
        }

        public void Delete(string name)
        {
           Employee employee = employees.DataBase.Find(x => x.Name.ToLower().Trim() == name.ToLower().Trim());
           employee.SoftDelete = true;
           GetAll();        
        }

        public void Get(string filter)
        {
            try
            {
                Employee employee = employees.DataBase.Find(m => m.Name.Contains(filter.ToLower().Trim())
                                                        || m.Surname.Contains(filter.ToLower().Trim()));
                Console.WriteLine(employee.Name + " " + employee.Surname);
            }
            catch (Exception)
            {
                Console.WriteLine("Employee not found");
            }        
        }

        public void GetAll()
        {
            foreach (var employee in employees.DataBase.Where(m => m.SoftDelete == false))
            {
                Console.WriteLine(employee.Name + " " + employee.Surname);
            }
        }

        public void Update(string name,double salary,string profession)
        {
            Employee employee = employees.DataBase.Find(z => z.Name.Trim().ToLower() == name.Trim().ToLower());
            employee.Salary = salary;
            employee.Profession=profession;
        }
    }
}
