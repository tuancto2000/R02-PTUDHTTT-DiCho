using System;
using System.Collections.Generic;

#nullable disable

namespace BackEndAPI.Entities
{
    public partial class SanPham
    {
        public int MaSp { get; set; }
        public int MaCuaHang { get; set; }
        public int MaDm { get; set; }
        public string TenSp { get; set; }
        public int? GiaSp { get; set; }
        public int? SoLuongConLai { get; set; }
        public string MoTa { get; set; }
        public double TrungBinhSao { get; set; }
        public int SoLuotDanhGia { get; set; }
        public virtual CuaHang CuaHang { get; set; }
        public virtual DanhMuc DanhMuc { get; set; }
        public virtual ICollection<ChiTietDonHang> DSChiTietDonHang { get; set; }
        public virtual ICollection<ChiTietGioHang> DSChiTietGioHang { get; set; }
        public virtual ICollection<ChiTietGoiSanPham> DSChiTietGoiSanPham { get; set; }
        public virtual ICollection<HinhAnh> DSHinhAnh { get; set; }
    }
}


