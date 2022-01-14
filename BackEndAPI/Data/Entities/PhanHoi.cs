using BackEndAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAPI.Data.Entities
{
    public class PhanHoi
    {
        public int MaPhanHoi { get; set; }
        public int MaNguoiPhanHoi { get; set; }
        public int MaNguoiDuocPhanHoi { get; set; }
        public string NoiDung { get; set; }
        public NguoiDung NguoiPhanHoi { get; set; }
        public NguoiDung NguoiDuocPhanHoi { get; set; }
    }
}
