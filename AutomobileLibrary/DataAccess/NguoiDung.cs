﻿using System;
using System.Collections.Generic;

namespace AutomobileLibrary.DataAccess
{
    public partial class NguoiDung
    {
        public string TenDangNhap { get; set; } = null!;
        public string MatKhau { get; set; } = null!;
        public int LoaiNguoiDung { get; set; }
        public int? MaNguoiDung { get; set; }
    }
}