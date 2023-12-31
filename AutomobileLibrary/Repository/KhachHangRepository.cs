﻿using AutomobileLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.Repository
{
    public class KhachHangRepository : IKhachHangRepository
    {
        public IEnumerable<KhachHang> GetKhachHangs(string sortBy) => KhachHangDao.Instance.GetKhachHangList(sortBy);
        public IEnumerable<KhachHang> GetKhachHangByName(string name, string sortBy, string CityName) => KhachHangDao.Instance.GetKhachHangBySearchName(name, sortBy, CityName);
        public KhachHang GetKhachHangByID(int id) => KhachHangDao.Instance.GetKhachHangByID(id);
        public void InsertKhachHang(KhachHang kh) => KhachHangDao.Instance.AddNew(kh);
        public void UpdateKhachHang(KhachHang kh) => KhachHangDao.Instance.Update(kh);
        public void DeleteKhachHang(int id) => KhachHangDao.Instance.Remove(id);
        public IEnumerable<KhachHang> DeleteSelectedKhachHang(IEnumerable<int> DeleteList) => KhachHangDao.Instance.RemoveKhachHangSelected(DeleteList);

    }
}
