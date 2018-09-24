﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fenit.Toolbox.Core.Extension
{
    public static class StringExtension
    {
        #region DateTime
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
        #endregion

        #region TimeSpan

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

        public static string SumLabel(this TimeSpan? time)
        {
            if (time == null) return String.Empty;
            return time.Value.SumLabel();
        }

        public static string SumLabel(this TimeSpan time)
        {
            return $"{(int)time.TotalHours} godzin {time.Minutes} minut";
        }

        public static string SmallSumLabel(this TimeSpan? time)
        {
            if (time == null) return String.Empty;
            return time.Value.SmallSumLabel();
        }

        public static string SmallSumLabel(this TimeSpan time)
        {
            if (time.Minutes > 9) return $"{(int)time.TotalHours}:{time.Minutes}";
            return $"{(int)time.TotalHours}:0{time.Minutes}";
        }

        #endregion

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

        public static string GetInnerMessage(this Exception e)
        {
            var sb = new StringBuilder();
            sb.Append("Message:\n");
            sb.Append(e.Message);
            sb.Append("\nStackTrace:\n");
            sb.Append(e.StackTrace);
            sb.Append("\nInfo:\n");
            sb.Append(e);
            var ie = e.InnerException;
            if (ie != null)
            {
                sb.Append("\nInnerException:\n");
                sb.Append(GetInnerMessage(ie));
            }

            return sb.ToString();
        }

        public static string ToJsString(this string value)
        {
            var result = value.Replace(" ", "_");
            result = result.Replace(" ", "_");
            result = result.Replace(" ", "_");
            result = result.Replace(".", "");
            result = result.Replace(".", "");
            return result;
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