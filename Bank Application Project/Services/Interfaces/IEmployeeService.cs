using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_Application_Project.Models;
using Bank_Application_Project.Services.Implementations;

namespace Bank_Application_Project.Services.Interfaces
{
    public interface IEmployeeService :  IBankService , IBranchService
    {
       
    }
}
