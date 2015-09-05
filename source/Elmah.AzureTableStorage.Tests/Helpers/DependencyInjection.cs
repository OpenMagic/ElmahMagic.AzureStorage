using System.Diagnostics;
using BoDi;
using TechTalk.SpecFlow;

namespace Elmah.AzureTableStorage.Tests.Helpers
{
    [Binding]
    public class DependencyInjection
    {
        private readonly IObjectContainer _objectContainer;
        private readonly TestConfiguration _testConfiguration;

        public DependencyInjection(TestConfiguration testConfiguration, IObjectContainer objectContainer)
        {
            _testConfiguration = testConfiguration;
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void InitializeContainer()
        {
            if (_testConfiguration.UseInMemoryRepository)
            {
                _objectContainer.RegisterTypeAs<InMemoryErrorRepository, IErrorRepository>();
            }
            else
            {
                _objectContainer.RegisterTypeAs<StorageEmulatorErrorRepository, IErrorRepository>();
            }
        }
    }
}