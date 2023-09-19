using AutomobileLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.Repository
{
    public interface IHoaDonRepository
    {
        IEnumerable<HoaDon> GetHoaDons(string sortBy);
        IEnumerable<HoaDon> GetHoaDonByName(string name, string sortBy);
        HoaDon GetHoaDonByID(int id);
        void InsertHoaDon(HoaDon hd);
        void UpdateHoaDon(HoaDon hd);
        void DeleteHoaDon(int id);
        IEnumerable<HoaDon> DeleteSelectedHoaDon(IEnumerable<int> DeleteList);
    }
}
