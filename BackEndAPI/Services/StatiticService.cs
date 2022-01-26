using BackEndAPI.Data.Enums;
using BackEndAPI.Entities;
using BackEndAPI.ViewModels.Statitics;
using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAPI.Services
{
    public class StatiticService : IStatiticService
    {
        private readonly XLColor HeaderColor = XLColor.FromArgb(79, 129, 189);
        private readonly XLColor RowColor = XLColor.FromArgb(220, 230, 240);
        private readonly PTUDContext _context;

        public StatiticService(PTUDContext context)
        {
            _context = context;
        }

        public async Task<List<DanhMucThietYeuVM>> ThongKeDanhMucThietYeu()
        {
            var reports = _context.DanhMuc.Join(_context.SanPham, dm => dm.MaDm, sp => sp.MaDm, (dm, sp) =>
            new
            {
                MaSp = sp.MaSp,
                MaDm = dm.MaDm,
                TenDm = dm.TenDm,
                ConLai = sp.SoLuongConLai
            }).Join(_context.ChiTietDonHang, sp => sp.MaSp, ct => ct.MaSp, (sp, ct) => new
            {
                MaDm = sp.MaDm,
                TenDm = sp.TenDm,
                SoLuong = ct.SoLuong,
                MaSp = ct.MaSp,
                ConLai = sp.ConLai
            }).GroupBy(x => new { MaDm = x.MaDm, TenDm = x.TenDm })
                    .Select(g => new DanhMucThietYeuVM()
                    {
                        Ten = g.Key.TenDm,
                        SoLoaiSanPham = g.Select(i => i.MaSp).Distinct().Count(),
                        SoLuongBanRa = g.Sum(i => i.SoLuong),
                        SoLuongConLai = g.Sum(i => i.ConLai)
                    }).ToList();
            return reports;
        }
        public async Task<List<NguoiDungTheoVungVM>> ThongKeNguoiDung()
        {
            var reports = await _context.NguoiDung.Include(x => x.DiaChi).Select(x => new NguoiDungTheoVungVM()
            {
                Ten = x.TenNguoiDung,
                Email = x.Email,
                Sđt = x.Sdt,
                Loai = x.VaiTro.ToString(),
                DiaChi = x.DiaChi.TenDiaChi,
                Vung = x.DiaChi.LoaiVung.ToString()
            }).Take(20).ToListAsync();
            var stores = await _context.CuaHang.Include(x => x.DiaChi).Select(x => new NguoiDungTheoVungVM()
            {
                Ten = x.TenCuaHang,
                Email = x.Email,
                Sđt = x.Sdt,
                Loai = "CuaHang",
                DiaChi = x.DiaChi.TenDiaChi,
                Vung = x.DiaChi.LoaiVung.ToString()
            }).Take(20).ToListAsync();
            reports.AddRange(stores);
            return reports;
        }
        public async Task<List<MatHangThietYeuVM>> ThongKeMatHangThietYeu(int maCuaHang)
        {
            var query = _context.SanPham.Include(x => x.DSChiTietDonHang).AsEnumerable();
            if (maCuaHang != 0) query = query.Where(x => x.MaCuaHang == maCuaHang);
            var reports = query
                 .Select(x => new MatHangThietYeuVM()
                 {
                     TenSp = x.TenSp,
                     SoLuongConLai = x.SoLuongConLai,
                     SoLuongBanRa = x.DSChiTietDonHang.Sum(x => x.SoLuong),
                     SoLuotDanhGia = x.SoLuotDanhGia,
                     TrungBinhSao = x.TrungBinhSao
                 }).ToList();
            return reports;
        }
        public async Task<List<SanPhamCungKyVM>> ThongKeNhuCauCungKy(string thoigian)
        {
            var reports = new List<SanPhamCungKyVM>();
            var query = _context.ChiTietDonHang.AsEnumerable()
             .Join(_context.DonHang, ct => ct.MaDonHang, dh => dh.MaDonHang
            , (ct, dh) => new
            {
                MaSp = ct.MaSp,
                Soluong = ct.SoLuong,
                NgayMua = dh.NgayMua
            });
            if (thoigian == "thang")
            {
                reports = query.Where(x => x.NgayMua > DateTime.Now.AddYears(-1) && x.NgayMua < DateTime.Now)
                    .GroupBy(x => new { Year = x.NgayMua.Year, Month = x.NgayMua.Month })
                    .Select(y => new SanPhamCungKyVM
                    {
                        SoLuongBanRa = y.Sum(x => x.Soluong),
                        Nam = y.Key.Year,
                        Thang = y.Key.Month
                    }).ToList();
            }
            if (thoigian == "nam")
            {
                reports = query.GroupBy(x => new { Year = x.NgayMua.Year })
                        .Select(y => new SanPhamCungKyVM
                        {
                            SoLuongBanRa = y.Sum(x => x.Soluong),
                            Nam = y.Key.Year,
                        }).ToList();
            }
            return reports;
        }
        public async Task<List<DoanhThuVM>> ThongKeDoanhThuSanPham(string thoigian)
        {
            var reports = new List<DoanhThuVM>();

            var query = _context.SanPham.Join(_context.ChiTietDonHang, sp => sp.MaSp, ct => ct.MaSp, (sp, ct) => new
            {
                MaSp = sp.MaSp,
                TenSp = sp.TenSp,
                Tien = ct.SoLuong * ct.DonGia,
                MaDonHang = ct.MaDonHang,

            }).Join(_context.DonHang, ct => ct.MaDonHang, dh => dh.MaDonHang, (ct, dh) => new
            {
                MaSp = ct.MaSp,
                TenSp = ct.TenSp,
                Tien = ct.Tien,
                NgayMua = dh.NgayMua,
                MaDonHang = dh.MaDonHang
            });
            if (thoigian == "thang")
            {
                reports = query.Where(x => x.NgayMua.Month == DateTime.Now.Month && x.NgayMua.Year == DateTime.Now.Year)
                    .GroupBy(x => new { x.MaSp, x.TenSp })
                    .Select(x => new DoanhThuVM
                    {
                        Ten = x.Key.TenSp,
                        DoanhThu = x.Sum(x => x.Tien),
                        SoLuongDonHang = x.Count(),
                        ThoiGian = string.Format($"{DateTime.Now.Month}/{ DateTime.Now.Year}")
                    }).ToList();
            }
            if (thoigian == "nam")
            {
                reports = query.Where(x => x.NgayMua.Year == DateTime.Now.Year)
                    .GroupBy(x => new { x.MaSp, x.TenSp })
                    .Select(x => new DoanhThuVM
                    {
                        Ten = x.Key.TenSp,
                        DoanhThu = x.Sum(x => x.Tien),
                        SoLuongDonHang = x.Count(),
                        ThoiGian = DateTime.Now.Year.ToString()
                    }).ToList();
            }
            return reports;
        }
        public async Task<List<DoanhThuVM>> ThongKeDoanhThuCuaHang(string thoigian)
        {
            var reports = new List<DoanhThuVM>();

            var query = _context.CuaHang.Join(_context.DonHang, ch => ch.MaCuaHang, dh => dh.MaCuaHang, (ch, dh) => new
            {
                MaCuaHang = ch.MaCuaHang,
                TenCuaHang = ch.TenCuaHang,
                Tien = dh.TongTien,
                NgayMua = dh.NgayMua,
                MaDonHang = dh.MaDonHang
            });
            if (thoigian == "thang")
            {
                reports = query.Where(x => x.NgayMua.Month == DateTime.Now.Month && x.NgayMua.Year == DateTime.Now.Year)
                    .GroupBy(x => new { x.MaCuaHang, x.TenCuaHang })
                    .Select(x => new DoanhThuVM
                    {
                        Ten = x.Key.TenCuaHang,
                        DoanhThu = x.Sum(x => x.Tien),
                        SoLuongDonHang = x.Count(),
                        ThoiGian = string.Format($"{DateTime.Now.Month}/{ DateTime.Now.Year}")
                    }).ToList();
            }
            if (thoigian == "nam")
            {
                reports = query.Where(x => x.NgayMua.Year == DateTime.Now.Year)
                     .GroupBy(x => new { x.MaCuaHang, x.TenCuaHang })
                    .Select(x => new DoanhThuVM
                    {
                        Ten = x.Key.TenCuaHang,
                        DoanhThu = x.Sum(x => x.Tien),
                        SoLuongDonHang = x.Count(),
                        ThoiGian = DateTime.Now.Year.ToString()
                    }).ToList();
            }
            return reports;
        }


        public XLWorkbook ExportThongKeNguoiDung(List<NguoiDungTheoVungVM> reports)
        {
            XLWorkbook workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Reports");
            int currentRow = 1;
            #region Header
            worksheet.Cell(currentRow, 1).Value = "Tên người dùng";
            worksheet.Cell(currentRow, 2).Value = "Loại người dùng";
            worksheet.Cell(currentRow, 3).Value = "Email";
            worksheet.Cell(currentRow, 4).Value = "Số điện thoại";
            worksheet.Cell(currentRow, 5).Value = "Địa chỉ";
            worksheet.Cell(currentRow, 6).Value = "Vùng";
            AddHeaderStyle(ref worksheet);
            #endregion
            #region Body
            foreach (var report in reports)
            {
                currentRow++;
                worksheet.Cell(currentRow, 1).Value = report.Ten;
                worksheet.Cell(currentRow, 2).Value = report.Loai;
                worksheet.Cell(currentRow, 3).Value = report.Email;
                worksheet.Cell(currentRow, 4).Value = report.Sđt;
                worksheet.Cell(currentRow, 5).Value = report.DiaChi;
                worksheet.Cell(currentRow, 6).Value = report.Vung;
                AddRowStyle(ref worksheet, currentRow);

            }
            #endregion
            AddTableStyle(ref worksheet, reports.Count + 1);
            return workbook;
        }

        public XLWorkbook ExportThongKeMatHangThietYeu(List<MatHangThietYeuVM> reports)
        {
            XLWorkbook workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Reports");
            int currentRow = 1;
            #region Header
            worksheet.Cell(currentRow, 1).Value = "Tên sản phẩm";
            worksheet.Cell(currentRow, 2).Value = "Số lượng còn lại";
            worksheet.Cell(currentRow, 3).Value = "Trung bình sao";
            worksheet.Cell(currentRow, 4).Value = "Số lượng bán ra";
            worksheet.Cell(currentRow, 5).Value = "Số lượng đánh giá";
            AddHeaderStyle(ref worksheet);
            #endregion
            #region Body
            foreach (var report in reports)
            {
                currentRow++;
                worksheet.Cell(currentRow, 1).Value = report.TenSp;
                worksheet.Cell(currentRow, 2).Value = report.SoLuongConLai;
                worksheet.Cell(currentRow, 3).Value = report.TrungBinhSao;
                worksheet.Cell(currentRow, 4).Value = report.SoLuongBanRa;
                worksheet.Cell(currentRow, 5).Value = report.SoLuotDanhGia;
                AddRowStyle(ref worksheet, currentRow);

            }
            #endregion
            AddTableStyle(ref worksheet, reports.Count + 1);
            return workbook;
        }

        public XLWorkbook ExportThongKeDanhMucThietYeu(List<DanhMucThietYeuVM> reports)
        {
            XLWorkbook workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Reports");
            int currentRow = 1;
            #region Header
            worksheet.Cell(currentRow, 1).Value = "Tên danh mục";
            worksheet.Cell(currentRow, 2).Value = "Số loại sản phẩm";
            worksheet.Cell(currentRow, 3).Value = "Số lượng còn lại";
            worksheet.Cell(currentRow, 4).Value = "Số lượng bán ra";
            AddHeaderStyle(ref worksheet);
            #endregion
            #region Body
            foreach (var report in reports)
            {
                currentRow++;
                worksheet.Cell(currentRow, 1).Value = report.Ten;
                worksheet.Cell(currentRow, 2).Value = report.SoLoaiSanPham;
                worksheet.Cell(currentRow, 3).Value = report.SoLuongConLai;
                worksheet.Cell(currentRow, 4).Value = report.SoLuongBanRa;
                AddRowStyle(ref worksheet, currentRow);

            }
            #endregion
            AddTableStyle(ref worksheet, reports.Count + 1);
            return workbook;
        }

        private void AddRowStyle(ref IXLWorksheet ws, int currentRow)
        {
            if (currentRow % 2 == 0)
            {
                ws.Range(currentRow, 1, currentRow, 7).Style.Fill.BackgroundColor = RowColor;
                ws.Range(currentRow, 1, currentRow, 7).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                ws.Range(currentRow, 1, currentRow, 7).Style.Border.BottomBorderColor = HeaderColor;
                ws.Range(currentRow, 1, currentRow, 7).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Range(currentRow, 1, currentRow, 7).Style.Border.TopBorderColor = HeaderColor;
            }
            else
            {
                ws.Range(currentRow, 1, currentRow, 7).Style.Fill.BackgroundColor = XLColor.White;
            }

        }
        private void AddHeaderStyle(ref IXLWorksheet ws)
        {
            int header = 1;
            ws.Row(header).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Row(header).Style.Font.FontSize = 12;
            ws.Row(header).Style.Font.SetBold();
            ws.Row(header).Style.Font.FontColor = XLColor.White;
            ws.Range(header, 1, header, 7).Style.Fill.BackgroundColor = HeaderColor;
        }
        private void AddTableStyle(ref IXLWorksheet ws, int numRows)
        {
            ws.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            ws.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            ws.Style.Font.FontName = "Arial";
            ws.Columns().AdjustToContents();
            ws.Rows().Height = 25;
            ws.Range(1, 1, numRows, 7).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            ws.Range(1, 1, numRows, 7).Style.Border.OutsideBorderColor = HeaderColor;
        }
    }
}
