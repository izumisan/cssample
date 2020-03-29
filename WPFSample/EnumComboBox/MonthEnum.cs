using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EnumComboBox
{
    public enum MonthEnum
    {
        [Display( Name = "睦月" )]
        January = 1,
        [Display( Name = "如月" )]
        Februrary,
        [Display( Name = "弥生" )]
        March,
        [Display( Name = "卯月" )]
        April,
        [Display( Name = "皐月" )]
        May,
        [Display( Name = "水無月" )]
        June,
        [Display( Name = "文月" )]
        July,
        [Display( Name = "葉月" )]
        August,
        [Display( Name = "長月" )]
        September,
        [Display( Name = "神無月" )]
        October,
        [Display( Name = "霜月" )]
        November,
        [Display( Name = "師走" )]
        December
    }


    public static class MonthEnumExtension
    {
        public static string ToDisplayName( this MonthEnum self )
        {
            var attr = typeof( MonthEnum ).GetField( self.ToString() ).GetCustomAttribute<DisplayAttribute>();
            return attr?.Name ?? string.Empty;
        }
    }
}
