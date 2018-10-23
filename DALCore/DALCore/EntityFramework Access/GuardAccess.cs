using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DALCore.EntityFramework_Access
{
    //public class GuardAccess
    //{
    //    static List<GuardData> AllLogs = new List<GuardData>();
    //    public bool UserValidation(string GuardId, string Password)
    //    {
    //        var entity = new VisitorsDatabaseContext();
    //        List<GuardLogs> guardsLogsList = entity.GuardLogs.FromSql("select * from VisitorsLogs").ToList<GuardLogs>();
    //        foreach (var entry in guardsLogsList)
    //        {
    //            GetGuardData(entry);
    //        }
    //        return false;
    //    }
    //    public static void GetGuardData(GuardLogs guard)
    //    {
    //        var entity = new VisitorsDatabaseContext();
    //        Guard guardData = entity.Guard.Find(guard.GuardId);
    //        GuardData entry = new GuardData();     

    //        entry.GuardId = guard.GuardId;
    //        entry.SerialNumber = guard.SerialNumber;
    //        entry.GuardPassword = guard.GuardPassword;
    //        entry.LoginTime = guard.LoginTime;
    //        entry.LogoutTime = guard.LogoutTime;
    //        entry.GuardName = guardData.GuardName;
    //        entry.EmailId = guardData.EmailId;
    //        entry.GuardStatus = guardData.GuardStatus;
    //        entry.Gender = guardData.Gender;
    //        entry.DateOfBirth = guardData.DateOfBirth;
    //        entry.LocalAddress = guardData.LocalAddress;
    //        entry.PermanentAddress = guardData.PermanentAddress;
    //        entry.EmergencyContactPerson = guardData.EmergencyContactPerson;
    //        entry.EmergencyContactNumber = guardData.EmergencyContactNumber;
    //        entry.PrimaryContactNumber = guardData.PrimaryContactNumber;
    //        entry.SecondaryContactNumber = guardData.SecondaryContactNumber;
    //        entry.DateOfJoining = guardData.DateOfJoining; 
    //        entry.DateOfResignation = guardData.DateOfResignation; 
    //        entry.Remark = guardData.Remark;
    //        entry.BloodGroup = guardData.BloodGroup;
    //        entry.MedicalSpecification = guardData.MedicalSpecification;  
    //        AllLogs.Add(entry);
    //    } 
    //}
}
