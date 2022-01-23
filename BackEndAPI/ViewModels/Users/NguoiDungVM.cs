using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAPI.ViewModels.Users
{
    public class NguoiDungVM
    {
        public int MaNguoiDung { get; set; }
        public string MatKhau { get; set; }
        public string TenNguoiDung { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public string VaiTro { get; set; }
    }
}
