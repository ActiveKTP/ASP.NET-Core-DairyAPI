using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DairyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DairyAPI.Data
{
    public class CowRepo : ICowRepo
    {
        private readonly DairyContext _context;
        public int add;

        public CowRepo(DairyContext context)
        {
            _context = context;
            add = 360;
        }

        public async Task<IEnumerable<CowFarms>> GetAllCowFarms()
        {
            var cowFarms = (from
                         cow in _context.Cow
                            join farm in _context.Farm on cow.cFarmId equals farm.fFarmId
                            join province in _context.RefProvince on farm.fProvinceCode equals province.refProvinceId
                            join amphur in _context.RefAmphur on farm.fAmphurCode equals amphur.refAmphurId
                            where (
                                farm.fStatus == "01" && cow.cActiveFlag == 1 && cow.cSex == "F" && cow.cStatus != "BU"
                                )
                            orderby cow.cBirthDate
                            //select farm
                            select new CowFarms
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
                                cLactation = cow.cLactation,
                                cNumOfService = cow.cNumOfService,
                                fFarmId = farm.fFarmId,
                                fName = farm.fName,
                                fAmphurCode = farm.fAmphurCode,
                                fProvinceCode = farm.fProvinceCode,
                                fAmphurName = amphur.refAmphurName,
                                fProvinceName = province.refProvinceName,
                                aiZone = farm.aiZone
                            }
                         ).Take(100).ToListAsync();
            return await cowFarms;
        }

        public async Task<IEnumerable<CowFarms>> GetAllCowFarms_Age12m()
        {
            //int add = 730;
            DateTime now = DateTime.Now;
            DateTime endDate = now.AddDays(-(330 + add));
            DateTime startDate = now.AddDays(-(360 + add));
            var cowFarms = (from
                         cow in _context.Cow
                            join farm in _context.Farm on cow.cFarmId equals farm.fFarmId
                            join province in _context.RefProvince on farm.fProvinceCode equals province.refProvinceId
                            join amphur in _context.RefAmphur on farm.fAmphurCode equals amphur.refAmphurId
                            where (
                                //(DateTime.Now.Subtract(cow.cBirthDate).Days == 11)  &&
                                //((DateTime.Today - cow.cBirthDate).Days >= 330 && (DateTime.Today - cow.cBirthDate).Days <= 360)
                                // && 
                                (cow.cBirthDate >= startDate && cow.cBirthDate <= endDate)
                                && farm.fStatus == "01" && cow.cActiveFlag == 1 && cow.cSex == "F" && cow.cStatus != "BU"
                                )
                            orderby cow.cBirthDate
                            //select farm
                            select new CowFarms
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
                                cLactation = cow.cLactation,
                                cNumOfService = cow.cNumOfService,
                                fFarmId = farm.fFarmId,
                                fName = farm.fName,
                                fAmphurCode = farm.fAmphurCode,
                                fProvinceCode = farm.fProvinceCode,
                                fAmphurName = amphur.refAmphurName,
                                fProvinceName = province.refProvinceName,
                                aiZone = farm.aiZone
                            }
                         ).ToListAsync();
            return await cowFarms;
        }

        public async Task<IEnumerable<CowFarms>> GetAllCowFarms_Age12mByaiZone(string aiZone)
        {
            DateTime now = DateTime.Now;
            DateTime endDate = now.AddDays(-(330 + add));
            DateTime startDate = now.AddDays(-(360 + add));
            var cowFarms = (from
                         cow in _context.Cow
                            join farm in _context.Farm on cow.cFarmId equals farm.fFarmId
                            join province in _context.RefProvince on farm.fProvinceCode equals province.refProvinceId
                            join amphur in _context.RefAmphur on farm.fAmphurCode equals amphur.refAmphurId
                            where (
                                //(DateTime.Now.Subtract(cow.cBirthDate).Days == 11)  &&
                                //((DateTime.Today - cow.cBirthDate).Days >= 330 && (DateTime.Today - cow.cBirthDate).Days <= 360)
                                // && 
                                (cow.cBirthDate >= startDate && cow.cBirthDate <= endDate)
                                && farm.fStatus == "01" && cow.cActiveFlag == 1 && cow.cSex == "F" && cow.cStatus != "BU"
                                && farm.aiZone == aiZone
                                )
                            orderby cow.cBirthDate
                            //select farm
                            select new CowFarms
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
                                cLactation = cow.cLactation,
                                cNumOfService = cow.cNumOfService,
                                fFarmId = farm.fFarmId,
                                fName = farm.fName,
                                fAmphurCode = farm.fAmphurCode,
                                fProvinceCode = farm.fProvinceCode,
                                fAmphurName = amphur.refAmphurName,
                                fProvinceName = province.refProvinceName,
                                aiZone = farm.aiZone
                            }
                         ).ToListAsync();
            return await cowFarms;
        }

        //public async Task<IEnumerable<CowFarms>> GetAllCowFarms_Age18m()
        public async Task<IEnumerable<CowFarms>> GetAllCowFarms_Age18m()
        {
            //int add = 730;
            DateTime now = DateTime.Now;
            DateTime endDate = now.AddDays(-(510 + add));
            DateTime startDate = now.AddDays(-(540 + add));
            var cowFarms = (from
                         cow in _context.Cow
                            join farm in _context.Farm on cow.cFarmId equals farm.fFarmId
                            join province in _context.RefProvince on farm.fProvinceCode equals province.refProvinceId
                            join amphur in _context.RefAmphur on farm.fAmphurCode equals amphur.refAmphurId
                            where (
                                //(DateTime.Now.Subtract(cow.cBirthDate).Days == 11)  &&
                                //((DateTime.Today - cow.cBirthDate).Days >= 330 && (DateTime.Today - cow.cBirthDate).Days <= 360)
                                // && 
                                (cow.cBirthDate >= startDate && cow.cBirthDate <= endDate)
                                && farm.fStatus == "01" && cow.cActiveFlag == 1 && cow.cSex == "F" && cow.cStatus != "BU"
                                )
                            orderby cow.cBirthDate
                            //select farm
                            select new CowFarms
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
                                cLactation = cow.cLactation,
                                cNumOfService = cow.cNumOfService,
                                fFarmId = farm.fFarmId,
                                fName = farm.fName,
                                fAmphurCode = farm.fAmphurCode,
                                fProvinceCode = farm.fProvinceCode,
                                fAmphurName = amphur.refAmphurName,
                                fProvinceName = province.refProvinceName,
                                aiZone = farm.aiZone
                            }
                         ).ToListAsync();
            return await cowFarms;
        }

        public async Task<IEnumerable<CowFarms>> GetAllCowFarms_Age18mByaiZone(string aiZone)
        {
            DateTime now = DateTime.Now;
            DateTime endDate = now.AddDays(-(510 + add));
            DateTime startDate = now.AddDays(-(540 + add));
            var cowFarms = (from
                         cow in _context.Cow
                            join farm in _context.Farm on cow.cFarmId equals farm.fFarmId
                            join province in _context.RefProvince on farm.fProvinceCode equals province.refProvinceId
                            join amphur in _context.RefAmphur on farm.fAmphurCode equals amphur.refAmphurId
                            where (
                                //(DateTime.Now.Subtract(cow.cBirthDate).Days == 11)  &&
                                //((DateTime.Today - cow.cBirthDate).Days >= 330 && (DateTime.Today - cow.cBirthDate).Days <= 360)
                                // && 
                                (cow.cBirthDate >= startDate && cow.cBirthDate <= endDate)
                                && farm.fStatus == "01" && cow.cActiveFlag == 1 && cow.cSex == "F" && cow.cStatus != "BU"
                                && farm.aiZone == aiZone
                                )
                            orderby cow.cBirthDate
                            //select farm
                            select new CowFarms
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
                                cLactation = cow.cLactation,
                                cNumOfService = cow.cNumOfService,
                                fFarmId = farm.fFarmId,
                                fName = farm.fName,
                                fAmphurCode = farm.fAmphurCode,
                                fProvinceCode = farm.fProvinceCode,
                                fAmphurName = amphur.refAmphurName,
                                fProvinceName = province.refProvinceName,
                                aiZone = farm.aiZone
                            }
                         ).ToListAsync();
            return await cowFarms;
        }

        public async Task<IEnumerable<CowFarms>> GetAllCowFarms_Age4m()
        {
            //int add = 730;
            DateTime now = DateTime.Now;
            DateTime endDate = now.AddDays(-(90 + add));
            DateTime startDate = now.AddDays(-(120 + add));
            var cowFarms = (from
                         cow in _context.Cow
                            join farm in _context.Farm on cow.cFarmId equals farm.fFarmId
                            join province in _context.RefProvince on farm.fProvinceCode equals province.refProvinceId
                            join amphur in _context.RefAmphur on farm.fAmphurCode equals amphur.refAmphurId
                            where (
                                //(DateTime.Now.Subtract(cow.cBirthDate).Days == 11)  &&
                                //((DateTime.Today - cow.cBirthDate).Days >= 330 && (DateTime.Today - cow.cBirthDate).Days <= 360)
                                // && 
                                (cow.cBirthDate >= startDate && cow.cBirthDate <= endDate)
                                && farm.fStatus == "01" && cow.cActiveFlag == 1 && cow.cSex == "F" && cow.cStatus != "BU"
                                )
                            orderby cow.cBirthDate
                            //select farm
                            select new CowFarms
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
                                cLactation = cow.cLactation,
                                cNumOfService = cow.cNumOfService,
                                fFarmId = farm.fFarmId,
                                fName = farm.fName,
                                fAmphurCode = farm.fAmphurCode,
                                fProvinceCode = farm.fProvinceCode,
                                fAmphurName = amphur.refAmphurName,
                                fProvinceName = province.refProvinceName,
                                aiZone = farm.aiZone
                            }
                         ).ToListAsync();
            return await cowFarms;
        }

        public async Task<IEnumerable<CowFarms>> GetAllCowFarms_Age4mByaiZone(string aiZone)
        {
            DateTime now = DateTime.Now;
            DateTime endDate = now.AddDays(-(90 + add));
            DateTime startDate = now.AddDays(-(120 + add));
            var cowFarms = (from
                         cow in _context.Cow
                            join farm in _context.Farm on cow.cFarmId equals farm.fFarmId
                            join province in _context.RefProvince on farm.fProvinceCode equals province.refProvinceId
                            join amphur in _context.RefAmphur on farm.fAmphurCode equals amphur.refAmphurId
                            where (
                                //(DateTime.Now.Subtract(cow.cBirthDate).Days == 11)  &&
                                //((DateTime.Today - cow.cBirthDate).Days >= 330 && (DateTime.Today - cow.cBirthDate).Days <= 360)
                                // && 
                                (cow.cBirthDate >= startDate && cow.cBirthDate <= endDate)
                                && farm.fStatus == "01" && cow.cActiveFlag == 1 && cow.cSex == "F" && cow.cStatus != "BU"
                                && farm.aiZone == aiZone
                                )
                            orderby cow.cBirthDate
                            //select farm
                            select new CowFarms
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
                                cLactation = cow.cLactation,
                                cNumOfService = cow.cNumOfService,
                                fFarmId = farm.fFarmId,
                                fName = farm.fName,
                                fAmphurCode = farm.fAmphurCode,
                                fProvinceCode = farm.fProvinceCode,
                                fAmphurName = amphur.refAmphurName,
                                fProvinceName = province.refProvinceName,
                                aiZone = farm.aiZone
                            }
                         ).ToListAsync();
            return await cowFarms;
        }

        public async Task<IEnumerable<Cow>> GetAllCows()
        {
            var cows = (from cow in _context.Cow
                        where (cow.cMilkingStatus.Contains("MK") && cow.cActiveFlag == 1)
                        orderby cow.ccowId
                        select cow).Take(50).ToListAsync();
            return await cows;
        }

        public async Task<Cow> GetCowById(string ccowId)
        {
            //var cow = _context.Cow.FirstOrDefault(i => i.ccowId == ccowId);
            var cow = _context.Cow.FindAsync(ccowId);
            return await cow;
        }
    }
}