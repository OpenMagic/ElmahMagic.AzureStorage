using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Elmah.Repository.Helpers;

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
            // todo: proper async support
            return _errorRepository.AddErrorAsync(error.ToErrorRecord()).Result;
        }

        /// <summary>
        ///     Returns the specified error from the database, or null if it does not exist.
        /// </summary>
        public override ErrorLogEntry GetError(string id)
        {
            // todo: proper async support
            var errorMessage = _errorRepository.GetErrorAsync(id).Result;
            var entry = new ErrorLogEntry(this, id, errorMessage.ToError());

            return entry;
        }

        /// <summary>
        ///     Updates errorEntryList with a page of errors from the repository in descending order of logged time and returns
        ///     total number of entries
        /// </summary>
        public override int GetErrors(int pageIndex, int pageSize, IList errorEntryList)
        {
            var errors = new Dictionary<string, ErrorRecord>();

            // todo: proper async support
            var totalCount = _errorRepository.GetErrorsAsync(pageIndex, pageSize, errors).Result;
            var errorLogEntries = errors.Select(error => new ErrorLogEntry(this, error.Key, error.Value.ToError()));

            foreach (var errorLogEntry in errorLogEntries)
            {
                errorEntryList.Add(errorLogEntry);
            }

            return totalCount;
        }
    }
}