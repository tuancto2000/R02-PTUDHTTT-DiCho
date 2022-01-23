using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAPI.ViewModels.Statitics
{
    // Thống kê khách hàng, shipper, cửa hàng ở các vùng đỏ vàng xanh
    public class ThongKeNguoiDung
    {
        public string Ten { get; set; }
        public string Loai { get; set; }
        public string Email { get; set; }
        public string Sđt { get; set; }
        public string DiaChi { get; set; }
        public string Vung { get; set; }
    }
}
