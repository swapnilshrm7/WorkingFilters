using DALCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeService
{
    public interface IEmployee
    {
        List<Employees> GetAllEmployees();
        void EditEmployee(Employees employee);
        void AddNewEmployee(Employees employee);
        string GetEmployeeNameById(string UserId);
    }
}
