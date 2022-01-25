using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAPI.ViewModels.Orders
{
    public class DonHangCreateRequest
    {
        public int MaNguoiDung { get; set; }
        public string DiaChi { get; set; }
        public string TenNguoiNhan { get; set; }
        public string Sdt { get; set; }
        public string PhanHoi { get; set; }
        public List<ChiTietVM> DSChiTietDonHang { get; set; }
    }
}
