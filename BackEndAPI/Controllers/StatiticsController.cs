using BackEndAPI.Entities;
using BackEndAPI.Services;
using BackEndAPI.ViewModels.Statitics;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatiticsController : ControllerBase
    {
        private readonly IStatiticService _service;

        public StatiticsController(IStatiticService service)
        {
            _service = service;
        }

        [HttpGet("nguoi-dung")]
        public async Task<IActionResult> ThongKeNguoiDung()
        {
            var items = await _service.ThongKeNguoiDung();
            var result = new ThongKeVM<NguoiDungTheoVungVM>()
            {
                Items = items,
                UrlDownload = "http://localhost:18291/api/statitics/export/nguoidung"
            };
            return Ok(result);
        }
        [HttpGet("mat-hang-thiet-yeu")]
        public async Task<IActionResult> ThongKeMatHangThietYeu(int maCuaHang = 0)
        {
            var items = await _service.ThongKeMatHangThietYeu(maCuaHang);
            var result = new ThongKeVM<MatHangThietYeuVM>()
            {
                Items = items,
                UrlDownload = "http://localhost:18291/api/statitics/export/mat-hang-thiet-yeu?maCuaHang=" + maCuaHang
            };
            return Ok(result);
        }
        [HttpGet("danh-muc-thiet-yeu")]
        public async Task<IActionResult> ThongKeDanhMucThietYeu()
        {
            var items = await _service.ThongKeDanhMucThietYeu();
            var result = new ThongKeVM<DanhMucThietYeuVM>()
            {
                Items = items,
                UrlDownload = "http://localhost:18291/api/statitics/export/danh-muc-thiet-yeu"
            };
            return Ok(result);
        }
        [HttpGet("nhu-cau-cung-ky")]
        public async Task<IActionResult> ThongKeNhuCauCungKy(string thoigian)
        {
            if (thoigian != "thang" && thoigian != "nam")
                return BadRequest("Khong dung dinh dang");
            var items = await _service.ThongKeNhuCauCungKy(thoigian);
            var result = new ThongKeVM<SanPhamCungKyVM>()
            {
                Items = items,
                UrlDownload = ""
            };
            return Ok(result);
        }
        [HttpGet("doanh-thu-cua-hang")]
        public async Task<IActionResult> ThongKeDoanhThuCuaHang(string thoigian)
        {
            if (thoigian != "thang" && thoigian != "nam")
                return BadRequest("Khong dung dinh dang");
            var items = await _service.ThongKeDoanhThuCuaHang(thoigian);
            var result = new ThongKeVM<DoanhThuVM>()
            {
                Items = items,
                UrlDownload = ""
            };
            return Ok(result);
        }
        [HttpGet("doanh-thu")]
        public async Task<IActionResult> ThongKeDoanhThu(string thoigian)
        {
            if (thoigian != "thang" && thoigian != "nam")
                return BadRequest("Khong dung dinh dang");
            var items = await _service.ThongKeDoanhThuSanPham(thoigian);
            var result = new ThongKeVM<DoanhThuVM>()
            {
                Items = items,
                UrlDownload = ""
            };
            return Ok(result);
        }
        [HttpGet("export/nguoi-dung")]
        public async Task<IActionResult> ExportThongKeNguoiDung()
        {
            var reports = await _service.ThongKeNguoiDung();
            if (reports == null)
                return BadRequest();
            var workbook = _service.ExportThongKeNguoiDung(reports);
            if (workbook == null)
                return BadRequest();

            using (var _workbook = workbook)
            {
                using (var stream = new MemoryStream())
                {
                    _workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ThongKeNguoiDung.xlsx");
                }
            }
        }
        [HttpGet("export/danh-muc-thiet-yeu")]
        public async Task<IActionResult> ExportThongKeDanhMucThietYeu()
        {
            var reports = await _service.ThongKeDanhMucThietYeu();
            if (reports == null)
                return BadRequest();
            var workbook = _service.ExportThongKeDanhMucThietYeu(reports);
            if (workbook == null)
                return BadRequest();

            using (var _workbook = workbook)
            {
                using (var stream = new MemoryStream())
                {
                    _workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ThongKeDanhMucThietYeu.xlsx");
                }
            }
        }
        [HttpGet("export/mat-hang-thiet-yeu")]
        public async Task<IActionResult> ExportThongKeMatHangThietYeu(int maCuaHang)
        {
            var reports = await _service.ThongKeMatHangThietYeu(maCuaHang);
            if (reports == null)
                return BadRequest();
            var workbook = _service.ExportThongKeMatHangThietYeu(reports);
            if (workbook == null)
                return BadRequest();

            using (var _workbook = workbook)
            {
                using (var stream = new MemoryStream())
                {
                    _workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ThongKeNguoiDung.xlsx");
                }
            }
        }
    }
}
