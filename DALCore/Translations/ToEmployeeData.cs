using DALCore.Models;
using System;
using System.Collections.Generic;
using Ui=UI.Entities;

namespace Translations
{
    public class ToEmployeeData
    {
        public List<Ui.EmployeeData> TranslateToEmployeeDataList(List<EmployeeLogs> EmployeeLogs)
        {
            try
            {
                List<Ui.EmployeeData> EmployeeDataList = new List<Ui.EmployeeData>();
                foreach(var entry in EmployeeLogs)
                {
                    Ui.EmployeeData Employee = new Ui.EmployeeData();
                    Employee.DateOfExit = entry.DateOfExit;
                    Employee.DateOfVisit = entry.DateOfVisit;
                    Employee.EmployeeId = entry.EmployeeId;
                    Employee.EmployeeName = entry.EmployeeName;
                    Employee.LogId = entry.LogId;
                    Employee.TimeOfEntry = entry.TimeOfEntry;
                    Employee.TimeOfExit = entry.TimeOfExit;
                    Employee.Error = false;
                    EmployeeDataList.Add(Employee);
                }
                return EmployeeDataList;
            }
            catch(Exception ex)
            {
                List<Ui.EmployeeData> Employee = new List<Ui.EmployeeData>();
                Employee[0].Error = true;
                return Employee;
            }
        }
        public Ui.EmployeeData TranslateToEmployeeData(EmployeeLogs employeeLogs)
        {
            try
            {
                Ui.EmployeeData Employee = new Ui.EmployeeData();
                Employee.DateOfExit = employeeLogs.DateOfExit;
                Employee.DateOfVisit = employeeLogs.DateOfVisit;
                Employee.EmployeeId = employeeLogs.EmployeeId;
                Employee.EmployeeName = employeeLogs.EmployeeName;
                Employee.LogId = employeeLogs.LogId;
                Employee.TimeOfEntry = employeeLogs.TimeOfEntry;
                Employee.TimeOfExit = employeeLogs.TimeOfExit;
                Employee.Error = false;
                return Employee;
            }
            catch(Exception ex)
            {
                Ui.EmployeeData Employee = new Ui.EmployeeData();
                Employee.Error = true;
                return Employee;
            }
        }
    }
}
