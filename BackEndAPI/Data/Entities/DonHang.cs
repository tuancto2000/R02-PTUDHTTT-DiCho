using BackEndAPI.Data.Enums;
using System;
using System.Collections.Generic;

#nullable disable

namespace BackEndAPI.Entities
{
    public partial class DonHang
    {
        public int MaDonHang { get; set; }
        public int MaNguoiDung { get; set; }
        public int MaCuaHang { get; set; }
        public int? MaShipper { get; set; }
        public string DiaChi { get; set; }
        public DateTime? NgayMua { get; set; }
        public TrangThaiDonHang TrangThai { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public string TenNguoiNhan { get; set; }
        public string Sdt { get; set; }
        public string PhanHoi { get; set; }

        public virtual CuaHang CuaHang { get; set; }
        public virtual NguoiDung NguoiMua { get; set; }
        public virtual NguoiDung Shipper { get; set; }
        public virtual ICollection<ChiTietDonHang> DSChiTietDonHang { get; set; }
    }
}
