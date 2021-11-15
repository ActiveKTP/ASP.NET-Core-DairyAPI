using System;
using System.ComponentModel.DataAnnotations;

namespace DairyAPI.Models
{
    public class Growth
    {
        [Key]
        public int gTranId { get; set; }
        public int gCowNo { get; set; }
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