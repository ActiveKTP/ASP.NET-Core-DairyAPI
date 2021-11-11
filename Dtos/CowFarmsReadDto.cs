using System;

namespace DairyAPI.Dtos
{
    public class CowFarmsReadDto
    {

        public string ccowId { get; set; }
        public string ccowName { get; set; }
        public string cSex { get; set; }
        public string cSireId { get; set; }
        public string cDamId { get; set; }

        public DateTime cBirthDate { get; set; }

        public string cStatus { get; set; }
        public string cProductionStatus { get; set; }
        public string cMilkingStatus { get; set; }
        public int? cLactation { get; set; }
        public int? cNumOfService { get; set; }

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

        public string cAge
        {
            get
            {
                var startDate = cBirthDate;
                var currentDate = DateTime.Today;
                var diff = (currentDate - startDate).TotalDays;
                var totalYears = Math.Truncate(diff / 365);
                var totalMonths = Math.Truncate((diff % 365) / 30);
                var cAge = $"{totalYears}-{totalMonths}";
                return cAge;
            }
            set { }
        }

        public string fFarmId { get; set; }
        public string fName { get; set; }
        //public string fStatus { get; set; }
        public string fAmphurCode { get; set; }
        public string fProvinceCode { get; set; }
        public string fAmphurName { get; set; }
        public string fProvinceName { get; set; }
        public string aiZone { get; set; }
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