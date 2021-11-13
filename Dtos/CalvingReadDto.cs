using System;

namespace DairyAPI.Dtos
{
    public class CalvingReadDto
    {
        public int? cvgTranId { get; set; }
        public int? cvgMaTranId { get; set; }
        public int? cvgCowNo { get; set; }
        public int? cvgLacNo { get; set; }
        public DateTime? cvgDate { get; set; }
        public int? cvgNoOfCalves { get; set; }
        public string cvgParturition { get; set; }
        public string cvgCalvingResult { get; set; }
        public string cvgCalvingAsst { get; set; }
        public string cFarmId { get; set; }
        public string cvgStaffId { get; set; }
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