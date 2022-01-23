using System;
using System.Collections.Generic;

#nullable disable

namespace BackEndAPI.Entities
{
    public partial class HopDong
    {
        public int MaNguoiDung { get; set; }
        public int MaHopDong { get; set; }
        public DateTime? NgayDangKy { get; set; }
        public DateTime? NgayKyHopDong { get; set; }
        public DateTime? NgayHieuLuc { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string GiayPhepKinhDoanhImg { get; set; }
        public string ChungNhanAnToanImg { get; set; }
        public string HopDongImg { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }
    }
}
