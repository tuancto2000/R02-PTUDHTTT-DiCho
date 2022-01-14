using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAPI.ViewModels.Products
{
    public class SanPhamVM
    {
        public int MaSp { get; set; }
        public int TenCuaHang { get; set; }
        public int MaDm { get; set; }
        public string TenDm { get; set; }
        public string TenSp { get; set; }
        public int? GiaSp { get; set; }
        public int? SoLuongConLai { get; set; }
        public string MoTa { get; set; }
    }
}
