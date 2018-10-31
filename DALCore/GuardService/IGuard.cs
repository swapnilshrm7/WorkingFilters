using Core.Contracts;
using DALCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuardService
{
    public interface IGuard
    {
        List<GuardData> GetAllGuardsFromLog();
        List<GuardData> GetGuardsLogByName(string searchInput);
        List<GuardData> GetGuardLogByDateAndTime(string fromDate, string toDate, string fromTime, string toTime);
        List<Guard> GetUniqueGuards();
        List<Guard> GetUniqueGuardsByName(string searchInput);
        bool DeleteGuard(string GuardId);
        bool AddGuard(Guard NewGuard);
        bool EditExistingGuard(Guard details);
        Guard GetGuardDetailsById(string GuardId);
        string AddGuardLogAtLogin(string GuardId);
        string EditGuardLogAtLogOut(string GuardId);
    }
}
