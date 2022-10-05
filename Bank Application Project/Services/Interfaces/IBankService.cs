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
        void Create();
        void Update();
        void Delete(T branch);
        void Get(string entity);
        void GetAll();
    }
}
