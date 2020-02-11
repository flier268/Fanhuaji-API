using System;
using System.Runtime.CompilerServices;

namespace Fanhuaji_API
{
    public class ColumnName : Attribute
    {
        public string Name { get; }
        internal bool Visible { get; }
        public ColumnName([CallerMemberName] string Name = null, bool Visible = true)
        {
            this.Name = Name;
            this.Visible = Visible;
        }
    }
}
