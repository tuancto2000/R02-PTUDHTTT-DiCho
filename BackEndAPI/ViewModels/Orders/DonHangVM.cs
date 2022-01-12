using BackEndAPI.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAPI.ViewModels.Orders
{
    public class DonHangVM
    {
        public int MaDonHang { get; set; }
        public string TenNguoiDung { get; set; }
        public string TenCuaHang { get; set; }
        public string TenShipper { get; set; }
        public string DiaChi { get; set; }
        public DateTime? NgayMua { get; set; }
        public string TrangThai { get; set; }
        public string TenNguoiNhan { get; set; }
        public string Sdt { get; set; }
        public string PhanHoi { get; set; }
        public List<ChiTietVM> DSChiTietDonHang { get; set; }
    }
}
