﻿using AutomobileLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.Repository
{
    public class NguoiDungRepository : INguoiDungRepository
    {
        public IEnumerable<NguoiDung> GetNguoiDungs(string sortBy) =>NguoiDungDao.Instance.GetNguoiDungList(sortBy);
        
    }
}
