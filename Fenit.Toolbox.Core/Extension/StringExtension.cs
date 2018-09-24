using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Fenit.Toolbox.Core.Extension
{
    public static class StringExtension
    {
        public static string AsSmallString(this DateTime val, string format)
        {
            return val.ToString(format);
        }

        public static string AsSmallString(this DateTime? val, string format)
        {
            return val.HasValue ? val.Value.AsSmallString(format) : string.Empty;
        }
        public static string AsSmallString(this DateTime val)
        {
            return val.ToString("yyyy-MM-dd");
        }

        public static string AsSmallString(this DateTime? val)
        {
            return val.HasValue ? val.Value.AsSmallString() : string.Empty;
        }
        public static string AsLongString(this DateTime val)
        {
            return val.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string AsLongString(this DateTime? val)
        {
            return val.HasValue ? val.Value.AsLongString() : string.Empty;
        }

        public static string AsStringHMS(this TimeSpan val)
        {
            return val.ToString(@"hh\:mm\:ss");
        }

        public static string AsStringHM(this TimeSpan val)
        {
            return val.ToString(@"hh\:mm");
        }

        public static string AsStringMS(this TimeSpan? val)
        {
            return val.HasValue ? val.Value.AsStringMS() : string.Empty;
        }

        public static string AsStringMS(this TimeSpan val)
        {
            return val.ToString(@"mm\:ss");
        }

        public static string AsStringHMS(this TimeSpan? val)
        {
            return val.HasValue ? val.Value.AsStringHMS() : "00:00:00";
        }

        public static string AsString(this decimal val)
        {
            return val.ToString("##.##");
        }

        public static string AsPln(this decimal val)
        {
            if (val > 0)
            {
                return val.ToString("##.## zł");
            }
            return String.Empty;

        }

        public static string AsString(this decimal? val)
        {
            return val != null ? val.Value.AsString() : string.Empty;
        }

        public static DateTime? AsNullDateTime(this string val)
        {
            return val.AsNullDateTime("yyyy-MM-dd");
        }

        public static TimeSpan AsTimeSpan(this string val)
        {
            var table = val.Split(':');
            int h;
            if (int.TryParse(table[0], out h))
            {
                int m;
                if (int.TryParse(table[1], out m))
                {
                    return new TimeSpan(h, m, 0);
                }
            }

            return new TimeSpan();
        }


        public static DateTime? AsNullDateTime(this string val, string format)
        {
            DateTime intervalVal;
            if (DateTime.TryParseExact(val,
                format,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out intervalVal))
            {
                return intervalVal;
            }
            return null;
        }


        public static DateTime AsDateTime(this string val, string format)
        {
            var dt = val.AsNullDateTime(format);
            if (dt != null)
            {
                return (DateTime)dt;
            }
            return DateTime.MinValue;
        }

        public static DateTime AsDateTime(this string val)
        {
            var dt = val.AsNullDateTime();
            if (dt != null)
            {
                return (DateTime)dt;
            }
            return DateTime.MinValue;
        }

        public static decimal AsDecimal(this string val)
        {
            var newString = val.Replace("zł", "").Trim();
            decimal result;
            decimal.TryParse(newString, out result);
            return result;
        }

        public static string ListAsString(this IEnumerable<int> list)
        {
            var result = string.Empty;
            var firts = false;
            foreach (var i in list)
            {
                if (firts)
                {
                    result += ", ";
                }
                result += i.ToString();
                firts = true;
            }
            return result;
        }

        public static string ListAsString(this IEnumerable<string> list)
        {
            var result = string.Empty;
            var firts = false;
            foreach (var i in list.OrderBy(w => w))
            {
                if (firts)
                {
                    result += ", ";
                }
                result += i;
                firts = true;
            }
            return result;
        }

        public static string AsString(this List<string> val)
        {
            var result = string.Empty;
            foreach (var row in val)
            {
                result += row;
                result += Environment.NewLine;
            }
            return result;
        }
    }

}