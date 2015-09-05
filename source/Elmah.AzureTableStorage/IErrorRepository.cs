using NullGuard;

namespace Elmah.AzureTableStorage
{
    public interface IErrorRepository
    {
        void Add(ErrorTableEntity errorTable);

        [return: AllowNull]
        ErrorTableEntity Find(string errorId);
    }
}