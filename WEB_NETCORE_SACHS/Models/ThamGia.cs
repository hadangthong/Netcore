using System;
using System.Collections.Generic;

#nullable disable

namespace WEB_NETCORE_SACHS.Models
{
    public partial class ThamGia
    {
        public int MaSach { get; set; }
        public int MaTacGia { get; set; }
        public string VaiTro { get; set; }
        public string ViTri { get; set; }

        public virtual Sach MaSachs { get; set; }
        public virtual TacGia MaTacGias { get; set; }
    }
}
