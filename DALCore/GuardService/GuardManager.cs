using Core.Contracts;
using DALCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace GuardService
{
    public class GuardManager : IGuard
    {
        static List<GuardData> allLogs = new List<GuardData>();
        static List<Guard> AllGuards = new List<Guard>();
        public List<GuardData> GetAllGuardsFromLog()
        {
            try
            {
                ClearList();
                var entity = new VisitorsDatabaseContext();
                List<GuardLogs> guardLogsList = entity.GuardLogs.FromSql("select * from GuardLogs").ToList<GuardLogs>();
                foreach (var entry in guardLogsList)
                {
                    GetGuardData(entry);
                }
                return allLogs;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not get Guard Logs! Please Contact Admin" + ex.StackTrace);
            }
        }
        public static void GetGuardData(GuardLogs guard)
        {
            try
            {
                var entity = new VisitorsDatabaseContext();
                Guard guardData = entity.Guard.Find(guard.GuardId);
                GuardData guardEntry = new GuardData(); 
                guardEntry.GuardId = guard.GuardId;
                guardEntry.SerialNumber = guard.SerialNumber;
                guardEntry.GuardPassword = guard.GuardPassword;
                guardEntry.LoginTime = guard.LoginTime;
                guardEntry.LogoutTime = guard.LogoutTime;
                guardEntry.GuardName = guardData.GuardName;
                guardEntry.EmailId = guardData.EmailId;
                guardEntry.GuardStatus = guardData.GuardStatus;
                guardEntry.Gender = guardData.Gender;
                guardEntry.DateOfBirth = guardData.DateOfBirth;
                guardEntry.LocalAddress = guardData.LocalAddress;
                guardEntry.PermanentAddress = guardData.PermanentAddress;
                guardEntry.EmergencyContactPerson = guardData.EmergencyContactPerson;
                guardEntry.EmergencyContactNumber = guardData.EmergencyContactNumber;
                guardEntry.PrimaryContactNumber = guardData.PrimaryContactNumber;
                guardEntry.SecondaryContactNumber = guardData.SecondaryContactNumber;
                guardEntry.DateOfJoining = guardData.DateOfJoining;
                guardEntry.DateOfResignation = guardData.DateOfResignation;
                guardEntry.Remark = guardData.Remark;
                guardEntry.BloodGroup = guardData.BloodGroup;
                guardEntry.MedicalSpecification = guardData.MedicalSpecification;
                guardEntry.LoginDate = guard.LoginDate;
                guardEntry.LogoutDate = guard.LogoutDate;
                allLogs.Add(guardEntry);
            }
            catch (Exception ex)
            {
                throw new Exception("Internal Error: GetGuardData" + ex.StackTrace);
            }
        }
        public List<GuardData> GetGuardsLogByName(string searchInput)
        {
            try
            {
                ClearList();
                var entity = new VisitorsDatabaseContext();
                List<Guard> guardLogsList = entity.Guard.FromSql("select * from Guard where GuardName  = @searchInput", new SqlParameter("@searchInput", searchInput)).ToList<Guard>();
                foreach (var entry in guardLogsList)
                {
                    GetGuardDataByName(entry);
                }
                return allLogs;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not get Guard Logs! Please Contact Admin" + ex.StackTrace);
            }
        }
        public void GetGuardDataByName(Guard guard)
        {
            try
            {
                var entity = new VisitorsDatabaseContext();
                List<GuardLogs> guardData = entity.GuardLogs.FromSql("select * from GuardLogs where GuardId = @searchInput", new SqlParameter("@searchInput", guard.GuardId)).ToList<GuardLogs>();
                foreach (var result in guardData)
                {
                    GuardData guardEntry = new GuardData();
                    guardEntry.GuardId = guard.GuardId;
                    guardEntry.GuardName = guard.GuardName;
                    guardEntry.EmailId = guard.EmailId;
                    guardEntry.GuardStatus = guard.GuardStatus;
                    guardEntry.Gender = guard.Gender;
                    guardEntry.DateOfBirth = guard.DateOfBirth;
                    guardEntry.LocalAddress = guard.LocalAddress;
                    guardEntry.PermanentAddress = guard.PermanentAddress;
                    guardEntry.EmergencyContactNumber = guard.EmergencyContactNumber;
                    guardEntry.EmergencyContactPerson = guard.EmergencyContactPerson;
                    guardEntry.PrimaryContactNumber = guard.PrimaryContactNumber;
                    guardEntry.DateOfJoining = guard.DateOfJoining;
                    guardEntry.Remark = guard.Remark;
                    guardEntry.BloodGroup = guard.BloodGroup;
                    guardEntry.MedicalSpecification = guard.MedicalSpecification;
                    guardEntry.SerialNumber = result.SerialNumber;
                    guardEntry.LoginTime = result.LoginTime;
                    guardEntry.LogoutTime = result.LogoutTime;
                    guardEntry.LoginDate = result.LoginDate;
                    guardEntry.LogoutDate = result.LogoutDate;

                    if (guard.GuardStatus.Equals("Active"))
                    {
                        guardEntry.DateOfResignation = guard.DateOfResignation;
                    }
                    allLogs.Add(guardEntry);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Internal Error: GetGuardDataByName" + ex.StackTrace);
            }
        }
        public List<GuardData> GetGuardLogByDateAndTime(string fromDate, string toDate, string fromTime, string toTime)
        {
            try
            {
                ClearList();
                if (fromTime == "" && toTime == "")
                {
                    fromTime = "00:00:00";
                    toTime = "23:59:59";
                }
                var entity = new VisitorsDatabaseContext();  
                List<GuardLogs> visitorLogsList = 
                    entity.GuardLogs.FromSql("select * from GuardLogs where LoginDate between @fromDate And @toDate and LogoutDate between @fromDate And @toDate and LoginTime >= @fromTime and LogoutTime <= @toTime", new SqlParameter("@fromDate", fromDate), new SqlParameter("@toDate", toDate), new SqlParameter("@fromTime", fromTime), new SqlParameter("@toTime", toTime)).ToList<GuardLogs>();

                foreach (var entry in visitorLogsList)
                {
                    GetGuardData(entry);
                }

                return allLogs;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not get Guards From Log. Please try again" + ex.StackTrace);
            }
        }
        public List<Guard> GetUniqueVisitors()
        {
            try
            {
                ClearList();
                var entity = new VisitorsDatabaseContext();
                List<Guard> GuardsList = entity.Guard.FromSql("select * from Guard").ToList<Guard>();
                foreach (var entry in GuardsList)
                {
                    Guard uniqueGuard = new Guard();
                    uniqueGuard.GuardId = entry.GuardId;
                    uniqueGuard.GuardName = entry.GuardName;
                    uniqueGuard.EmailId = entry.EmailId;
                    uniqueGuard.GuardStatus = entry.GuardStatus;
                    uniqueGuard.Gender = entry.Gender;
                    uniqueGuard.DateOfBirth = entry.DateOfBirth;
                    uniqueGuard.LocalAddress = entry.LocalAddress;
                    uniqueGuard.EmergencyContactPerson = entry.EmergencyContactPerson;
                    uniqueGuard.PermanentAddress = entry.PermanentAddress;
                    uniqueGuard.EmergencyContactNumber = entry.EmergencyContactNumber;
                    uniqueGuard.PrimaryContactNumber = entry.PrimaryContactNumber;
                    uniqueGuard.DateOfJoining = entry.DateOfJoining;
                    uniqueGuard.DateOfResignation = entry.DateOfResignation;
                    uniqueGuard.Remark = entry.Remark;
                    uniqueGuard.BloodGroup = entry.BloodGroup;
                    uniqueGuard.MedicalSpecification = entry.MedicalSpecification;
                    AllGuards.Add(uniqueGuard);
                }
                return AllGuards;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not get Visitors. Please try again" + ex.StackTrace);
            }
        }
        public List<Guard> GetUniqueVisitorsByName(string searchInput)
        {
            try
            {
                ClearList();
                var entity = new VisitorsDatabaseContext();
                List<Guard> GuardsList = entity.Guard.FromSql("select * from Guard where GuardName = @searchInput", new SqlParameter("@searchInput", searchInput)).ToList<Guard>();
                foreach (var entry in GuardsList)
                {
                    Guard uniqueGuard = new Guard();
                    uniqueGuard.GuardId = entry.GuardId;
                    uniqueGuard.GuardName = entry.GuardName;
                    uniqueGuard.EmailId = entry.EmailId;
                    uniqueGuard.GuardStatus = entry.GuardStatus;
                    uniqueGuard.Gender = entry.Gender;
                    uniqueGuard.DateOfBirth = entry.DateOfBirth;
                    uniqueGuard.LocalAddress = entry.LocalAddress;
                    uniqueGuard.EmergencyContactPerson = entry.EmergencyContactPerson;
                    uniqueGuard.PermanentAddress = entry.PermanentAddress;
                    uniqueGuard.EmergencyContactNumber = entry.EmergencyContactNumber;
                    uniqueGuard.PrimaryContactNumber = entry.PrimaryContactNumber;
                    uniqueGuard.DateOfJoining = entry.DateOfJoining;
                    uniqueGuard.DateOfResignation = entry.DateOfResignation;
                    uniqueGuard.Remark = entry.Remark;
                    uniqueGuard.BloodGroup = entry.BloodGroup;
                    uniqueGuard.MedicalSpecification = entry.MedicalSpecification;
                    AllGuards.Add(uniqueGuard);
                }
                return AllGuards;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not get Visitors. Please try again" + ex.StackTrace);
            }
        }
        public void DeleteGuard(string GuardId)
        {
            try
            {
                var entity = new VisitorsDatabaseContext();
                entity.Database.ExecuteSqlCommand("DELETE FROM Guard WHERE GuardId=@GuardId", new SqlParameter("@GuardId", GuardId));
            }
            catch (Exception ex)
            {
                throw new Exception("Could not delete Guard. Please try again" + ex.StackTrace);
            }
        }
        public void AddGuard(Guard NewGuard)
        {
            try
            {
                var entity = new VisitorsDatabaseContext();
                entity.Database.ExecuteSqlCommand("insert into Guard(GuardId, GuardName, EmailId, GuardStatus, Gender, DateOfBirth, LocalAddress, PermanentAddress, EmergencyContactPerson, EmergencyContactNumber, PrimaryContactNumber, SecondaryContactNumber, DateOfJoining, DateOfResignation, Remark, BloodGroup, MedicalSpecification)values(@GuardId,@GuardName,@EmailId,@Location,@GuardStatus,@Gender,@DateOfBirth,@LocalAddress,@PermanentAddress,@EmergencyContactPerson,@EmergencyContactNumber,@PrimaryContactNumber,@SecondaryContactNumber,@DateOfJoining,@DateOfResignation,@Remark,@BloodGroup,@MedicalSpecification)", new SqlParameter("@GuardId", NewGuard.GuardId), new SqlParameter("@GuardName", NewGuard.GuardName), new SqlParameter("@EmailId", NewGuard.EmailId), new SqlParameter("@GuardStatus", NewGuard.GuardStatus), new SqlParameter("@Gender", NewGuard.Gender), new SqlParameter("@DateOfBirth", NewGuard.DateOfBirth), new SqlParameter("@LocalAddress", NewGuard.LocalAddress), new SqlParameter("@PermanentAddress", NewGuard.PermanentAddress), new SqlParameter("@EmergencyContactPerson", NewGuard.EmergencyContactPerson), new SqlParameter("@EmergencyContactNumber", NewGuard.EmergencyContactNumber), new SqlParameter("@PrimaryContactNumber", NewGuard.PrimaryContactNumber), new SqlParameter("@SecondaryContactNumber", NewGuard.SecondaryContactNumber), new SqlParameter("@DateOfJoining", NewGuard.DateOfJoining), new SqlParameter("@DateOfResignation", NewGuard.DateOfResignation), new SqlParameter("@Remark", NewGuard.Remark), new SqlParameter("@BloodGroup", NewGuard.BloodGroup), new SqlParameter("@MedicalSpecification", NewGuard.MedicalSpecification));
                //entity.Guard.FromSql("insert into Guard(GuardId, GuardName, EmailId, GuardStatus, Gender, DateOfBirth, LocalAddress, PermanentAddress, EmergencyContactPerson, EmergencyContactNumber, PrimaryContactNumber, SecondaryContactNumber, DateOfJoining, DateOfResignation, Remark, BloodGroup, MedicalSpecification)values(NewGuard.GuardId, NewGuard.GuardName, NewGuard.EmailId, NewGuard.GuardStatus, NewGuard.Gender, NewGuard.DateOfBirth, NewGuard.LocalAddress, NewGuard.PermanentAddress, NewGuard.EmergencyContactPerson, NewGuard.EmergencyContactNumber, NewGuard.PrimaryContactNumber, NewGuard.SecondaryContactNumber, NewGuard.DateOfJoining, NewGuard.DateOfResignation, NewGuard.Remark, NewGuard.BloodGroup, NewGuard.MedicalSpecification");
            }
            catch (Exception ex)
            {
                throw new Exception("Could not Add Guard. Please try again" + ex.StackTrace);
            }
        }
        public void ClearList()
        {
            allLogs.Clear();
            AllGuards.Clear();
        }
    }
}

