using System;
using System.ComponentModel.DataAnnotations;

namespace DairyAPI.Models
{
    public class Calve
    {
        [Key]
        public int? cvgTranId { get; set; }
        public int? cvSeqNo { get; set; }
        public int? cvCowNo { get; set; }
        public string cvCalveSex { get; set; }
        public DateTime? cvDate { get; set; }
        public string cvCalveNo { get; set; }
        public string cvCalveName { get; set; }
        public string cvPostCalveStatus { get; set; }
        public double? cvWeight { get; set; }
        public double? cvCalveSalePrice { get; set; }
        public DateTime? date_updated { get; set; }
        public string user_updated { get; set; }
    }
}