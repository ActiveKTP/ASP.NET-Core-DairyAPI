using System;

namespace DairyAPI.Dtos
{
    public class CalveReadDto
    {
        public int? cvgTranId { get; set; }
        public int? cvSeqNo { get; set; }
        public int? cvCowNo { get; set; }
        public string cvCalveSex { get; set; }
        public DateTime? cvDate { get; set; }
        public string cvCalveNo { get; set; }
        public string cvCalveName { get; set; }
        public string cvPostCalveStatus { get; set; }
        public float? cvWeight { get; set; }
        public float? cvCalveSalePrice { get; set; }
        public DateTime? date_updated { get; set; }
        public string user_updated { get; set; }

        public DateTime currentDate
        {
            get
            {
                DateTime newDate = DateTime.Today;
                return newDate;
            }
            set { }
        }
    }
}