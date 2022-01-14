using System;
using BackEndAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BackEndAPI.Entities
{
    public partial class PTUDContext : DbContext
    {
        public PTUDContext()
        {
        }

        public PTUDContext(DbContextOptions<PTUDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChiTietDonHang> ChiTietDonHang { get; set; }
        public virtual DbSet<ChiTietGioHang> ChiTietGioHang { get; set; }
        public virtual DbSet<ChiTietGoiSanPham> ChiTietGoiSanPham { get; set; }
        public virtual DbSet<DanhMuc> DanhMuc { get; set; }
        public virtual DbSet<CuaHang> CuaHang { get; set; }
        public virtual DbSet<DonHang> DonHang { get; set; }
        public virtual DbSet<GioHang> GioHang { get; set; }
        public virtual DbSet<GoiSanPham> GoiSanPham { get; set; }
        public virtual DbSet<HinhAnh> HinhAnh { get; set; }
        public virtual DbSet<HopDong> HopDong { get; set; }
        public virtual DbSet<NguoiDung> NguoiDung { get; set; }
        public virtual DbSet<SanPham> SanPham { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoan { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ChiTietDonHang>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityColumn();

                entity.ToTable("CHI_TIET_DON_HANG");

                entity.Property(e => e.MaDonHang).HasColumnName("MA_DON_HANG");

                entity.Property(e => e.MaSp).HasColumnName("MA_SP");

                entity.Property(e => e.DonGia).HasColumnName("DON_GIA");

                entity.Property(e => e.SoLuong).HasColumnName("SO_LUONG");

                entity.HasOne(d => d.DonHang)
                    .WithMany(p => p.DSChiTietDonHang)
                    .HasForeignKey(d => d.MaDonHang);

                entity.HasOne(d => d.SanPham)
                    .WithMany(p => p.DSChiTietDonHang)
                    .HasForeignKey(d => d.MaSp);
            });

            modelBuilder.Entity<ChiTietGioHang>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityColumn();
                entity.ToTable("CHI_TIET_GIO_HANG");

                entity.Property(e => e.MaGioHang).HasColumnName("MA_GIO_HANG");

                entity.Property(e => e.MaSp).HasColumnName("MA_SP");

                entity.Property(e => e.SoLuong).HasColumnName("SO_LUONG");

                entity.HasOne(d => d.GioHang)
                    .WithMany(p => p.DSChiTietGioHang)
                    .HasForeignKey(d => d.MaGioHang);

                entity.HasOne(d => d.SanPham)
                    .WithMany(p => p.DSChiTietGioHang)
                    .HasForeignKey(d => d.MaSp);
            });

            modelBuilder.Entity<ChiTietGoiSanPham>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityColumn();

                entity.ToTable("CHI_TIET_GOI_SAN_PHAM");

                entity.Property(e => e.MaSp).HasColumnName("MA_SP");

                entity.Property(e => e.MaGoiSp).HasColumnName("MA_GOI_SP");

                entity.Property(e => e.SoLuong).HasColumnName("SO_LUONG");

                entity.HasOne(d => d.GoiSanPham)
                    .WithMany(p => p.DSChiTietGoiSanPham)
                    .HasForeignKey(d => d.MaGoiSp);

                entity.HasOne(d => d.SanPham)
                    .WithMany(p => p.DSChiTietGoiSanPham)
                    .HasForeignKey(d => d.MaSp);
            });

            modelBuilder.Entity<DanhMuc>(entity =>
            {
                entity.HasKey(e => e.MaDm);
                entity.Property(e => e.MaDm).UseIdentityColumn();

                entity.ToTable("DANH_MUC");

                entity.Property(e => e.MaDm).HasColumnName("MA_DM").UseIdentityColumn();

                entity.Property(e => e.TenDm).HasColumnName("TEN_DM");
            });

            modelBuilder.Entity<CuaHang>(entity =>
            {
                entity.HasKey(e => e.MaCuaHang);
                entity.ToTable("CUA_HANG");

                entity.Property(e => e.MaCuaHang).HasColumnName("MA_CUA_HANG").UseIdentityColumn();

                entity.Property(e => e.Email).HasColumnName("EMAIL");

                entity.Property(e => e.MaDiaChi).HasColumnName("MA_DIA_CHI");

                entity.Property(e => e.MaNguoiDung).IsRequired().HasColumnName("MA_NGUOI_DUNG");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SDT");

                entity.Property(e => e.TenCuaHang).HasColumnName("TEN_CUA_HANG");

                entity.HasOne(d => d.NguoiDung)
                    .WithMany(p => p.CuaHang)
                    .HasForeignKey(d => d.MaNguoiDung);
                entity.HasOne(d => d.DiaChi).WithMany().HasForeignKey(d => d.MaDiaChi);
            });

            modelBuilder.Entity<DonHang>(entity =>
            {
                entity.HasKey(e => e.MaDonHang);
                entity.Property(e => e.MaDonHang).UseIdentityColumn();
                entity.ToTable("DON_HANG");

                entity.Property(e => e.MaDonHang).HasColumnName("MA_DON_HANG").UseIdentityColumn();

                entity.Property(e => e.DiaChi).HasColumnName("DIA_CHI");

                entity.Property(e => e.MaCuaHang).IsRequired().HasColumnName("MA_CUA_HANG");

                entity.Property(e => e.MaNguoiDung).IsRequired().HasColumnName("MA_NGUOI_DUNG");

                entity.Property(e => e.NgayCapNhat).HasColumnName("NGAY_CAP_NHAT");

                entity.Property(e => e.NgayMua).HasColumnName("NGAY_MUA");

                entity.Property(e => e.MaShipper).HasColumnName("MA_SHIPPER");

                entity.Property(e => e.PhanHoi).HasColumnName("PHAN_HOI");

                entity.Property(e => e.Sdt).HasColumnName("SDT");

                entity.Property(e => e.TenNguoiNhan)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TEN_NGUOI_NHAN");

                entity.Property(e => e.TrangThai).HasColumnName("TRANG_THAI");

                entity.HasOne(d => d.CuaHang)
                    .WithMany(p => p.DSDonHang)
                    .HasForeignKey(d => d.MaCuaHang).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.NguoiMua)
                    .WithMany(p => p.DSDonHangDaMua)
                    .HasForeignKey(d => d.MaNguoiDung).OnDelete(DeleteBehavior.Restrict); 

                entity.HasOne(d => d.Shipper)
                    .WithMany(p => p.DSDonHangDaShip)
                    .HasForeignKey(d => d.MaShipper).OnDelete(DeleteBehavior.Restrict); 
            });

            modelBuilder.Entity<GioHang>(entity =>
            {
                entity.HasKey(e => e.MaGioHang);
                entity.Property(e => e.MaGioHang).UseIdentityColumn();

                entity.ToTable("GIO_HANG");

                entity.Property(e => e.MaGioHang).HasColumnName("MA_GIO_HANG").UseIdentityColumn();

                entity.Property(e => e.MaNguoiDung).IsRequired().HasColumnName("MA_NGUOI_DUNG");

                entity.Property(e => e.TongTien).HasColumnName("TONG_TIEN");

                entity.HasOne(d => d.NguoiDung)
                    .WithMany(p => p.DSGioHang).OnDelete(DeleteBehavior.Restrict)
                    .HasForeignKey(d => d.MaGioHang);
            });

            modelBuilder.Entity<GoiSanPham>(entity =>
            {
                entity.HasKey(e => e.MaGoiSp);
                entity.Property(e => e.MaGoiSp).UseIdentityColumn();


                entity.ToTable("GOI_SAN_PHAM");

                entity.Property(e => e.MaGoiSp).HasColumnName("MA_GOI_SP");

                entity.Property(e => e.TenGoiSp).HasColumnName("TEN_GOI_SP");
            });

            modelBuilder.Entity<HinhAnh>(entity =>
            {
                entity.HasKey(e => e.MaHinhAnh);
                entity.Property(e => e.MaHinhAnh).UseIdentityColumn();

                entity.ToTable("HINH_ANH");

                entity.Property(e => e.MaHinhAnh).HasColumnName("MA_HINH_ANH");

                entity.Property(e => e.MaSp).HasColumnName("MA_SP");

                entity.Property(e => e.MacDinh).HasColumnName("MAC_DINH");

                entity.Property(e => e.NguonHinhAnh).HasColumnName("NGUON_HINH_ANH");

                entity.HasOne(d => d.SanPham)
                    .WithMany(p => p.DSHinhAnh)
                    .HasForeignKey(d => d.MaSp);
            });

            modelBuilder.Entity<HopDong>(entity =>
            {
                entity.HasKey(e => e.MaHopDong);

                entity.ToTable("HOP_DONG");

                entity.Property(e => e.MaHopDong).HasColumnName("MA_HOP_DONG");

                entity.Property(e => e.MaNguoiDung).IsRequired().HasColumnName("MA_NGUOI_DUNG");

                entity.Property(e => e.NgayHieuLuc).HasColumnName("NGAY_HIEU_LUC");

                entity.Property(e => e.NgayKetThuc).HasColumnName("NGAY_KET_THUC");

                entity.Property(e => e.NgayKyHopDong).HasColumnName("NGAY_KY_HOP_DONG");

                entity.HasOne(d => d.NguoiDung).WithMany().HasForeignKey(d => d.MaNguoiDung);
            });

            modelBuilder.Entity<NguoiDung>(entity =>
            {
                entity.HasKey(e => e.MaNguoiDung);
                entity.Property(e => e.MaNguoiDung).UseIdentityColumn();

                entity.ToTable("NGUOI_DUNG");

                entity.Property(e => e.MaNguoiDung).HasColumnName("MA_NGUOI_DUNG");

                entity.Property(e => e.MaDiaChi).HasColumnName("MA_DIA_CHI");

                entity.Property(e => e.Email).HasColumnName("EMAIL");

                entity.Property(e => e.NgaySinh).HasColumnName("NGAY_SINH");

                entity.Property(e => e.Sdt).HasColumnName("SDT");

                entity.Property(e => e.TenNguoiDung).HasColumnName("TEN_NGUOI_DUNG");

                entity.Property(e => e.VaiTro).HasColumnName("VAI_TRO");

                entity.HasOne(d => d.DiaChi).WithMany().HasForeignKey(d => d.MaDiaChi);
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSp);

                entity.Property(e => e.MaSp).UseIdentityColumn().HasColumnName("MA_SP");

                entity.ToTable("SAN_PHAM");

                entity.Property(e => e.GiaSp).HasColumnName("GIA_SP");

                entity.Property(e => e.MaCuaHang).IsRequired().HasColumnName("MA_CUA_HANG");

                entity.Property(e => e.MaDm).HasColumnName("MA_DM");

                entity.Property(e => e.MoTa).HasColumnName("MO_TA");

                entity.Property(e => e.SoLuongConLai).HasColumnName("SO_LUONG_CON_LAI");

                entity.Property(e => e.TenSp).HasColumnName("TEN_SP");

                entity.HasOne(d => d.CuaHang).WithMany(p => p.DSSanPham).HasForeignKey(d => d.MaCuaHang);

                entity.HasOne(d => d.DanhMuc).WithMany(p => p.DSSanPham).HasForeignKey(d => d.MaDm);
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.HasKey(e=>e.MaNguoiDung);

                entity.ToTable("TAI_KHOAN");

                entity.Property(e => e.MaNguoiDung).IsRequired().HasColumnName("MA_NGUOI_DUNG");

                entity.Property(e => e.MatKhau).IsRequired().HasColumnName("MAT_KHAU");

                entity.HasOne(d => d.NguoiDung).WithMany().HasForeignKey(d => d.MaNguoiDung);
            });
            modelBuilder.Entity<DiaChi>(entity =>
            {
                entity.HasKey(e => e.MaDiaChi);

                entity.ToTable("DIA_CHI");

                entity.Property(e => e.MaDiaChi).IsRequired().HasColumnName("MA_DIA_CHI");

                entity.Property(e => e.ToaDoDong).IsRequired().HasColumnName("TOA_DO_DONG");

                entity.Property(e => e.ToaDoTay).IsRequired().HasColumnName("TOA_DO_TAY");

                entity.Property(e => e.TenDiaChi).IsRequired().HasColumnName("TEN_DIA_CHI");
                
                entity.Property(e => e.LoaiVung).IsRequired().HasColumnName("LOAI_VUNG");
            });
        }
    }
}
