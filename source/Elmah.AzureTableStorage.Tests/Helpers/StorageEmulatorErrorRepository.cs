using System;
using Elmah.AzureTableStorage.Helpers;

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

        public void Add(ErrorTableEntity errorTableEntity)
        {
            _repository.Add(errorTableEntity);
        }

        public ErrorTableEntity Find(string errorId)
        {
            return _repository.Find(errorId);
        }

        private void DeleteTableIfExists()
        {
            var table = CloudTableHelpers.GetTableReference(ConnectionString, _tableName, false);
            table.DeleteIfExists();
        }
    }
}