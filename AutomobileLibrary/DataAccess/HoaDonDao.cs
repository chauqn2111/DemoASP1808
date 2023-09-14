using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.DataAccess
{
    public class HoaDonDao
    {
        private static HoaDonDao instance = null;
        private static readonly object instanceLock = new object();
        public static HoaDonDao Instance
        {
            //Singlestone pattern
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new HoaDonDao();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<HoaDon> RemoveHoaDonSelected(IEnumerable<int> DeleteList)
        {
            using var context = new MyStoreContext();
            var DeleteCatList = context.HoaDons.Where(z => DeleteList.Contains(z.MaHoaDon)).ToList();
            context.HoaDons.RemoveRange(DeleteCatList);
            context.SaveChanges();
            return DeleteCatList;
        }
        public IEnumerable<HoaDon> GetHoaDonList(string sortBy)
        {
            using var context = new MyStoreContext();
            List<HoaDon> model = context.HoaDons.ToList();
            try
            {
                switch (sortBy)
                {
                    case "id":
                        model = model.OrderBy(o => o.MaHoaDon).ToList();
                        break;
                    case "iddesc":
                        model = model.OrderByDescending(o => o.MaHoaDon).ToList();
                        break;
                    case "MaNhanVien":
                        model = model.OrderBy(o => o.MaNhanVien).ToList();
                        break;
                    case "MaNhanViendesc":
                        model = model.OrderByDescending(o => o.MaNhanVien).ToList();
                        break;
                    case "NgayBan":
                        model = model.OrderBy(o => o.NgayBan).ToList();
                        break;
                    case "NgayBandesc":
                        model = model.OrderByDescending(o => o.NgayBan).ToList();
                        break;
                    case "TongTien":
                        model = model.OrderBy(o => o.TongTien).ToList();
                        break;
                    case "TongTiendesc":
                        model = model.OrderByDescending(o => o.TongTien).ToList();
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

        //public IEnumerable<KhachHang> GetKhachHangList()
        //{
        //    var khachHangs = new List<KhachHang>();
        //    try
        //    {
        //        using var context = new MyStoreContext();
        //        khachHangs = context.KhachHangs.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return khachHangs;
        //}

        public HoaDon GetHoaDonByID(int id)
        {
            HoaDon hd = null;
            try
            {
                using var context = new MyStoreContext();
                hd = context.HoaDons.SingleOrDefault(k => k.MaHoaDon == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return hd;
        }

        public IEnumerable<HoaDon> GetHoaDonBySearchName(string name, string sortBy)
        {
            var context = new MyStoreContext();
            /*var khachHangs = new List<KhachHang>();*/
            //IQueryable<KhachHang> model = context.KhachHangs;
            List<HoaDon> model = context.HoaDons.ToList();
            try
            {
                if (!String.IsNullOrEmpty(name))
                {
                    //model = model.Where(x => x.MaNhanVien.ToLower().Contains(name)).ToList();
                    switch (sortBy)
                    {
                        case "id":
                            model = model.OrderBy(o => o.MaHoaDon).ToList();
                            break;
                        case "iddesc":
                            model = model.OrderByDescending(o => o.MaHoaDon).ToList();
                            break;
                        case "MaNhanVien":
                            model = model.OrderBy(o => o.MaNhanVien).ToList();
                            break;
                        case "MaNhanViendesc":
                            model = model.OrderByDescending(o => o.MaNhanVien).ToList();
                            break;
                        case "NgayBan":
                            model = model.OrderBy(o => o.NgayBan).ToList();
                            break;
                        case "NgayBandesc":
                            model = model.OrderByDescending(o => o.NgayBan).ToList();
                            break;
                        case "MaKhachHang":
                            model = model.OrderBy(o => o.MaKhachHang).ToList();
                            break;
                        case "MaKhachHangdesc":
                            model = model.OrderByDescending(o => o.MaKhachHang).ToList();
                            break;
                        case "TongTien":
                            model = model.OrderBy(o => o.TongTien).ToList();
                            break;
                        case "TongTiendesc":
                            model = model.OrderByDescending(o => o.TongTien).ToList();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return model;
        }

        public void AddNew(HoaDon hd)
        {

            try
            {
                HoaDon _hd = GetHoaDonByID(hd.MaHoaDon);
                if (_hd == null)
                {
                    using var context = new MyStoreContext();
                    context.HoaDons.Add(hd);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This Customer is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(HoaDon hd)
        {

            try
            {
                HoaDon _hd = GetHoaDonByID(hd.MaHoaDon);
                if (_hd != null)
                {
                    using var context = new MyStoreContext();
                    context.HoaDons.Update(hd);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This Customer does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int id)
        {
            try
            {
                HoaDon _hd = GetHoaDonByID(id);
                if (_hd != null)
                {
                    using var context = new MyStoreContext();
                    context.HoaDons.Remove(_hd);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This Customer does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
