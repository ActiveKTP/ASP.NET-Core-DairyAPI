using System;

namespace DairyAPI.Dtos
{
    public class CowFarmsGrowthReadDto
    {
        public int? ccowNo { get; set; }
        public string ccowId { get; set; }
        public string ccowName { get; set; }
        public string cSex { get; set; }
        public string cSireId { get; set; }
        public string cDamId { get; set; }
        public DateTime cBirthDate { get; set; }
        public string cStatus { get; set; }
        public string cProductionStatus { get; set; }
        public string cMilkingStatus { get; set; }
        public string cBirthDate_th
        {
            get
            {
                //cBirthDate = "01/01/64";
                var date_th = cBirthDate.ToString().Split(' ')[0].Split('/');

                return $"{date_th[1]}/{date_th[0]}/{Int32.Parse(date_th[2]) + 543}";
            }
            set { }
        }

        public int Age_day
        {
            get
            {
                var startDate = cBirthDate;
                var currentDate = DateTime.Today;
                var diff = (currentDate - startDate).Days;
                return diff;
            }
            set { }
        }

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