using System;
using System.Collections.Generic;

#nullable disable

namespace BackEndAPI.Entities
{
    public partial class GioHang
    {
        public int MaGioHang { get; set; }
        public int MaNguoiDung { get; set; }
        public int TongTien { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }
        public virtual ICollection<ChiTietGioHang> DSChiTietGioHang { get; set; }
    }
}
