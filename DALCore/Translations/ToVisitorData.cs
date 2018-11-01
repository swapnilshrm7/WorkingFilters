using DALCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using UI.Entities;

namespace Translations
{
    public class ToVisitorData
    {
        public List<VisitorData> TranslateToVisitorDataList(List<Visitors> VisitorDataList)
        {
            try
            {
                List<VisitorData> TranslatedList = new List<VisitorData>();
                foreach(var entry in VisitorDataList)
                {
                    VisitorData visitorData = new VisitorData();
                    visitorData.Contact = entry.Contact;
                    visitorData.Error = false;
                    visitorData.GovtIdProof = entry.GovtIdProof;
                    visitorData.NameOfVisitor = entry.NameOfVisitor;
                    visitorData.VisitorId = entry.VisitorId;
                    visitorData.VisitorImage = entry.VisitorImage;
                    TranslatedList.Add(visitorData);
                }
                return TranslatedList;
            }
            catch(Exception ex)
            {
                List<VisitorData> TranslatedList = new List<VisitorData>();
                TranslatedList[0].Error = true;
                return TranslatedList;
            }
        }
        public VisitorData TranslateToVisitorData(Visitors VisitorData)
        {
            try
            {
                    VisitorData visitorData = new VisitorData();
                    visitorData.Contact = VisitorData.Contact;
                    visitorData.Error = false;
                    visitorData.GovtIdProof = VisitorData.GovtIdProof;
                    visitorData.NameOfVisitor = VisitorData.NameOfVisitor;
                    visitorData.VisitorId = VisitorData.VisitorId;
                    visitorData.VisitorImage = VisitorData.VisitorImage;
                return visitorData;
            }
            catch (Exception ex)
            {
                VisitorData TranslatedData = new VisitorData();
                TranslatedData.Error = true;
                return TranslatedData;
            }
        }
    }
}
