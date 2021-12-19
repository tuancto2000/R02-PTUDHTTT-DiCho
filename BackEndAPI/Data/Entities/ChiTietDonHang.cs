using System;
using System.Collections.Generic;

#nullable disable

namespace BackEndAPI.Entities
{
    public partial class ChiTietDonHang
    {
        public int Id { get; set; }
        public int MaDonHang { get; set; }
        public int MaSp { get; set; }
        public int? SoLuong { get; set; }
        public int? DonGia { get; set; }

        public virtual DonHang DonHang { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}
