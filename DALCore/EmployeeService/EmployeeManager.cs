using Core.Contracts.Models;
using DALCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Translations;
using UI.Entities;

namespace EmployeeService
{
    public class EmployeeManager : IEmployee
    {
        public List<Employee> GetAllEmployees()
        {
            try
            {
                var entity = new DatabaseContext();
                List<Employees> AllEmployees = entity.Employees.ToList<Employees>();
                ToEmployee convert = new ToEmployee();
                List<Employee> TranslatedList = convert.ToEmployeesList(AllEmployees);
                return TranslatedList;
            }
            catch (Exception ex)
            {
                List<Employee> EmployeeList = new List<Employee>();
                EmployeeList[0].Error = true; 
                return EmployeeList;
            }
        }
        public string EditEmployee(Employees employee)
        {
            try
            {
                var entity = new DatabaseContext();
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
                return "Employee edited successfully";
            }
            catch (Exception ex)
            {
                return ("Could not edit Employees! Please Contact Admin" + ex.StackTrace);
            }
        }
        public bool AddNewEmployee(Employees employee)
        {
            try
            {
                var entity = new DatabaseContext();
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
        public string GetEmployeeNameById(string employeeID)
        {
            try
            {
                var entity = new DatabaseContext();
                Employees MatchingEmployee = entity.Employees.Where(x => x.EmployeeId == employeeID).FirstOrDefault();
                return MatchingEmployee.EmployeeName;
            }
            catch (Exception ex)
            {
                return "Could not get Employee by Id! Please Contact Admin" + ex.StackTrace;
            }
        }
        public Employee GetEmployeeDetailsById(string employeeID)
        {
            try
            {
                var entity = new DatabaseContext();
                Employees MatchingEmployee = entity.Employees.Where(x => x.EmployeeId == employeeID).FirstOrDefault();
                ToEmployee convert = new ToEmployee();
                Employee TranslatedData = convert.ToEmployees(MatchingEmployee);
                return TranslatedData;
            }
            catch (Exception ex)
            {
                Employee EmployeeData = new Employee();
                EmployeeData.Error = true; 
                return EmployeeData;
            }
        }
        public List<EmployeeData> GetAllEmployeesLogs()
        {
            try
            {
                var entity = new DatabaseContext();
                List<EmployeeLogs> AllEmployeeLogs = entity.EmployeeLogs.ToList<EmployeeLogs>();
                ToEmployeeData convert = new ToEmployeeData();
                List<EmployeeData> TranslatedData = convert.TranslateToEmployeeDataList(AllEmployeeLogs);
                return TranslatedData;
            }
            catch (Exception ex)
            {
                List<EmployeeData> EmployeeData = new List<EmployeeData>();
                EmployeeData[0].Error = true;
                return EmployeeData;
            }
        }
        public void AddEmployeeLog(string EmployeeId)
        {
            try
            {
                var entity = new DatabaseContext();
                string EmployeeName = GetEmployeeNameById(EmployeeId);
                EmployeeLogs NewLog = new EmployeeLogs();
                NewLog.EmployeeId = EmployeeId;
                NewLog.EmployeeName = EmployeeName;
                NewLog.DateOfVisit = DateTime.Today;
                NewLog.TimeOfEntry = DateTime.Now.TimeOfDay;
                entity.EmployeeLogs.Add(NewLog);
                entity.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Could not Add Employee ! Please Contact Admin" + ex.StackTrace);
            }
        }
        public string LogEmployeeExit(string EmplpyeeId)
        {
            try
            {
                var entity = new DatabaseContext();
                EmployeeLogs Log = entity.EmployeeLogs.Where(entry => entry.EmployeeId == EmplpyeeId).FirstOrDefault();
                Log.DateOfExit = DateTime.Today;
                Log.TimeOfExit = DateTime.Now.TimeOfDay;
                entity.SaveChanges();
                return "Exit time successfully recorder";
            }
            catch (Exception ex)
            {
                return "Unable to log exit time";
            }

        }
        public List<EmployeeData> GetEmployeeLogByName(string EmployeeName)
        {
            try
            {
                var entity = new DatabaseContext();
                List<EmployeeLogs> AllLogsByName = entity.EmployeeLogs.Where(x => x.EmployeeName == EmployeeName).ToList<EmployeeLogs>();
                ToEmployeeData convert = new ToEmployeeData();
                List<EmployeeData> TranslatedData = convert.TranslateToEmployeeDataList(AllLogsByName);
                return TranslatedData;
            }
            catch (Exception ex)
            {
                List<EmployeeData> EmployeeData = new List<EmployeeData>();
                EmployeeData[0].Error = true;
                return EmployeeData;
            }
        }
        public List<EmployeeData> GetEmployeeLogsByDate(string fromDate, string toDate, string fromTime, string toTime)
        {
            try
            {
                var entity = new DatabaseContext();
                List<EmployeeLogs> AllLogsBetweenDateAndTime = entity.EmployeeLogs.Where(entry => entry.DateOfVisit >= Convert.ToDateTime(fromDate).Date && entry.DateOfVisit <= Convert.ToDateTime(toDate).Date && entry.TimeOfEntry >= Convert.ToDateTime(fromTime).TimeOfDay && entry.TimeOfExit <= Convert.ToDateTime(toTime).TimeOfDay).ToList<EmployeeLogs>();
                ToEmployeeData convert = new ToEmployeeData();
                List<EmployeeData> TranslatedData = convert.TranslateToEmployeeDataList(AllLogsBetweenDateAndTime);
                return TranslatedData;
            }
            catch (Exception ex)
            {
                List<EmployeeData> EmployeeData = new List<EmployeeData>();
                EmployeeData[0].Error = true;
                return EmployeeData;
            }
        }
        public List<EmployeeData> GetEmployeeLogsByNameAndDate(string nameOfEmployee, string fromDate, string toDate, string fromTime, string toTime)
        {
            try
            {
                var entity = new DatabaseContext();
                List<EmployeeLogs> AllLogsByNameBetweenDateAndTime = entity.EmployeeLogs.Where(entry => entry.EmployeeName == nameOfEmployee && entry.DateOfVisit >= Convert.ToDateTime(fromDate).Date && entry.DateOfVisit <= Convert.ToDateTime(toDate).Date && entry.TimeOfEntry >= Convert.ToDateTime(fromTime).TimeOfDay && entry.TimeOfExit <= Convert.ToDateTime(toTime).TimeOfDay).ToList<EmployeeLogs>();
                ToEmployeeData convert = new ToEmployeeData();
                List<EmployeeData> TranslatedData = convert.TranslateToEmployeeDataList(AllLogsByNameBetweenDateAndTime);
                return TranslatedData;
            }
            catch (Exception ex)
            {
                List<EmployeeData> EmployeeData = new List<EmployeeData>();
                EmployeeData[0].Error = true;
                return EmployeeData;
            }
        }
        public List<EmployeeData> GetEmployeeLogsById(string EmployeeId)
        {
            try
            {
                var entity = new DatabaseContext();
                List<EmployeeLogs> MatchingLogs = entity.EmployeeLogs.Where(entry => entry.EmployeeId == EmployeeId).ToList<EmployeeLogs>();
                ToEmployeeData convert = new ToEmployeeData();
                List<EmployeeData> TranslatedData = convert.TranslateToEmployeeDataList(MatchingLogs);
                return TranslatedData;
            }
            catch (Exception ex)
            {
                List<EmployeeData> EmployeeData = new List<EmployeeData>();
                EmployeeData[0].Error = true;
                return EmployeeData;
            }
        }
    }
}
