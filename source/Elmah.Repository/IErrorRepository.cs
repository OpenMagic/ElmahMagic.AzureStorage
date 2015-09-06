using System.Collections.Generic;
using NullGuard;

namespace Elmah.Repository
{
    public interface IErrorRepository
    {
        /// <summary>
        ///     Add an error to the repository.
        /// </summary>
        /// <param name="error">The error to add.</param>
        /// <returns>
        ///     The id of the saved error.
        /// </returns>
        string AddError(Error error);

        /// <summary>
        ///     Gets an error from the repository.
        /// </summary>
        /// <param name="errorId">The error's id.</param>
        /// <returns>
        ///     The requested error or null if the error does not exist.
        /// </returns>
        [return: AllowNull]
        Error GetError(string errorId);

        /// <summary>
        ///     Get a page of errors from the repository in descending order of logged time.
        /// </summary>
        /// <param name="pageIndex">The page of errors to get.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="errors">The collection of errors to update.</param>
        /// <returns>
        ///     The total number of errors in the repository.
        /// </returns>
        int GetErrors(int pageIndex, int pageSize, IDictionary<string, Error> errors);
    }
}