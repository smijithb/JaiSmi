using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JaiSmi.Code.Util
{
    public class DataCast
    {
        public static int ToInt(object value, int defaultValue = -1)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return defaultValue;
            }
        }

        public static DateTime ToDateTime(object value, DateTime? defaultValue = null)
        {
            try
            {
                return Convert.ToDateTime(value);
            }
            catch
            {
                return defaultValue == null ? DateTime.MinValue : (DateTime)defaultValue;
            }
        }
    }
}