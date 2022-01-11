using BackEndAPI.Entities;
using BackEndAPI.ViewModels.Orders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly PTUDContext _context;

        public OrdersController(PTUDContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = _context.DonHang;
            return Ok(orders);
        }
        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetDetail(int orderId)
        {
            var order = await _context.DonHang.Include(x => x.DSChiTietDonHang).ThenInclude(x => x.SanPham)
                .Include(x => x.NguoiMua).Include(x => x.Shipper).Include(x => x.CuaHang)
                .FirstOrDefaultAsync(x => x.MaDonHang == orderId);
            if (order == null)
                throw new Exception($"Can not find order with Id {orderId}");
            var model = new DonHangVM
            {
                MaDonHang = order.MaDonHang,
                TenNguoiDung = order.NguoiMua.TenNguoiDung,
                TenCuaHang = order.CuaHang.TenCuaHang,
                DiaChi = order.DiaChi,
                NgayMua = order.NgayMua,
                TrangThai = order.TrangThai,
                TenNguoiNhan = order.TenNguoiNhan,
                Sdt = order.Sdt,
                PhanHoi = order.PhanHoi,
                DSChiTietDonHang = order.DSChiTietDonHang.Select(x => new ChiTietVM {
                    MaDonHang = x.MaDonHang,
                    TenSp = x.SanPham.TenSp,
                    SoLuong = x.SoLuong,
                    DonGia = x.DonGia
                }).ToList()
            };
            if (order.MaShipper != null) model.TenShipper = order.Shipper.TenNguoiDung;

            return Ok(model);
        }
    }
}
