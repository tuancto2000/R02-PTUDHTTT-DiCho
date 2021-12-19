using System;
using System.Collections.Generic;

#nullable disable

namespace BackEndAPI.Entities
{
    public partial class ChiTietGioHang
    {
        public int Id { get; set; }
        public int MaGioHang { get; set; }
        public int MaSp { get; set; }
        public int? SoLuong { get; set; }

        public virtual GioHang GioHang { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}
