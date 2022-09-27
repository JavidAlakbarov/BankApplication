using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Application_Project.Models
{
    public class Manager : GenericProperties
    {
        public string Surname { get; set; }
        
        public string Username = Console.ReadLine();
        public string Login = "Javid023";
        public int Password = int.Parse(Console.ReadLine());
        public int pinCode = 2323;

        public Manager(string name, string surname, string username, int password )
        {
            this.Name = name;
            this.Surname = surname;
            this.Username = username;
            this.Password = password;
            this.SoftDelete = false;
        }
    }
}
