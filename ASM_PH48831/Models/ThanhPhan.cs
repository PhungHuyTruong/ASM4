using System.ComponentModel.DataAnnotations;

namespace ASM_PH48831.Models
{
    public class ThanhPhan
    {
        [Key]
        public int ThanhPhanId { get; set; }
        [StringLength(100, ErrorMessage = "Tên loại món không được vượt quá 100 ký tự")]
        public string TenThanhPhan { get; set; }

        public ICollection<MonAn> MonAns { get; set; }
    }
}
