using BackEndAPI.Data.Enums;
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
        [HttpGet("paging")]
        public async Task<IActionResult> GetPaging(string search, int state = -1, int page = 1, int pageSize = 7)
        {
            var orders = _context.DonHang.Include(x => x.DSChiTietDonHang).ThenInclude(x => x.SanPham)
               .Include(x => x.NguoiMua).Include(x => x.Shipper).Include(x => x.CuaHang).AsQueryable();
            if (!String.IsNullOrEmpty(search)) orders = orders.Where(x => x.NguoiMua.TenNguoiDung.Contains(search) || x.TenNguoiNhan.Contains(search));
            if (state != -1) orders = orders.Where(x => (int)x.TrangThai == state);
            var total = await orders.CountAsync();
            orders = orders.Skip((page - 1) * pageSize).Take(pageSize);
            var data = orders.Select(x => new DonHangVM
            {
                MaDonHang = x.MaDonHang,
                TenNguoiDung = x.NguoiMua.TenNguoiDung,
                TenCuaHang = x.CuaHang.TenCuaHang,
                DiaChi = x.DiaChi,
                NgayMua = x.NgayMua,
                TrangThai = x.TrangThai.ToString(),
                TenNguoiNhan = x.TenNguoiNhan,
                Sdt = x.Sdt,
                PhanHoi = x.PhanHoi,
            }).ToList();
            return Ok(new { Data = data, Total = total });
        }

        [HttpGet("detail/{orderId}")]
        public async Task<IActionResult> GetDetail([FromRoute] int orderId)
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
                TrangThai = order.TrangThai.ToString(),
                TenNguoiNhan = order.TenNguoiNhan,
                Sdt = order.Sdt,
                PhanHoi = order.PhanHoi,
                DSChiTietDonHang = order.DSChiTietDonHang.Select(x => new ChiTietVM
                {
                    MaDonHang = x.MaDonHang,
                    TenSp = x.SanPham.TenSp,
                    SoLuong = x.SoLuong,
                    DonGia = x.DonGia
                }).ToList()
            };
            if (order.MaShipper != null) model.TenShipper = order.Shipper.TenNguoiDung;

            return Ok(model);
        }
        [HttpPut("cancel/{orderId}")]
        public async Task<IActionResult> Cancel(int orderId)
        {
            var order = await _context.DonHang.FirstOrDefaultAsync(x => x.MaDonHang == orderId);
            if (order == null)
                throw new Exception($"Khong tim thay don hang voi id: {orderId}");
            order.TrangThai = TrangThaiDonHang.Huy;
            if (await _context.SaveChangesAsync() > 0)
                return Ok();
            return BadRequest("Co loi trong qua trinh huy don hang");
        }
        [HttpPut("{orderId}")]
        public async Task<IActionResult> UpdateNextState(int orderId)
        {
            var order = await _context.DonHang.FirstOrDefaultAsync(x => x.MaDonHang == orderId);
            if (order == null)
                throw new Exception($"Khong tim thay don hang voi id: {orderId}");

            order.TrangThai = NextState(order.TrangThai);

            if (await _context.SaveChangesAsync() > 0)
                return Ok();
            return BadRequest("Co loi trong qua trinh cap nhat don hang");
        }
        private TrangThaiDonHang NextState(TrangThaiDonHang state)
        {
            switch (state)
            {
                case TrangThaiDonHang.ChoXacNhan:
                    {
                        return TrangThaiDonHang.DongGoi;
                    }
                case TrangThaiDonHang.DongGoi:
                    {
                        return TrangThaiDonHang.DangLayHang;
                    }
                case TrangThaiDonHang.DangLayHang:
                    {
                        return TrangThaiDonHang.DangGiaoHang;
                    }
                case TrangThaiDonHang.DangGiaoHang:
                    {
                        return TrangThaiDonHang.ThanhCong;
                    }
                default: return state;
            }
        }
    }
}
