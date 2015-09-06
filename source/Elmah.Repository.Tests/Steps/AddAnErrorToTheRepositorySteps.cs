using System;
using FakeItEasy;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace Elmah.Repository.Tests.Steps
{
    [Binding]
    public class AddAnErrorToTheRepositorySteps
    {
        private readonly IErrorRepository _errorRepository;
        private readonly Error _error;
        private string _actualErrorId;
        private ErrorLog _errorLog;
        private readonly string _expectedErrorId;

        public AddAnErrorToTheRepositorySteps()
        {
            _error = new Error(new Exception("dummy exception"));
            _errorRepository = A.Fake<IErrorRepository>();
            _expectedErrorId = Guid.NewGuid().ToString();

            A.CallTo(() => _errorRepository.AddError(_error)).Returns(_expectedErrorId);
        }

        [Given(@"an error log has been created")]
        public void GivenAnErrorLogHasBeenCreated()
        {
            _errorLog = new RepositoryErrorLog(_errorRepository);
        }

        [When(@"an error is passed to the error log")]
        public void WhenAnErrorIsPassedToTheErrorLog()
        {
            _actualErrorId = _errorLog.Log(_error);
        }

         [Then(@"the error is added to the repository")]
        public void ThenTheErrorIsAddedToTheRepository()
        {
            A.CallTo(() => _errorRepository.AddError(_error))
                .MustHaveHappened(Repeated.Exactly.Once);
        }

        [Then(@"the error id is returned")]
        public void ThenTheErrorIdIsReturned()
        {
            _actualErrorId.Should().Be(_expectedErrorId);
        }
    }
}