using Elmah.AzureTableStorage.Helpers;
using EmptyStringGuard;
using Microsoft.WindowsAzure.Storage.Table;
using NullGuard;
using ValidationFlags = EmptyStringGuard.ValidationFlags;

namespace Elmah.AzureTableStorage
{
    [EmptyStringGuard(ValidationFlags.None)]
    [NullGuard(NullGuard.ValidationFlags.None)]
    public class ErrorTableEntity : TableEntity
    {
        public ErrorTableEntity()
        {
            // todo: fody
        }

        public ErrorTableEntity(Error error) : this(Elmah.ErrorXml.EncodeString(error))
        {
        }

        private ErrorTableEntity(string errorXml) : base("", TableEntityHelpers.DescendingOrderRowKey())
        {
            ErrorXml = errorXml;
        }

        public string ErrorXml { get; set; }
    }
}