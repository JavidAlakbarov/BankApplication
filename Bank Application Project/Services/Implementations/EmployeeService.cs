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
        public void Create()
        {           
                Console.Write("Enter the name :");
                string name = Console.ReadLine();
                Console.Write("Enter the surname :");
                string surname = Console.ReadLine();
                Console.WriteLine("Enter the salary :");
                double salary = double.Parse(Console.ReadLine());
                Console.Write("Enter the profession :");
                string profession = Console.ReadLine();
                Employee employee = new Employee();
                employee.Name = name;
                employee.Surname = surname;
                employee.Salary = salary;
                employee.Profession = profession;
                employees.DataBase.Add(employee);
                Console.WriteLine($"Name:{name},Surname:{surname},Salary:{salary},Profession:{profession}");                          
        }
        public void Delete(Employee employee1)
        {
           Employee employee = employees.DataBase.Find(x => x.Name.ToLower().Trim() == employee1.Name.ToLower().Trim());                   
          employee.SoftDelete = true;
           GetAll();        
        }
        public void Get(string entity)
        {
            try
            {
                Employee employee = employees.DataBase.Find(m => m.Name.Contains(entity.ToLower().Trim())
                                                        || m.Surname.Contains(entity.ToLower().Trim()));
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
        public void Update()
        {
            Console.Write("Enter the name :");
            string Name = Console.ReadLine();
            Employee employee = employees.DataBase.Find(z => z.Name.Trim().ToLower() == Name.Trim().ToLower());
            Console.Write("Enter the salary :");
            employee.Salary = double.Parse(Console.ReadLine());
            Console.Write("Enter the profession :");
            employee.Profession = Console.ReadLine();
        }
    }
}
