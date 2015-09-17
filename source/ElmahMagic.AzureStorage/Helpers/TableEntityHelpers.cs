using System;

namespace ElmahMagic.AzureStorage.Helpers
{
    public class TableEntityHelpers
    {
        public static string DescendingOrderRowKey()
        {
            return $"{(DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks).ToString("d19")}-{Guid.NewGuid()}";
        }
    }
}