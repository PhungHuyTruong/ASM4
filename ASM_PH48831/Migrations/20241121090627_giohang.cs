using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASM_PH48831.Migrations
{
    /// <inheritdoc />
    public partial class giohang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Combos",
                columns: table => new
                {
                    ComboId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCombo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GiaCombo = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combos", x => x.ComboId);
                });

            migrationBuilder.CreateTable(
                name: "DiaChiQuan",
                columns: table => new
                {
                    DiachiquanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaChiChiTiet = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaChiQuan", x => x.DiachiquanId);
                });

            migrationBuilder.CreateTable(
                name: "Kichco",
                columns: table => new
                {
                    KichCoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKichCo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kichco", x => x.KichCoId);
                });

            migrationBuilder.CreateTable(
                name: "LoaiMonAn",
                columns: table => new
                {
                    LoaiMonAnId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiMon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiMonAn", x => x.LoaiMonAnId);
                });

            migrationBuilder.CreateTable(
                name: "ThanhPhan",
                columns: table => new
                {
                    ThanhPhanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThanhPhan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThanhPhan", x => x.ThanhPhanId);
                });

            migrationBuilder.CreateTable(
                name: "TrangThaiHoaDons",
                columns: table => new
                {
                    IdTrangThai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrangThaiHoaDons", x => x.IdTrangThai);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    NguoiDungId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNguoiDung = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TaiKhoan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VaiTro = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.NguoiDungId);
                });

            migrationBuilder.CreateTable(
                name: "MonAns",
                columns: table => new
                {
                    MonAnId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenMon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LoaiMonAnId = table.Column<int>(type: "int", nullable: false),
                    KichCoId = table.Column<int>(type: "int", nullable: true),
                    DiachiquanId = table.Column<int>(type: "int", nullable: false),
                    ThanhPhanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonAns", x => x.MonAnId);
                    table.ForeignKey(
                        name: "FK_MonAns_DiaChiQuan_DiachiquanId",
                        column: x => x.DiachiquanId,
                        principalTable: "DiaChiQuan",
                        principalColumn: "DiachiquanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonAns_Kichco_KichCoId",
                        column: x => x.KichCoId,
                        principalTable: "Kichco",
                        principalColumn: "KichCoId");
                    table.ForeignKey(
                        name: "FK_MonAns_LoaiMonAn_LoaiMonAnId",
                        column: x => x.LoaiMonAnId,
                        principalTable: "LoaiMonAn",
                        principalColumn: "LoaiMonAnId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonAns_ThanhPhan_ThanhPhanId",
                        column: x => x.ThanhPhanId,
                        principalTable: "ThanhPhan",
                        principalColumn: "ThanhPhanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GioHangs",
                columns: table => new
                {
                    GioHangId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NguoiDungId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHangs", x => x.GioHangId);
                    table.ForeignKey(
                        name: "FK_GioHangs_Users_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "Users",
                        principalColumn: "NguoiDungId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDons",
                columns: table => new
                {
                    HoaDonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NguoiDungId = table.Column<int>(type: "int", nullable: false),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrangThaiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDons", x => x.HoaDonId);
                    table.ForeignKey(
                        name: "FK_HoaDons_TrangThaiHoaDons_TrangThaiId",
                        column: x => x.TrangThaiId,
                        principalTable: "TrangThaiHoaDons",
                        principalColumn: "IdTrangThai",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HoaDons_Users_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "Users",
                        principalColumn: "NguoiDungId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComboChiTiets",
                columns: table => new
                {
                    ComboChiTietId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComboId = table.Column<int>(type: "int", nullable: false),
                    MonAnId = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComboChiTiets", x => x.ComboChiTietId);
                    table.ForeignKey(
                        name: "FK_ComboChiTiets_Combos_ComboId",
                        column: x => x.ComboId,
                        principalTable: "Combos",
                        principalColumn: "ComboId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComboChiTiets_MonAns_MonAnId",
                        column: x => x.MonAnId,
                        principalTable: "MonAns",
                        principalColumn: "MonAnId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GioHangChiTiets",
                columns: table => new
                {
                    GioHangChiTietId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GioHangId = table.Column<int>(type: "int", nullable: false),
                    MonAnId = table.Column<int>(type: "int", nullable: true),
                    ComboId = table.Column<int>(type: "int", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHangChiTiets", x => x.GioHangChiTietId);
                    table.ForeignKey(
                        name: "FK_GioHangChiTiets_Combos_ComboId",
                        column: x => x.ComboId,
                        principalTable: "Combos",
                        principalColumn: "ComboId");
                    table.ForeignKey(
                        name: "FK_GioHangChiTiets_GioHangs_GioHangId",
                        column: x => x.GioHangId,
                        principalTable: "GioHangs",
                        principalColumn: "GioHangId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GioHangChiTiets_MonAns_MonAnId",
                        column: x => x.MonAnId,
                        principalTable: "MonAns",
                        principalColumn: "MonAnId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDonChiTiets",
                columns: table => new
                {
                    HoaDonChiTietId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoaDonId = table.Column<int>(type: "int", nullable: false),
                    MonAnId = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonChiTiets", x => x.HoaDonChiTietId);
                    table.ForeignKey(
                        name: "FK_HoaDonChiTiets_HoaDons_HoaDonId",
                        column: x => x.HoaDonId,
                        principalTable: "HoaDons",
                        principalColumn: "HoaDonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDonChiTiets_MonAns_MonAnId",
                        column: x => x.MonAnId,
                        principalTable: "MonAns",
                        principalColumn: "MonAnId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Combos",
                columns: new[] { "ComboId", "GiaCombo", "TenCombo" },
                values: new object[,]
                {
                    { 1, 50000m, "Combo Bữa Trưa" },
                    { 2, 100000m, "Combo Bữa Tối" }
                });

            migrationBuilder.InsertData(
                table: "DiaChiQuan",
                columns: new[] { "DiachiquanId", "DiaChiChiTiet" },
                values: new object[,]
                {
                    { 1, "Hà nội" },
                    { 2, "Hải phòng" },
                    { 3, "Hải Dương" }
                });

            migrationBuilder.InsertData(
                table: "Kichco",
                columns: new[] { "KichCoId", "TenKichCo" },
                values: new object[,]
                {
                    { 1, "Lớn" },
                    { 2, "Nhỏ" },
                    { 3, "Trung Bình" }
                });

            migrationBuilder.InsertData(
                table: "LoaiMonAn",
                columns: new[] { "LoaiMonAnId", "TenLoaiMon" },
                values: new object[,]
                {
                    { 1, "Đồ chay" },
                    { 2, "Thịt cá" },
                    { 3, "Món ăn khác" }
                });

            migrationBuilder.InsertData(
                table: "ThanhPhan",
                columns: new[] { "ThanhPhanId", "TenThanhPhan" },
                values: new object[,]
                {
                    { 1, "Thịt gà, bột mì" },
                    { 2, "Phô mai, cà chua" },
                    { 3, "Thịt cá" }
                });

            migrationBuilder.InsertData(
                table: "TrangThaiHoaDons",
                columns: new[] { "IdTrangThai", "TenTrangThai" },
                values: new object[,]
                {
                    { 1, "Đang xử lý" },
                    { 2, "Đang giao" },
                    { 3, "Đã giao" },
                    { 4, "Đã thanh toán" },
                    { 5, "Đã hủy" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "NguoiDungId", "DiaChi", "Email", "MatKhau", "NgaySinh", "TaiKhoan", "TenNguoiDung", "VaiTro" },
                values: new object[,]
                {
                    { 1, "123 Đường Admin, Hà Nội", "admin@example.com", "admin123", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin", "Administrator", "Admin" },
                    { 2, "456 Đường User, Hồ Chí Minh", "user1@example.com", "user123", new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "user1", "Nguyen Van A", "User" }
                });

            migrationBuilder.InsertData(
                table: "HoaDons",
                columns: new[] { "HoaDonId", "NgayLap", "NguoiDungId", "TongTien", "TrangThaiId" },
                values: new object[] { 1, new DateTime(2024, 11, 21, 16, 6, 27, 506, DateTimeKind.Local).AddTicks(8930), 2, 250000m, 1 });

            migrationBuilder.InsertData(
                table: "MonAns",
                columns: new[] { "MonAnId", "DiachiquanId", "Gia", "HinhAnh", "KichCoId", "LoaiMonAnId", "MoTa", "TenMon", "ThanhPhanId" },
                values: new object[,]
                {
                    { 1, 1, 200000m, "/Images/hosting-fpt-removebg-preview.png", null, 3, "Pizza truyền thống", "Pizza", 1 },
                    { 2, 2, 15000m, "/Images/img-1000x600-1.jpg", null, 1, "Bánh mì Việt Nam", "Bánh mì", 1 },
                    { 3, 3, 60000m, "/Images/istockphoto-1200064755-170667a.jpg", null, 2, "Món bún nổi tiếng", "Bún bò Huế", 2 },
                    { 4, 1, 50000m, "/Images/istockphoto-1200064755-170667a.jpg", null, 2, "Món phở truyền thống", "Phở", 3 },
                    { 5, 2, 70000m, "/Images/istockphoto-1200064755-170667a.jpg", null, 2, "Gà rán giòn tan", "Gà rán", 2 },
                    { 6, 3, 30000m, "/Images/istockphoto-1200064755-170667a.jpg", null, 1, "Bánh xèo giòn", "Bánh xèo", 1 },
                    { 7, 1, 45000m, "/Images/istockphoto-1200064755-170667a.jpg", null, 2, "Hủ tiếu Nam Vang", "Hủ tiếu", 2 },
                    { 8, 2, 120000m, "/Images/istockphoto-1200064755-170667a.jpg", null, 2, "Món sushi Nhật Bản", "Sushi", 3 },
                    { 9, 3, 80000m, "/Images/z6035875873720_114730cc66faa67749315b417c790719.jpg", null, 3, "Mì Ý sốt cà chua", "Mì Ý", 1 },
                    { 10, 1, 25000m, "/Images/z6035875881929_d785375a00c2dabf615d911288f4930a.jpg", null, 1, "Trà sữa truyền thống", "Trà sữa", 2 },
                    { 11, 2, 30000m, "/Images/z6042058761907_810f9203bd7cd908f0e8c873ab0bbfd3.jpg", null, 1, "Salad rau củ tươi ngon", "Salad", 3 },
                    { 12, 3, 20000m, "/Images/z6042058820293_1b98c0f4626db7ed36546748783f2ca4.jpg", null, 1, "Chè đậu xanh", "Chè", 1 }
                });

            migrationBuilder.InsertData(
                table: "ComboChiTiets",
                columns: new[] { "ComboChiTietId", "ComboId", "MonAnId", "SoLuong" },
                values: new object[,]
                {
                    { 1, 1, 1, 2 },
                    { 2, 1, 2, 1 },
                    { 3, 1, 3, 1 },
                    { 4, 2, 4, 1 },
                    { 5, 2, 5, 1 }
                });

            migrationBuilder.InsertData(
                table: "HoaDonChiTiets",
                columns: new[] { "HoaDonChiTietId", "DonGia", "HoaDonId", "MonAnId", "SoLuong" },
                values: new object[,]
                {
                    { 1, 200000m, 1, 1, 1 },
                    { 2, 15000m, 1, 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComboChiTiets_ComboId",
                table: "ComboChiTiets",
                column: "ComboId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboChiTiets_MonAnId",
                table: "ComboChiTiets",
                column: "MonAnId");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangChiTiets_ComboId",
                table: "GioHangChiTiets",
                column: "ComboId");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangChiTiets_GioHangId",
                table: "GioHangChiTiets",
                column: "GioHangId");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangChiTiets_MonAnId",
                table: "GioHangChiTiets",
                column: "MonAnId");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangs_NguoiDungId",
                table: "GioHangs",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonChiTiets_HoaDonId",
                table: "HoaDonChiTiets",
                column: "HoaDonId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonChiTiets_MonAnId",
                table: "HoaDonChiTiets",
                column: "MonAnId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_NguoiDungId",
                table: "HoaDons",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_TrangThaiId",
                table: "HoaDons",
                column: "TrangThaiId");

            migrationBuilder.CreateIndex(
                name: "IX_MonAns_DiachiquanId",
                table: "MonAns",
                column: "DiachiquanId");

            migrationBuilder.CreateIndex(
                name: "IX_MonAns_KichCoId",
                table: "MonAns",
                column: "KichCoId");

            migrationBuilder.CreateIndex(
                name: "IX_MonAns_LoaiMonAnId",
                table: "MonAns",
                column: "LoaiMonAnId");

            migrationBuilder.CreateIndex(
                name: "IX_MonAns_ThanhPhanId",
                table: "MonAns",
                column: "ThanhPhanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComboChiTiets");

            migrationBuilder.DropTable(
                name: "GioHangChiTiets");

            migrationBuilder.DropTable(
                name: "HoaDonChiTiets");

            migrationBuilder.DropTable(
                name: "Combos");

            migrationBuilder.DropTable(
                name: "GioHangs");

            migrationBuilder.DropTable(
                name: "HoaDons");

            migrationBuilder.DropTable(
                name: "MonAns");

            migrationBuilder.DropTable(
                name: "TrangThaiHoaDons");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "DiaChiQuan");

            migrationBuilder.DropTable(
                name: "Kichco");

            migrationBuilder.DropTable(
                name: "LoaiMonAn");

            migrationBuilder.DropTable(
                name: "ThanhPhan");
        }
    }
}
