using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Elmah.Repository
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
            return _errorRepository.AddError(error);
        }

        /// <summary>
        ///     Returns the specified error from the database, or null if it does not exist.
        /// </summary>
        public override ErrorLogEntry GetError(string id)
        {
            var error = _errorRepository.GetError(id);
            var entry = new ErrorLogEntry(this, id, error);

            return entry;
        }

        /// <summary>
        ///     Updates errorEntryList with a page of errors from the repository in descending order of logged time and returns
        ///     total number of entries
        /// </summary>
        public override int GetErrors(int pageIndex, int pageSize, IList errorEntryList)
        {
            var errors = new Dictionary<string, Error>();

            var totalCount = _errorRepository.GetErrors(pageIndex, pageSize, errors);
            var errorLogEntries = errors.Select(error => new ErrorLogEntry(this, error.Key, error.Value));

            foreach (var errorLogEntry in errorLogEntries)
            {
                errorEntryList.Add(errorLogEntry);
            }

            return totalCount;
        }
    }
}