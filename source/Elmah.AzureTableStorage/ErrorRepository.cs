using System;
using System.Collections.Generic;
using Elmah.AzureTableStorage.Helpers;
using Elmah.Repository;
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

        public string AddError(Error error)
        {
            var tableEntity = ErrorTableEntity.FromError(error);
            _errorTable.Execute(TableOperation.Insert(tableEntity));
            return tableEntity.RowKey;
        }

        [return: AllowNull]
        public Error GetError(string errorId)
        {
            var operation = TableOperation.Retrieve<ErrorTableEntity>("", errorId);
            var result = _errorTable.Execute(operation);
            var tableEntity = result.Result as ErrorTableEntity;
            var error = tableEntity?.ToError();

            return error;
        }

        public int GetErrors(int pageIndex, int pageSize, IDictionary<string, Error> errors)
        {
            throw new NotImplementedException();
        }

        public static ErrorRepository FromConnectionString(string connectionString, string tableName)
        {
            return new ErrorRepository(connectionString, tableName);
        }
    }
}