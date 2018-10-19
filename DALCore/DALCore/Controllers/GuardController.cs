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
        public List<GuardData> GetVisitorsFromLog()
        {
            return guard.GetAllGuardsFromLog();
        }

        [HttpPut]
        [Route("api/[controller]/ByName")]
        public List<GuardData> GetVisitorsLogByName(SearchFilter searchInput)
        {
            return guard.GetGuardsLogByName(searchInput.UserInput);
        }
        [HttpPut]
        [Route("api/[controller]/DateAndTime")]
        public List<GuardData> GetLogByDateAndTime(DateAndTime UserInput)
        {
            return guard.GetGuardLogByDateAndTime(UserInput.fromDate, UserInput.toDate, UserInput.fromTime, UserInput.toTime);
        }
        [HttpPut]
        [Route("api/[controller]/AllGuards")]
        public List<Guard> GetAllUniqueGuards(SearchFilter searchInput)
        {
            return guard.GetUniqueVisitors();
        }
        [HttpPut]
        [Route("api/[controller]/UniqueGuardByName")]
        public List<Guard> GetGuardByName(SearchFilter searchInput)
        {
            return guard.GetUniqueVisitorsByName(searchInput.UserInput);
        }
    }
}