using System;

namespace Elmah.AzureTableStorage.Helpers
{
    public class TableEntityHelpers
    {
        public static string DescendingOrderRowKey()
        {
            return $"{(DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks).ToString("d19")}-{Guid.NewGuid()}";
        }
    }
}