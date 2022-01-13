using BackEndAPI.Data.Enums;
using BackEndAPI.Entities;
using BackEndAPI.ViewModels.Contracts;
using BackEndAPI.ViewModels.Users;
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
    public class ContractsController : ControllerBase
    {
        private readonly PTUDContext _context;

        public ContractsController(PTUDContext context)
        {
            _context = context;
        }

        [HttpPost("shipper/{userId}")]
        public async Task<IActionResult> ShipperRegister(int userId)
        {
            var nguoidung = await _context.NguoiDung.FindAsync(userId);
            if (nguoidung == null)
                return BadRequest($"Khong tim thay nguoi dung voi Id : {userId}");
            var checkHopdong = await _context.HopDong.FirstOrDefaultAsync(x => x.MaNguoiDung == userId);
            if (checkHopdong != null)
                return BadRequest($"Ban da dang ky roi");
            var hopdong = new HopDong
            {
                MaNguoiDung = userId,
                NgayDangKy = DateTime.Now
            };
            nguoidung.VaiTro = LoaiNguoiDung.Shipper;
            _context.HopDong.Add(hopdong);
            if (await _context.SaveChangesAsync() > 0)
                return Ok(hopdong.MaHopDong);
            return BadRequest("Co loi trong qua trinh dang ky lam shipper");
        }
        [HttpPost("store")]
        public async Task<IActionResult> StoreRegister([FromBody] CuaHangCreateRequest request)
        {
            var nguoidung = await _context.NguoiDung.FindAsync(request.MaNguoiDung);
            if (nguoidung == null)
                throw new Exception($"Khong tim thay nguoi dung voi Id : {request.MaNguoiDung}");
            var checkHopdong = await _context.HopDong.FirstOrDefaultAsync(x => x.MaNguoiDung == request.MaNguoiDung);
            if (checkHopdong != null)
                return BadRequest($"Ban da dang ky roi");
            var cuahang = new CuaHang
            {
                MaNguoiDung = request.MaNguoiDung,
                DiaChi = request.DiaChi,
                Email = request.Email,
                Sdt = request.Sdt,
                TenCuaHang = request.TenCuaHang,
            };
            var hopdong = new HopDong
            {
                MaNguoiDung = request.MaNguoiDung,
                ChungNhanAnToanImg = request.ChungNhanAnToanImg,
                GiayPhepKinhDoanhImg = request.GiayPhepKinhDoanhImg,
                NgayDangKy = DateTime.Now
            };
            nguoidung.VaiTro = LoaiNguoiDung.CuaHang;
            _context.HopDong.Add(hopdong);
            _context.CuaHang.Add(cuahang);

            if (await _context.SaveChangesAsync() > 0)
                return Ok(hopdong.MaHopDong);
            return BadRequest("Co loi trong qua trinh dang ky lam cua hang");
        }
        [HttpPost("accept")]
        public async Task<IActionResult> Accept([FromBody] ContractVM request)
        {
            var nguoidung = await _context.NguoiDung.FindAsync(request.MaNguoiDung);
            if (nguoidung == null)
                throw new Exception($"Khong tim thay nguoi dung voi Id : {request.MaNguoiDung}");

            var hopdong = await _context.HopDong.FindAsync(request.MaHopDong);
            if (hopdong == null)
                throw new Exception($"Khong tim thay hopdong voi Id : {request.MaHopDong}");

            hopdong.NgayKyHopDong = DateTime.Now;
            hopdong.NgayHieuLuc = request.NgayHieuLuc;
            hopdong.NgayKetThuc = request.NgayKetThuc;
            hopdong.HopDongImg = request.HopDongImg;

            nguoidung.KichHoat = true;

            if (await _context.SaveChangesAsync() > 0)
                return Ok(hopdong.MaHopDong);
            return BadRequest("Co loi trong qua trinh xet duyet hop dong");
        }
        [HttpGet("RegisterRequest")]
        public async Task<IActionResult> GetRegisterRequest(string type, int page = 1, int pageSize = 7)
        {
            var loainguoidung = type == "shipper" ? LoaiNguoiDung.Shipper : LoaiNguoiDung.CuaHang;
            var contract = _context.HopDong.Include(x => x.NguoiDung)
                .Where(x => x.NguoiDung.KichHoat == false && x.NguoiDung.VaiTro == loainguoidung)
                            .Select(x => new
                            {
                                TenNguoiDung = x.NguoiDung.TenNguoiDung,
                                Sdt = x.NguoiDung.Sdt,
                                Email = x.NguoiDung.Email,
                                NgayDangKy = x.NgayDangKy,
                            });
            return Ok(contract);

        }
        [HttpGet("detail/shipper/{contractId}")]
        public async Task<IActionResult> DetailShipper(int contractId)
        {
            var contract = await _context.HopDong.Include(x => x.NguoiDung)
                .FirstOrDefaultAsync(x => x.MaHopDong == contractId && x.NguoiDung.VaiTro == LoaiNguoiDung.Shipper);
            return Ok(contract);
        }
        [HttpGet("detail/store/{contractId}")]
        public async Task<IActionResult> DetailStore(int contractId)
        {
            var contract = await _context.HopDong.Include(x => x.NguoiDung).ThenInclude(x => x.CuaHang)
                .FirstOrDefaultAsync(x => x.MaHopDong == contractId && x.NguoiDung.VaiTro == LoaiNguoiDung.CuaHang);
            return Ok(contract);
        }
    }
}
