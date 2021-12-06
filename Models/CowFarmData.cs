using System;
using System.ComponentModel.DataAnnotations;

namespace DairyAPI.Models
{
    public class CowFarmData
    {
        public int? ccowNo { get; set; }

        [Key]
        public string ccowId { get; set; }
        public string ccowName { get; set; }
        public string cSex { get; set; }
        public string cSireId { get; set; }
        public string cDamId { get; set; }

        public DateTime? cBirthDate { get; set; }

        public string cStatus { get; set; }
        public string cProductionStatus { get; set; }
        public string cMilkingStatus { get; set; }
        public int? cLactation { get; set; }
        public int? cNumOfService { get; set; }
        //public int? cActiveFlag { get; set; }

        public string fFarmId { get; set; }
        public string fName { get; set; }
        //public string fStatus { get; set; }
        public string aiZone { get; set; }

        public string cbcowId { get; set; }
        public string cbBreedId { get; set; }
        public string cbBreedDetail { get; set; }
    }
}