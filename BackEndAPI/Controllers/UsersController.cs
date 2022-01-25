using BackEndAPI.Data.Entities;
using BackEndAPI.Data.Enums;
using BackEndAPI.Entities;
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
    public class UsersController : ControllerBase
    {
        private readonly PTUDContext _context;

        public UsersController(PTUDContext context)
        {
            _context = context;
        }
        [HttpGet("getbyrole/{role}")]
        public async Task<IActionResult> GetUsersByRole(int role)
        {
            var nguoidung = _context.NguoiDung.Where(x => (int)x.VaiTro == role).ToList();
            return Ok(nguoidung);
        }
        [HttpPost("getUser")]
        public async Task<IActionResult> getUser(string username)
        {
            var taikhoan = await _context.TaiKhoan.FirstOrDefaultAsync(x => x.Username == username);
            if (taikhoan == null)
                return BadRequest($"Username or password is incorrect");
            var user = await _context.NguoiDung.FindAsync(taikhoan.MaNguoiDung);
            if (user == null)
                return BadRequest("Can not login");
            return Ok(user.MaNguoiDung);
        }
        [HttpPost("getPassword")]
        public async Task<IActionResult> getPassword(string username)
        {
            var taikhoan = await _context.TaiKhoan.FirstOrDefaultAsync(x => x.Username == username);
            if (taikhoan == null)
                return BadRequest($"Username or password is incorrect");
            var user = await _context.TaiKhoan.FindAsync(taikhoan.MaNguoiDung);
            if (user == null)
                return BadRequest("Can not login");
            return Ok(user.MatKhau);
        }

        [HttpGet("{cusId}")]
        public async Task<IActionResult> GetDetail(int cusId)
        {
            var taikhoan = await _context.TaiKhoan.Include(x => x.NguoiDung).ThenInclude(y => y.DiaChi).FirstOrDefaultAsync(x => x.MaNguoiDung == cusId);
            if (taikhoan == null)
                throw new Exception($"Can not find user with Id {cusId}");
            var model = new NguoiDungVM
            {
                MaNguoiDung = taikhoan.MaNguoiDung,
                MatKhau = taikhoan.MatKhau,
                DiaChi = taikhoan.NguoiDung.DiaChi.TenDiaChi,
                Email = taikhoan.NguoiDung.Email,
                NgaySinh = taikhoan.NguoiDung.NgaySinh,
                Sdt = taikhoan.NguoiDung.Sdt,
                TenNguoiDung = taikhoan.NguoiDung.TenNguoiDung,
                VaiTro = taikhoan.NguoiDung.VaiTro.ToString()
            };
            return Ok(model);
        }
        [HttpPost]
        public async Task<IActionResult> Register(NguoiDungVM request)
        {
            var taikhoan = new TaiKhoan
            {
                MatKhau = request.MatKhau,
                Username = request.Username,
                NguoiDung = new NguoiDung
                {
                    DiaChi = new DiaChi
                    {
                        TenDiaChi = request.DiaChi,
                        ToaDoBac = 0,
                        ToaDoDong = 0,
                        LoaiVung = LoaiVung.Do
                    },
                    Email = request.Email,
                    NgaySinh = request.NgaySinh,
                    Sdt = request.Sdt,
                    TenNguoiDung = request.TenNguoiDung,
                    VaiTro = LoaiNguoiDung.NguoiMua
                }
            };
            _context.TaiKhoan.Add(taikhoan);
            if (await _context.SaveChangesAsync() > 0)
                return Ok(taikhoan.MaNguoiDung);
            return BadRequest("Co loi trong qua trinh tao tai khoan");
        }


    }

}
