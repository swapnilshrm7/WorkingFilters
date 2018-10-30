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
            List<Employees> AllEmployees = entity.Employees.FromSql("select * from Employees").ToList<Employees>();
            return AllEmployees;
        }
        public void EditEmployee(Employees employee)
        {
            var entity = new VisitorsDatabaseContext();
            //List<Employees> MatchingEmployee = entity.Employees.FromSql("select * from Employees where EmployeeId = @EmpId", new SqlParameter("@EmpId", employee.EmployeeId)).ToList<Employees>();
            entity.Database.ExecuteSqlCommand("Update Employees SET EmployeeId=@EmployeeId,EmployeeName=@EmployeeName,EmailId=@EmailId,Location=@Location,EmployeeStatus=@EmployeeStatus,Gender=@Gender,DateOfBirth=@DateOfBirth,LocalAddress=@LocalAddress,PermanentAddress=@PermanentAddress,EmergencyContactPerson=@EmergencyContactPerson,EmergencyContactNumber=@EmergencyContactNumber,PrimaryContactNumber=@PrimaryContactNumber,SecondaryContactNumber=@SecondaryContactNumber,DateOfJoining=@DateOfJoining,DateOfResignation=@DateOfResignation,Remark=@Remark,BloodGroup=@BloodGroup,MedicalSpecification=@MedicalSpecification where EmployeeId=@MatchingId", new SqlParameter("@EmployeeId", employee.EmployeeId), new SqlParameter("@EmployeeName", employee.EmployeeName), new SqlParameter("@EmailId", employee.EmailId), new SqlParameter("@Location", employee.Location), new SqlParameter("@EmployeeStatus", employee.EmployeeStatus), new SqlParameter("@Gender", employee.Gender), new SqlParameter("@DateOfBirth", employee.DateOfBirth), new SqlParameter("@LocalAddress", employee.LocalAddress), new SqlParameter("@PermanentAddress", employee.PermanentAddress), new SqlParameter("@EmergencyContactPerson", employee.EmergencyContactPerson), new SqlParameter("@EmergencyContactNumber", employee.EmergencyContactNumber), new SqlParameter("@PrimaryContactNumber", employee.PrimaryContactNumber), new SqlParameter("@SecondaryContactNumber", employee.SecondaryContactNumber), new SqlParameter("@DateOfJoining", employee.DateOfJoining), new SqlParameter("@DateOfResignation", employee.DateOfResignation), new SqlParameter("@Remark", employee.Remark), new SqlParameter("@BloodGroup", employee.BloodGroup), new SqlParameter("@MedicalSpecification", employee.MedicalSpecification), new SqlParameter("@MatchingId", employee.EmployeeId));
        }
        public bool AddNewEmployee(Employees employee)
        {
            try
            {
                var entity = new VisitorsDatabaseContext();
                entity.Database.ExecuteSqlCommand("Insert into Employees(EmployeeId,EmployeeName,EmailId,Location,EmployeeStatus,Gender,DateOfBirth,LocalAddress,PermanentAddress,EmergencyContactPerson,EmergencyContactNumber,PrimaryContactNumber,SecondaryContactNumber,DateOfJoining,DateOfResignation,Remark,BloodGroup,MedicalSpecification) values (@EmployeeId,@EmployeeName,@EmailId,@Location,@EmployeeStatus,@Gender,@DateOfBirth,@LocalAddress,@PermanentAddress,@EmergencyContactPerson,@EmergencyContactNumber,@PrimaryContactNumber,@SecondaryContactNumber,@DateOfJoining,@DateOfResignation,@Remark,@BloodGroup,@MedicalSpecification)", new SqlParameter("@EmployeeId", employee.EmployeeId), new SqlParameter("@EmployeeName", employee.EmployeeName), new SqlParameter("@EmailId", employee.EmailId), new SqlParameter("@Location", employee.Location), new SqlParameter("@EmployeeStatus", employee.EmployeeStatus), new SqlParameter("@Gender", employee.Gender), new SqlParameter("@DateOfBirth", employee.DateOfBirth), new SqlParameter("@LocalAddress", employee.LocalAddress), new SqlParameter("@PermanentAddress", employee.PermanentAddress), new SqlParameter("@EmergencyContactPerson", employee.EmergencyContactPerson), new SqlParameter("@EmergencyContactNumber", employee.EmergencyContactNumber), new SqlParameter("@PrimaryContactNumber", employee.PrimaryContactNumber), new SqlParameter("@SecondaryContactNumber", employee.SecondaryContactNumber), new SqlParameter("@DateOfJoining", employee.DateOfJoining), new SqlParameter("@DateOfResignation", employee.DateOfResignation), new SqlParameter("@Remark", employee.Remark), new SqlParameter("@BloodGroup", employee.BloodGroup), new SqlParameter("@MedicalSpecification", employee.MedicalSpecification));
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
            List<Employees> Employee = entity.Employees.FromSql("select * from Employees where EmployeeId = @employeeId", new SqlParameter("@employeeId", UserId)).ToList<Employees>();
            return Employee[0].EmployeeName;
        }
        public Employees GetEmployeeDetailsById(string UserId)
        {
            var entity = new VisitorsDatabaseContext();
            List<Employees> Employee = entity.Employees.FromSql("select * from Employees where EmployeeId = @employeeId", new SqlParameter("@employeeId", UserId)).ToList<Employees>();
            return Employee[0];
        }
        public List<EmployeeLogs> GetAllEmployeesLogs()
        {
            var entity = new VisitorsDatabaseContext();
            List<EmployeeLogs> AllEmployeeLogs = entity.EmployeeLogs.FromSql("select * from EmployeeLogs").ToList<EmployeeLogs>();
            return AllEmployeeLogs;
        }
        public void AddEmployeeLog(string EmployeeId)
        {
            var entity = new VisitorsDatabaseContext();
            string EmployeeName = GetEmployeeNameById(EmployeeId);
            entity.Database.ExecuteSqlCommand("Insert into EmployeeLogs(EmployeeId,EmployeeName,DateOfVisit,TimeOfEntry) values (@EmployeeId,@EmployeeName,@DateOfVisit,@TimeOfEntry)", new SqlParameter("@EmployeeId", EmployeeId), new SqlParameter("@EmployeeName", EmployeeName), new SqlParameter("@DateOfVisit", DateTime.Today), new SqlParameter("@TimeOfEntry", DateTime.Now));
        }
        public List<EmployeeLogs> GetEmployeeLogByName(string EmployeeName)
        {
            var entity = new VisitorsDatabaseContext();
            List<EmployeeLogs> AllLogsByName = entity.EmployeeLogs.FromSql("select * from EmployeeLogs where EmployeeName = @employeeName", new SqlParameter("@employeeName", EmployeeName)).ToList<EmployeeLogs>();
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
