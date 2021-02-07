using System;
using System.Collections.Generic;

namespace lib
{
    public class Methods
    {
        public static int GetSemestry()
        {
            var month = DateTime.Now.Month;
            if (month >= 9 && month <= 12)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
        public static string GetMonth()
        {
            string[] months = new string[]{
                "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь","Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"
            };
            int month = DateTime.Now.Month;
            return months[month - 1];
        }
        public static string date(string toDate)
        {
            List<string> months = new List<string>{
                "Января","Февраля","Марта","Апреля","Май","Июня","Июля","Августа","Сентября","Октября","Ноября","Декабря"
            };
            var date = DateTime.Parse(toDate);
            var day = date.Day;
            var month = months[date.Month - 1];
            var year = date.Year + " года";
            var hour = date.TimeOfDay;
            var dd = day + " " + month + " " + year;
            var result = new
            {
                date = dd,
                hour = hour,
                day = day,
                month = month,
                year = year
            };
            return dd;
        }

    }
}