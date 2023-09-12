using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.DataAccess
{
    public class KhachHangDao
    {
        private static KhachHangDao instance = null;
        private static readonly object instanceLock = new object();
        public static KhachHangDao Instance
        {
            //Singlestone pattern
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new KhachHangDao();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<KhachHang> RemoveKhachHangSelected(IEnumerable<int> DeleteList)
        {
            using var context = new MyStoreContext();
            var DeleteCatList = context.KhachHangs.Where(z => DeleteList.Contains(z.MaKhachHang)).ToList();
            context.KhachHangs.RemoveRange(DeleteCatList);
            context.SaveChanges();
            return DeleteCatList;
        }
        public IEnumerable<KhachHang> GetKhachHangList(string sortBy)
        {
            using var context = new MyStoreContext();
            List<KhachHang> model = context.KhachHangs.ToList();
            try
            {
                switch (sortBy)
                {
                    case "id":
                        model = model.OrderBy(o => o.MaKhachHang).ToList();
                        break;
                    case "iddesc":
                        model = model.OrderByDescending(o => o.MaKhachHang).ToList();
                        break;
                    case "TenKhachHang":
                        model = model.OrderBy(o => o.TenKhachHang).ToList();
                        break;
                    case "TenKhachHangdesc":
                        model = model.OrderByDescending(o => o.TenKhachHang).ToList();
                        break;
                    case "DiaChi":
                        model = model.OrderBy(o => o.DiaChi).ToList();
                        break;
                    case "DiaChidesc":
                        model = model.OrderByDescending(o => o.DiaChi).ToList();
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

        public KhachHang GetKhachHangByID(int id)
        {
            KhachHang kh = null;
            try
            {
                using var context = new MyStoreContext();
                kh = context.KhachHangs.SingleOrDefault(k => k.MaKhachHang == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return kh;
        }

        public IEnumerable<KhachHang> GetKhachHangBySearchName(string name, string sortBy)
        {
            var context = new MyStoreContext();
            /*var khachHangs = new List<KhachHang>();*/
            //IQueryable<KhachHang> model = context.KhachHangs;
            List<KhachHang> model = context.KhachHangs.ToList();
            try
            {
                if (!String.IsNullOrEmpty(name))
                {
                    model = model.Where(x => x.TenKhachHang.ToLower().Contains(name)).ToList();
                    switch (sortBy)
                    {
                        case "id":
                            model = model.OrderBy(o => o.MaKhachHang).ToList();
                            break;
                        case "iddesc":
                            model = model.OrderByDescending(o => o.MaKhachHang).ToList();
                            break;
                        case "TenKhachHang":
                            model = model.OrderBy(o => o.TenKhachHang).ToList();
                            break;
                        case "TenKhachHangdesc":
                            model = model.OrderByDescending(o => o.TenKhachHang).ToList();
                            break;
                        case "DiaChi":
                            model = model.OrderBy(o => o.DiaChi).ToList();
                            break;
                        case "DiaChidesc":
                            model = model.OrderByDescending(o => o.DiaChi).ToList();
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

        public void AddNew(KhachHang kh)
        {

            try
            {
                KhachHang _kh = GetKhachHangByID(kh.MaKhachHang);
                if (_kh == null)
                {
                    using var context = new MyStoreContext();
                    context.KhachHangs.Add(kh);
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

        public void Update(KhachHang kh)
        {

            try
            {
                KhachHang _kh = GetKhachHangByID(kh.MaKhachHang);
                if (_kh != null)
                {
                    using var context = new MyStoreContext();
                    context.KhachHangs.Update(kh);
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
                KhachHang _kh = GetKhachHangByID(id);
                if (_kh != null)
                {
                    using var context = new MyStoreContext();
                    context.KhachHangs.Remove(_kh);
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
