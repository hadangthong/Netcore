using System;
using System.Collections.Generic;

#nullable disable

namespace WEB_NETCORE_SACHS.Models
{
    public partial class Sach
    {
        public Sach()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
            ThamGia = new HashSet<ThamGia>();
        }

        public int MaSach { get; set; }
        public string TenSach { get; set; }
        public decimal? GiaBan { get; set; }
        public string MoTa { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public string AnhBia { get; set; }
        public int? SoLuongTon { get; set; }
        public int? MaChuDe { get; set; }
        public int? MaNxb { get; set; }
        public int? Moi { get; set; }
        
        public virtual ChuDe ChuDe { get; set; }
        public virtual NhaXuatBan NhaXuatBan { get; set; }
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual ICollection<ThamGia> ThamGia { get; set; }
    }
}
