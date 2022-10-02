using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Application_Project.Models
{
    public class Manager : GeneralProperties
    {
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


        public Manager(string name, string surname, string username, string password )
        {
            this.Name = name;
            this.Surname = surname;
            this.Username = username;
            this.Password = password;
            this.SoftDelete = false;
        }
    }
}
