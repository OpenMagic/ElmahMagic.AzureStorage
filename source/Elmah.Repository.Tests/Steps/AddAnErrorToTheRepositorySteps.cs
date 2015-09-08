using System;
using Elmah.Repository.Helpers;
using Elmah.Repository.Tests.Helpers;
using FakeItEasy;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace Elmah.Repository.Tests.Steps
{
    [Binding]
    public class AddAnErrorToTheRepositorySteps
    {
        private readonly IErrorRepository _errorRepository;
        private string _actualErrorId;
        private ErrorLog _errorLog;
        private readonly string _givenErrorId;
        private readonly Error _givenError;
        private int _callsToAddErrorAsync;

        public AddAnErrorToTheRepositorySteps()
        {
            _givenError = new Error(new Exception("dummy exception"));
            _givenErrorId = Guid.NewGuid().ToString();

            _errorRepository = A.Fake<IErrorRepository>();

            A.CallTo(() => _errorRepository.AddErrorAsync(A<ErrorRecord>.That.Matches(errorRecord => errorRecord.IsEquivalentTo(_givenError.ToErrorRecord()))))
                .Invokes(x => _callsToAddErrorAsync += 1)
                .Returns(_givenErrorId);
        }

        [Given(@"an error log has been created")]
        public void GivenAnErrorLogHasBeenCreated()
        {
            _errorLog = new RepositoryErrorLog(_errorRepository);
        }

        [When(@"an error is passed to the error log")]
        public void WhenAnErrorIsPassedToTheErrorLog()
        {
            _actualErrorId = _errorLog.Log(_givenError);
        }

        [Then(@"the error is added to the repository")]
        public void ThenTheErrorIsAddedToTheRepository()
        {
            _callsToAddErrorAsync.Should().Be(1);
        }

        [Then(@"the error id is returned")]
        public void ThenTheErrorIdIsReturned()
        {
            _actualErrorId.Should().Be(_givenErrorId);
        }
    }
}