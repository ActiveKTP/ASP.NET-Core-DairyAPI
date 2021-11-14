using System;
using System.ComponentModel.DataAnnotations;

namespace DairyAPI.Models
{
    public class CowFarmsMatingPG
    {
        [Key]
        public int? ccowNo { get; set; }
        public string ccowId { get; set; }
        public string ccowName { get; set; }
        public string cSex { get; set; }
        public string cSireId { get; set; }
        public string cDamId { get; set; }
        public DateTime? cBirthDate { get; set; }
        public string cStatus { get; set; }
        public string cProductionStatus { get; set; }
        public string cMilkingStatus { get; set; }

        public string fFarmId { get; set; }
        public string fName { get; set; }
        public string fAmphurCode { get; set; }
        public string fProvinceCode { get; set; }
        public string fAmphurName { get; set; }
        public string fProvinceName { get; set; }
        public string aiZone { get; set; }

        public int? maTranId { get; set; }
        public int? bsTranId { get; set; }
        public int? maLactation { get; set; }
        public int? maNumberOfServiceInCurrLact { get; set; }
        public DateTime? maDate { get; set; }
        public string maMatingMethod { get; set; }
        public string maSemenId { get; set; }
        public int? maSemenDose { get; set; }
        public string maResult { get; set; }
        public string maPregResult { get; set; }
        public string cFarmId { get; set; }
        public string maStaffId { get; set; }
        public DateTime? date_updated { get; set; }
        public string user_updated { get; set; }
    }
}