using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Fanhuaji_API
{
    internal static class Extentions
    {
        internal static string GetColumnName(this PropertyInfo property)
        {
            var attr = (ColumnName[])property.GetCustomAttributes(typeof(ColumnName), false);
            if (attr.Length > 0)
                return attr[0].Name ?? property.Name;
            else
                return property.Name;
        }
        internal static bool GetVisible(this PropertyInfo property)
        {
            var attr = (ColumnName[])property.GetCustomAttributes(typeof(ColumnName), false);
            if (attr.Length > 0)
                return attr[0].Visible;
            else
                return true;
        }
    }
}
