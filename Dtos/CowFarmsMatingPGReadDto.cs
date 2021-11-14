using System;

namespace DairyAPI.Dtos
{
    public class CowFarmsMatingPGReadDto
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
        public string fAmphurCode { get; set; }
        public string fProvinceCode { get; set; }
        public string fAmphurName { get; set; }
        public string fProvinceName { get; set; }
        public string aiZone { get; set; }

        public int? maTranId { get; set; }
        //public int? bsTranId { get; set; }
        public int? maLactation { get; set; }
        public int? maNumberOfServiceInCurrLact { get; set; }
        public DateTime maDate { get; set; }
        //public string maMatingMethod { get; set; }
        public string maSemenId { get; set; }
        public int? maSemenDose { get; set; }
        public string maResult { get; set; }
        public string maPregResult { get; set; }
        public string cFarmId { get; set; }
        public string maStaffId { get; set; }
        public DateTime? date_updated { get; set; }
        public string user_updated { get; set; }

        public DateTime predicCalvingDate
        {
            get
            {
                DateTime predicDate = maDate.AddDays(280);
                return predicDate;
            }
            set { }
        }

        public string predicCalvingDate_th
        {
            get
            {
                var predicDate = maDate.AddDays(280).ToString().Split(' ')[0].Split('/');
                var predicDate_th = $"{predicDate[1]}/{predicDate[0]}/{Int32.Parse(predicDate[2]) + 543}";
                return predicDate_th;
            }
            set { }
        }

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