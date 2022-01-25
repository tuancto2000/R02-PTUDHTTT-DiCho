using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAPI.ViewModels.Statitics
{
    public class DanhMucThietYeuVM
    {
        public string Ten { get; set; }
        public int SoLoaiSanPham { get; set; }
        public int? SoLuongConLai { get; set; }
        public int SoLuongBanRa { get; set; }
    }
}
