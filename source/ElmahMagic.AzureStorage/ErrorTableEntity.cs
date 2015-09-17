using Elmah;
using EmptyStringGuard;
using Microsoft.WindowsAzure.Storage.Table;
using NullGuard;
using ValidationFlags = EmptyStringGuard.ValidationFlags;

namespace ElmahMagic.AzureStorage
{
    [EmptyStringGuard(ValidationFlags.None)]
    [NullGuard(NullGuard.ValidationFlags.None)]
    public class ErrorTableEntity : TableEntity
    {
        internal static ErrorTableEntity FromError(Error error)
        {
            throw new System.NotImplementedException();
        }

        [return: AllowNull]
        public Error ToError()
        {
            throw new System.NotImplementedException();
        }
    }
}