using System.ComponentModel.DataAnnotations;

namespace DairyAPI.Models
{
    public class RefAmphur
    {
        [Key]
        public string refAmphurId { get; set; }
        public string refAmphurName { get; set; }
    }
}