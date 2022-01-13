using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAPI.ViewModels.Users
{
    public class CuaHangCreateRequest
    {
        public int MaNguoiDung { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public string TenCuaHang { get; set; }
        public string DiaChi { get; set; }
        public string GiayPhepKinhDoanhImg { get; set; }
        public string ChungNhanAnToanImg { get; set; }
    }
}
