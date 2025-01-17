﻿// <auto-generated />
using System;
using ASM_PH48831.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ASM_PH48831.Migrations
{
    [DbContext(typeof(ASMDbContext))]
    [Migration("20241117123324_anh")]
    partial class anh
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ASM_PH48831.Models.Combo", b =>
                {
                    b.Property<int>("ComboId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComboId"));

                    b.Property<decimal>("GiaCombo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TenCombo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ComboId");

                    b.ToTable("Combos");

                    b.HasData(
                        new
                        {
                            ComboId = 1,
                            GiaCombo = 50000m,
                            TenCombo = "Combo Bữa Trưa"
                        },
                        new
                        {
                            ComboId = 2,
                            GiaCombo = 100000m,
                            TenCombo = "Combo Bữa Tối"
                        });
                });

            modelBuilder.Entity("ASM_PH48831.Models.ComboChiTiet", b =>
                {
                    b.Property<int>("ComboChiTietId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComboChiTietId"));

                    b.Property<int>("ComboId")
                        .HasColumnType("int");

                    b.Property<int>("MonAnId")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("ComboChiTietId");

                    b.HasIndex("ComboId");

                    b.HasIndex("MonAnId");

                    b.ToTable("ComboChiTiets");

                    b.HasData(
                        new
                        {
                            ComboChiTietId = 1,
                            ComboId = 1,
                            MonAnId = 1,
                            SoLuong = 2
                        },
                        new
                        {
                            ComboChiTietId = 2,
                            ComboId = 1,
                            MonAnId = 2,
                            SoLuong = 1
                        },
                        new
                        {
                            ComboChiTietId = 3,
                            ComboId = 1,
                            MonAnId = 3,
                            SoLuong = 1
                        },
                        new
                        {
                            ComboChiTietId = 4,
                            ComboId = 2,
                            MonAnId = 4,
                            SoLuong = 1
                        },
                        new
                        {
                            ComboChiTietId = 5,
                            ComboId = 2,
                            MonAnId = 5,
                            SoLuong = 1
                        });
                });

            modelBuilder.Entity("ASM_PH48831.Models.DiaChiQuan", b =>
                {
                    b.Property<int>("DiachiquanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiachiquanId"));

                    b.Property<string>("DiaChiChiTiet")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("DiachiquanId");

                    b.ToTable("DiaChiQuan");

                    b.HasData(
                        new
                        {
                            DiachiquanId = 1,
                            DiaChiChiTiet = "Hà nội"
                        },
                        new
                        {
                            DiachiquanId = 2,
                            DiaChiChiTiet = "Hải phòng"
                        },
                        new
                        {
                            DiachiquanId = 3,
                            DiaChiChiTiet = "Hải Dương"
                        });
                });

            modelBuilder.Entity("ASM_PH48831.Models.GioHang", b =>
                {
                    b.Property<int>("GioHangId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GioHangId"));

                    b.Property<int>("NguoiDungId")
                        .HasColumnType("int");

                    b.Property<int>("UserNguoiDungId")
                        .HasColumnType("int");

                    b.HasKey("GioHangId");

                    b.HasIndex("UserNguoiDungId");

                    b.ToTable("GioHangs");
                });

            modelBuilder.Entity("ASM_PH48831.Models.GioHangChiTiet", b =>
                {
                    b.Property<int>("GioHangChiTietId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GioHangChiTietId"));

                    b.Property<int>("GioHangId")
                        .HasColumnType("int");

                    b.Property<int>("MonAnId")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("GioHangChiTietId");

                    b.HasIndex("GioHangId");

                    b.HasIndex("MonAnId");

                    b.ToTable("GioHangChiTiets");
                });

            modelBuilder.Entity("ASM_PH48831.Models.HoaDon", b =>
                {
                    b.Property<int>("HoaDonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HoaDonId"));

                    b.Property<DateTime>("NgayLap")
                        .HasColumnType("datetime2");

                    b.Property<int>("NguoiDungId")
                        .HasColumnType("int");

                    b.Property<decimal>("TongTien")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("HoaDonId");

                    b.HasIndex("NguoiDungId");

                    b.ToTable("HoaDons");

                    b.HasData(
                        new
                        {
                            HoaDonId = 1,
                            NgayLap = new DateTime(2024, 11, 17, 19, 33, 24, 39, DateTimeKind.Local).AddTicks(6590),
                            NguoiDungId = 2,
                            TongTien = 250000m
                        });
                });

            modelBuilder.Entity("ASM_PH48831.Models.HoaDonChiTiet", b =>
                {
                    b.Property<int>("HoaDonChiTietId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HoaDonChiTietId"));

                    b.Property<decimal>("DonGia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("HoaDonId")
                        .HasColumnType("int");

                    b.Property<int>("MonAnId")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("HoaDonChiTietId");

                    b.HasIndex("HoaDonId");

                    b.HasIndex("MonAnId");

                    b.ToTable("HoaDonChiTiets");

                    b.HasData(
                        new
                        {
                            HoaDonChiTietId = 1,
                            DonGia = 200000m,
                            HoaDonId = 1,
                            MonAnId = 1,
                            SoLuong = 1
                        },
                        new
                        {
                            HoaDonChiTietId = 2,
                            DonGia = 15000m,
                            HoaDonId = 1,
                            MonAnId = 2,
                            SoLuong = 1
                        });
                });

            modelBuilder.Entity("ASM_PH48831.Models.Kichco", b =>
                {
                    b.Property<int>("KichCoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KichCoId"));

                    b.Property<string>("TenKichCo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("KichCoId");

                    b.ToTable("Kichco");

                    b.HasData(
                        new
                        {
                            KichCoId = 1,
                            TenKichCo = "Lớn"
                        },
                        new
                        {
                            KichCoId = 2,
                            TenKichCo = "Nhỏ"
                        },
                        new
                        {
                            KichCoId = 3,
                            TenKichCo = "Trung Bình"
                        });
                });

            modelBuilder.Entity("ASM_PH48831.Models.LoaiMonAn", b =>
                {
                    b.Property<int>("LoaiMonAnId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoaiMonAnId"));

                    b.Property<string>("TenLoaiMon")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("LoaiMonAnId");

                    b.ToTable("LoaiMonAn");

                    b.HasData(
                        new
                        {
                            LoaiMonAnId = 1,
                            TenLoaiMon = "Đồ chay"
                        },
                        new
                        {
                            LoaiMonAnId = 2,
                            TenLoaiMon = "Thịt cá"
                        },
                        new
                        {
                            LoaiMonAnId = 3,
                            TenLoaiMon = "Món ăn khác"
                        });
                });

            modelBuilder.Entity("ASM_PH48831.Models.MonAn", b =>
                {
                    b.Property<int>("MonAnId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MonAnId"));

                    b.Property<int>("DiachiquanId")
                        .HasColumnType("int");

                    b.Property<decimal>("Gia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("HinhAnh")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("KichCoId")
                        .HasColumnType("int");

                    b.Property<int>("LoaiMonAnId")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("TenMon")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ThanhPhanId")
                        .HasColumnType("int");

                    b.HasKey("MonAnId");

                    b.HasIndex("DiachiquanId");

                    b.HasIndex("KichCoId");

                    b.HasIndex("LoaiMonAnId");

                    b.HasIndex("ThanhPhanId");

                    b.ToTable("MonAns");

                    b.HasData(
                        new
                        {
                            MonAnId = 1,
                            DiachiquanId = 1,
                            Gia = 200000m,
                            HinhAnh = "/Images/hosting-fpt-removebg-preview.png",
                            LoaiMonAnId = 3,
                            MoTa = "Pizza truyền thống",
                            TenMon = "Pizza",
                            ThanhPhanId = 1
                        },
                        new
                        {
                            MonAnId = 2,
                            DiachiquanId = 2,
                            Gia = 15000m,
                            HinhAnh = "/Images/img-1000x600-1.jpg",
                            LoaiMonAnId = 1,
                            MoTa = "Bánh mì Việt Nam",
                            TenMon = "Bánh mì",
                            ThanhPhanId = 1
                        },
                        new
                        {
                            MonAnId = 3,
                            DiachiquanId = 3,
                            Gia = 60000m,
                            HinhAnh = "/Images/istockphoto-1200064755-170667a.jpg",
                            LoaiMonAnId = 2,
                            MoTa = "Món bún nổi tiếng",
                            TenMon = "Bún bò Huế",
                            ThanhPhanId = 2
                        },
                        new
                        {
                            MonAnId = 4,
                            DiachiquanId = 1,
                            Gia = 50000m,
                            HinhAnh = "/Images/istockphoto-1200064755-170667a.jpg",
                            LoaiMonAnId = 2,
                            MoTa = "Món phở truyền thống",
                            TenMon = "Phở",
                            ThanhPhanId = 3
                        },
                        new
                        {
                            MonAnId = 5,
                            DiachiquanId = 2,
                            Gia = 70000m,
                            HinhAnh = "/Images/istockphoto-1200064755-170667a.jpg",
                            LoaiMonAnId = 2,
                            MoTa = "Gà rán giòn tan",
                            TenMon = "Gà rán",
                            ThanhPhanId = 2
                        },
                        new
                        {
                            MonAnId = 6,
                            DiachiquanId = 3,
                            Gia = 30000m,
                            HinhAnh = "/Images/istockphoto-1200064755-170667a.jpg",
                            LoaiMonAnId = 1,
                            MoTa = "Bánh xèo giòn",
                            TenMon = "Bánh xèo",
                            ThanhPhanId = 1
                        },
                        new
                        {
                            MonAnId = 7,
                            DiachiquanId = 1,
                            Gia = 45000m,
                            HinhAnh = "/Images/istockphoto-1200064755-170667a.jpg",
                            LoaiMonAnId = 2,
                            MoTa = "Hủ tiếu Nam Vang",
                            TenMon = "Hủ tiếu",
                            ThanhPhanId = 2
                        },
                        new
                        {
                            MonAnId = 8,
                            DiachiquanId = 2,
                            Gia = 120000m,
                            HinhAnh = "/Images/istockphoto-1200064755-170667a.jpg",
                            LoaiMonAnId = 2,
                            MoTa = "Món sushi Nhật Bản",
                            TenMon = "Sushi",
                            ThanhPhanId = 3
                        },
                        new
                        {
                            MonAnId = 9,
                            DiachiquanId = 3,
                            Gia = 80000m,
                            HinhAnh = "/Images/z6035875873720_114730cc66faa67749315b417c790719.jpg",
                            LoaiMonAnId = 3,
                            MoTa = "Mì Ý sốt cà chua",
                            TenMon = "Mì Ý",
                            ThanhPhanId = 1
                        },
                        new
                        {
                            MonAnId = 10,
                            DiachiquanId = 1,
                            Gia = 25000m,
                            HinhAnh = "/Images/z6035875881929_d785375a00c2dabf615d911288f4930a.jpg",
                            LoaiMonAnId = 1,
                            MoTa = "Trà sữa truyền thống",
                            TenMon = "Trà sữa",
                            ThanhPhanId = 2
                        },
                        new
                        {
                            MonAnId = 11,
                            DiachiquanId = 2,
                            Gia = 30000m,
                            HinhAnh = "/Images/z6042058761907_810f9203bd7cd908f0e8c873ab0bbfd3.jpg",
                            LoaiMonAnId = 1,
                            MoTa = "Salad rau củ tươi ngon",
                            TenMon = "Salad",
                            ThanhPhanId = 3
                        },
                        new
                        {
                            MonAnId = 12,
                            DiachiquanId = 3,
                            Gia = 20000m,
                            HinhAnh = "/Images/z6042058820293_1b98c0f4626db7ed36546748783f2ca4.jpg",
                            LoaiMonAnId = 1,
                            MoTa = "Chè đậu xanh",
                            TenMon = "Chè",
                            ThanhPhanId = 1
                        });
                });

            modelBuilder.Entity("ASM_PH48831.Models.ThanhPhan", b =>
                {
                    b.Property<int>("ThanhPhanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ThanhPhanId"));

                    b.Property<string>("TenThanhPhan")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ThanhPhanId");

                    b.ToTable("ThanhPhan");

                    b.HasData(
                        new
                        {
                            ThanhPhanId = 1,
                            TenThanhPhan = "Thịt gà, bột mì"
                        },
                        new
                        {
                            ThanhPhanId = 2,
                            TenThanhPhan = "Phô mai, cà chua"
                        },
                        new
                        {
                            ThanhPhanId = 3,
                            TenThanhPhan = "Thịt cá"
                        });
                });

            modelBuilder.Entity("ASM_PH48831.Models.User", b =>
                {
                    b.Property<int>("NguoiDungId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NguoiDungId"));

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("TaiKhoan")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TenNguoiDung")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("VaiTro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NguoiDungId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            NguoiDungId = 1,
                            DiaChi = "123 Đường Admin, Hà Nội",
                            Email = "admin@example.com",
                            MatKhau = "admin123",
                            NgaySinh = new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TaiKhoan = "admin",
                            TenNguoiDung = "Administrator",
                            VaiTro = "Admin"
                        },
                        new
                        {
                            NguoiDungId = 2,
                            DiaChi = "456 Đường User, Hồ Chí Minh",
                            Email = "user1@example.com",
                            MatKhau = "user123",
                            NgaySinh = new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TaiKhoan = "user1",
                            TenNguoiDung = "Nguyen Van A",
                            VaiTro = "User"
                        });
                });

            modelBuilder.Entity("ASM_PH48831.Models.ComboChiTiet", b =>
                {
                    b.HasOne("ASM_PH48831.Models.Combo", "Combo")
                        .WithMany("ComboChiTiets")
                        .HasForeignKey("ComboId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASM_PH48831.Models.MonAn", "MonAn")
                        .WithMany("ComboChiTiets")
                        .HasForeignKey("MonAnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Combo");

                    b.Navigation("MonAn");
                });

            modelBuilder.Entity("ASM_PH48831.Models.GioHang", b =>
                {
                    b.HasOne("ASM_PH48831.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserNguoiDungId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ASM_PH48831.Models.GioHangChiTiet", b =>
                {
                    b.HasOne("ASM_PH48831.Models.GioHang", "GioHang")
                        .WithMany("GioHangChiTiets")
                        .HasForeignKey("GioHangId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASM_PH48831.Models.MonAn", "MonAn")
                        .WithMany("GioHangChiTiets")
                        .HasForeignKey("MonAnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GioHang");

                    b.Navigation("MonAn");
                });

            modelBuilder.Entity("ASM_PH48831.Models.HoaDon", b =>
                {
                    b.HasOne("ASM_PH48831.Models.User", "User")
                        .WithMany("HoaDons")
                        .HasForeignKey("NguoiDungId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ASM_PH48831.Models.HoaDonChiTiet", b =>
                {
                    b.HasOne("ASM_PH48831.Models.HoaDon", "HoaDon")
                        .WithMany("HoaDonChiTiets")
                        .HasForeignKey("HoaDonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASM_PH48831.Models.MonAn", "MonAn")
                        .WithMany("HoaDonChiTiets")
                        .HasForeignKey("MonAnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HoaDon");

                    b.Navigation("MonAn");
                });

            modelBuilder.Entity("ASM_PH48831.Models.MonAn", b =>
                {
                    b.HasOne("ASM_PH48831.Models.DiaChiQuan", "DiaChiQuan")
                        .WithMany("MonAns")
                        .HasForeignKey("DiachiquanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASM_PH48831.Models.Kichco", "Kichco")
                        .WithMany("MonAns")
                        .HasForeignKey("KichCoId");

                    b.HasOne("ASM_PH48831.Models.LoaiMonAn", "LoaiMonAn")
                        .WithMany("MonAns")
                        .HasForeignKey("LoaiMonAnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASM_PH48831.Models.ThanhPhan", "ThanhPhan")
                        .WithMany("MonAns")
                        .HasForeignKey("ThanhPhanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DiaChiQuan");

                    b.Navigation("Kichco");

                    b.Navigation("LoaiMonAn");

                    b.Navigation("ThanhPhan");
                });

            modelBuilder.Entity("ASM_PH48831.Models.Combo", b =>
                {
                    b.Navigation("ComboChiTiets");
                });

            modelBuilder.Entity("ASM_PH48831.Models.DiaChiQuan", b =>
                {
                    b.Navigation("MonAns");
                });

            modelBuilder.Entity("ASM_PH48831.Models.GioHang", b =>
                {
                    b.Navigation("GioHangChiTiets");
                });

            modelBuilder.Entity("ASM_PH48831.Models.HoaDon", b =>
                {
                    b.Navigation("HoaDonChiTiets");
                });

            modelBuilder.Entity("ASM_PH48831.Models.Kichco", b =>
                {
                    b.Navigation("MonAns");
                });

            modelBuilder.Entity("ASM_PH48831.Models.LoaiMonAn", b =>
                {
                    b.Navigation("MonAns");
                });

            modelBuilder.Entity("ASM_PH48831.Models.MonAn", b =>
                {
                    b.Navigation("ComboChiTiets");

                    b.Navigation("GioHangChiTiets");

                    b.Navigation("HoaDonChiTiets");
                });

            modelBuilder.Entity("ASM_PH48831.Models.ThanhPhan", b =>
                {
                    b.Navigation("MonAns");
                });

            modelBuilder.Entity("ASM_PH48831.Models.User", b =>
                {
                    b.Navigation("HoaDons");
                });
#pragma warning restore 612, 618
        }
    }
}
