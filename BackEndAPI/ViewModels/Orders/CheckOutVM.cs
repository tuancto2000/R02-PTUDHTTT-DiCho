using BackEndAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAPI.ViewModels.Orders
{
    public class CheckOutVM
    {
        public int MaCuaHang { get; set; }
        public List<ChiTietDonHang> DsChiTiet { get; set; }
    }
}
