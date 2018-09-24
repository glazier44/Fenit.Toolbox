using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Fenit.Toolbox.Core.Extension
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
                        $"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation errors:");
                    result.Append(Environment.NewLine);
                    result.Append(
                        eve.ValidationErrors.Select(
                            ve => $"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\""));
                    result.Append(Environment.NewLine);
                }

                // LoggerManager.Log(source, result.ToString());
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
            if (time == null) return string.Empty;
            return time.Value.SumLabel();
        }

        public static string SumLabel(this TimeSpan time)
        {
            return $"{(int) time.TotalHours} godzin {time.Minutes} minut";
        }

        public static string SmallSumLabel(this TimeSpan? time)
        {
            if (time == null) return string.Empty;
            return time.Value.SmallSumLabel();
        }

        public static string SmallSumLabel(this TimeSpan time)
        {
            if (time.Minutes > 9) return $"{(int) time.TotalHours}:{time.Minutes}";
            return $"{(int) time.TotalHours}:0{time.Minutes}";
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

        public static T GetAttribute<T>(this System.Enum value) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return (T) attributes[0];
        }

        public static decimal DecimalTryParse(this string val)
        {
            decimal result = 0;
            if (val.Contains(","))
            {
                var numinf = new NumberFormatInfo {NumberDecimalSeparator = ","};
                result = decimal.Parse(val, numinf);
            }
            else
            {
                if (!string.IsNullOrEmpty(val) && !string.IsNullOrWhiteSpace(val))
                {
                    var numinf = new NumberFormatInfo {NumberDecimalSeparator = "."};
                    result = decimal.Parse(val, numinf);
                }
            }

            return result;
        }

        public static int? ConvertIntNullable(this string val)
        {
            if (int.TryParse(val, out var @int)) return @int;
            return null;
        }

        public static int ConvertInt(this string val)
        {
            int.TryParse(val, out var @int);
            return @int;
        }

        public static short? ConvertShortNullable(this string val)
        {
            if (short.TryParse(val, out var @short)) return @short;
            return null;
        }

        public static short ConvertShort(this string val)
        {
            short.TryParse(val, out var @short);
            return @short;
        }
    }
}