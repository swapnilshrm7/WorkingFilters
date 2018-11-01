using System;
using System.Collections.Generic;
using System.Text;
using Core.Contracts;
using Core.Contracts.Models;
using DALCore.Models;
using UI.Entities;

namespace VisitorService
{
    public interface IVisitor
    {
        List<VisitorsData> GetAllVisitorsFromLog();
        List<VisitorsData> GetVisitorsLogByName(string searchInput);
        List<VisitorsData> GetVisitorsLogByMeetingPerson(string SearchInput);
        List<VisitorsData> GetVisitorLogByDate(string fromDate, string toDate, string fromTime, string toTime);
        List<VisitorsData> GetVisitorLogByPurposeOfVisitor(string searchInput);
        List<VisitorsData> GetVisitorLogByNameAndDate(string nameOfVisitor, string fromDate, string toDate, string fromTime, string toTime);
        List<VisitorData> GetUniqueVisitors();
        List<VisitorData> GetUniqueVisitorsByName(string searchInput);
        string AddNewVisitor(NewVisitorFormData newVisitorData);
        List<MatchingSubstring> AllMatchingEmployeeNames(string userInput);
        int SendAndReturnOtp(string ContactNo);
        string GetVisitorNameById(int Id);
        string SaveVisitorExitTime(int Id);
        string AddNewVisitorLog(NewVisitorFormData VisitorData);
    }

}
