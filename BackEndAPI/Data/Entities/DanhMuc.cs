using System;
using System.Collections.Generic;

#nullable disable

namespace BackEndAPI.Entities
{
    public partial class DanhMuc
    {

        public int MaDm { get; set; }
        public string TenDm { get; set; }
        public virtual ICollection<SanPham> DSSanPham { get; set; }
    }
}
