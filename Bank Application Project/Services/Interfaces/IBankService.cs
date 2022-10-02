using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_Application_Project.Models;

namespace Bank_Application_Project.Services.Interfaces
{
    public interface IBankService <T> where T : GeneralProperties
    {
        void Create(T entity);
        void Update(string name,double salary,string profession);
        void Delete(string name);
        void Get(string entity);
        void GetAll();
    }
}
