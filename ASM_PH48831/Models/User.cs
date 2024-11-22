using System.ComponentModel.DataAnnotations;

namespace ASM_PH48831.Models
{
    public class User
    {
        [Key]
        public int NguoiDungId { get; set; }

        [Required(ErrorMessage = "Tên người dùng là bắt buộc")]
        [StringLength(100, ErrorMessage = "Tên người dùng không được vượt quá 100 ký tự")]
        [Display(Name = "Tên Người Dùng")]
        public string TenNguoiDung { get; set; }

        [Required(ErrorMessage = "Ngày sinh là bắt buộc")]
        [DataType(DataType.Date)]
        [Display(Name = "Ngày Sinh")]
        public DateTime NgaySinh { get; set; }

        [Required(ErrorMessage = "Địa chỉ là bắt buộc")]
        [StringLength(200, ErrorMessage = "Địa chỉ không được vượt quá 200 ký tự")]
        [Display(Name = "Địa Chỉ")]
        public string DiaChi { get; set; }

        [Required(ErrorMessage = "Tài khoản là bắt buộc")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Tài khoản phải có độ dài từ 5 đến 50 ký tự")]
        public string TaiKhoan { get; set; }

        [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải có độ dài ít nhất 6 ký tự")]
        public string MatKhau { get; set; }

        [Required(ErrorMessage = "Email là bắt buộc")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vai trò là bắt buộc")]
        public string VaiTro { get; set; } = "User";

        public ICollection<HoaDon> HoaDons { get; set; }
        public ICollection<GioHang> GioHangs { get; set; }
    }
}
