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
        public void AddEmployee([FromBody]Employees Employee)
        {
            employee.AddNewEmployee(Employee);
        }
        [HttpPut]
        [Route("api/[controller]/GetNameById")]
        public string GetEmployeeName([FromBody]SearchFilter userId)
        {
            return employee.GetEmployeeNameById(userId.UserInput);
        }
    }
}