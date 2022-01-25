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
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DonHangCreateRequest request)
        {
            var checkout = new List<CheckOutVM>();
            foreach (var item in request.DSChiTietDonHang)
            {
                var sanpham = await _context.SanPham.FindAsync(item.MaSp);
                if (sanpham == null) return BadRequest("Khong tim thay san pham");
                var maCuaHang = sanpham.MaCuaHang;
                var rs = checkout.FirstOrDefault(x => x.MaCuaHang == maCuaHang);
                if(rs != null)
                {
                    checkout.FirstOrDefault(x => x.MaCuaHang == maCuaHang).DsChiTiet.Add(new ChiTietDonHang
                    {
                        MaSp = item.MaSp,
                        SoLuong = item.SoLuong,
                        DonGia = item.DonGia
                    });
                }
                else
                {
                    var ds = new List<ChiTietDonHang>();
                    ds.Add(new ChiTietDonHang
                    {
                        MaSp = item.MaSp,
                        SoLuong = item.SoLuong,
                        DonGia = item.DonGia
                    });
                    var c = new CheckOutVM
                    {
                        MaCuaHang = maCuaHang,
                        DsChiTiet = ds
                    };
                    checkout.Add(c);
                }
            }
            foreach (var item in checkout)
            {
                var donhang = new DonHang
                {
                    MaNguoiDung = request.MaNguoiDung,
                    MaCuaHang = item.MaCuaHang,
                    DiaChi = request.DiaChi,
                    NgayMua = DateTime.Now,
                    TrangThai = TrangThaiDonHang.ChoXacNhan,
                    TenNguoiNhan = request.TenNguoiNhan,
                    Sdt = request.Sdt,
                    PhanHoi = request.PhanHoi,
                    DSChiTietDonHang = item.DsChiTiet,
                    TongTien = item.DsChiTiet.Sum(x => x.SoLuong * x.DonGia)
                };
                _context.DonHang.Add(donhang);
            }
           
            if (await _context.SaveChangesAsync() > 0)
                return Ok();
            return BadRequest("Co loi trong qua trinh tao don hang");
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetPaging(string search, int state = -1, int page = 1, int pageSize = 7, int maKhachHang = 0)
        {
            var orders = _context.DonHang.Include(x => x.DSChiTietDonHang).ThenInclude(x => x.SanPham)
               .Include(x => x.NguoiMua).Include(x => x.Shipper).Include(x => x.CuaHang).AsQueryable();
            if (maKhachHang != 0) orders = orders.Where(x => x.MaNguoiDung == maKhachHang);
            if (!String.IsNullOrEmpty(search)) orders = orders.Where(x => x.DiaChi.Contains(search));
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
                TongTien = x.TongTien

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
                    TenSp = x.SanPham.TenSp,
                    SoLuong = x.SoLuong,
                    DonGia = x.DonGia
                }).ToList(),
                TongTien = order.TongTien
            };
            if (order.MaShipper != null) model.TenShipper = order.Shipper.TenNguoiDung;

            return Ok(model);
        }
        [HttpPut("cancel/{orderId}")]
        public async Task<IActionResult> Cancel(int orderId)
        {
            var order = await _context.DonHang.FirstOrDefaultAsync(x => x.MaDonHang == orderId);
            if (order == null)
                return BadRequest($"Khong tim thay don hang voi id: {orderId}");
            if (order.TrangThai == TrangThaiDonHang.Huy)
                return BadRequest($"Khong the huy don hang co trang thai huy");
            if (order.TrangThai == TrangThaiDonHang.ThanhCong)
                return BadRequest($"Khong the huy don hang co trang thai thanh cong");
            order.TrangThai = TrangThaiDonHang.Huy;
            if (await _context.SaveChangesAsync() > 0)
                return Ok();
            return BadRequest("Co loi trong qua trinh huy don hang");
        }
        [HttpPut("{orderId}")]
        public async Task<IActionResult> UpdateNextState(int orderId, [FromQuery] int shipperId = -1)
        {
            var order = await _context.DonHang.FindAsync(orderId);
            if (order == null)
                throw new Exception($"Khong tim thay don hang voi id: {orderId}");
            if (shipperId != -1)
            {
                var shipper = await _context.NguoiDung.FindAsync(shipperId);
                if (shipper.VaiTro != LoaiNguoiDung.Shipper)
                    return BadRequest("Ban khong phai la shipper");
                order.MaShipper = shipperId;
            }
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
        [HttpGet("getbystore/{storeId}")]
        public async Task<IActionResult> GetByStore(int storeId)
        {
            var donhang = _context.DonHang.Include(x => x.DSChiTietDonHang).ThenInclude(x => x.SanPham)
                .Where(x => x.MaCuaHang == storeId).Select(x => new DonHangVM
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
                    TongTien = x.TongTien,
                    DSChiTietDonHang = x.DSChiTietDonHang.Select(x => new ChiTietVM
                    {
                        DonGia = x.DonGia,
                        MaSp = x.MaSp,
                        SoLuong = x.SoLuong,
                        TenSp = x.SanPham.TenSp
                    }).ToList()
                }).ToList(); 

            return Ok(donhang);
        }
    }
}
