using System.Collections.Generic;

namespace service.Main.Extention
{
    public static class Extentions
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
    }
}