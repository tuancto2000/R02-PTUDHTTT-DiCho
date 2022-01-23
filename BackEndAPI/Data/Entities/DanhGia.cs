using BackEndAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAPI.Data.Entities
{
    public class DanhGia
    {
        public int MaDanhGia { get; set; }
        public int MaNguoiDung { get; set; }
        public int MaChiTietDonHang { get; set; }
        public int MaSanPham { get; set; }
        public int Sao { get; set; }
        public string BinhLuan { get; set; }
        public NguoiDung NguoiDung { get; set; }
        public ChiTietDonHang ChiTietDonHang { get; set; }
        public SanPham SanPham { get; set; }
    }
}
