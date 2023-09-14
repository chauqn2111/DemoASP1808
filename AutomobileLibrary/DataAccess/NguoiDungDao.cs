using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.DataAccess
{
    public class NguoiDungDao
    {
        private static NguoiDungDao instance = null;
        private static readonly object instanceLock = new object();
        public static NguoiDungDao Instance
        {
            //Singlestone pattern
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new NguoiDungDao();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<NguoiDung> GetNguoiDungList(string sortBy)
        {
            using var context = new MyStoreContext();
            List<NguoiDung> model = context.NguoiDungs.ToList();
            try
            {
                switch (sortBy)
                {
                    
                    case "TenDangNhap":
                        model = model.OrderBy(o => o.TenDangNhap).ToList();
                        break;
                    case "TenDangNhapdesc":
                        model = model.OrderByDescending(o => o.TenDangNhap).ToList();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return model;
        }
        //public IEnumerable<NguoiDung> RemoveNguoiDungnSelected(IEnumerable<int> DeleteList)
        //{
        //    using var context = new MyStoreContext();
        //    var DeleteCatList = context.NguoiDungs.Where(z => DeleteList.Contains(z.MaNguoiDung)).ToList();
        //    context.NguoiDungs.RemoveRange(DeleteCatList);
        //    context.SaveChanges();
        //    return DeleteCatList;
     
    }
}
