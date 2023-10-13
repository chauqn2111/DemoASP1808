using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutomobileLibrary.DataAccess
{
    public partial class NguoiDung
    {
        [Display(Name = "Tên Đăng Nhập")]
        [Required(ErrorMessage = "Yêu Cầu Nhập Tên Đăng Nhập")]
        public string TenDangNhap { get; set; } 
        [Display(Name = "Mật Khẩu")]
        [Required(ErrorMessage = "Yêu Cầu Nhập Mật Khẩu")]
        public string MatKhau { get; set; } 
        [Display(Name = "Loại Người Dùng")]
        [Required(ErrorMessage = "Yêu Cầu Nhập Loại Người Dùng")]
        public int LoaiNguoiDung { get; set; }
        [Display(Name = "Mã Người Dùng")]
        [Required(ErrorMessage = "Yêu Cầu Nhập Mã Người Dùng")]
        public int? MaNguoiDung { get; set; }
        [Display(Name = "Giới Tính User")]
        public bool Status { get; set; }
    }
}
