using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public Task<string> AddErrorAsync(ErrorRecord error)
        {
            throw new NotImplementedException();
            //var tableEntity = error.ToTableEntity();
            //_errorTable.Execute(TableOperation.Insert(tableEntity));
            //return tableEntity.RowKey;
        }

        [return: AllowNull]
        public Task<ErrorRecord> GetErrorAsync(string errorId)
        {
            throw new NotImplementedException();
            //var operation = TableOperation.Retrieve<ErrorTableEntity>("", errorId);
            //var result = _errorTable.Execute(operation);
            //var tableEntity = result.Result as ErrorTableEntity;
            //var error = tableEntity?.ToError();

            //return error;
        }

        public Task<int> GetErrorsAsync(int pageIndex, int pageSize, IDictionary<string, ErrorRecord> errors)
        {
            throw new NotImplementedException();
        }

        public static ErrorRepository FromConnectionString(string connectionString, string tableName)
        {
            return new ErrorRepository(connectionString, tableName);
        }
    }
}