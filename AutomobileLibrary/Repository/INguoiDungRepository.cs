﻿using AutomobileLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.Repository
{
    public interface INguoiDungRepository
    {
        IEnumerable<NguoiDungViewModel> GetNguoiDungs(string sortBy);
        IEnumerable<NguoiDungViewModel> GetNguoiDungByNames(string searchName, int userType, string sortBy);
    }
}
