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
                List<GuardLogs> guardLogsList = entity.GuardLogs.ToList<GuardLogs>();
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
                guardEntry.LoginTime = guard.LoginTime;
                guardEntry.LogoutTime = guard.LogoutTime;
                guardEntry.GuardName = guardData.GuardName;
                guardEntry.EmailId = guardData.EmailId;
                guardEntry.GuardStatus = guardData.GuardStatus;
                guardEntry.Gender = guardData.Gender;
                guardEntry.PrimaryContactNumber = guardData.PrimaryContactNumber;
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
                List<Guard> guardLogsList = entity.Guard.Where(entry => entry.GuardName == searchInput).ToList<Guard>();
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
                List<GuardLogs> guardData = entity.GuardLogs.Where(entry => entry.GuardId == guard.GuardId).ToList<GuardLogs>();
                foreach (var result in guardData)
                {
                    GuardData guardEntry = new GuardData();
                    guardEntry.GuardId = guard.GuardId;
                    guardEntry.GuardName = guard.GuardName;
                    guardEntry.EmailId = guard.EmailId;
                    guardEntry.GuardStatus = guard.GuardStatus;
                    guardEntry.Gender = guard.Gender;
                    guardEntry.PrimaryContactNumber = guard.PrimaryContactNumber;
                    guardEntry.MedicalSpecification = guard.MedicalSpecification;
                    guardEntry.SerialNumber = result.SerialNumber;
                    guardEntry.LoginTime = result.LoginTime;
                    guardEntry.LogoutTime = result.LogoutTime;
                    guardEntry.LoginDate = result.LoginDate;
                    guardEntry.LogoutDate = result.LogoutDate;
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
        public List<Guard> GetUniqueGuards()
        {
            try
            {
                ClearList();
                var entity = new VisitorsDatabaseContext();
                List<Guard> GuardsList = entity.Guard.ToList<Guard>();
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
        public List<Guard> GetUniqueGuardsByName(string searchInput)
        {
            try
            {
                ClearList();
                var entity = new VisitorsDatabaseContext();
                List<Guard> GuardsList = entity.Guard.Where(entry => entry.GuardName == searchInput).ToList<Guard>();
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
        public bool DeleteGuard(string GuardId)
        {
            try
            {
                var entity = new VisitorsDatabaseContext();
                var GuardDetails = entity.Guard.Find(GuardId);
                GuardDetails.GuardStatus = "INACTIVE";
                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool AddGuard(Guard NewGuard)
        {
            try
            {
                var entity = new VisitorsDatabaseContext();
                if (NewGuard.SecondaryContactNumber == null)
                    NewGuard.SecondaryContactNumber = "";
                if (NewGuard.MedicalSpecification == null)
                    NewGuard.MedicalSpecification = "";
                if (NewGuard.Remark == null)
                    NewGuard.Remark = "";
                Guard NewGuardEntry = new Guard();
                NewGuardEntry.GuardId = NewGuard.GuardId;
                NewGuardEntry.GuardName = NewGuard.GuardName;
                NewGuardEntry.EmailId = NewGuard.EmailId;
                NewGuardEntry.GuardStatus = NewGuard.GuardStatus;
                NewGuardEntry.Gender = NewGuard.Gender;
                NewGuardEntry.DateOfBirth = NewGuard.DateOfBirth;
                NewGuardEntry.LocalAddress = NewGuard.LocalAddress;
                NewGuardEntry.PermanentAddress = NewGuard.PermanentAddress;
                NewGuardEntry.EmergencyContactNumber = NewGuard.EmergencyContactNumber;
                NewGuardEntry.EmergencyContactPerson = NewGuard.EmergencyContactPerson;
                NewGuardEntry.PrimaryContactNumber = NewGuard.PrimaryContactNumber;
                NewGuardEntry.SecondaryContactNumber = NewGuard.SecondaryContactNumber;
                NewGuardEntry.DateOfJoining = NewGuard.DateOfJoining;
                NewGuardEntry.DateOfResignation = NewGuard.DateOfResignation;
                NewGuardEntry.Remark = NewGuard.Remark;
                NewGuardEntry.BloodGroup = NewGuard.BloodGroup;
                NewGuardEntry.MedicalSpecification = NewGuard.MedicalSpecification;
                entity.Guard.Add(NewGuardEntry);
                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not Add Guard. Please try again" + ex.StackTrace);
            }
        }
        public bool EditExistingGuard(Guard details)
        {
            try
            {
                var entity = new VisitorsDatabaseContext();
                var GuardDetails = entity.Guard.Find(details.GuardId);
                GuardDetails.DateOfJoining = details.DateOfJoining;
                GuardDetails.DateOfResignation = details.DateOfResignation;
                GuardDetails.EmailId = details.EmailId;
                GuardDetails.EmergencyContactNumber = details.EmergencyContactNumber;
                GuardDetails.EmergencyContactPerson = details.EmergencyContactPerson;
                GuardDetails.Gender = details.Gender;
                GuardDetails.GuardName = details.GuardName;
                GuardDetails.GuardStatus = details.GuardStatus;
                GuardDetails.LocalAddress = details.LocalAddress;
                GuardDetails.MedicalSpecification = details.MedicalSpecification;
                GuardDetails.PrimaryContactNumber = details.PrimaryContactNumber;
                GuardDetails.Remark = details.Remark;
                GuardDetails.SecondaryContactNumber = details.SecondaryContactNumber;
                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Guard GetGuardDetailsById(string GuardId)
        {
            var entity = new VisitorsDatabaseContext();
            Guard GuardDetails = entity.Guard.Find(GuardId);
            return GuardDetails;
        }
        public string AddGuardLogAtLogin(string GuardId)
        {
            try
            {
                var entity = new VisitorsDatabaseContext();
                GuardLogs NewLog = new GuardLogs();
                NewLog.GuardId = GuardId;
                NewLog.LoginDate = DateTime.Today;
                NewLog.LoginTime = DateTime.Now.TimeOfDay;
                entity.GuardLogs.Add(NewLog);
                entity.SaveChanges();
                return "Logged Successfully";
            }
            catch(Exception ex)
            {
                return "Unable to Log Guard Activity";
            }
        }
        public string EditGuardLogAtLogOut(string GuardId)
        {
            try
            {
                var entity = new VisitorsDatabaseContext();
                string time = "00:00:00.0000000";
                GuardLogs ExistingLog = entity.GuardLogs.Where(entry => entry.LogoutTime == Convert.ToDateTime(time).TimeOfDay && entry.GuardId==GuardId).FirstOrDefault();
                ExistingLog.LogoutTime = DateTime.Now.TimeOfDay;
                ExistingLog.LogoutDate = DateTime.Today;
                entity.SaveChanges();
                return "Logged Successfully";
            }
            catch(Exception ex)
            {
                return "Unable to Log Guard Activity";
            }
        }
        public void ClearList()
        {
            allLogs.Clear();
            AllGuards.Clear();
        }
    }
}

