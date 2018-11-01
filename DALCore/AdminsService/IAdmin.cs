using Core.Contracts;
using Core.Contracts.Models;
using DALCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using UI.Entities;

namespace AdminsService
{
    public interface IAdmin
    {
        List<AllLogs> GetAllLogs();
        List<AllLogs> GuardLogsToAllLogs(List<GuardData> GuardData);
        List<AllLogs> VisitorsLogsToAllLogs(List<VisitorsData> VisitorData);
        List<AllLogs> EmployeeLogsToAllLogs(List<EmployeeData> EmployeeData);
    }
}
