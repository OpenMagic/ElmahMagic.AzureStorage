using System.Collections.Generic;

namespace Elmah.AzureTableStorage.Tests.Helpers
{
    public class InMemoryErrorRepository : IErrorRepository
    {
        private readonly Dictionary<string, ErrorTableEntity> _errors = new Dictionary<string, ErrorTableEntity>();

        public void Add(ErrorTableEntity errorTable)
        {
            _errors.Add(errorTable.RowKey, errorTable);
        }

        public ErrorTableEntity Find(string errorId)
        {
            return _errors[errorId];
        }
    }
}