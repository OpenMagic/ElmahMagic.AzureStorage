using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public Task<string> AddErrorAsync(ErrorRecord error)
        {
            return _repository.AddErrorAsync(error);
        }

        public Task<ErrorRecord> GetErrorAsync(string errorId)
        {
            return _repository.GetErrorAsync(errorId);
        }

        public Task<int> GetErrorsAsync(int pageIndex, int pageSize, IDictionary<string, ErrorRecord> errors)
        {
            return _repository.GetErrorsAsync(pageIndex, pageSize, errors);
        }

        private void DeleteTableIfExists()
        {
            var table = CloudTableHelpers.GetTableReference(ConnectionString, _tableName, false);
            table.DeleteIfExists();
        }
    }
}