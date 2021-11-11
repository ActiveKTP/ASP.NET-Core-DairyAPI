using System.Collections.Generic;
using System.Linq;
using DairyAPI.Models;

namespace DairyAPI.Data
{
    public class FarmRepo : IFarmRepo
    {
        private readonly DairyContext _farmContext;

        public FarmRepo(DairyContext farmContext)
        {
            _farmContext = farmContext;
        }

        public IEnumerable<Farm> GetAllFarms()
        {
            var farms = (from farm in _farmContext.Farm
                         join province in _farmContext.RefProvince on farm.fProvinceCode equals province.refProvinceId
                         join amphur in _farmContext.RefAmphur on farm.fAmphurCode equals amphur.refAmphurId
                         where (farm.fStatus == "01")
                         orderby farm.fFarmId
                         //select farm
                         select new Farm
                         {
                             fFarmId = farm.fFarmId,
                             fName = farm.fName,
                             fStatus = farm.fStatus,
                             fAmphurCode = farm.fAmphurCode,
                             fProvinceCode = farm.fProvinceCode,
                             aiZone = farm.aiZone,
                             fAmphurName = amphur.refAmphurName,
                             fProvinceName = province.refProvinceName
                         }
                         ).Take(50);
            return farms;
        }

        public Farm GetFarmById(string fFarmId)
        {
            var farms = (from farm in _farmContext.Farm
                         join province in _farmContext.RefProvince on farm.fProvinceCode equals province.refProvinceId
                         join amphur in _farmContext.RefAmphur on farm.fAmphurCode equals amphur.refAmphurId
                         //where (farm.fStatus == "01")
                         orderby farm.fFarmId
                         //select farm
                         select new Farm
                         {
                             fFarmId = farm.fFarmId,
                             fName = farm.fName,
                             fStatus = farm.fStatus,
                             fAmphurCode = farm.fAmphurCode,
                             fProvinceCode = farm.fProvinceCode,
                             aiZone = farm.aiZone,
                             fAmphurName = amphur.refAmphurName,
                             fProvinceName = province.refProvinceName
                         }
                         ).FirstOrDefault(i => i.fFarmId == fFarmId);
            return farms;
        }

    }
}