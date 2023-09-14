using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutomobileLibrary.DataAccess
{
    public partial class HoaDon
    {
        public HoaDon()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }
        [Display(Name = "Mã Hóa Đơn")]
        public int MaHoaDon { get; set; }
        [Display(Name = "Mã Nhân Viên")]
        public int MaNhanVien { get; set; }
        [Display(Name = "Mã Khách Hàng")]
        public int MaKhachHang { get; set; }
        [Display(Name = "Ngày Bán")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy")]
        [DataType(DataType.Date)]
        public DateTime NgayBan { get; set; }
        [Display(Name = "Tổng Tiền")]
        public decimal TongTien { get; set; }

        public virtual KhachHang MaKhachHangNavigation { get; set; } = null!;
        public virtual NhanVien MaNhanVienNavigation { get; set; } = null!;
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
