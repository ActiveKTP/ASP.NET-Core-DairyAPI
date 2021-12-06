using System.ComponentModel.DataAnnotations;

namespace DairyAPI.Models
{
    public class Staff
    {
        [Key]
        public string staffId { get; set; }
        public string staffPrefix { get; set; }
        public string staffFName { get; set; }
        public string staffLastName { get; set; }
        public string staffSex { get; set; }

        public string staffOrgId { get; set; }

        public string staffMobileNo { get; set; }

        public string staffEmailAddress { get; set; }
    }
}