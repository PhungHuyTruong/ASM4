﻿using System.ComponentModel.DataAnnotations;

namespace ASM_PH48831.Models
{
    public class HoaDonChiTiet
    {
        [Key]
        public int HoaDonChiTietId { get; set; }

        [Required(ErrorMessage = "Hóa đơn là bắt buộc")]
        public int HoaDonId { get; set; }
        public HoaDon HoaDon { get; set; }

        [Required(ErrorMessage = "Món ăn là bắt buộc")]
        public int MonAnId { get; set; }
        public MonAn MonAn { get; set; }

        [Required(ErrorMessage = "Số lượng là bắt buộc")]
        [Range(1, 100, ErrorMessage = "Số lượng phải nằm trong khoảng từ 1 đến 100")]
        public int SoLuong { get; set; }

        [Required(ErrorMessage = "Đơn giá là bắt buộc")]
        public decimal DonGia { get; set; }
    }
}