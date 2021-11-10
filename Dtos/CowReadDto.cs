using System;
using System.ComponentModel.DataAnnotations;

namespace DairyAPI.Dtos
{
    public class CowReadDto
    {

        public string ccowId { get; set; }
        public string ccowName { get; set; }
        public string cSex { get; set; }
        public string cSireId { get; set; }
        public string cDamId { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{MM/dd/yyyy}")]
        public string cBirthDate { get; set; }

        public string cStatus { get; set; }
        public string cProductionStatus { get; set; }
        public string cMilkingStatus { get; set; }
        public string cFarmId { get; set; }
        public int? cLactation { get; set; }
        public int? cNumOfService { get; set; }

        public string cBirthDate_th
        {
            get
            {
                //cBirthDate = "01/01/64";
                var date_th = cBirthDate.Split(' ')[0].Split('/');

                return $"{date_th[1]}/{date_th[0]}/{Int32.Parse(date_th[2]) + 543}";
            }
            set { }
        }
    }
}