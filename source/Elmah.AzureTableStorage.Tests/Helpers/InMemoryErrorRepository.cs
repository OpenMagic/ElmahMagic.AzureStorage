using System.Collections.Generic;
using Elmah.Repository;

namespace Elmah.AzureTableStorage.Tests.Helpers
{
    public class InMemoryErrorRepository : IErrorRepository
    {
        public string AddError(Error error)
        {
            throw new System.NotImplementedException();
        }

        public Error GetError(string errorId)
        {
            throw new System.NotImplementedException();
        }

        public int GetErrors(int pageIndex, int pageSize, IDictionary<string, Error> errors)
        {
            throw new System.NotImplementedException();
        }
    }
}