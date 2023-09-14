using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutomobileLibrary.DataAccess
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            HoaDons = new HashSet<HoaDon>();
        }
        [Display(Name = "Mã khách hàng")]
        [Required(ErrorMessage ="Yêu Cầu Nhập Mã Khách Hàng")]
        public int MaKhachHang { get; set; }
        [Display(Name = "Tên khách hàng")]
        [Required(ErrorMessage = "Yêu Cầu Nhập Tên Khách Hàng")]
        public string? TenKhachHang { get; set; }
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Yêu Cầu Nhập Địa Chỉ")]
        public string? DiaChi { get; set; }
        [Display(Name = "Điện thoại")]
        [Required(ErrorMessage = "Yêu Cầu Nhập Số Điện Thoại")]
        public string? DienThoai { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
