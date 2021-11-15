using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DairyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DairyAPI.Data
{
    public class GrowthRepo : IGrowthRepo
    {
        private readonly DairyContext _context;

        public GrowthRepo(DairyContext context)
        {
            _context = context;
        }

        public async Task<Growth> CreateGrowth(Growth growth)
        {
            if (growth == null)
            {
                throw new ArgumentNullException(nameof(growth));
            }

            _context.Growth.Add(growth);
            await _context.SaveChangesAsync();

            return growth;
        }

        public async Task Delete(Growth growth)
        {
            //var growthDelete = await _context.Growth.FindAsync(gTranId);
            if (growth == null)
            {
                throw new ArgumentNullException(nameof(growth));
            }
            _context.Growth.Remove(growth);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CowFarmsGrowthCV>> GetAllCowFarmsGrowthCV_aiZone(string aiZone, int year, int month)
        {
            var queryString = from cow in _context.Cow
                              join farm in _context.Farm on cow.cFarmId equals farm.fFarmId
                              join province in _context.RefProvince on farm.fProvinceCode equals province.refProvinceId
                              join amphur in _context.RefAmphur on farm.fAmphurCode equals amphur.refAmphurId
                              join mating in _context.Mating on
                               new
                               {
                                   key1 = cow.ccowNo,
                                   key2 = cow.cLactation,
                                   key3 = cow.cNumOfService
                               }
                                equals
                               new
                               {
                                   key1 = mating.maCowNo,
                                   key2 = mating.maLactation,
                                   key3 = mating.maNumberOfServiceInCurrLact
                               }
                               /* join cv in
                                (from calving in _context.Calving
                                     //where calving.gCowStatus == "04"
                                 select calving) on mating.maTranId equals cv.cvgMaTranId into tempcv
                                from xcv in tempcv.DefaultIfEmpty()
                                join ca in
                                (from calve in _context.Calve
                                 select calve) on xcv.cvgTranId equals ca.cvgTranId into tempca
                                from xca in tempca.DefaultIfEmpty()*/
                              join g in
                                  (from growth in _context.Growth
                                   where growth.gCowStatus == "04"
                                   select growth) on cow.ccowNo equals g.gCowNo into temp
                              from x in temp.DefaultIfEmpty()
                              where

                                  cow.cActiveFlag == 1 && cow.cSex == "F"
                                  && mating.maPregResult == "PG"
                                  && farm.aiZone == aiZone
                                  && farm.fStatus == "04"
                                  && mating.maDate.AddDays(280).Year == year && mating.maDate.AddDays(280).Month == month
                              orderby cow.cBirthDate descending
                              select new CowFarmsGrowthCV
                              {
                                  ccowNo = cow.ccowNo,
                                  ccowId = cow.ccowId,
                                  ccowName = cow.ccowName,
                                  cSex = cow.cSex,
                                  cSireId = cow.cSireId,
                                  cDamId = cow.cDamId,
                                  cBirthDate = cow.cBirthDate,
                                  cStatus = cow.cStatus,
                                  cProductionStatus = cow.cProductionStatus,
                                  cMilkingStatus = cow.cMilkingStatus,
                                  fFarmId = farm.fFarmId,
                                  fName = farm.fName,
                                  fAmphurCode = farm.fAmphurCode,
                                  fProvinceCode = farm.fProvinceCode,
                                  fAmphurName = amphur.refAmphurName,
                                  fProvinceName = province.refProvinceName,
                                  aiZone = farm.aiZone,

                                  maTranId = mating.maTranId,
                                  maDate = mating.maDate,
                                  maPregResult = mating.maPregResult,

                                  /*cvgTranId = xcv.cvgTranId,
                                  cvgDate = xcv.cvgDate,
                                  cvgNoOfCalves = xcv.cvgNoOfCalves,

                                  cvSeqNo = xca.cvSeqNo,
                                  cvCalveSex = xca.cvCalveSex,
                                  cvDate = xca.cvDate,
                                  cvCalveName = xca.cvCalveName,
                                  cvWeight = xca.cvWeight,*/

                                  gTranId = x.gTranId,
                                  gCowStatus = x.gCowStatus,
                                  gMeasureDate = x.gMeasureDate,
                                  gMeasureType = x.gMeasureType,
                                  gHeartGirth = x.gHeartGirth,
                                  gWeight = x.gWeight,
                                  gBodyConditionScore = x.gBodyConditionScore,
                                  gEvaluator = x.gEvaluator,
                                  gRemark = x.gRemark,
                                  gBodylength = x.gBodylength,
                                  gHeight = x.gHeight,
                                  gTranType = x.gTranType,
                                  date_updated = x.date_updated,
                                  user_updated = x.user_updated
                              }
                         ;
            Console.WriteLine(queryString.ToQueryString());
            return await queryString.ToListAsync();
        }

        public async Task<IEnumerable<CowFarmsGrowth>> GetAllCowFarmsGrowth_type_aiZone(string type, string aiZone, int year, int month)
        {
            var queryString = from cow in _context.Cow
                              join farm in _context.Farm on cow.cFarmId equals farm.fFarmId
                              join province in _context.RefProvince on farm.fProvinceCode equals province.refProvinceId
                              join amphur in _context.RefAmphur on farm.fAmphurCode equals amphur.refAmphurId
                              join g in
                                  (from growth in _context.Growth
                                   where growth.gCowStatus == type
                                   select growth) on cow.ccowNo equals g.gCowNo into temp
                              from x in temp.DefaultIfEmpty()
                              where
                                  cow.cBirthDate.Year == year && cow.cBirthDate.Month == month
                                  && farm.fStatus == "04" && cow.cActiveFlag == 1 && cow.cSex == "F" && cow.cStatus != "BU"
                                  && farm.aiZone == aiZone
                              orderby cow.cBirthDate descending
                              select new CowFarmsGrowth
                              {
                                  ccowNo = cow.ccowNo,
                                  ccowId = cow.ccowId,
                                  ccowName = cow.ccowName,
                                  cSex = cow.cSex,
                                  cSireId = cow.cSireId,
                                  cDamId = cow.cDamId,
                                  cBirthDate = cow.cBirthDate,
                                  cStatus = cow.cStatus,
                                  cProductionStatus = cow.cProductionStatus,
                                  cMilkingStatus = cow.cMilkingStatus,
                                  fFarmId = farm.fFarmId,
                                  fName = farm.fName,
                                  fAmphurCode = farm.fAmphurCode,
                                  fProvinceCode = farm.fProvinceCode,
                                  fAmphurName = amphur.refAmphurName,
                                  fProvinceName = province.refProvinceName,
                                  aiZone = farm.aiZone,

                                  gTranId = x.gTranId,
                                  gCowStatus = x.gCowStatus,
                                  gMeasureDate = x.gMeasureDate,
                                  gMeasureType = x.gMeasureType,
                                  gHeartGirth = x.gHeartGirth,
                                  gWeight = x.gWeight,
                                  gBodyConditionScore = x.gBodyConditionScore,
                                  gEvaluator = x.gEvaluator,
                                  gRemark = x.gRemark,
                                  gBodylength = x.gBodylength,
                                  gHeight = x.gHeight,
                                  gTranType = x.gTranType,
                                  date_updated = x.date_updated,
                                  user_updated = x.user_updated
                              }
                         ;
            Console.WriteLine(queryString.ToQueryString());
            return await queryString.ToListAsync();
        }

        public async Task<IEnumerable<Growth>> GetAllGrowth()
        {
            var growth = (from m in _context.Growth
                          orderby m.date_updated descending
                          select m).Take(50).ToListAsync();
            return await growth;
        }

        public async Task<Growth> GetGrowthBygTranId(int gTranId)
        {
            var growth = _context.Growth.FindAsync(gTranId);
            return await growth;
        }

        public async Task Update(Growth growth)
        {
            _context.Entry(growth).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        /*public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }*/
    }
}