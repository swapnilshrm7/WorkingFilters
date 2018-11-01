using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Contracts.Models;
using DALCore.Models;
using EmployeeService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UI.Entities;

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
        public List<Employee> GetAllEmployeeData()
        {
            return employee.GetAllEmployees();
        }
        [HttpPut]
        [Route("api/[controller]/EditEmployee")]
        public string EditExistingEmployee([FromBody]Employees Employee)
        {
            return employee.EditEmployee(Employee);
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
        public Employee GetEmployeeById([FromBody]SearchFilter userId)
        {
            return employee.GetEmployeeDetailsById(userId.UserInput);
        }
        [HttpPut]
        [Route("api/[controller]/EmployeeLogById")]
        public List<EmployeeData> GetEmployeeLogsById([FromBody]SearchFilter userId)
        {
            return employee.GetEmployeeLogsById(userId.UserInput);
        }
        [HttpGet]
        [Route("api/[controller]/EmployeeLogs")]
        public List<EmployeeData> AllEmployeeLogs()
        {
            return employee.GetAllEmployeesLogs();
                //return AutoMapper.Mapper.Map<List<UI.Entities.EmployeeLogs>>(employee.GetAllEmployeesLogs());
        }
        [HttpPut]
        [Route("api/[controller]/AddLog")]
        public void AddEmployeeLog([FromBody]SearchFilter userId)
        {
            employee.AddEmployeeLog(userId.UserInput);
        }
        [HttpPut]
        [Route("api/[controller]/LogsByName")]
        public List<EmployeeData> EmployeeLogByName([FromBody]SearchFilter userId)
        {
            return employee.GetEmployeeLogByName(userId.UserInput);
        }
        [HttpPut]
        [Route("api/[controller]/LogsByDate")]
        public List<EmployeeData> EmployeeLogsByDate([FromBody]DateAndTime UserInput)
        {
            return employee.GetEmployeeLogsByDate(UserInput.fromDate, UserInput.toDate, UserInput.fromTime, UserInput.toTime);
        }
        [HttpPut]
        [Route("api/[controller]/LogsByDateAndName")]
        public List<EmployeeData> EmployeeLogsByDateAndName([FromBody]DateAndName UserInput)
        {
            return employee.GetEmployeeLogsByNameAndDate(UserInput.nameOfVisitor, UserInput.fromDate, UserInput.toDate, UserInput.fromTime, UserInput.toTime);
        }
        [HttpPut]
        [Route("api/[controller]/LogExit")]
        public string LogEmployeeExitTime([FromBody]SearchFilter UserId)
        {
            return employee.LogEmployeeExit(UserId.UserInput);
        }
    }
}