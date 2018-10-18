using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DALCore.EntityFramework_Access;
using DALCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Contracts;
using VisitorService;
using Core.Contracts.Models;

namespace DALCore.Controllers
{
   
    [ApiController]
    public class VisitorsController : ControllerBase
    {
        IVisitor visitor;
        public VisitorsController(IVisitor _visitor)
        {
            visitor = _visitor;
        } 
        [HttpGet]
        [Route("api/[controller]/Log")]
        public List<VisitorsData> GetVisitorsFromLog()
        {
            return visitor.GetAllVisitorsFromLog();
        }
        [HttpPut]
        [Route("api/[controller]/ByName")]
        public List<VisitorsData> GetVisitorsLogByName([FromBody]SearchFilter Name)
        {
            return visitor.GetVisitorsLogByName(Name.UserInput);
        }
        [HttpPut]
        [Route("api/[controller]/ByMeetingPerson")]
        public List<VisitorsData> GetVisitorLogByMeetingPerson([FromBody]SearchFilter MeetingPerson)
        {
            return visitor.GetVisitorsLogByMeetingPerson(MeetingPerson.UserInput);
        }
        [HttpPut]
        [Route("api/[controller]/DateAndTime")]
        public List<VisitorsData> GetLogByDateAndTime([FromBody]DateAndTime UserInput)
        {
            return visitor.GetVisitorLogByDate(UserInput.fromDate, UserInput.toDate, UserInput.fromTime, UserInput.toTime);
        }
        [HttpPut]
        [Route("api/[controller]/PurposeOfVisit")]
        public List<VisitorsData> GetLogByPurposeOfVisit([FromBody]SearchFilter purposeOfVisit)
        {
            return visitor.GetVisitorLogByPurposeOfVisitor(purposeOfVisit.UserInput);
        }
        [HttpPut]
        [Route("api/[controller]/DateAndName")]
        public List<VisitorsData> GetLogByDateAndName([FromBody]DateAndName UserInput)
        {
            return visitor.GetVisitorLogByNameAndDate(UserInput.nameOfVisitor,UserInput.fromDate, UserInput.toDate, UserInput.fromTime, UserInput.toTime);
        }
        [HttpPut]
        [Route("api/[controller]/UniqueVisitors")]
        public List<Visitors> GetAllVisitors()
        {
            return visitor.GetUniqueVisitors();
        }
        [HttpPut]
        [Route("api/[controller]/UniqueVisitorsByName")]
        public List<Visitors> GetUniqueVisitorByName([FromBody]SearchFilter Name)
        {
            return visitor.GetUniqueVisitorsByName(Name.UserInput);
        }
    }
}
