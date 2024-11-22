using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required(ErrorMessage = "Trạng thái là bắt buộc")]
        public int TrangThaiId { get; set; }
        [ForeignKey("TrangThaiId")]
        public TrangThaiHoaDon TrangThaiHoaDon { get; set; }

        public ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; }
    }
}
