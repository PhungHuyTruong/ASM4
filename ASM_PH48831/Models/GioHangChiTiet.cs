using System.ComponentModel.DataAnnotations;

namespace ASM_PH48831.Models
{
    public class GioHangChiTiet
    {
        [Key]
        public int GioHangChiTietId { get; set; }

        [Required(ErrorMessage = "Giỏ hàng là bắt buộc")]
        public int GioHangId { get; set; }
        public GioHang GioHang { get; set; }

        [Required(ErrorMessage = "Món ăn là bắt buộc")]
        public int MonAnId { get; set; }
        public MonAn MonAn { get; set; }

        [Required(ErrorMessage = "Số lượng là bắt buộc")]
        [Range(1, 100, ErrorMessage = "Số lượng phải nằm trong khoảng từ 1 đến 100")]
        public int SoLuong { get; set; }
    }
}