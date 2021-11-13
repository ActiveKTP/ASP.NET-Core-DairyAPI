using System;

namespace DairyAPI.Dtos
{
    public class MatingReadDto
    {
        public int maTranId { get; set; }
        public int maCowNo { get; set; }
        public int bsTranId { get; set; }
        public int maLactation { get; set; }
        public int maNumberOfServiceInCurrLact { get; set; }
        public DateTime? maDate { get; set; }
        public string maMatingMethod { get; set; }
        public string maSemenId { get; set; }
        public int maSemenDose { get; set; }
        public string maResult { get; set; }
        public string maPregResult { get; set; }
        public string cFarmId { get; set; }
        public string maStaffId { get; set; }
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