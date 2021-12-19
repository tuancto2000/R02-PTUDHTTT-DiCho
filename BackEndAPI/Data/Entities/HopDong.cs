using System;
using System.Collections.Generic;

#nullable disable

namespace BackEndAPI.Entities
{
    public partial class HopDong
    {
        public int MaNguoiDung { get; set; }
        public int MaHopDong { get; set; }
        public DateTime? NgayKyHopDong { get; set; }
        public DateTime? NgayHieuLuc { get; set; }
        public DateTime? NgayKetThuc { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }
    }
}
