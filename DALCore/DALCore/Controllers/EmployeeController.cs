using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Contracts.Models;
using DALCore.Models;
using EmployeeService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DALCore.Controllers
{
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployee employee;
        public EmployeeController(IEmployee _employee)
        {
            employee = _employee;
        }
        [HttpGet]
        [Route("api/[controller]/AllEmployees")]
        public List<Employees> GetAllEmployeeData()
        {
            return employee.GetAllEmployees();
        }
        [HttpPut]
        [Route("api/[controller]/EditEmployee")]
        public void EditExistingEmployee([FromBody]Employees Employee)
        {
            employee.EditEmployee(Employee);
        }
        [HttpPost]
        [Route("api/[controller]/AddEmployee")]
        public bool AddEmployee([FromBody]Employees Employee)
        {
            return employee.AddNewEmployee(Employee);
        }
        [HttpPut]
        [Route("api/[controller]/NameById")]
        public string GetEmployeeName([FromBody]SearchFilter userId)
        {
            return employee.GetEmployeeNameById(userId.UserInput);
        }
        [HttpPut]
        [Route("api/[controller]/EmployeeById")]
        public Employees GetEmployeeById([FromBody]SearchFilter userId)
        {
            return employee.GetEmployeeDetailsById(userId.UserInput);
        }
        [HttpGet]
        [Route("api/[controller]/EmployeeLogs")]
        public List<EmployeeLogs> AllEmployeeLogs()
        {
            return employee.GetAllEmployeesLogs();
        }
        [HttpPut]
        [Route("api/[controller]/AddLog")]
        public void AddEmployeeLog([FromBody]SearchFilter userId)
        {
            employee.AddEmployeeLog(userId.UserInput);
        }
        [HttpPut]
        [Route("api/[controller]/LogsByName")]
        public List<EmployeeLogs> EmployeeLogByName([FromBody]SearchFilter userId)
        {
            return employee.GetEmployeeLogByName(userId.UserInput);
        }
        [HttpPut]
        [Route("api/[controller]/LogsByDate")]
        public List<EmployeeLogs> EmployeeLogsByDate([FromBody]DateAndTime UserInput)
        {
            return employee.GetEmployeeLogsByDate(UserInput.fromDate, UserInput.toDate, UserInput.fromTime, UserInput.toTime);
        }
        [HttpPut]
        [Route("api/[controller]/LogsByDateAndName")]
        public List<EmployeeLogs> EmployeeLogsByDateAndName([FromBody]DateAndName UserInput)
        {
            return employee.GetEmployeeLogsByNameAndDate(UserInput.nameOfVisitor, UserInput.fromDate, UserInput.toDate, UserInput.fromTime, UserInput.toTime);
        }
    }
}