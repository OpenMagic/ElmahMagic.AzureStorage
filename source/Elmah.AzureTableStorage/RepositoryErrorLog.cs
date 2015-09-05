using System;
using System.Collections;

namespace Elmah.AzureTableStorage
{
    public class RepositoryErrorLog : ErrorLog
    {
        private readonly IErrorRepository _errorRepository;

        public RepositoryErrorLog(IErrorRepository errorRepository)
        {
            _errorRepository = errorRepository;
        }

        /// <summary>
        ///     Logs an error in log for the application.
        /// </summary>
        /// <returns>
        ///     The id the error can be retrieved by
        /// </returns>
        public override string Log(Error error)
        {
            var entity = new ErrorTableEntity(error);
            _errorRepository.Add(entity);
            return entity.RowKey;
        }

        /// <summary>
        ///     Returns the specified error from the database, or null if it does not exist.
        /// </summary>
        public override ErrorLogEntry GetError(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Returns a page of errors from the database in descending order of logged time.
        /// </summary>
        public override int GetErrors(int pageIndex, int pageSize, IList errorEntryList)
        {
            throw new NotImplementedException();
        }
    }
}