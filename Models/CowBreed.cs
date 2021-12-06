using System.ComponentModel.DataAnnotations;

namespace DairyAPI.Models
{
    public class CowBreed
    {
        [Key]
        public string cbcowId { get; set; }
        public string cbBreedId { get; set; }
        public string cbBreedDetail { get; set; }
    }
}