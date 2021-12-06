using System;
using System.ComponentModel.DataAnnotations;

namespace DairyAPI.Models
{
    public class CowFarmsGrowth
    {
        [Key]
        public int? ccowNo { get; set; }
        public string ccowId { get; set; }
        public string ccowName { get; set; }
        public string cSex { get; set; }
        public string cSireId { get; set; }
        public string cDamId { get; set; }
        public DateTime? cBirthDate { get; set; }
        public string cStatus { get; set; }
        public string cProductionStatus { get; set; }
        public string cMilkingStatus { get; set; }

        public string fFarmId { get; set; }
        public string fName { get; set; }
        public string fAmphurCode { get; set; }
        public string fProvinceCode { get; set; }
        public string fAmphurName { get; set; }
        public string fProvinceName { get; set; }
        public string aiZone { get; set; }

        public int? gTranId { get; set; }
        public DateTime? gMeasureDate { get; set; }
        public string gMeasureType { get; set; }
        public double? gHeartGirth { get; set; }
        public double? gWeight { get; set; }
        public int? gBodyConditionScore { get; set; }
        public string gCowStatus { get; set; }
        public string gEvaluator { get; set; }
        public string gRemark { get; set; }
        public double? gBodylength { get; set; }
        public double? gHeight { get; set; }
        public string gTranType { get; set; }
        public DateTime? date_updated { get; set; }
        public string user_updated { get; set; }
    }
}