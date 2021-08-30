using System;
using System.Collections.Generic;

#nullable disable

namespace WEB_NETCORE_SACHS.Models
{
    public partial class KhachHang
    {
        public int MaKh { get; set; }
        public string HoTen { get; set; }
        public string DienThoai { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
    }
}
