using Core.Contracts;
using Core.Contracts.Models;
using DALCore.Models;
using GuardService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DALCore.Controllers
{ 
    [ApiController]
    public class GuardController : Controller
    {
        IGuard guard;
        public GuardController(IGuard _guard)
        {
            guard = _guard;
        }
        [HttpGet]
        [Route("api/[controller]/Log")]
        public List<GuardData> GetGuardsFromLog()
        {
            return guard.GetAllGuardsFromLog();
        }

        [HttpPut]
        [Route("api/[controller]/ByName")]
        public List<GuardData> GetGuardsLogByName([FromBody]SearchFilter searchInput)
        {
            return guard.GetGuardsLogByName(searchInput.UserInput);
        }
        [HttpPut]
        [Route("api/[controller]/DateAndTime")]
        public List<GuardData> GetLogByDateAndTime([FromBody]DateAndTime UserInput)
        {
            return guard.GetGuardLogByDateAndTime(UserInput.fromDate, UserInput.toDate, UserInput.fromTime, UserInput.toTime);
        }
        [HttpGet]
        [Route("api/[controller]/AllGuards")]
        public List<Guard> GetAllUniqueGuards()
        {
            return guard.GetUniqueVisitors();
        }
        [HttpPut]
        [Route("api/[controller]/UniqueGuardByName")]
        public List<Guard> GetGuardByName([FromBody]SearchFilter searchInput)
        {
            return guard.GetUniqueVisitorsByName(searchInput.UserInput);
        }
        [HttpPut]
        [Route("api/[controller]/EditGuard")]
        public bool EditingGuard([FromBody]Guard Details)
        {
            return guard.EditExistingGuard(Details);
        }
        [HttpPost]
        [Route("api/[controller]/AddGuard")]
        public bool AddNewGuard([FromBody]Guard NewGuard)
        {
            if (guard.AddGuard(NewGuard))
                return true;
            return false;
        }
        [HttpDelete]
        [Route("api/[controller]/RemoveGuard")]
        public void RemoveGuard([FromBody]SearchFilter searchInput)
        {
            guard.DeleteGuard(searchInput.UserInput);
        }
        [HttpPut]
        [Route("api/[controller]/GuardById")]
        public Guard GetGuardById([FromBody]SearchFilter userId)
        {
            return guard.GetGuardDetailsById(userId.UserInput);
        }
    }
}