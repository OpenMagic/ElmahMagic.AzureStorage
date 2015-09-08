using System;
using NullGuard;

namespace Elmah.Repository.Helpers.ValueFormatter
{

    internal class NullValueFormatter : IValueFormatter
    {
        public bool CanFormat(TypeCode typeCode, [AllowNull]object value)
        {
            return value == null;
        }

        [return: AllowNull]
        public object Format(TypeCode typeCode, [AllowNull]object value)
        {
            return null;
        }
    }
}