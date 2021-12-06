using System;
using System.ComponentModel.DataAnnotations;

namespace DairyAPI.Dtos
{
    public class CowFarmsGrowthCVReadDto
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

        public int? maTranId { get; set; }
        public int? maCowNo { get; set; }
        public int? bsTranId { get; set; }
        public int? maLactation { get; set; }
        public int? maNumberOfServiceInCurrLact { get; set; }
        public DateTime maDate { get; set; }
        public string maDate_th
        {
            get
            {
                /*if (maDate != null)
                {*/
                var date_th = maDate.ToString().Split(' ')[0].Split('/');
                return $"{date_th[1]}/{date_th[0]}/{Int32.Parse(date_th[2]) + 543}";
                /* }
                 else
                 {
                     return null;
                 }*/
            }
            set { }
        }
        //public string maMatingMethod { get; set; }
        public string maSemenId { get; set; }
        //public int? maSemenDose { get; set; }
        //public string maResult { get; set; }
        public string maPregResult { get; set; }
        //public string cFarmId { get; set; }
        //public string maStaffId { get; set; }
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

        public int? cvgTranId { get; set; }
        //public int? cvgMaTranId { get; set; }
        //public int? cvgCowNo { get; set; }
        //public int? cvgLacNo { get; set; }
        public DateTime? cvgDate { get; set; }
        public string cvgDate_th
        {
            get
            {
                if (cvgDate != null)
                {
                    var date_th = cvgDate.ToString().Split(' ')[0].Split('/');
                    return $"{date_th[1]}/{date_th[0]}/{Int32.Parse(date_th[2]) + 543}";
                }
                else
                {
                    return null;
                }
            }
            set { }
        }
        public int? cvgNoOfCalves { get; set; }
        //public string cvgParturition { get; set; }
        //public string cvgCalvingResult { get; set; }
        //public string cvgCalvingAsst { get; set; }
        //public string cFarmId { get; set; }
        //public string cvgStaffId { get; set; }

        //public int? cvSeqNo { get; set; }
        public string cvCalveSex { get; set; }
        //public DateTime? cvDate { get; set; }
        //public string cvCalveNo { get; set; }
        //public string cvCalveName { get; set; }
        //public string cvPostCalveStatus { get; set; }
        public float cvWeight { get; set; }
        //public string cvWeight { get; set; }
        //public float? cvCalveSalePrice { get; set; }

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