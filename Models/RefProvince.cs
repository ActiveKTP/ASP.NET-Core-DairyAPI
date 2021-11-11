using System.ComponentModel.DataAnnotations;

namespace DairyAPI.Models
{
    public class RefProvince
    {
        [Key]
        public string refProvinceId { get; set; }
        public string refProvinceName { get; set; }
    }
}