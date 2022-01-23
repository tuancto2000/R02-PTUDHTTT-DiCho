﻿// <auto-generated />
using System;
using BackEndAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BackEndAPI.Migrations
{
    [DbContext(typeof(PTUDContext))]
    [Migration("20220115150714_product-status")]
    partial class productstatus
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BackEndAPI.Data.Entities.DanhGia", b =>
                {
                    b.Property<int>("MaDanhGia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MA_DANH_GIA")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BinhLuan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("BINH_LUAN");

                    b.Property<int>("MaChiTietDonHang")
                        .HasColumnType("int")
                        .HasColumnName("MA_CHI_TIET_DON_HANG");

                    b.Property<int>("MaNguoiDung")
                        .HasColumnType("int")
                        .HasColumnName("MA_NGUOI_DUNG");

                    b.Property<int>("MaSanPham")
                        .HasColumnType("int")
                        .HasColumnName("MA_SAN_PHAM");

                    b.Property<int>("Sao")
                        .HasColumnType("int")
                        .HasColumnName("SAO");

                    b.HasKey("MaDanhGia");

                    b.HasIndex("MaChiTietDonHang");

                    b.HasIndex("MaNguoiDung");

                    b.HasIndex("MaSanPham");

                    b.ToTable("DANH_GIA");
                });

            modelBuilder.Entity("BackEndAPI.Data.Entities.DiaChi", b =>
                {
                    b.Property<int>("MaDiaChi")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MA_DIA_CHI")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LoaiVung")
                        .HasColumnType("int")
                        .HasColumnName("LOAI_VUNG");

                    b.Property<string>("TenDiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TEN_DIA_CHI");

                    b.Property<int>("ToaDoDong")
                        .HasColumnType("int")
                        .HasColumnName("TOA_DO_DONG");

                    b.Property<int>("ToaDoTay")
                        .HasColumnType("int")
                        .HasColumnName("TOA_DO_TAY");

                    b.HasKey("MaDiaChi");

                    b.ToTable("DIA_CHI");
                });

            modelBuilder.Entity("BackEndAPI.Entities.ChiTietDonHang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DonGia")
                        .HasColumnType("int")
                        .HasColumnName("DON_GIA");

                    b.Property<int>("MaDonHang")
                        .HasColumnType("int")
                        .HasColumnName("MA_DON_HANG");

                    b.Property<int>("MaSp")
                        .HasColumnType("int")
                        .HasColumnName("MA_SP");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int")
                        .HasColumnName("SO_LUONG");

                    b.HasKey("Id");

                    b.HasIndex("MaDonHang");

                    b.HasIndex("MaSp");

                    b.ToTable("CHI_TIET_DON_HANG");
                });

            modelBuilder.Entity("BackEndAPI.Entities.ChiTietGioHang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaGioHang")
                        .HasColumnType("int")
                        .HasColumnName("MA_GIO_HANG");

                    b.Property<int>("MaSp")
                        .HasColumnType("int")
                        .HasColumnName("MA_SP");

                    b.Property<int?>("SoLuong")
                        .HasColumnType("int")
                        .HasColumnName("SO_LUONG");

                    b.HasKey("Id");

                    b.HasIndex("MaGioHang");

                    b.HasIndex("MaSp");

                    b.ToTable("CHI_TIET_GIO_HANG");
                });

            modelBuilder.Entity("BackEndAPI.Entities.ChiTietGoiSanPham", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaGoiSp")
                        .HasColumnType("int")
                        .HasColumnName("MA_GOI_SP");

                    b.Property<int>("MaSp")
                        .HasColumnType("int")
                        .HasColumnName("MA_SP");

                    b.Property<int?>("SoLuong")
                        .HasColumnType("int")
                        .HasColumnName("SO_LUONG");

                    b.HasKey("Id");

                    b.HasIndex("MaGoiSp");

                    b.HasIndex("MaSp");

                    b.ToTable("CHI_TIET_GOI_SAN_PHAM");
                });

            modelBuilder.Entity("BackEndAPI.Entities.CuaHang", b =>
                {
                    b.Property<int>("MaCuaHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MA_CUA_HANG")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("EMAIL");

                    b.Property<int?>("MaDiaChi")
                        .HasColumnType("int")
                        .HasColumnName("MA_DIA_CHI");

                    b.Property<int>("MaNguoiDung")
                        .HasColumnType("int")
                        .HasColumnName("MA_NGUOI_DUNG");

                    b.Property<string>("Sdt")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("SDT");

                    b.Property<string>("TenCuaHang")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TEN_CUA_HANG");

                    b.HasKey("MaCuaHang");

                    b.HasIndex("MaDiaChi");

                    b.HasIndex("MaNguoiDung");

                    b.ToTable("CUA_HANG");
                });

            modelBuilder.Entity("BackEndAPI.Entities.DanhMuc", b =>
                {
                    b.Property<int>("MaDm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MA_DM")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenDm")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TEN_DM");

                    b.HasKey("MaDm");

                    b.ToTable("DANH_MUC");
                });

            modelBuilder.Entity("BackEndAPI.Entities.DonHang", b =>
                {
                    b.Property<int>("MaDonHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MA_DON_HANG")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DIA_CHI");

                    b.Property<int>("MaCuaHang")
                        .HasColumnType("int")
                        .HasColumnName("MA_CUA_HANG");

                    b.Property<int>("MaNguoiDung")
                        .HasColumnType("int")
                        .HasColumnName("MA_NGUOI_DUNG");

                    b.Property<int?>("MaShipper")
                        .HasColumnType("int")
                        .HasColumnName("MA_SHIPPER");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime2")
                        .HasColumnName("NGAY_CAP_NHAT");

                    b.Property<DateTime?>("NgayMua")
                        .HasColumnType("datetime2")
                        .HasColumnName("NGAY_MUA");

                    b.Property<string>("PhanHoi")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PHAN_HOI");

                    b.Property<string>("Sdt")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SDT");

                    b.Property<string>("TenNguoiNhan")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("TEN_NGUOI_NHAN");

                    b.Property<int>("TongTien")
                        .HasColumnType("int");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int")
                        .HasColumnName("TRANG_THAI");

                    b.HasKey("MaDonHang");

                    b.HasIndex("MaCuaHang");

                    b.HasIndex("MaNguoiDung");

                    b.HasIndex("MaShipper");

                    b.ToTable("DON_HANG");
                });

            modelBuilder.Entity("BackEndAPI.Entities.GioHang", b =>
                {
                    b.Property<int>("MaGioHang")
                        .HasColumnType("int")
                        .HasColumnName("MA_GIO_HANG")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaNguoiDung")
                        .HasColumnType("int")
                        .HasColumnName("MA_NGUOI_DUNG");

                    b.Property<int>("TongTien")
                        .HasColumnType("int")
                        .HasColumnName("TONG_TIEN");

                    b.HasKey("MaGioHang");

                    b.ToTable("GIO_HANG");
                });

            modelBuilder.Entity("BackEndAPI.Entities.GoiSanPham", b =>
                {
                    b.Property<int>("MaGoiSp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MA_GOI_SP")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenGoiSp")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TEN_GOI_SP");

                    b.HasKey("MaGoiSp");

                    b.ToTable("GOI_SAN_PHAM");
                });

            modelBuilder.Entity("BackEndAPI.Entities.HinhAnh", b =>
                {
                    b.Property<int>("MaHinhAnh")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MA_HINH_ANH")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaSp")
                        .HasColumnType("int")
                        .HasColumnName("MA_SP");

                    b.Property<bool?>("MacDinh")
                        .HasColumnType("bit")
                        .HasColumnName("MAC_DINH");

                    b.Property<string>("NguonHinhAnh")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NGUON_HINH_ANH");

                    b.HasKey("MaHinhAnh");

                    b.HasIndex("MaSp");

                    b.ToTable("HINH_ANH");
                });

            modelBuilder.Entity("BackEndAPI.Entities.HopDong", b =>
                {
                    b.Property<int>("MaHopDong")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MA_HOP_DONG")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ChungNhanAnToanImg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GiayPhepKinhDoanhImg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HopDongImg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaNguoiDung")
                        .HasColumnType("int")
                        .HasColumnName("MA_NGUOI_DUNG");

                    b.Property<DateTime?>("NgayDangKy")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayHieuLuc")
                        .HasColumnType("datetime2")
                        .HasColumnName("NGAY_HIEU_LUC");

                    b.Property<DateTime?>("NgayKetThuc")
                        .HasColumnType("datetime2")
                        .HasColumnName("NGAY_KET_THUC");

                    b.Property<DateTime?>("NgayKyHopDong")
                        .HasColumnType("datetime2")
                        .HasColumnName("NGAY_KY_HOP_DONG");

                    b.HasKey("MaHopDong");

                    b.HasIndex("MaNguoiDung");

                    b.ToTable("HOP_DONG");
                });

            modelBuilder.Entity("BackEndAPI.Entities.NguoiDung", b =>
                {
                    b.Property<int>("MaNguoiDung")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MA_NGUOI_DUNG")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("EMAIL");

                    b.Property<bool>("KichHoat")
                        .HasColumnType("bit");

                    b.Property<int?>("MaDiaChi")
                        .HasColumnType("int")
                        .HasColumnName("MA_DIA_CHI");

                    b.Property<DateTime?>("NgaySinh")
                        .HasColumnType("datetime2")
                        .HasColumnName("NGAY_SINH");

                    b.Property<string>("Sdt")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SDT");

                    b.Property<string>("TenNguoiDung")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TEN_NGUOI_DUNG");

                    b.Property<int>("VaiTro")
                        .HasColumnType("int")
                        .HasColumnName("VAI_TRO");

                    b.HasKey("MaNguoiDung");

                    b.HasIndex("MaDiaChi");

                    b.ToTable("NGUOI_DUNG");
                });

            modelBuilder.Entity("BackEndAPI.Entities.SanPham", b =>
                {
                    b.Property<int>("MaSp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MA_SP")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GiaSp")
                        .HasColumnType("int")
                        .HasColumnName("GIA_SP");

                    b.Property<int>("MaCuaHang")
                        .HasColumnType("int")
                        .HasColumnName("MA_CUA_HANG");

                    b.Property<int>("MaDm")
                        .HasColumnType("int")
                        .HasColumnName("MA_DM");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("MO_TA");

                    b.Property<int?>("SoLuongConLai")
                        .HasColumnType("int")
                        .HasColumnName("SO_LUONG_CON_LAI");

                    b.Property<int>("SoLuotDanhGia")
                        .HasColumnType("int");

                    b.Property<string>("TenSp")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TEN_SP");

                    b.Property<bool?>("TrangThai")
                        .HasColumnType("bit")
                        .HasColumnName("TRANG_THAI");

                    b.Property<double>("TrungBinhSao")
                        .HasColumnType("float");

                    b.HasKey("MaSp");

                    b.HasIndex("MaCuaHang");

                    b.HasIndex("MaDm");

                    b.ToTable("SAN_PHAM");
                });

            modelBuilder.Entity("BackEndAPI.Entities.TaiKhoan", b =>
                {
                    b.Property<int>("MaNguoiDung")
                        .HasColumnType("int")
                        .HasColumnName("MA_NGUOI_DUNG");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("MAT_KHAU");

                    b.HasKey("MaNguoiDung");

                    b.ToTable("TAI_KHOAN");
                });

            modelBuilder.Entity("BackEndAPI.Data.Entities.DanhGia", b =>
                {
                    b.HasOne("BackEndAPI.Entities.ChiTietDonHang", "ChiTietDonHang")
                        .WithMany()
                        .HasForeignKey("MaChiTietDonHang")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BackEndAPI.Entities.NguoiDung", "NguoiDung")
                        .WithMany()
                        .HasForeignKey("MaNguoiDung")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BackEndAPI.Entities.SanPham", "SanPham")
                        .WithMany()
                        .HasForeignKey("MaSanPham")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ChiTietDonHang");

                    b.Navigation("NguoiDung");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("BackEndAPI.Entities.ChiTietDonHang", b =>
                {
                    b.HasOne("BackEndAPI.Entities.DonHang", "DonHang")
                        .WithMany("DSChiTietDonHang")
                        .HasForeignKey("MaDonHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEndAPI.Entities.SanPham", "SanPham")
                        .WithMany("DSChiTietDonHang")
                        .HasForeignKey("MaSp")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DonHang");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("BackEndAPI.Entities.ChiTietGioHang", b =>
                {
                    b.HasOne("BackEndAPI.Entities.GioHang", "GioHang")
                        .WithMany("DSChiTietGioHang")
                        .HasForeignKey("MaGioHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEndAPI.Entities.SanPham", "SanPham")
                        .WithMany("DSChiTietGioHang")
                        .HasForeignKey("MaSp")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GioHang");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("BackEndAPI.Entities.ChiTietGoiSanPham", b =>
                {
                    b.HasOne("BackEndAPI.Entities.GoiSanPham", "GoiSanPham")
                        .WithMany("DSChiTietGoiSanPham")
                        .HasForeignKey("MaGoiSp")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEndAPI.Entities.SanPham", "SanPham")
                        .WithMany("DSChiTietGoiSanPham")
                        .HasForeignKey("MaSp")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GoiSanPham");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("BackEndAPI.Entities.CuaHang", b =>
                {
                    b.HasOne("BackEndAPI.Data.Entities.DiaChi", "DiaChi")
                        .WithMany()
                        .HasForeignKey("MaDiaChi");

                    b.HasOne("BackEndAPI.Entities.NguoiDung", "NguoiDung")
                        .WithMany("CuaHang")
                        .HasForeignKey("MaNguoiDung")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DiaChi");

                    b.Navigation("NguoiDung");
                });

            modelBuilder.Entity("BackEndAPI.Entities.DonHang", b =>
                {
                    b.HasOne("BackEndAPI.Entities.CuaHang", "CuaHang")
                        .WithMany("DSDonHang")
                        .HasForeignKey("MaCuaHang")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BackEndAPI.Entities.NguoiDung", "NguoiMua")
                        .WithMany("DSDonHangDaMua")
                        .HasForeignKey("MaNguoiDung")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BackEndAPI.Entities.NguoiDung", "Shipper")
                        .WithMany("DSDonHangDaShip")
                        .HasForeignKey("MaShipper")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("CuaHang");

                    b.Navigation("NguoiMua");

                    b.Navigation("Shipper");
                });

            modelBuilder.Entity("BackEndAPI.Entities.GioHang", b =>
                {
                    b.HasOne("BackEndAPI.Entities.NguoiDung", "NguoiDung")
                        .WithMany("DSGioHang")
                        .HasForeignKey("MaGioHang")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("NguoiDung");
                });

            modelBuilder.Entity("BackEndAPI.Entities.HinhAnh", b =>
                {
                    b.HasOne("BackEndAPI.Entities.SanPham", "SanPham")
                        .WithMany("DSHinhAnh")
                        .HasForeignKey("MaSp")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("BackEndAPI.Entities.HopDong", b =>
                {
                    b.HasOne("BackEndAPI.Entities.NguoiDung", "NguoiDung")
                        .WithMany()
                        .HasForeignKey("MaNguoiDung")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NguoiDung");
                });

            modelBuilder.Entity("BackEndAPI.Entities.NguoiDung", b =>
                {
                    b.HasOne("BackEndAPI.Data.Entities.DiaChi", "DiaChi")
                        .WithMany()
                        .HasForeignKey("MaDiaChi");

                    b.Navigation("DiaChi");
                });

            modelBuilder.Entity("BackEndAPI.Entities.SanPham", b =>
                {
                    b.HasOne("BackEndAPI.Entities.CuaHang", "CuaHang")
                        .WithMany("DSSanPham")
                        .HasForeignKey("MaCuaHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEndAPI.Entities.DanhMuc", "DanhMuc")
                        .WithMany("DSSanPham")
                        .HasForeignKey("MaDm")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CuaHang");

                    b.Navigation("DanhMuc");
                });

            modelBuilder.Entity("BackEndAPI.Entities.TaiKhoan", b =>
                {
                    b.HasOne("BackEndAPI.Entities.NguoiDung", "NguoiDung")
                        .WithMany()
                        .HasForeignKey("MaNguoiDung")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NguoiDung");
                });

            modelBuilder.Entity("BackEndAPI.Entities.CuaHang", b =>
                {
                    b.Navigation("DSDonHang");

                    b.Navigation("DSSanPham");
                });

            modelBuilder.Entity("BackEndAPI.Entities.DanhMuc", b =>
                {
                    b.Navigation("DSSanPham");
                });

            modelBuilder.Entity("BackEndAPI.Entities.DonHang", b =>
                {
                    b.Navigation("DSChiTietDonHang");
                });

            modelBuilder.Entity("BackEndAPI.Entities.GioHang", b =>
                {
                    b.Navigation("DSChiTietGioHang");
                });

            modelBuilder.Entity("BackEndAPI.Entities.GoiSanPham", b =>
                {
                    b.Navigation("DSChiTietGoiSanPham");
                });

            modelBuilder.Entity("BackEndAPI.Entities.NguoiDung", b =>
                {
                    b.Navigation("CuaHang");

                    b.Navigation("DSDonHangDaMua");

                    b.Navigation("DSDonHangDaShip");

                    b.Navigation("DSGioHang");
                });

            modelBuilder.Entity("BackEndAPI.Entities.SanPham", b =>
                {
                    b.Navigation("DSChiTietDonHang");

                    b.Navigation("DSChiTietGioHang");

                    b.Navigation("DSChiTietGoiSanPham");

                    b.Navigation("DSHinhAnh");
                });
#pragma warning restore 612, 618
        }
    }
}
