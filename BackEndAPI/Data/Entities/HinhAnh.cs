using System;
using System.Collections.Generic;

#nullable disable

namespace BackEndAPI.Entities
{
    public partial class HinhAnh
    {
        public int MaHinhAnh { get; set; }
        public int MaSp { get; set; }
        public string NguonHinhAnh { get; set; }
        public bool? MacDinh { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
