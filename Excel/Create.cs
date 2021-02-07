﻿using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.IO;

namespace Excel
{
    public class Create
    {
        public byte[] Build(Action<ExcelPackage> result)
        {
            var package = new ExcelPackage();
            result(package);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            return package.GetAsByteArray();
        }

        public void Build(Action<ExcelPackage> result, string path)
        {
            //Build new Excel file
            var package = new ExcelPackage();
            result(package);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            package.SaveAs(path switch
            {
                "." => new FileInfo($@"{Directory.GetCurrentDirectory()}\\worksheet.xlsx".Replace("\'", "\\'")),
                _ => new FileInfo($@"{path}.xlsx".Replace("\'", "\\'"))
            });
        }
    }

    public class Package
    {
        public ExcelPackage package { get; private set; }
        public Package()
        {
            package = new ExcelPackage();
        }

        public WorkSheet addWorkSheet(string worksheetName)
        {
            return new WorkSheet(package, worksheetName);
        }
    }

    public static class ExcelResult
    {
        public static FileContentResult Excel(this ControllerBase obj, Action<Package> result, string fileName = "file")
        {
            var package = new Package();
            result(package);
            return obj.File(
                fileContents: package.package.GetAsByteArray(),
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: fileName + ".xlsx");
        }
    }
}
