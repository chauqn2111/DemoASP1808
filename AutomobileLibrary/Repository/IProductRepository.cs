﻿using AutomobileLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.Repository
{
    public interface IProductRepository
    {
        IEnumerable<HangHoa> GetProducts(string sortBy);
        IEnumerable<HangHoa> GetProductByName(string name, string sortBy);
        HangHoa GetProductByID(int id);
        void InsertProduct(HangHoa hh);
        void UpdateProduct(HangHoa hh);
        void DeleteProduct(int id);
    }
}
