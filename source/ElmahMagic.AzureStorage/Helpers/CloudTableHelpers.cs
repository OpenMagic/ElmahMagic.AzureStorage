using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace ElmahMagic.AzureStorage.Helpers
{
    public static class CloudTableHelpers
    {
        public static CloudTable GetTableReference(string connectionString, string tableName, bool createTableIfNotExists = true)
        {
            var storageAccount = CloudStorageAccount.Parse(connectionString);
            var tableClient = storageAccount.CreateCloudTableClient();
            var table = tableClient.GetTableReference(tableName);

            if (createTableIfNotExists)
            {
                table.CreateIfNotExists();
            }

            return table;
        }
    }
}