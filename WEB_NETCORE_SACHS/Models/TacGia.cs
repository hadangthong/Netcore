using System;
using System.Collections.Generic;

#nullable disable

namespace WEB_NETCORE_SACHS.Models
{
    public partial class TacGia
    {
        public TacGia()
        {
            ThamGia = new HashSet<ThamGia>();
        }

        public int MaTacGia { get; set; }
        public string TenTacGia { get; set; }
        public string DiaChi { get; set; }
        public string TieuSu { get; set; }
        public string DienThoai { get; set; }

        public virtual ICollection<ThamGia> ThamGia { get; set; }
    }
}
