using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.DataAccess
{
    public class NhanVienDao
    {
        private static NhanVienDao instance = null;
        private static readonly object instanceLock = new object();
        public static NhanVienDao Instance
        {
            //Singlestone pattern
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new NhanVienDao();
                    }
                    return instance;
                }
            }
        }
        
        public IEnumerable<NhanVien> GetNhanVienList(string sortBy)
        {
            using var context = new MyStoreContext();
            List<NhanVien> model = context.NhanViens.ToList();
            try
            {
                switch (sortBy)
                {
                    case "id":
                        model = model.OrderBy(o => o.MaNhanVien).ToList();
                        break;
                    case "iddesc":
                        model = model.OrderByDescending(o => o.MaNhanVien).ToList();
                        break;
                    case "TenNhanVien":
                        model = model.OrderBy(o => o.TenNhanVien).ToList();
                        break;
                    case "TenNhanViendesc":
                        model = model.OrderByDescending(o => o.TenNhanVien).ToList();
                        break;
                    case "DiaChi":
                        model = model.OrderBy(o => o.DiaChi).ToList();
                        break;
                    case "DiaChidesc":
                        model = model.OrderByDescending(o => o.DiaChi).ToList();
                        break;
                    case "NgaySinh":
                        model = model.OrderBy(o => o.NgaySinh).ToList();
                        break;
                    case "NgaySinhdesc":
                        model = model.OrderByDescending(o => o.NgaySinh).ToList();
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

        

        public NhanVien GetNhanVienByID(int id)
        {
            NhanVien nv = null;
            try
            {
                using var context = new MyStoreContext();
                nv = context.NhanViens.SingleOrDefault(k => k.MaNhanVien == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return nv;
        }

        public IEnumerable<NhanVien> GetNhanVienBySearchName(string name, string sortBy)
        {
            var context = new MyStoreContext();
            
            List<NhanVien> model = context.NhanViens.ToList();
            try
            {
                if (!String.IsNullOrEmpty(name))
                {
                    model = model.Where(x => x.TenNhanVien.ToLower().Contains(name)).ToList();
                    switch (sortBy)
                    {
                        case "id":
                            model = model.OrderBy(o => o.MaNhanVien).ToList();
                            break;
                        case "iddesc":
                            model = model.OrderByDescending(o => o.MaNhanVien).ToList();
                            break;
                        case "TenKhachHang":
                            model = model.OrderBy(o => o.TenNhanVien).ToList();
                            break;
                        case "TenKhachHangdesc":
                            model = model.OrderByDescending(o => o.TenNhanVien).ToList();
                            break;
                        case "DiaChi":
                            model = model.OrderBy(o => o.DiaChi).ToList();
                            break;
                        case "DiaChidesc":
                            model = model.OrderByDescending(o => o.DiaChi).ToList();
                            break;
                        
                        case "NgaySinh":
                            model = model.OrderBy(o => o.NgaySinh).ToList();
                            break;
                        case "NgaySinhdesc":
                            model = model.OrderByDescending(o => o.NgaySinh).ToList();
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

        public void AddNew(NhanVien nv)
        {

            try
            {
                NhanVien _nv = GetNhanVienByID(nv.MaNhanVien);
                if (_nv == null)
                {
                    using var context = new MyStoreContext();
                    context.NhanViens.Add(nv);
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

        public void Update(NhanVien nv)
        {

            try
            {
                NhanVien _nv = GetNhanVienByID(nv.MaNhanVien);
                if (_nv != null)
                {
                    using var context = new MyStoreContext();
                    context.NhanViens.Update(nv);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This Nhan Vien does not already exist.");
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
                NhanVien _nv = GetNhanVienByID(id);
                if (_nv != null)
                {
                    using var context = new MyStoreContext();
                    context.NhanViens.Remove(_nv);
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
        public IEnumerable<NhanVien> RemoveNhanVienSelected(IEnumerable<int> DeleteList)
        {
            using var context = new MyStoreContext();
            var DeleteCatList = context.NhanViens.Where(z => DeleteList.Contains(z.MaNhanVien)).ToList();
            context.NhanViens.RemoveRange(DeleteCatList);
            context.SaveChanges();
            return DeleteCatList;
        }
        public bool ChangeStatus(int id)
        {
            using var context = new MyStoreContext();
            var nv = context.NhanViens.Find(id);
            nv.GioiTinh = !nv.GioiTinh;
            //context.NhanViens.Update(nv);
            context.SaveChanges();
            return nv.GioiTinh;
        }
    }
}
