using BackEndAPI.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAPI.Data.Entities
{
    public class DiaChi
    {
        public int MaDiaChi { get; set; }
        public string TenDiaChi { get; set; }
        public int ToaDoDong { get; set; }
        public int ToaDoTay { get; set; }
        public LoaiVung LoaiVung { get; set; }
    }
}
