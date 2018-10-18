using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DALCore.EntityFramework_Access
{
    public class VisitorAccess
    {
       //static List<VisitorsData> AllLogs=new List<VisitorsData>();
       // public static List<VisitorsData> GetAllVisitorsFromLog()
       // {
       //     var entity = new VisitorsDatabaseContext();
       //     List<VisitorsLogs> visitorLogsList = entity.VisitorsLogs.FromSql("select * from VisitorsLogs").ToList<VisitorsLogs>();
       //     foreach(var entry in visitorLogsList)
       //     {
       //         GetVisitorData(entry);
       //     }
       //     return AllLogs;
       // }
       // public static void GetVisitorData(VisitorsLogs visitor)
       // {
       //     var entity = new VisitorsDatabaseContext();
       //     Visitors visitorData = entity.Visitors.Find(visitor.VisitorId);
       //     VisitorsData entry=new VisitorsData();
       //     entry.NameOfVisitor = visitorData.NameOfVisitor;
       //     entry.GovtIdProof = visitorData.GovtIdProof;
       //     entry.Contact = visitorData.Contact;
       //     entry.ComingFrom = visitor.ComingFrom;
       //     entry.WhomToMeet = visitor.WhomToMeet;
       //     entry.EmployeeId = visitor.EmployeeId;
       //     entry.TimeIn = visitor.TimeIn.ToString();
       //     entry.TimeOut = visitor.TimeOut.ToString();
       //     entry.VisitorId = visitor.VisitorId;
       //     entry.GuardId = visitor.GuardId;
       //     AllLogs.Add(entry);
       // }
       // public static List<VisitorsData> GetVisitorsLogByName(string searchInput)
       // {
       //     var entity = new VisitorsDatabaseContext();
       //     List<Visitors> visitorLogsList = entity.Visitors.FromSql("select * from Visitors where NameOfVisitor = @searchInput", new SqlParameter("@searchInput", searchInput)).ToList<Visitors>();
       //     foreach (var entry in visitorLogsList)
       //     {
       //         GetVisitorDataByName(entry);
       //     }
       //     return AllLogs;
       // }
       // public static void GetVisitorDataByName(Visitors visitor)
       // {
       //     var entity = new VisitorsDatabaseContext();
       //     List<VisitorsLogs> visitorData = entity.VisitorsLogs.FromSql("select * from VisitorsLogs where VisitorId = @searchInput", new SqlParameter("@searchInput", visitor.VisitorId)).ToList<VisitorsLogs>();
       //     foreach (var result in visitorData)
       //     {
       //         VisitorsData entry = new VisitorsData();
       //         entry.NameOfVisitor = visitor.NameOfVisitor;
       //         entry.GovtIdProof = visitor.GovtIdProof;
       //         entry.Contact = visitor.Contact;
       //         entry.ComingFrom = result.ComingFrom;
       //         entry.WhomToMeet = result.WhomToMeet;
       //         entry.EmployeeId = result.EmployeeId;
       //         entry.TimeIn = result.TimeIn.ToString();
       //         entry.TimeOut = result.TimeOut.ToString();
       //         entry.VisitorId = result.VisitorId;
       //         entry.GuardId = result.GuardId;
       //         AllLogs.Add(entry);
       //     }
       // }
       // public static List<VisitorsData> GetVisitorsLogByMeetingPerson(string SearchInput)
       // {
       //     var entity = new VisitorsDatabaseContext();
       //     List<VisitorsLogs> visitorLogsList = entity.VisitorsLogs.FromSql("select * from VisitorsLogs where WhomToMeet = @searchInput", new SqlParameter("@searchInput", SearchInput)).ToList<VisitorsLogs>();
       //     foreach (var entry in visitorLogsList)
       //     {
       //         GetVisitorDataByMeetingPerson(entry,SearchInput);
       //     }
       //     return AllLogs;
       // }
       // public static void GetVisitorDataByMeetingPerson(VisitorsLogs visitor,string searchInput)
       // {
       //     var entity = new VisitorsDatabaseContext();
       //     List<Visitors> visitorData = entity.Visitors.FromSql("select * from Visitors where VisitorId = @searchInput", new SqlParameter("@searchInput", visitor.VisitorId)).ToList<Visitors>();
       //     foreach (var result in visitorData)
       //     {
       //         VisitorsData entry = new VisitorsData();
       //         entry.NameOfVisitor = result.NameOfVisitor;
       //         entry.GovtIdProof = result.GovtIdProof;
       //         entry.Contact = result.Contact;
       //         entry.ComingFrom = visitor.ComingFrom;
       //         entry.WhomToMeet = visitor.WhomToMeet;
       //         entry.EmployeeId = visitor.EmployeeId;
       //         entry.TimeIn = visitor.TimeIn.ToString();
       //         entry.TimeOut = visitor.TimeOut.ToString();
       //         entry.VisitorId = visitor.VisitorId;
       //         entry.GuardId = visitor.GuardId;
       //         AllLogs.Add(entry);
       //     }
       // }
       // public static List<VisitorsData> GetVisitorLogByDate(string fromDate,string toDate,string fromTime,string toTime)
       // {
       //     if (fromTime == "" && toTime == "")
       //     {
       //         fromTime = "00:00:00";
       //         toTime = "23:59:59";
       //     }
       //     var entity = new VisitorsDatabaseContext();
       //     List<VisitorsLogs> visitorLogsList = entity.VisitorsLogs.FromSql("select * from VisitorsLogs where DateOfVisit between @fromDate And @toDate and TimeIn >= @fromTime and TimeOut <= @toTime", new SqlParameter("@fromDate", fromDate), new SqlParameter("@toDate", toDate), new SqlParameter("@fromTime", fromTime), new SqlParameter("@toTime", toTime)).ToList<VisitorsLogs>();
       //     foreach(var entry in visitorLogsList)
       //     {
       //         GetVisitorData(entry);
       //     }
       //     return AllLogs;
       // }
       // public static List<VisitorsData> GetVisitorDataByPurposeOfVisitor(string searchInput)
       // {
       //     var entity = new VisitorsDatabaseContext();
       //     List<VisitorsLogs> visitorLogsList = entity.VisitorsLogs.FromSql("select * from VisitorsLogs where PurposeOfVisit = @purpose", new SqlParameter("@purpose", searchInput)).ToList<VisitorsLogs>();
       //     foreach (var entry in visitorLogsList)
       //     {
       //         GetVisitorData(entry);
       //     }
       //     return AllLogs;
       // }
    }
}
