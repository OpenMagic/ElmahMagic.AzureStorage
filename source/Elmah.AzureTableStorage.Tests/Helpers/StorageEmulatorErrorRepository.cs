using System;
using System.Collections.Generic;
using Elmah.AzureTableStorage.Helpers;
using Elmah.Repository;

namespace Elmah.AzureTableStorage.Tests.Helpers
{
    public class StorageEmulatorErrorRepository : IErrorRepository, IDisposable
    {
        private const string ConnectionString = "UseDevelopmentStorage=true;";
        private readonly ErrorRepository _repository;
        private readonly string _tableName;

        public StorageEmulatorErrorRepository()
        {
            WindowsAzureStorageEmulator.StartIfNotRunning();

            _tableName = $"Temp{Guid.NewGuid().ToString().Replace("-", "")}";
            _repository = ErrorRepository.FromConnectionString(ConnectionString, _tableName);
        }

        public void Dispose()
        {
            DeleteTableIfExists();
        }

        public string AddError(Error error)
        {
            return _repository.AddError(error);
        }

        public Error GetError(string errorId)
        {
            return _repository.GetError(errorId);
        }

        public int GetErrors(int pageIndex, int pageSize, IDictionary<string, Error> errors)
        {
            return _repository.GetErrors(pageIndex, pageSize, errors);
        }

        private void DeleteTableIfExists()
        {
            var table = CloudTableHelpers.GetTableReference(ConnectionString, _tableName, false);
            table.DeleteIfExists();
        }
    }
}