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
        [Required(ErrorMessage = "Yêu Cầu Nhập Tên Nhân Viên")]
        public string? TenNhanVien { get; set; }
        [Display(Name = "Giới Tính")]
        [Required(ErrorMessage = "Yêu Cầu Nhập Giới Tính Nhân Viên")]
        public bool GioiTinh { get; set; }
        [Display(Name = "Địa Chỉ")]
        [Required(ErrorMessage = "Yêu Cầu Nhập Địa Chỉ Nhân Viên")]
        public string? DiaChi { get; set; }
        [Display(Name = "Điện Thoại")]
        [Required(ErrorMessage = "Yêu Cầu Nhập Điện Thoại Nhân Viên")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\d{10,}$",ErrorMessage ="Số điện thoại hợp lệ")]
        public string? DienThoai { get; set; }

        [Display(Name = "Ngày Sinh")]
        [Required(ErrorMessage = "Yêu Cầu Nhập Ngày Sinh Nhân Viên")]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime NgaySinh { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
