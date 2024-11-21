using System.ComponentModel.DataAnnotations;

namespace ASM_PH48831.Models
{
    public class HoaDon
    {
        [Key]
        public int HoaDonId { get; set; }

        [Required(ErrorMessage = "Người dùng là bắt buộc")]
        public int NguoiDungId { get; set; }
        public User User { get; set; }

        [Required(ErrorMessage = "Ngày lập là bắt buộc")]
        public DateTime NgayLap { get; set; }

        [Required(ErrorMessage = "Tổng tiền là bắt buộc")]
        public decimal TongTien { get; set; }

        public ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; }
    }
}
