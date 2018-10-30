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

namespace DALCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        [HttpGet]
        [Route("api/[controller]/Excel")]
        public string Export()
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
                // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Employees");
                //First add the headers
                worksheet.Cells[1, 1].Value = "ID";
                worksheet.Cells[1, 2].Value = "Name";
                worksheet.Cells[1, 3].Value = "Email";
                worksheet.Cells[1, 4].Value = "Contact NO.";

                var entity = new VisitorsDatabaseContext();
                List<Employees> AllEmployees = entity.Employees.FromSql("select * from Employees").ToList<Employees>();
                //Add values
                int i = 1;
                foreach (var entry in AllEmployees)
                {
                    i++;
                    string rowNumber = i.ToString();
                    worksheet.Cells["A" + rowNumber].Value = entry.EmployeeId;
                    worksheet.Cells["B" + rowNumber].Value = entry.EmployeeName;
                    worksheet.Cells["C" + rowNumber].Value = entry.EmailId;
                    worksheet.Cells["D" + rowNumber].Value = entry.PrimaryContactNumber;
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
    }
}