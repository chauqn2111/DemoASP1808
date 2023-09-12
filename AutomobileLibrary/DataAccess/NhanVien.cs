using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutomobileLibrary.DataAccess
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            HoaDons = new HashSet<HoaDon>();
        }
        [Display(Name = "Mã Nhân Viên")]
        public int MaNhanVien { get; set; }
        [Display(Name = "Tên Nhân Viên")]
        public string? TenNhanVien { get; set; }
        [Display(Name = "Giới Tính")]
        public bool GioiTinh { get; set; }
        [Display(Name = "Địa Chỉ")]
        public string? DiaChi { get; set; }
        [Display(Name = "Điện Thoại")]
        public string? DienThoai { get; set; }
        [Display(Name = "Ngày Sinh")]
        public DateTime NgaySinh { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
