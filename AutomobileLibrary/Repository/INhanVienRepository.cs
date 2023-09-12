﻿using AutomobileLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.Repository
{
    public interface INhanVienRepository
    {
        IEnumerable<NhanVien> GetNhanViens(string sortBy);
        IEnumerable<NhanVien> GetNhanVienByName(string name, string sortBy);
        NhanVien GetNhanVienByID(int id);
        void InsertNhanVien(NhanVien nv);
        void UpdateNhanVien(NhanVien nv);
        void DeleteNhanVien(int id);
        IEnumerable<NhanVien> DeleteSelectedNhanVien(IEnumerable<int> DeleteList);
    }
}
