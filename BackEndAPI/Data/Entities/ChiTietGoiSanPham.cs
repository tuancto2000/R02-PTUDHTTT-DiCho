using System;
using System.Collections.Generic;

#nullable disable

namespace BackEndAPI.Entities
{
    public partial class ChiTietGoiSanPham
    {
        public int Id { get; set; }
        public int MaSp { get; set; }
        public int MaGoiSp { get; set; }
        public int? SoLuong { get; set; }

        public virtual GoiSanPham GoiSanPham { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}
