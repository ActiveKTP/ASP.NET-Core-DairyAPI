using System;
using System.ComponentModel.DataAnnotations;

namespace DairyAPI.Dtos
{
    public class GrowthCreateDto
    {
        [Required]
        public int gCowNo { get; set; }
        [Required]
        public DateTime gMeasureDate { get; set; }
        //public string gMeasureType { get; set; }
        //public double? gHeartGirth { get; set; }
        [Required]
        public double gWeight { get; set; }
        //public int gBodyConditionScore { get; set; }
        [Required]
        public string gCowStatus { get; set; }
        [Required]
        public string gEvaluator { get; set; }
        public string gRemark { get; set; }
        //public double? gBodylength { get; set; }
        //public double? gHeight { get; set; }
        //public string gTranType { get; set; }
        public DateTime date_updated
        {
            get
            {
                DateTime newDate = DateTime.Now;
                return newDate;
            }
            set
            {
                DateTime date_updated = DateTime.Now;
                //return newDate;
            }
        }
        [Required]
        public string user_updated { get; set; }
    }
}