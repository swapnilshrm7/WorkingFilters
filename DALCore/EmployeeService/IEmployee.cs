using DALCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using UI.Entities;

namespace EmployeeService
{
    public interface IEmployee
    {
        List<Employee> GetAllEmployees();
        string EditEmployee(Employees employee);
        bool AddNewEmployee(Employees employee);
        string GetEmployeeNameById(string UserId);
        List<EmployeeData> GetAllEmployeesLogs();
        void AddEmployeeLog(string EmployeeId);
        List<EmployeeData> GetEmployeeLogByName(string EmployeeName);
        List<EmployeeData> GetEmployeeLogsByDate(string fromDate, string toDate, string fromTime, string toTime);
        List<EmployeeData> GetEmployeeLogsByNameAndDate(string nameOfEmployee, string fromDate, string toDate, string fromTime, string toTime);
        Employee GetEmployeeDetailsById(string UserId);
        string LogEmployeeExit(string EmplpyeeId);
        List<EmployeeData> GetEmployeeLogsById(string EmployeeId);
    }
}
