using DALCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using UI.Entities;

namespace Translations
{
    public class ToEmployee
    {
        public List<Employee> ToEmployeesList(List<Employees> Employees)
        {
            try
            {
                List<Employee> EmployeeList = new List<Employee>();
                foreach (var entry in Employees)
                {
                    Employee employee = new Employee();
                    employee.BloodGroup = entry.BloodGroup;
                    employee.DateOfBirth = entry.DateOfBirth;
                    employee.DateOfJoining = entry.DateOfJoining;
                    employee.DateOfResignation = entry.DateOfResignation;
                    employee.EmailId = entry.EmailId;
                    employee.EmergencyContactNumber = entry.EmergencyContactNumber;
                    employee.EmergencyContactPerson = entry.EmergencyContactPerson;
                    employee.EmployeeId = entry.EmployeeId;
                    employee.EmployeeName = entry.EmployeeName;
                    employee.EmployeeStatus = entry.EmployeeStatus;
                    employee.Error = false;
                    employee.Gender = entry.Gender;
                    employee.LocalAddress = entry.LocalAddress;
                    employee.Location = entry.Location;
                    employee.MedicalSpecification = entry.MedicalSpecification;
                    employee.PermanentAddress = entry.PermanentAddress;
                    employee.PrimaryContactNumber = entry.PrimaryContactNumber;
                    employee.Remark = entry.Remark;
                    employee.SecondaryContactNumber = entry.SecondaryContactNumber;
                    EmployeeList.Add(employee);
                }
                return EmployeeList;
            }
            catch(Exception ex)
            {
                List<Employee> EmployeeList = new List<Employee>();
                EmployeeList[0].Error = true;
                return EmployeeList;
            }
        }
        public Employee ToEmployees(Employees Employees)
        {
            try
            {
                    Employee employee = new Employee();
                    employee.BloodGroup = Employees.BloodGroup;
                    employee.DateOfBirth = Employees.DateOfBirth;
                    employee.DateOfJoining = Employees.DateOfJoining;
                    employee.DateOfResignation = Employees.DateOfResignation;
                    employee.EmailId = Employees.EmailId;
                    employee.EmergencyContactNumber = Employees.EmergencyContactNumber;
                    employee.EmergencyContactPerson = Employees.EmergencyContactPerson;
                    employee.EmployeeId = Employees.EmployeeId;
                    employee.EmployeeName = Employees.EmployeeName;
                    employee.EmployeeStatus = Employees.EmployeeStatus;
                    employee.Error = false;
                    employee.Gender = Employees.Gender;
                    employee.LocalAddress = Employees.LocalAddress;
                    employee.Location = Employees.Location;
                    employee.MedicalSpecification = Employees.MedicalSpecification;
                    employee.PermanentAddress = Employees.PermanentAddress;
                    employee.PrimaryContactNumber = Employees.PrimaryContactNumber;
                    employee.Remark = Employees.Remark;
                    employee.SecondaryContactNumber = Employees.SecondaryContactNumber;
                return employee;
            }
            catch (Exception ex)
            {
                Employee Employee = new Employee();
                Employee.Error = true;
                return Employee;
            }
        }
    }
}
