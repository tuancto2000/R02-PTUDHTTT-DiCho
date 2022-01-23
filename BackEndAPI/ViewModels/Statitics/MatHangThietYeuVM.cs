using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAPI.ViewModels.Statitics
{
    public class MatHangThietYeuVM
    {
        public string TenDanhMuc { get; set; }
        public int TongSoLuongBanRa { get; set; }
        public int TongDoanhThu { get; set; }
        public List<DoanhThuSanPhamVM> DsSanPham { get; set; }
    }
}
