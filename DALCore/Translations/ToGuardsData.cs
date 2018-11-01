using DALCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using UI.Entities;

namespace Translations
{
    public class ToGuardsData
    {
        public List<GuardsData> TranslateToGuardsDataList(List<Guard> GuardList)
        {
            try
            {
                List<GuardsData> TranslatedData = new List<GuardsData>();
                foreach(var entry in GuardList)
                {
                    GuardsData Guard = new GuardsData();
                    Guard.BloodGroup = entry.BloodGroup;
                    Guard.DateOfBirth = entry.DateOfBirth;
                    Guard.DateOfJoining = entry.DateOfJoining;
                    Guard.DateOfResignation = entry.DateOfResignation;
                    Guard.EmailId = entry.EmailId;
                    Guard.EmergencyContactNumber = entry.EmergencyContactNumber;
                    Guard.EmergencyContactPerson = entry.EmergencyContactPerson;
                    Guard.GuardId = entry.GuardId;
                    Guard.GuardName = entry.GuardName;
                    Guard.GuardStatus = entry.GuardStatus;
                    Guard.Error = false;
                    Guard.Gender = entry.Gender;
                    Guard.LocalAddress = entry.LocalAddress;
                    Guard.MedicalSpecification = entry.MedicalSpecification;
                    Guard.PermanentAddress = entry.PermanentAddress;
                    Guard.PrimaryContactNumber = entry.PrimaryContactNumber;
                    Guard.Remark = entry.Remark;
                    Guard.SecondaryContactNumber = entry.SecondaryContactNumber;
                    TranslatedData.Add(Guard);
                }
                return TranslatedData;
            }
            catch(Exception ex)
            {
                List<GuardsData> TranslatedData = new List<GuardsData>();
                TranslatedData[0].Error = true;
                return TranslatedData;
            }
        }
        public GuardsData TranslateToGuardsData(Guard GuardData)
        {
            try
            {
                    GuardsData Guard = new GuardsData();
                    Guard.BloodGroup = GuardData.BloodGroup;
                    Guard.DateOfBirth = GuardData.DateOfBirth;
                    Guard.DateOfJoining = GuardData.DateOfJoining;
                    Guard.DateOfResignation = GuardData.DateOfResignation;
                    Guard.EmailId = GuardData.EmailId;
                    Guard.EmergencyContactNumber = GuardData.EmergencyContactNumber;
                    Guard.EmergencyContactPerson = GuardData.EmergencyContactPerson;
                    Guard.GuardId = GuardData.GuardId;
                    Guard.GuardName = GuardData.GuardName;
                    Guard.GuardStatus = GuardData.GuardStatus;
                    Guard.Error = false;
                    Guard.Gender = GuardData.Gender;
                    Guard.LocalAddress = GuardData.LocalAddress;
                    Guard.MedicalSpecification = GuardData.MedicalSpecification;
                    Guard.PermanentAddress = GuardData.PermanentAddress;
                    Guard.PrimaryContactNumber = GuardData.PrimaryContactNumber;
                    Guard.Remark = GuardData.Remark;
                    Guard.SecondaryContactNumber = GuardData.SecondaryContactNumber;
                return Guard;
            }
            catch (Exception ex)
            {
                GuardsData TranslatedData = new GuardsData();
                TranslatedData.Error = true;
                return TranslatedData;
            }
        }
    }
}
