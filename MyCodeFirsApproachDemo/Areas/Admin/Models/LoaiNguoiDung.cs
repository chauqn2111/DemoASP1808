using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyCodeFirsApproachDemo.Areas.Admin.Models
{
    public class LoaiNguoiDung
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

    }
}
