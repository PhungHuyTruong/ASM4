using System.ComponentModel.DataAnnotations;

namespace ASM_PH48831.Models
{
    public class GioHang
    {
        [Key]
        public int GioHangId { get; set; }

        [Required(ErrorMessage = "Người dùng là bắt buộc")]
        public int NguoiDungId { get; set; }
        public User User { get; set; }

        public ICollection<GioHangChiTiet> GioHangChiTiets { get; set; }
    }
}
