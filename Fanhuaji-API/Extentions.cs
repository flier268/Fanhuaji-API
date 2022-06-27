using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Fanhuaji_API
{
    internal static class Extentions
    {
        internal static string GetColumnName(this PropertyInfo property)
        {
            return property.GetCustomAttribute<JsonPropertyNameAttribute>().Name ?? property.Name;
        }

        internal static bool GetVisible(this PropertyInfo property)
        {
            return property.GetCustomAttribute<JsonIgnoreAttribute>() != null;
        }
    }
}