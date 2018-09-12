using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Text;
using Fenit.Core.Web.Log;

namespace Fenit.Core.Web.Extension
{
    public static class SystemExtension
    {
        public static void CatchDbEntityValidationException(Exception ex, string source)
        {

            var e = ex as DbEntityValidationException;
            if (e != null)
            {
                var result = new StringBuilder();
                foreach (var eve in e.EntityValidationErrors)
                {
                    result.Append(
                        String.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    result.Append(Environment.NewLine);
                    result.Append(
                        eve.ValidationErrors.Select(
                            ve => String.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage)));
                    result.Append(Environment.NewLine);

                }
                LoggerManager.Log(source, result.ToString());
            }
            else
            {
                LoggerManager.Log(source, ex);
            }
        }
        public static TimeSpan Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, TimeSpan> selector)
        {
            return source.Select(selector).Aggregate(TimeSpan.Zero, (t1, t2) => t1 + t2);
        }

        public static bool IntLenth(this int val, int lenth)
        {
            var valtring = val.ToString();
            return valtring.Length == lenth;
        }

        public static string SumLabel(this TimeSpan? time)
        {
            if (time == null)
            {
                return string.Empty;
            }
            return time.Value.SumLabel();
        }

        public static string SumLabel(this TimeSpan time)
        {

            return string.Format("{0} godzin {1} minut", (int)time.TotalHours, (int)time.Minutes);
        }

        public static string SmallSumLabel(this TimeSpan? time)
        {
            if (time == null)
            {
                return string.Empty;
            }
            return time.Value.SmallSumLabel();
        }

        public static string SmallSumLabel(this TimeSpan time)
        {
            if ((int)time.Minutes > 9)
            {
                return string.Format("{0}:{1}", (int)time.TotalHours, (int)time.Minutes);
            }
            return string.Format("{0}:0{1}", (int)time.TotalHours, (int)time.Minutes);

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

        public static string ToName(this System.Enum value)
        {
            var attribute = value.GetAttribute<DescriptionAttribute>();
            return attribute == null ? value.ToString() : attribute.Description;
        }

        public static T GetAttribute<T>(this System.Enum value) where T :Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return (T)attributes[0];
        }

        public static decimal DecimalTryParse(this string val)
        {
            decimal result = 0;
            if (val.Contains(","))
            {
                var numinf = new NumberFormatInfo { NumberDecimalSeparator = "," };
                result = decimal.Parse(val, numinf);
            }
            else
            {
                if (!string.IsNullOrEmpty(val) && !string.IsNullOrWhiteSpace(val))
                {
                    var numinf = new NumberFormatInfo { NumberDecimalSeparator = "." };
                    result = decimal.Parse(val, numinf);
                }
            }
            return result;
        }

        public static int? ConvertIntNullable(this string val)
        {
            var @int = 0;
            if (Int32.TryParse(val, out @int))
            {
                return @int;
            }
            return null;
        }

        public static int ConvertInt(this string val)
        {
            var @int = 0;
            Int32.TryParse(val, out @int);
            return @int;
        }

        public static short? ConvertShortNullable(this string val)
        {
            short @short = 0;
            if (Int16.TryParse(val, out @short))
            {
                return @short;
            }
            return null;
        }

        public static short ConvertShort(this string val)
        {
            short @short = 0;
            Int16.TryParse(val, out @short);
            return @short;
        }

    }
}