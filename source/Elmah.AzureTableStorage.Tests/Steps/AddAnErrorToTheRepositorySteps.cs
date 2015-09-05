using System;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace Elmah.AzureTableStorage.Tests.Steps
{
    [Binding]
    public class AddAnErrorToTheRepositorySteps
    {
        private readonly IErrorRepository _errorRepository;
        private Error _error;
        private string _errorId;
        private ErrorLog _errorLog;

        public AddAnErrorToTheRepositorySteps(IErrorRepository errorRepository)
        {
            _errorRepository = errorRepository;
        }

        [Given(@"an error log has been created")]
        public void GivenAnErrorLogHasBeenCreated()
        {
            _errorLog = new RepositoryErrorLog(_errorRepository);
        }

        [When(@"an error is passed to the error log")]
        public void WhenAnErrorIsPassedToTheErrorLog()
        {
            _error = new Error(new Exception("dummy exception"));
            _errorId = _errorLog.Log(_error);
        }

        [Then(@"the error id is returned")]
        public void ThenTheErrorIdIsReturned()
        {
            _errorId.Should().NotBeNullOrWhiteSpace();
        }

        [Then(@"the error is added to the repository")]
        public void ThenTheErrorIsAddedToTheRepository()
        {
            var errorTableEntity = _errorRepository.Find(_errorId);

            errorTableEntity.Should().NotBeNull();
            errorTableEntity.ErrorXml.Should().NotBeNullOrWhiteSpace();

            var actualError = ErrorXml.DecodeString(errorTableEntity.ErrorXml);

            actualError.ShouldBeEquivalentTo(_error, config => config.Excluding(error => error.Exception));
        }
    }
}