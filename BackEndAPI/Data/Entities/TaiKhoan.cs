using System;
using System.Collections.Generic;

#nullable disable

namespace BackEndAPI.Entities
{
    public partial class TaiKhoan
    {
        public int MaNguoiDung { get; set; }
        public string MatKhau { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }
    }
}
