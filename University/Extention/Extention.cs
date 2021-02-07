using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Newtonsoft.Json.JsonConvert;

namespace Extention
{
    public static class File
    {

        public static async Task<string> AddFile(this IWebHostEnvironment _appEnvironment, IFormFile file, string type, string group)
        {
            string path = $"\\{type}\\{group}\\" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + "_" + file.FileName;
            using FileStream fileStream = new FileStream(_appEnvironment.WebRootPath + path, System.IO.FileMode.Create);
            await file.CopyToAsync(fileStream);
            return "\\wwwroot\\" + path;
        }

        public static dynamic readJson(this ControllerBase obj, string fileName, string key)
        {
            var build = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile(fileName).Build();
            return build[key];
        }
        public static dynamic AppSetting(this ControllerBase obj, string key)
        {
            var build = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json").Build();
            return build[key];
        }
    }

    public static class Sessions
    {
        public static void updateData<T>(this ControllerBase obj, string key, T array)
        {
            obj.HttpContext.Session.Remove(key);
            obj.HttpContext.Session.SetString(key, JsonConvert.SerializeObject(array));
        }

        public static void removeData<T>(this ControllerBase obj, string key)
        {
            obj.HttpContext.Session.Remove(key);
        }

        public static async Task<T> getSession<T>(this ControllerBase obj, string key)
        {
            string temp = obj.HttpContext.Session.GetString(key);
            T deserialized = JsonConvert.DeserializeObject<T>(temp);
            return await Task.Run(() => deserialized);
        }
    }


    public static class Hash
    {

        public static async Task<string> GetHash(this string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            return await Task.Run(() => Convert.ToBase64String(hash));
        }
        public static async Task<string> Sha256Hash(this string value)
        {
            StringBuilder Sb = new StringBuilder();

            using SHA256 hash = SHA256Managed.Create();

            var enc = Encoding.UTF8;
            Byte[] result = hash.ComputeHash(enc.GetBytes(value));

            foreach (Byte b in result)
                Sb.Append(b.ToString("x2"));

            return await Task.Run(() => Sb.ToString());
        }
    }

    public static class Sort
    {
        public static List<T> Paginate<T>(this List<T> objects, int page = 1, int count = 7)
        {
            List<T> retArr = new List<T>();

            page = (page - 1) * count;
            count = page + count;

            if (objects.Count > count)
            {
                for (int i = page; i < count; i++)
                {
                    retArr.Add(objects[i]);
                }
            }
            else
            {
                for (int i = page; i < objects.Count; i++)
                {
                    retArr.Add(objects[i]);
                }
            }
            return retArr;
        }


        public static List<Dictionary<string, string>> toJson<T>(this List<T> listOfObj)
        {
            string[] converted = listOfObj.Select(e => SerializeObject(e)
                                          .Replace("{", "")
                                          .Replace("}", "")
                                          .Replace("\"", ""))
                                          .ToArray();

            List<Dictionary<string, string>> dict = new List<Dictionary<string, string>>();
            for (int i = 0; i < converted.Count(); i++)
            {
                Dictionary<string, string> tempDict = new Dictionary<string, string>();
                string[] tempArr = converted[i].Split(",");
                for (int o = 0; o < tempArr.Count(); o++)
                {
                    string[] finalEl = tempArr[o].Split(":", 2);
                    tempDict[finalEl[0]] = finalEl[1];
                }
                dict.Add(tempDict);
            }
            return dict;
        }

        public static Dictionary<string, string> toJson<T>(T obj)
        {
            string converted = SerializeObject(obj).Replace("{", "").Replace("}", "").Replace("\"", "");
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            string[] tempArr = converted.Split(",");
            var first = tempArr[0].Split(":");
            if (first[1] == "0")
            {
                Dict[first[0]] = "null";
            }
            else
            {
                Dict[first[0]] = first[1];
            }
            for (int o = 1; o < tempArr.Count(); o++)
            {
                string[] finalEl = tempArr[o].Split(":", 2);
                Dict[finalEl[0]] = finalEl[1];
            }
            return Dict;
        }

    }





    // public static List<Dictionary<int, int>> statist<T>(this List<T> list)
    // {
    //     //test 
    //     var returnVal = new List<Dictionary<int, int>>(){
    //             list.Select(dict => new{
    //                 name = Convert.ToInt32(dict.ProductId),
    //                 count = list.Count(s => s == dict)})
    //                    .Where(obj => obj.count > 0 )
    //                    .Distinct()
    //                    .ToDictionary(obj => obj.name, obj => obj.count)
    //         };
    //     return returnVal;
    // }

}