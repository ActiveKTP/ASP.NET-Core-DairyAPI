using System;
using System.ComponentModel.DataAnnotations;

namespace DairyAPI.Models
{
    public class Growth
    {
        [Key]
        public int? gTranId { get; set; }
        public int? gCowNo { get; set; }
        public DateTime? gMeasureDate { get; set; }
        public string gMeasureType { get; set; }
        public float? gHeartGirth { get; set; }
        public float? gWeight { get; set; }
        public int? gBodyConditionScore { get; set; }
        public string gCowStatus { get; set; }
        public string gEvaluator { get; set; }
        public string gRemark { get; set; }
        public float? gBodylength { get; set; }
        public float? gHeight { get; set; }
        public string gTranType { get; set; }
        public DateTime? date_updated { get; set; }
        public string user_updated { get; set; }
    }
}