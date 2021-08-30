using System;
using System.Collections.Generic;

#nullable disable

namespace WEB_NETCORE_SACHS.Models
{
    public partial class ChiTietDonHang
    {
        public int MaDonHang { get; set; }
        public int MaSach { get; set; }
        public int? SoLuong { get; set; }
        public decimal? DonGia { get; set; }

        public virtual Sach MaSachs { get; set; }
        public virtual DonHang MaDonHangs { get; set; }
    }
}
