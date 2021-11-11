using System.ComponentModel.DataAnnotations;

namespace DairyAPI.Models
{
    public class Farm
    {
        [Key]
        public string fFarmId { get; set; }
        public string fName { get; set; }
        public string fStatus { get; set; }
        public string fAmphurCode { get; set; }
        public string fProvinceCode { get; set; }

        public string aiZone { get; set; }

        public string fAmphurName { get; set; }

        public string fProvinceName { get; set; }
    }
}