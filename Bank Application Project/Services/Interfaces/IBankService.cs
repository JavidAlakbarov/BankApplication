using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_Application_Project.Models;

namespace Bank_Application_Project.Services.Interfaces
{
    public interface IBankService <T> where T : GenericProperties
    {
        void Create(T entity);
        void Update();
        void Delete(string name);
        void Get(string filter);
        void GetAll();
    }
}
