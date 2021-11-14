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

        public async Task<IEnumerable<CowFarmsMatingPG>> GetAllCowFarmsMatingPG()
        {
            var queryString = (from
                               cow in _context.Cow
                               join farm in _context.Farm on cow.cFarmId equals farm.fFarmId
                               join province in _context.RefProvince on farm.fProvinceCode equals province.refProvinceId
                               join amphur in _context.RefAmphur on farm.fAmphurCode equals amphur.refAmphurId
                               join Mating in _context.Mating on
                               new
                               {
                                   key1 = cow.ccowNo,
                                   key2 = cow.cLactation,
                                   key3 = cow.cNumOfService
                               }
                                equals
                               new
                               {
                                   key1 = Mating.maCowNo,
                                   key2 = Mating.maLactation,
                                   key3 = Mating.maNumberOfServiceInCurrLact
                               } into temp
                               from x in temp
                               where (
                                   farm.fStatus == "01" && cow.cActiveFlag == 1
                                   && cow.cProductionStatus == "PG"
                                   )
                               orderby x.maDate descending
                               select new CowFarmsMatingPG
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

                                   maTranId = x.maTranId,
                                   bsTranId = x.bsTranId,
                                   maLactation = x.maLactation,
                                   maNumberOfServiceInCurrLact = x.maNumberOfServiceInCurrLact,
                                   maDate = x.maDate,
                                   maMatingMethod = x.maMatingMethod,
                                   maSemenId = x.maSemenId,
                                   maSemenDose = x.maSemenDose,
                                   maResult = x.maResult,
                                   maPregResult = x.maPregResult,
                                   cFarmId = x.cFarmId,
                                   maStaffId = x.maStaffId,
                                   date_updated = x.date_updated,
                                   user_updated = x.user_updated
                               }
             );
            Console.WriteLine(queryString.ToQueryString());
            return await queryString.Take(100).ToListAsync();
        }

        public async Task<IEnumerable<CowFarmsMatingPG>> GetAllCowFarmsMatingPGByaiZone(string aiZone)
        {
            var queryString = (from
                            cow in _context.Cow
                               join farm in _context.Farm on cow.cFarmId equals farm.fFarmId
                               join province in _context.RefProvince on farm.fProvinceCode equals province.refProvinceId
                               join amphur in _context.RefAmphur on farm.fAmphurCode equals amphur.refAmphurId
                               join Mating in _context.Mating on
                               new
                               {
                                   key1 = cow.ccowNo,
                                   key2 = cow.cLactation,
                                   key3 = cow.cNumOfService
                               }
                                equals
                               new
                               {
                                   key1 = Mating.maCowNo,
                                   key2 = Mating.maLactation,
                                   key3 = Mating.maNumberOfServiceInCurrLact
                               } into temp
                               from x in temp
                               where (
                                   farm.fStatus == "01" && cow.cActiveFlag == 1
                                   && cow.cProductionStatus == "PG"
                                   && farm.aiZone == aiZone
                                   )
                               orderby x.maDate descending
                               select new CowFarmsMatingPG
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

                                   maTranId = x.maTranId,
                                   bsTranId = x.bsTranId,
                                   maLactation = x.maLactation,
                                   maNumberOfServiceInCurrLact = x.maNumberOfServiceInCurrLact,
                                   maDate = x.maDate,
                                   maMatingMethod = x.maMatingMethod,
                                   maSemenId = x.maSemenId,
                                   maSemenDose = x.maSemenDose,
                                   maResult = x.maResult,
                                   maPregResult = x.maPregResult,
                                   cFarmId = x.cFarmId,
                                   maStaffId = x.maStaffId,
                                   date_updated = x.date_updated,
                                   user_updated = x.user_updated
                               }
                         );
            Console.WriteLine(queryString.ToQueryString());
            return await queryString.Take(100).ToListAsync();
        }

        public async Task<IEnumerable<CowFarms>> GetAllCowFarms_Age(int age, string aiZone, DateTime startDate, DateTime endDate)
        {
            DateTime newendDate = endDate.AddDays(-(age * 30));
            DateTime newstartDate = startDate.AddDays(-(age * 30));
            var queryString = (from
                         cow in _context.Cow
                               join farm in _context.Farm on cow.cFarmId equals farm.fFarmId
                               join province in _context.RefProvince on farm.fProvinceCode equals province.refProvinceId
                               join amphur in _context.RefAmphur on farm.fAmphurCode equals amphur.refAmphurId
                               where (
                                   (cow.cBirthDate >= newstartDate && cow.cBirthDate <= newendDate)
                                   && farm.fStatus == "01" && cow.cActiveFlag == 1 && cow.cSex == "F" && cow.cStatus != "BU"
                                   && farm.aiZone == aiZone
                                   )
                               orderby cow.cBirthDate descending
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
                         );
            //return await cowFarms;
            Console.WriteLine(queryString.ToQueryString());
            return await queryString.ToListAsync();
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
                                (cow.cBirthDate >= startDate && cow.cBirthDate <= endDate)
                                && farm.fStatus == "01" && cow.cActiveFlag == 1 && cow.cSex == "F" && cow.cStatus != "BU"
                                )
                            orderby cow.cBirthDate descending
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
                            orderby cow.cBirthDate descending
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

        public async Task<IEnumerable<CowFarms>> GetAllCowFarms_Age12mByaiZone_setDate(string aiZone, DateTime startDate, DateTime endDate)
        {
            //DateTime now = DateTime.Now;
            DateTime newendDate = endDate.AddDays(-360);
            DateTime newstartDate = startDate.AddDays(-360);
            var queryString = (from
                         cow in _context.Cow
                               join farm in _context.Farm on cow.cFarmId equals farm.fFarmId
                               join province in _context.RefProvince on farm.fProvinceCode equals province.refProvinceId
                               join amphur in _context.RefAmphur on farm.fAmphurCode equals amphur.refAmphurId
                               where (
                                   (cow.cBirthDate >= newstartDate && cow.cBirthDate <= newendDate)
                                   && farm.fStatus == "01" && cow.cActiveFlag == 1 && cow.cSex == "F" && cow.cStatus != "BU"
                                   && farm.aiZone == aiZone
                                   )
                               orderby cow.cBirthDate descending
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
                         );
            //return await cowFarms;
            Console.WriteLine(queryString.ToQueryString());
            return await queryString.ToListAsync();
        }

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
                                (cow.cBirthDate >= startDate && cow.cBirthDate <= endDate)
                                && farm.fStatus == "01" && cow.cActiveFlag == 1 && cow.cSex == "F" && cow.cStatus != "BU"
                                )
                            orderby cow.cBirthDate descending
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
                                (cow.cBirthDate >= startDate && cow.cBirthDate <= endDate)
                                && farm.fStatus == "01" && cow.cActiveFlag == 1 && cow.cSex == "F" && cow.cStatus != "BU"
                                && farm.aiZone == aiZone
                                )
                            orderby cow.cBirthDate descending
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

        public async Task<IEnumerable<CowFarms>> GetAllCowFarms_Age18mByaiZone_setDate(string aiZone, DateTime startDate, DateTime endDate)
        {
            DateTime newendDate = endDate.AddDays(-540);
            DateTime newstartDate = startDate.AddDays(-540);
            var queryString = (from
                         cow in _context.Cow
                               join farm in _context.Farm on cow.cFarmId equals farm.fFarmId
                               join province in _context.RefProvince on farm.fProvinceCode equals province.refProvinceId
                               join amphur in _context.RefAmphur on farm.fAmphurCode equals amphur.refAmphurId
                               where (
                                   (cow.cBirthDate >= newstartDate && cow.cBirthDate <= newendDate)
                                   && farm.fStatus == "01" && cow.cActiveFlag == 1 && cow.cSex == "F" && cow.cStatus != "BU"
                                   && farm.aiZone == aiZone
                                   )
                               orderby cow.cBirthDate descending
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
                         );
            //return await cowFarms;
            Console.WriteLine(queryString.ToQueryString());
            return await queryString.ToListAsync();
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
                                (cow.cBirthDate >= startDate && cow.cBirthDate <= endDate)
                                && farm.fStatus == "01" && cow.cActiveFlag == 1 && cow.cSex == "F" && cow.cStatus != "BU"
                                )
                            orderby cow.cBirthDate descending
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
                                (cow.cBirthDate >= startDate && cow.cBirthDate <= endDate)
                                && farm.fStatus == "01" && cow.cActiveFlag == 1 && cow.cSex == "F" && cow.cStatus != "BU"
                                && farm.aiZone == aiZone
                                )
                            orderby cow.cBirthDate descending
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

        public async Task<IEnumerable<CowFarms>> GetAllCowFarms_Age4mByaiZone_setDate(string aiZone, DateTime startDate, DateTime endDate)
        {
            DateTime newendDate = endDate.AddDays(-120);
            DateTime newstartDate = startDate.AddDays(-120);
            var queryString = (from
                         cow in _context.Cow
                               join farm in _context.Farm on cow.cFarmId equals farm.fFarmId
                               join province in _context.RefProvince on farm.fProvinceCode equals province.refProvinceId
                               join amphur in _context.RefAmphur on farm.fAmphurCode equals amphur.refAmphurId
                               where (
                                   (cow.cBirthDate >= newstartDate && cow.cBirthDate <= newendDate)
                                   && farm.fStatus == "01" && cow.cActiveFlag == 1 && cow.cSex == "F" && cow.cStatus != "BU"
                                   && farm.aiZone == aiZone
                                   )
                               orderby cow.cBirthDate descending
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
                         );
            //return await cowFarms;
            Console.WriteLine(queryString.ToQueryString());
            return await queryString.ToListAsync();
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