using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Application_Project.Data
{
    public class Bank <T> 
    {
        public List<T> DataBase { get; set; }
        public Bank()
        {
            DataBase = new List<T>();
        }
    }
}
