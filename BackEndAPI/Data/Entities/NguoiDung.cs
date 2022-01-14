using BackEndAPI.Data.Entities;
using BackEndAPI.Data.Enums;
using System;
using System.Collections.Generic;

#nullable disable

namespace BackEndAPI.Entities
{
    public partial class NguoiDung
    {

        public int MaNguoiDung { get; set; }
        public int? MaDiaChi { get; set; }
        public string TenNguoiDung { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public LoaiNguoiDung VaiTro { get; set; }
        public bool KichHoat { get; set; }
        public virtual ICollection<CuaHang> CuaHang { get; set; }
        public virtual ICollection<DonHang> DSDonHangDaMua { get; set; }
        public virtual ICollection<DonHang> DSDonHangDaShip { get; set; }
        public virtual ICollection<GioHang> DSGioHang { get; set; }
        public virtual DiaChi DiaChi { get; set; }
    }
}
