using AutomobileLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.Repository
{
    public class HoaDonRepository : IHoaDonRepository
    {
        public IEnumerable<HoaDon> GetHoaDons(string sortBy) => HoaDonDao.Instance.GetHoaDonList(sortBy);
        public IEnumerable<HoaDon> GetHoaDonByName(string name, string sortBy) => HoaDonDao.Instance.GetHoaDonBySearchName(name, sortBy);
        public HoaDon GetHoaDonByID(int id) => HoaDonDao.Instance.GetHoaDonByID(id);
        public void InsertHoaDon(HoaDon hd) => HoaDonDao.Instance.AddNew(hd);
        public void UpdateHoaDon(HoaDon hd) => HoaDonDao.Instance.Update(hd);
        public void DeleteHoaDon(int id) => HoaDonDao.Instance.Remove(id);
        public IEnumerable<HoaDon> DeleteSelectedHoaDon(IEnumerable<int> DeleteList) => HoaDonDao.Instance.RemoveHoaDonSelected(DeleteList);
    }
}
