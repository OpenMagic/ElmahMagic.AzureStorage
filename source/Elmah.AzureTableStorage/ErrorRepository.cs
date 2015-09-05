using Elmah.AzureTableStorage.Helpers;
using Microsoft.WindowsAzure.Storage.Table;
using NullGuard;

namespace Elmah.AzureTableStorage
{
    public class ErrorRepository : IErrorRepository
    {
        private readonly CloudTable _errorTable;

        private ErrorRepository(string connectionString, string tableName)
        {
            _errorTable = CloudTableHelpers.GetTableReference(connectionString, tableName);
        }

        public void Add(ErrorTableEntity errorTable)
        {
            _errorTable.Execute(TableOperation.Insert(errorTable));
        }

        [return: AllowNull]
        public ErrorTableEntity Find(string errorId)
        {
            var operation = TableOperation.Retrieve<ErrorTableEntity>("", errorId);
            var result = _errorTable.Execute(operation);

            return result.Result as ErrorTableEntity;
        }

        public static ErrorRepository FromConnectionString(string connectionString, string tableName)
        {
            return new ErrorRepository(connectionString, tableName);
        }
    }
}