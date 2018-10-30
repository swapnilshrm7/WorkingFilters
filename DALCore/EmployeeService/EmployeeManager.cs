using Core.Contracts.Models;
using DALCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EmployeeService
{
    public class EmployeeManager : IEmployee
    {
        public List<Employees> GetAllEmployees()
        {
            var entity = new VisitorsDatabaseContext();
            List<Employees> AllEmployees = entity.Employees.ToList<Employees>();
            return AllEmployees;
        }
        public void EditEmployee(Employees employee)
        {
            var entity = new VisitorsDatabaseContext();
            Employees EmployeeDetails = entity.Employees.Where(x => x.EmployeeId == employee.EmployeeId).FirstOrDefault();
            EmployeeDetails.EmployeeName = employee.EmployeeName;
            EmployeeDetails.EmailId = employee.EmailId;
            EmployeeDetails.Location = employee.Location;
            EmployeeDetails.Gender = employee.Gender;
            EmployeeDetails.LocalAddress = employee.LocalAddress;
            EmployeeDetails.EmergencyContactPerson = employee.EmergencyContactPerson;
            EmployeeDetails.EmergencyContactNumber = employee.EmergencyContactNumber;
            EmployeeDetails.PrimaryContactNumber = employee.PrimaryContactNumber;
            EmployeeDetails.SecondaryContactNumber = employee.SecondaryContactNumber;
            EmployeeDetails.Remark = employee.Remark;
            EmployeeDetails.MedicalSpecification = employee.MedicalSpecification;
            entity.SaveChanges();
        }
        public bool AddNewEmployee(Employees employee)
        {
            try
            {
                var entity = new VisitorsDatabaseContext();
                Employees NewEmployee = new Employees();
                NewEmployee.EmployeeId = employee.EmployeeId;
                NewEmployee.EmployeeName = employee.EmployeeName;
                NewEmployee.EmailId = employee.EmailId;
                NewEmployee.Location = employee.Location;
                NewEmployee.EmployeeStatus = employee.EmployeeStatus;
                NewEmployee.Gender = employee.Gender;
                NewEmployee.DateOfBirth = employee.DateOfBirth;
                NewEmployee.LocalAddress = employee.LocalAddress;
                NewEmployee.PermanentAddress = employee.PermanentAddress;
                NewEmployee.EmergencyContactPerson = employee.EmergencyContactPerson;
                NewEmployee.EmergencyContactNumber = employee.EmergencyContactNumber;
                NewEmployee.PrimaryContactNumber = employee.PrimaryContactNumber;
                NewEmployee.SecondaryContactNumber = employee.SecondaryContactNumber;
                NewEmployee.DateOfJoining = employee.DateOfJoining;
                NewEmployee.DateOfResignation = employee.DateOfResignation;
                NewEmployee.Remark = employee.Remark;
                NewEmployee.BloodGroup = employee.BloodGroup;
                NewEmployee.MedicalSpecification = employee.MedicalSpecification;
                entity.Employees.Add(NewEmployee);
                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public string GetEmployeeNameById(string UserId)
        {
            var entity = new VisitorsDatabaseContext();
            Employees MatchingEmployee = entity.Employees.Where(x => x.EmployeeId == UserId).FirstOrDefault();
            return MatchingEmployee.EmployeeName;
        }
        public Employees GetEmployeeDetailsById(string UserId)
        {
            var entity = new VisitorsDatabaseContext();
            Employees MatchingEmployee = entity.Employees.Where(x => x.EmployeeId == UserId).FirstOrDefault();
            return MatchingEmployee;
        }
        public List<EmployeeLogs> GetAllEmployeesLogs()
        {
            var entity = new VisitorsDatabaseContext();
            List<EmployeeLogs> AllEmployeeLogs = entity.EmployeeLogs.ToList<EmployeeLogs>();
            return AllEmployeeLogs;
        }
        public void AddEmployeeLog(string EmployeeId)
        {
            var entity = new VisitorsDatabaseContext();
            string EmployeeName = GetEmployeeNameById(EmployeeId);
            EmployeeLogs NewLog = new EmployeeLogs();
            NewLog.EmployeeId = EmployeeId;
            NewLog.EmployeeName = EmployeeName;
            NewLog.DateOfVisit = DateTime.Today;
            NewLog.TimeOfEntry = DateTime.Now;
            entity.EmployeeLogs.Add(NewLog);
        }
        public List<EmployeeLogs> GetEmployeeLogByName(string EmployeeName)
        {
            var entity = new VisitorsDatabaseContext();
            List<EmployeeLogs> AllLogsByName = entity.EmployeeLogs.Where(x => x.EmployeeName == EmployeeName).ToList<EmployeeLogs>();
            return AllLogsByName;
        }
        public List<EmployeeLogs> GetEmployeeLogsByDate(string fromDate, string toDate, string fromTime, string toTime)
        {
            var entity = new VisitorsDatabaseContext();
            List<EmployeeLogs> AllLogsBetweenDateAndTime = entity.EmployeeLogs.FromSql("select * from EmployeeLogs where DateOfVisit between @fromDate And @toDate and TimeOfEntry >= @fromTime and TimeOfEntry <= @toTime", new SqlParameter("@fromDate", fromDate), new SqlParameter("@toDate", toDate), new SqlParameter("@fromTime", fromTime), new SqlParameter("@toTime", toTime)).ToList<EmployeeLogs>();
            return AllLogsBetweenDateAndTime;
        }
        public List<EmployeeLogs> GetEmployeeLogsByNameAndDate(string nameOfEmployee, string fromDate, string toDate, string fromTime, string toTime)
        {
            var entity = new VisitorsDatabaseContext();
            List<EmployeeLogs> AllLogsByNameBetweenDateAndTime = entity.EmployeeLogs.FromSql("select * from EmployeeLogs where EmployeeName = @nameOfEmployee and DateOfVisit between @fromDate And @toDate and TimeOfEntry >= @fromTime and TimeOfEntry <= @toTime", new SqlParameter("@nameOfEmployee", nameOfEmployee), new SqlParameter("@fromDate", fromDate), new SqlParameter("@toDate", toDate), new SqlParameter("@fromTime", fromTime), new SqlParameter("@toTime", toTime)).ToList<EmployeeLogs>();
            return AllLogsByNameBetweenDateAndTime;
        }
    }
}
