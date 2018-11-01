using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using DALCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using Core.Contracts.Models;
using AdminsService;

namespace DALCore.Controllers
{
    [ApiController]
    public class AdminController : ControllerBase
    {
        IAdmin admin;
        public AdminController(IAdmin _admin)
        {
            admin = _admin;
        }
        [HttpPut]
        [Route("api/[controller]/Excel")]
        public string Export([FromBody]SearchFilter input)
        {
            string sWebRootFolder = "C:\\";
            string sFileName = @"demo.xlsx";
            string URL = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, sFileName);
            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            if (file.Exists)
            {
                file.Delete();
                file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            }
            using (ExcelPackage package = new ExcelPackage(file))
            {
                var entity = new DatabaseContext();
                if (input.UserInput == "Employees")
                {
                    // add a new worksheet to the empty workbook
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Employees");
                    //First add the headers
                    worksheet.Cells[1, 1].Value = "LogId";
                    worksheet.Cells[1, 2].Value = "EmployeeId";
                    worksheet.Cells[1, 3].Value = "EmployeeName";
                    worksheet.Cells[1, 4].Value = "DateOfVisit";
                    worksheet.Cells[1, 5].Value = "TimeOfEntry";
                    worksheet.Cells[1, 6].Value = "DateOfExit";
                    worksheet.Cells[1, 7].Value = "TimeOfExit";

                    List<EmployeeLogs> AllEmployeeLogs = entity.EmployeeLogs.ToList<EmployeeLogs>();
                    //Add values
                    int i = 1;
                    foreach (var entry in AllEmployeeLogs)
                    {
                        i++;
                        string rowNumber = i.ToString();
                        worksheet.Cells["A" + rowNumber].Value = entry.LogId;
                        worksheet.Cells["B" + rowNumber].Value = entry.EmployeeId;
                        worksheet.Cells["C" + rowNumber].Value = entry.EmployeeName;
                        worksheet.Cells["D" + rowNumber].Value = entry.DateOfVisit.ToString();
                        worksheet.Cells["E" + rowNumber].Value = entry.TimeOfEntry.ToString();
                        worksheet.Cells["F" + rowNumber].Value = entry.DateOfExit.ToString();
                        worksheet.Cells["G" + rowNumber].Value = entry.TimeOfExit.ToString();
                    }
                }
                else if (input.UserInput == "Visitor")
                {
                    // add a new worksheet to the empty workbook
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Visitors");
                    //First add the headers
                    worksheet.Cells[1, 1].Value = "LogId";
                    worksheet.Cells[1, 2].Value = "ComingFrom";
                    worksheet.Cells[1, 3].Value = "WhomToMeet";
                    worksheet.Cells[1, 4].Value = "DateOfVisit";
                    worksheet.Cells[1, 5].Value = "TimeIn";
                    worksheet.Cells[1, 6].Value = "TimeOut";
                    worksheet.Cells[1, 7].Value = "VisitorId";
                    worksheet.Cells[1, 8].Value = "GuardId";
                    worksheet.Cells[1, 9].Value = "PurposeOfVisit";
                    List<VisitorsLogs> AllVisitorsLogs = entity.VisitorsLogs.ToList<VisitorsLogs>();
                    //Add values
                    int i = 1;
                    foreach (var entry in AllVisitorsLogs)
                    {
                        i++;
                        string rowNumber = i.ToString();
                        worksheet.Cells["A" + rowNumber].Value = entry.LogId;
                        worksheet.Cells["B" + rowNumber].Value = entry.ComingFrom;
                        worksheet.Cells["C" + rowNumber].Value = entry.WhomToMeet;
                        worksheet.Cells["D" + rowNumber].Value = entry.DateOfVisit.ToString();
                        worksheet.Cells["E" + rowNumber].Value = entry.TimeIn.ToString();
                        worksheet.Cells["F" + rowNumber].Value = entry.TimeOut.ToString();
                        worksheet.Cells["G" + rowNumber].Value = entry.VisitorId;
                        worksheet.Cells["H" + rowNumber].Value = entry.GuardId;
                        worksheet.Cells["I" + rowNumber].Value = entry.PurposeOfVisit;
                    }
                }
                    package.Save(); //Save the workbook.
                var credentials = new BasicAWSCredentials("AKIAJJR3X7CVOZZAUB5A", "eRFGQOM9tkv4MPX3EnLLoC19lxeIqL5myvI/Z2/6");
                AmazonS3Client client = new AmazonS3Client(credentials, RegionEndpoint.APSouth1);

                // Create a PutObject request
                Amazon.S3.Model.PutObjectRequest request = new Amazon.S3.Model.PutObjectRequest
                {
                    BucketName = "visitors-excel",
                    Key = "Item1.xlsx",
                    FilePath = @"C:\\demo.xlsx",
                    CannedACL = S3CannedACL.PublicRead
                };

                // Put object
                //var response = 
                client.PutObjectAsync(request);
            }
            return "https://s3.ap-south-1.amazonaws.com/visitors-excel/Item1.xlsx";
        }
        [HttpPut]
        [Route("api/[controller]/GetAllLogs")]
        public List<AllLogs> getAllLogs([FromBody]SearchFilter userId)
        {
            return admin.GetAllLogs().OrderByDescending(entry=>entry.IndateInTime).ToList<AllLogs>();
        }
    }
}