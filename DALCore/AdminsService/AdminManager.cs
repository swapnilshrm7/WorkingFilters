using Core.Contracts;
using Core.Contracts.Models;
using DALCore.Models;
using EmployeeService;
using GuardService;
using System;
using System.Collections.Generic;
using VisitorService;
using System.Linq;
using UI.Entities;

namespace AdminsService
{
    public class AdminManager : IAdmin
    {
        public List<AllLogs> GetAllLogs()
        {
            try
            {
                List<AllLogs> AllLogs = new List<AllLogs>();
                List<AllLogs> LogByCategory = new List<AllLogs>();
                var entity = new DatabaseContext();
                GuardManager Guard = new GuardManager();
                EmployeeManager Employee = new EmployeeManager();
                VisitorManager Visitor = new VisitorManager();
                List<GuardData> GuardData = Guard.GetAllGuardsFromLog();
                List<VisitorsData> VisitorData = Visitor.GetAllVisitorsFromLog();
                List<EmployeeData> EmployeeData = Employee.GetAllEmployeesLogs();
                LogByCategory = GuardLogsToAllLogs(GuardData);
                AllLogs.AddRange(LogByCategory);
                LogByCategory.Clear();
                LogByCategory = VisitorsLogsToAllLogs(VisitorData);
                AllLogs.AddRange(LogByCategory);
                LogByCategory.Clear();
                LogByCategory = EmployeeLogsToAllLogs(EmployeeData);
                AllLogs.AddRange(LogByCategory);
                AllLogs.OrderByDescending(entry => entry.InTime);
                return AllLogs;
            }
            catch(Exception ex)
            {
                throw new Exception("Could not get all Logs! Please Contact Admin" + ex.StackTrace);
            }
        }
        public List<AllLogs> GuardLogsToAllLogs(List<GuardData> GuardData)
        {
            try
            {
                List<AllLogs> GuardLog = new List<AllLogs>();
                foreach (var entry in GuardData)
                {
                    AllLogs GuardLogs = new AllLogs();
                    GuardLogs.Category = "Guard";
                    GuardLogs.ContactNo = entry.PrimaryContactNumber;
                    GuardLogs.InDate = entry.LoginDate;
                    GuardLogs.InTime = entry.LoginTime;
                    GuardLogs.OutDate = entry.LogoutDate;
                    GuardLogs.OutTime = entry.LogoutTime;
                    GuardLogs.Name = entry.GuardName;
                    GuardLogs.IndateInTime =  entry.LoginDate + entry.LoginTime;
                    GuardLog.Add(GuardLogs);
                }
                return GuardLog.OrderBy(entry=>entry.InDate).ToList<AllLogs>();
            }
            catch(Exception ex)
            {
                throw new Exception("Could not get Guard Logs! Please Contact Admin" + ex.StackTrace);
            }
        }
        public List<AllLogs> VisitorsLogsToAllLogs(List<VisitorsData> VisitorData)
        {
            try
            {
                List<AllLogs> VisitorsLog = new List<AllLogs>();
                foreach (var entry in VisitorData)
                {
                    AllLogs VisitorsLogEntry = new AllLogs();
                    VisitorsLogEntry.Category = "Visitor";
                    VisitorsLogEntry.ContactNo = entry.Contact;
                    VisitorsLogEntry.InDate = Convert.ToDateTime(entry.DateOfVisit);
                    VisitorsLogEntry.InTime = Convert.ToDateTime(entry.TimeIn).TimeOfDay;
                    VisitorsLogEntry.OutDate = Convert.ToDateTime(entry.DateOfVisit);
                    VisitorsLogEntry.OutTime = Convert.ToDateTime(entry.TimeOut).TimeOfDay;
                    VisitorsLogEntry.Name = entry.NameOfVisitor;
                    VisitorsLogEntry.IndateInTime = Convert.ToDateTime(entry.DateOfVisit).Date + Convert.ToDateTime(entry.TimeIn).TimeOfDay;
                    VisitorsLog.Add(VisitorsLogEntry);
                }
                return VisitorsLog.OrderBy(entry => entry.InDate).ToList<AllLogs>();
            }
            catch (Exception ex)
            {
                throw new Exception("Could not get Visitors Logs! Please Contact Admin" + ex.StackTrace);
            }
        }
        public List<AllLogs> EmployeeLogsToAllLogs(List<EmployeeData> EmployeeData)
        {
            try
            {
                List<AllLogs> EmployeeLogs = new List<AllLogs>();
                int i = -1;
                foreach (var entry in EmployeeData)
                {
                    AllLogs EmployeeLogEntry = new AllLogs();
                    EmployeeLogEntry.Category = "Employee";
                    var entity = new DatabaseContext();
                    EmployeeManager Employee = new EmployeeManager();
                    Employees row = entity.Employees.Where(data => data.EmployeeId == entry.EmployeeId).FirstOrDefault();
                    EmployeeLogEntry.ContactNo = row.EmergencyContactNumber;
                    EmployeeLogEntry.InDate = entry.DateOfVisit;
                    EmployeeLogEntry.InTime = entry.TimeOfEntry;
                    EmployeeLogEntry.OutDate = entry.DateOfExit;
                    EmployeeLogEntry.OutTime = entry.TimeOfExit;
                    EmployeeLogEntry.Name = entry.EmployeeName;
                    EmployeeLogEntry.IndateInTime = entry.DateOfVisit + entry.TimeOfEntry;
                    EmployeeLogs.Add(EmployeeLogEntry);
                }
                return EmployeeLogs.OrderBy(entry => entry.InDate).ToList<AllLogs>();
            }
            catch(Exception ex)
            {
                throw new Exception("Could not get Visitors Logs! Please Contact Admin" + ex.StackTrace);
            }
        }
    }
}
