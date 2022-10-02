using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Application_Project.Models
{
    public class Branch : GeneralProperties
    {
        public string Address { get; set; }
        public double Budget { get; set; }
        public List<Employee> employees { get; set; }
        public Branch(string name, string address, double budget)
        {
            this.Name = name;
            this.Address = address;
            this.Budget = budget;
            this.employees = new List<Employee>();
            this.SoftDelete = false;            
        }
    
    }
}
