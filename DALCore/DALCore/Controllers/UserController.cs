using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService;
using Core.Contracts;
using GuardService;
using Core.Contracts.Models;
using Newtonsoft.Json.Linq;

namespace DALCore.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserAuthentication admin; 
        public UserController(IUserAuthentication _admin)
        {
            admin = _admin;
        } 
        [HttpPut]
        [Route("api/[controller]/Login")]
        public bool ValidateUser([FromBody]LoginBasicDetails loginBasicDetails)
        { 
            return admin.UserValidation(loginBasicDetails.UserId, loginBasicDetails.Password);
        }
       
    }
}