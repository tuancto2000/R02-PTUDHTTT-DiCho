using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAPI.ViewModels.Contracts
{
    public class ContractVM
    {
        public int MaNguoiDung { get; set; }
        public int MaHopDong { get; set; }
        public DateTime? NgayDangKy { get; set; }
        public DateTime? NgayHieuLuc { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string HopDongImg { get; set; }
    }
}
