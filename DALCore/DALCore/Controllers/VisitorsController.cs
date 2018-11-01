using System.Collections.Generic;
using DALCore.Models;
using Microsoft.AspNetCore.Mvc;
using Core.Contracts;
using VisitorService;
using Core.Contracts.Models;
using UI.Entities;

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
        [Route("api/[controller]/LogsByName")]
        public List<VisitorsData> GetVisitorsLogByName([FromBody]SearchFilter Name)
        {
            return visitor.GetVisitorsLogByName(Name.UserInput);
        }
        [HttpPut]
        [Route("api/[controller]/LogsByMeetingPerson")]
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
        [HttpGet]
        [Route("api/[controller]/UniqueVisitors")]
        public List<VisitorData> GetAllVisitors()
        {
            return visitor.GetUniqueVisitors();
        }
        [HttpPut]
        [Route("api/[controller]/UniqueVisitorsByName")]
        public List<VisitorData> GetUniqueVisitorByName([FromBody]SearchFilter Name)
        {
            return visitor.GetUniqueVisitorsByName(Name.UserInput);
        }
        [HttpPost]
        [Route("api/[controller]/AddNewVisitor")]
        public string NewVisitorEntry([FromBody]NewVisitorFormData newVisitor)
        {
            return visitor.AddNewVisitor(newVisitor);
        }
        [HttpPut]
        [Route("api/[controller]/EmployeesMatchingSubstring")]
        public List<MatchingSubstring> GetMatchingEmployeesNames([FromBody]SearchFilter Name)
        {
            return visitor.AllMatchingEmployeeNames(Name.UserInput);
        }

        [HttpPut]
        [Route("api/[controller]/GetOtp")]
        public int SendOtpToUser([FromBody]SearchFilter ContactNo)
        {
            return visitor.SendAndReturnOtp(ContactNo.UserInput);
        }
        [HttpPut]
        [Route("api/[controller]/GetVisitorNameById")]
        public string VisitorNameById([FromBody]UserId Id)
        {
            return visitor.GetVisitorNameById(Id.userId);
        }
        [HttpPut]
        [Route("api/[controller]/SaveExitTime")]
        public string SavingExitTime([FromBody]UserId Id)
        {           
            return visitor.SaveVisitorExitTime(Id.userId);
        }
        [HttpPost]
        [Route("api/[controller]/AddVisitorLog")]
        public string AddNewVisitorLogById([FromBody]NewVisitorFormData VisitorData)
        {
            return visitor.AddNewVisitor(VisitorData);
        }
    }
}
