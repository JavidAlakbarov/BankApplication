﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_Application_Project.Data;
using Bank_Application_Project.Models;
using Bank_Application_Project.Services.Interfaces;

namespace Bank_Application_Project.Services.Implementations
{
    public class BranchService : IBranchService, IBankService<Branch>
    {
        public Bank<Branch> branches;

        public BranchService()  //Dependency Injection (Data-Bank classini gormek ucun)
        {
            branches = new Bank<Branch>();
        }
        public void Create(Branch entity)
        {
            if (entity.SoftDelete == false)
            {
                branches.DataBase.Add(entity);
            }       
          
        }

        public void Delete(string name)
        {
            Branch branch = branches.DataBase.Find(x => x.Name.ToLower().Trim() == name.ToLower().Trim());
            branch.SoftDelete = false;
            GetAll();
        }

        public void Get(string filter)
        {
            try
            {
                Branch branch = branches.DataBase.Find(m => m.Name.Contains(filter.ToLower().Trim()));
                Console.WriteLine(branch.Name);
            }
            catch (Exception)
            {
                Console.WriteLine("Branch not found");
            }
        }

        public void GetAll()
        {
            foreach (var branch in branches.DataBase.Where(m => m.SoftDelete == false))
            {
                Console.WriteLine(branch.Name +" "+ branch.Address);
            }
        }

        public void GetProfit()
        {
            throw new NotImplementedException();
        }

        public void HireEmployee()
        {
            throw new NotImplementedException();
        }

        public void TransferEmployee()
        {
            throw new NotImplementedException();
        }

        public void TransferMoney()
        {
            throw new NotImplementedException();
        }

        public void Update(string name,double budget,string address)
        {
            Branch branch = branches.DataBase.Find(z => z.Name.Trim().ToLower() == name.Trim().ToLower());
            branch.Budget = budget;
            branch.Address = address;
        }
    }
}
