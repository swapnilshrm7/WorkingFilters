using Core.Contracts;
using Core.Contracts.Models;
using DALCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLDatabase
{
    public class VisitorDatabase
    {
        public List<VisitorsLogs> GetAllVisitorLogs()
        {
            VisitorsDatabaseContext dbContext = new VisitorsDatabaseContext();
            var allVisitorLogs = dbContext.VisitorsLogs.ToList<VisitorsLogs>();
            return allVisitorLogs;
        }
        public List<VisitorsLogs> GetVisitorLogsById(int visitorId)
        {
            VisitorsDatabaseContext dbContext = new VisitorsDatabaseContext();
            var visitorLogs = dbContext.VisitorsLogs.Where(x => x.VisitorId == visitorId).ToList();
            return visitorLogs;
        }
        public List<VisitorsLogs> GetVisitorLogsByWhomToMeet(string meetingPerson)
        {
            VisitorsDatabaseContext dbContext = new VisitorsDatabaseContext();
            var visitorLogs = dbContext.VisitorsLogs.Where(x => x.WhomToMeet.Equals(meetingPerson)).ToList();
            return visitorLogs;
        }


        public Visitors GetVisitorById(int visitorId)
        {
            VisitorsDatabaseContext dbContext = new VisitorsDatabaseContext();
            var visitor = dbContext.Visitors.Find(visitorId);
            return visitor;
        }
        public List<Visitors> GetVisitorsByName(string visitorName)
        {
            VisitorsDatabaseContext dbContext = new VisitorsDatabaseContext();
            var visitors = dbContext.Visitors.Where(x => x.NameOfVisitor.Equals(visitorName)).ToList();
            return visitors;
        }
        public void AddNewVisitor(string nameOfVisitor, string contactNo, string govtIdProof)
        {
            VisitorsDatabaseContext dbContext = new VisitorsDatabaseContext();
            Visitors newVisitor = new Visitors();
            newVisitor.NameOfVisitor = nameOfVisitor;
            newVisitor.Contact = contactNo;
            newVisitor.GovtIdProof = govtIdProof;
            dbContext.Visitors.Add(newVisitor);
            dbContext.SaveChanges();
        }
        //public void AddVisitorLog(string nameOfVisitor, string contactNo, string govtIdProof, string comingFrom, string whomToMeet, string purposeOfVisit, string guardId)
        //{
        //    VisitorsDatabaseContext dbContext = new VisitorsDatabaseContext();
        //    VisitorsData newVisitor = new VisitorsData();
        //    newVisitor.NameOfVisitor = nameOfVisitor;
        //    newVisitor.Contact = contactNo;
        //    newVisitor.GovtIdProof = govtIdProof;
        //    newVisitor.WhomToMeet = whomToMeet;
    
        //    dbContext.Visitors.Add(newVisitor);
        //    dbContext.SaveChanges();
        //}
        
    }
}
