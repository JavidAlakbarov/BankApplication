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
    }
}
