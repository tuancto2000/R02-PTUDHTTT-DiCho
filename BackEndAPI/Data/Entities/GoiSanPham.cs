using System;
using System.Collections.Generic;

#nullable disable

namespace BackEndAPI.Entities
{
    public partial class GoiSanPham
    {
        public int MaGoiSp { get; set; }
        public string TenGoiSp { get; set; }

        public virtual ICollection<ChiTietGoiSanPham> DSChiTietGoiSanPham { get; set; }
    }
}
