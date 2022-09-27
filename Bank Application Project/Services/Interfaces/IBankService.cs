using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_Application_Project.Models;

namespace Bank_Application_Project.Services.Interfaces
{
    public interface IBankService 
    {
        void Create();
        void Update();
        void Delete();
        void Get();
        void GetAll();
    }
}
