using System;

namespace Elmah.AzureTableStorage.Tests.Helpers
{
    public class TestConfiguration
    {
        public TestConfiguration()
        {
            UseInMemoryRepository = Environment.GetEnvironmentVariable("UseInMemoryRepository") != null;
        }

        public bool UseInMemoryRepository { get; private set; }
    }
}