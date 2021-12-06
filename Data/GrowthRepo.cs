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

        public async Task<IEnumerable<CowFarmsGrowthCV>> GetAllCowFarmsGrowthCV_aiZone(string aiZone, int year, int month, int _start, int _limit)
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
                              join cv in
                                  (from calving in _context.Calving
                                   select calving) on mating.maTranId equals cv.cvgMaTranId into tempcv
                              from xcv in tempcv.DefaultIfEmpty()
                                  /*
                                                                join ca in
                                                                (from calve in _context.Calve
                                                                 select calve) on xcv.cvgTranId equals ca.cvgTranId into tempca
                                                                from xca in tempca.DefaultIfEmpty()
                                  */
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
                              //orderby cow.cBirthDate descending
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
                                  maSemenId = mating.maSemenId,

                                  cvgTranId = xcv.cvgTranId,
                                  cvgDate = xcv.cvgDate,
                                  cvgNoOfCalves = xcv.cvgNoOfCalves,

                                  //cvSeqNo = xca.cvSeqNo,
                                  //cvCalveSex = xca.cvCalveSex,
                                  //cvDate = xca.cvDate,
                                  //cvCalveName = xca.cvCalveName,
                                  //cvWeight = xca.cvWeight,

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
                              };
            Console.WriteLine(queryString.ToQueryString());
            var result = _start == 0 && _limit == 0 ? queryString.OrderByDescending(x => x.cBirthDate).ThenByDescending(x => x.ccowId) : queryString.OrderByDescending(x => x.cBirthDate).ThenByDescending(x => x.ccowId).Skip(_start).Take(_limit);
            return await result.ToListAsync();
            /*
                        var caveQuery = (from calve in _context.Calve
                                             //group calve by calve.cvgTranId into g
                                         where calve.cvgTranId != null
                                         select new Calve
                                         {
                                             cvgTranId = calve.cvgTranId != null ? calve.cvgTranId : 0,
                                             cvCowNo = calve.cvCowNo != null ? calve.cvCowNo : 0,
                                             cvCalveSex = calve.cvCalveSex
                                         })
                                         .Where(item => item.cvgTranId != null)
                                         .ToList()
                        //.ToList()
                        .GroupBy(o => o.cvgTranId)
                    .Select(g => new Calve
                    {
                        cvgTranId = g.Key,
                        cvCowNo = g.First().cvCowNo,
                        cvCalveSex = (g.Select(x => x.cvCalveSex)).Aggregate((a, b) => (a + "," + b)),
                        //cvWeight = (g.Select(x => x.cvWeight)).Aggregate((a,b) => (a + ", " + b))
                    }).ToList();

                        var result = from cv in queryString
                                     join ca in caveQuery on cv.cvgTranId equals ca.cvgTranId into temps
                                     from cave in temps.DefaultIfEmpty()
                                     select new CowFarmsGrowthCV
                                     {
                                         ccowNo = cv.ccowNo,
                                         ccowId = cv.ccowId,
                                         ccowName = cv.ccowName,
                                         cSex = cv.cSex,
                                         cSireId = cv.cSireId,
                                         cDamId = cv.cDamId,
                                         cBirthDate = cv.cBirthDate,
                                         cStatus = cv.cStatus,
                                         cProductionStatus = cv.cProductionStatus,
                                         cMilkingStatus = cv.cMilkingStatus,
                                         fFarmId = cv.fFarmId,
                                         fName = cv.fName,
                                         fAmphurCode = cv.fAmphurCode,
                                         fProvinceCode = cv.fProvinceCode,
                                         fAmphurName = cv.fAmphurName,
                                         fProvinceName = cv.fProvinceName,
                                         aiZone = cv.aiZone,

                                         maTranId = cv.maTranId,
                                         maDate = cv.maDate,
                                         maPregResult = cv.maPregResult,

                                         cvgTranId = cv.cvgTranId,
                                         cvgDate = cv.cvgDate,
                                         cvgNoOfCalves = cv.cvgNoOfCalves,

                                         //cvSeqNo = xca.cvSeqNo,
                                         cvCalveSex = cave.cvCalveSex,
                                         //cvDate = xca.cvDate,
                                         //cvCalveName = xca.cvCalveName,
                                         //cvWeight = xca.cvWeight,

                                         gTranId = cv.gTranId,
                                         gCowStatus = cv.gCowStatus,
                                         gMeasureDate = cv.gMeasureDate,
                                         gMeasureType = cv.gMeasureType,
                                         gHeartGirth = cv.gHeartGirth,
                                         gWeight = cv.gWeight,
                                         gBodyConditionScore = cv.gBodyConditionScore,
                                         gEvaluator = cv.gEvaluator,
                                         gRemark = cv.gRemark,
                                         gBodylength = cv.gBodylength,
                                         gHeight = cv.gHeight,
                                         gTranType = cv.gTranType,
                                         date_updated = cv.date_updated,
                                         user_updated = cv.user_updated
                                     };


                        //Console.WriteLine(result.ToQueryString());
                        return result.ToList();
                        //////////////////////////////
                        //var filteredResults = queryString.Where(item => item != null);
                        var groupedResult = await queryString.ToListAsync();
                        var result = groupedResult.GroupBy(a => a.cvgTranId)
                            // Because the ToList(), this select projection is not done in the DB
                            .Select(eg => new CowFarmsGrowthCV
                            {
                                cvgTranId = eg.Key,
                                ccowNo = eg.First().ccowNo,
                                cvCalveSex = string.Join(",", eg.Select(i => i.cvCalveSex))
                            });
                        return result.Take(5);


                        /*var query = (from calve in _context.Calve
                                     where calve.cvgTranId != null
                                     select new Calve
                                     {
                                         cvgTranId = calve.cvgTranId != null ? calve.cvgTranId : 0,
                                         cvCalveSex = calve.cvCalveSex
                                     })
                        .Where(item => item.cvgTranId != null)
                        //.ToList()
                        .GroupBy(o => o.cvgTranId)
                    .Select(g => new
                    {
                        cvgTranId = g.Key,
                        cvCalveSex = (g.Select(x => x.cvCalveSex)).Aggregate((a, b) => (a + ", " + b)),
                        //cvWeight = (g.Select(x => x.cvWeight)).Aggregate((a,b) => (a + ", " + b))
                    });
                        //Console.WriteLine(calveData);*/
            ////////////////////////////////////*/
        }

        public async Task<IEnumerable<CowFarmsGrowth>> GetAllCowFarmsGrowth_type_aiZone(string type, string aiZone, int year, int month, int _start, int _limit)
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
                              //orderby cow.cBirthDate descending
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
            var result = _start == 0 && _limit == 0 ? queryString.OrderByDescending(x => x.cBirthDate).ThenByDescending(x => x.ccowId) : queryString.OrderByDescending(x => x.cBirthDate).ThenByDescending(x => x.ccowId).Skip(_start).Take(_limit);
            return await result.ToListAsync();
        }

        public async Task<IEnumerable<Growth>> GetAllGrowth()
        {
            var growth = (from m in _context.Growth
                          orderby m.date_updated descending
                          select m).Take(50).ToListAsync();
            return await growth;
        }

        public async Task<CowFarmsGrowth> GetGrowthByCowId_gStatus(string ccowId, string type)
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
                                  cow.cActiveFlag == 1 && cow.cSex == "F" && cow.cStatus != "BU"
                                   && cow.ccowId == ccowId
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
            return await queryString.FirstAsync();
        }

        public async Task<Growth> GetGrowthBygTranId(int gTranId)
        {
            var growth = _context.Growth.FindAsync(gTranId);
            return await growth;
        }

        public async Task<CowFarmsGrowthCV> GetGrowth_CVByCowId_gStatus(string ccowId, string type)
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
                              join cv in
                                  (from calving in _context.Calving
                                   select calving) on mating.maTranId equals cv.cvgMaTranId into tempcv
                              from xcv in tempcv.DefaultIfEmpty()
                                  /*
                                                                join ca in
                                                                (from calve in _context.Calve
                                                                 select calve) on xcv.cvgTranId equals ca.cvgTranId into tempca
                                                                from xca in tempca.DefaultIfEmpty()
                                  */
                              join g in
                                 (from growth in _context.Growth
                                  where growth.gCowStatus == "04"
                                  select growth) on cow.ccowNo equals g.gCowNo into temp
                              from x in temp.DefaultIfEmpty()
                              where
                                   cow.cActiveFlag == 1 && cow.cSex == "F" && cow.cStatus != "BU"
                                   && cow.ccowId == ccowId
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
                                  maSemenId = mating.maSemenId,

                                  cvgTranId = xcv.cvgTranId,
                                  cvgDate = xcv.cvgDate,
                                  cvgNoOfCalves = xcv.cvgNoOfCalves,

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
                              };
            Console.WriteLine(queryString.ToQueryString());
            return await queryString.FirstAsync();
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