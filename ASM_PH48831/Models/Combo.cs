using ASM_PH48831.Models;
using System.ComponentModel.DataAnnotations;

namespace ASM_PH48831.Models
{
    public class Combo
    {
        [Key]
        public int ComboId { get; set; }

        [Required(ErrorMessage = "Tên combo là bắt buộc")]
        [StringLength(100, ErrorMessage = "Tên combo không được vượt quá 100 ký tự")]
        public string TenCombo { get; set; }

        [Required(ErrorMessage = "Giá combo là bắt buộc")]
        [Range(1000, 1000000, ErrorMessage = "Giá combo phải nằm trong khoảng từ 1.000 đến 1.000.000")]
        public decimal GiaCombo { get; set; }

        public ICollection<ComboChiTiet> ComboChiTiets { get; set; }
    }
}
