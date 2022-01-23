using BackEndAPI.Data.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace BackEndAPI.Entities
{
    public partial class CuaHang
    {
        public int MaCuaHang { get; set; }
        public int MaNguoiDung { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public string TenCuaHang { get; set; }
        public int? MaDiaChi { get; set; }
        public DiaChi DiaChi { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }
        public virtual ICollection<DonHang> DSDonHang { get; set; }
        public virtual ICollection<SanPham> DSSanPham { get; set; }
    }
}
