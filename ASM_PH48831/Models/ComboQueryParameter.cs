namespace ASM_PH48831.Models
{
    public class ComboQueryParameter
    {
        public string SortBy { get; set; } = "tatca";
        public string Keyword { get; set; }
        public decimal? FromPrice { get; set; }
        public decimal? ToPrice { get; set; }
        public int PageNumber { get; set; } = 1; 
        public int PageSize { get; set; } = 9;
    }
}
