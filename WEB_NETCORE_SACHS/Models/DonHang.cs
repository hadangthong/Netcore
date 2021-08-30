using System;
using System.Collections.Generic;

#nullable disable

namespace WEB_NETCORE_SACHS.Models
{
    public partial class DonHang
    {
        public int MaDonHang { get; set; }
        public DateTime? NgayGiao { get; set; }
        public DateTime? NgayDat { get; set; }
        public string TtthanhToan { get; set; }
        public string TtgiaoHang { get; set; }
        public int MaKh { get; set; }
        public decimal? TongTien { get; set; }
        public virtual KhachHang KhachHang { get; set; }
    }
}
