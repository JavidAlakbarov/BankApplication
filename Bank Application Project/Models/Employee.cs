using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Application_Project.Models
{
    public class Employee : GeneralProperties
    {
        public string Surname { get; set; }
        public double Salary { get; set; }
        public string Profession { get; set; }
        //public Branch branch { get; set; }               
    }
}
