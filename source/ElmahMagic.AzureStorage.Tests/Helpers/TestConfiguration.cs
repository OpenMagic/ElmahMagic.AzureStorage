using System;

namespace ElmahMagic.AzureStorage.Tests.Helpers
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