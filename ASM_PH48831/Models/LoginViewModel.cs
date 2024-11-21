using System.ComponentModel.DataAnnotations;

namespace ASM_PH48831.Models
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Tài khoản là bắt buộc")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Tài khoản phải có độ dài từ 5 đến 50 ký tự")]
        public string TaiKhoan { get; set; }

        [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải có độ dài ít nhất 6 ký tự")]
        public string MatKhau { get; set; }
    }
}
