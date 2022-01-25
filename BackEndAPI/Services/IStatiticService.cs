using BackEndAPI.Data.Enums;
using BackEndAPI.ViewModels.Statitics;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAPI.Services
{
    public interface IStatiticService
    {
        public Task<List<NguoiDungTheoVungVM>> ThongKeNguoiDung();
        public XLWorkbook ExportThongKeNguoiDung(List<NguoiDungTheoVungVM> reports);

        public Task<List<MatHangThietYeuVM>> ThongKeMatHangThietYeu(int maCuaHang);
        public XLWorkbook ExportThongKeMatHangThietYeu(List<MatHangThietYeuVM> reports);

        public Task<List<DanhMucThietYeuVM>> ThongKeDanhMucThietYeu();
        public XLWorkbook ExportThongKeDanhMucThietYeu(List<DanhMucThietYeuVM> reports);

        public Task<List<SanPhamCungKyVM>> ThongKeNhuCauCungKy(string thoigian);

        public Task<List<DoanhThuVM>> ThongKeDoanhThuSanPham(string thoigian);

        public Task<List<DoanhThuVM>> ThongKeDoanhThuCuaHang(string thoigian);
    }
}
