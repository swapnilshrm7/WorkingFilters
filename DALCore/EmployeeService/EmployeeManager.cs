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
        public void AddNewEmployee(Employees employee)
        {
            var entity = new VisitorsDatabaseContext();
            entity.Database.ExecuteSqlCommand("Insert into Employees(EmployeeId,EmployeeName,EmailId,Location,EmployeeStatus,Gender,DateOfBirth,LocalAddress,PermanentAddress,EmergencyContactPerson,EmergencyContactNumber,PrimaryContactNumber,SecondaryContactNumber,DateOfJoining,DateOfResignation,Remark,BloodGroup,MedicalSpecification) values (@EmployeeId,@EmployeeName,@EmailId,@Location,@EmployeeStatus,@Gender,@DateOfBirth,@LocalAddress,@PermanentAddress,@EmergencyContactPerson,@EmergencyContactNumber,@PrimaryContactNumber,@SecondaryContactNumber,@DateOfJoining,@DateOfResignation,@Remark,@BloodGroup,@MedicalSpecification)", new SqlParameter("@EmployeeId", employee.EmployeeId), new SqlParameter("@EmployeeName", employee.EmployeeName), new SqlParameter("@EmailId", employee.EmailId), new SqlParameter("@Location", employee.Location), new SqlParameter("@EmployeeStatus", employee.EmployeeStatus), new SqlParameter("@Gender", employee.Gender), new SqlParameter("@DateOfBirth", employee.DateOfBirth), new SqlParameter("@LocalAddress", employee.LocalAddress), new SqlParameter("@PermanentAddress", employee.PermanentAddress), new SqlParameter("@EmergencyContactPerson", employee.EmergencyContactPerson), new SqlParameter("@EmergencyContactNumber", employee.EmergencyContactNumber), new SqlParameter("@PrimaryContactNumber", employee.PrimaryContactNumber), new SqlParameter("@SecondaryContactNumber", employee.SecondaryContactNumber), new SqlParameter("@DateOfJoining", employee.DateOfJoining), new SqlParameter("@DateOfResignation", employee.DateOfResignation), new SqlParameter("@Remark", employee.Remark), new SqlParameter("@BloodGroup", employee.BloodGroup), new SqlParameter("@MedicalSpecification", employee.MedicalSpecification));
        }
        public string GetEmployeeNameById(string UserId)
        {
            var entity = new VisitorsDatabaseContext();
            List<Employees> Employee = entity.Employees.FromSql("select * from Employees where EmployeeId = @employeeId", new SqlParameter("@employeeId", UserId)).ToList<Employees>();
            return Employee[0].EmployeeName;
        }
    }
}
