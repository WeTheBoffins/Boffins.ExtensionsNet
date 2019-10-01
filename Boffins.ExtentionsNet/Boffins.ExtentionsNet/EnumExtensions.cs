using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Boffins.ExtentionsNet
{
    public static class EnumExtensions
    {
        public static Dictionary<int, string> ToDictionary<T>() where T : struct =>
            Enum.GetValues(typeof(T)).Cast<int>()
                .ToDictionary(v => v, v => Enum.GetName(typeof(T), v));

        public static Dictionary<int, string> ToDictionary(this Enum sourceEnum) =>
            Enum.GetValues(sourceEnum.GetType()).Cast<int>()
                .ToDictionary(v => v, v => Enum.GetName(sourceEnum.GetType(), v));

        public static T ToEnum<T>(this string input) where T : struct
        {
            Enum.TryParse<T>(input, true, out var result);

            return result;
        }

        public static string GetDescription(this Enum source)
        {
            var field = source.GetType().GetField(source.ToString());
            var attributes = (DescriptionAttribute[]) field.GetCustomAttributes(typeof(DescriptionAttribute), false);
           
            return attributes?.Length > 0 ? attributes[0].Description : source.ToString();
        }
    }
}