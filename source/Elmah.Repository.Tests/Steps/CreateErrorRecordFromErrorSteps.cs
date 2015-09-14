using Elmah.Repository.Helpers;
using Elmah.Repository.Tests.Helpers;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace Elmah.Repository.Tests.Steps
{
    [Binding]
    public class CreateErrorRecordFromErrorSteps
    {
        private Error _givenError;
        private ErrorRecord _result;

        [Given(@"an ELMAH Error")]
        public void GivenAnELMAHError()
        {
            _givenError = Random.ElmahError;
        }
        
        [When(@"I call ToErrorRecord")]
        public void WhenICallToErrorRecord()
        {
            _result = _givenError.ToErrorRecord();
        }
        
        [Then(@"the result should be an ErrorRecord")]
        public void ThenTheResultShouldBeAnErrorRecord()
        {
            _result.Should().BeOfType<Error>();
        }
        
        [Then(@"all public Error properties are copied to ErrorRecord")]
        public void ThenAllPublicErrorPropertiesAreCopiedToErrorRecord()
        {
            _result.ShouldBeEquivalentTo(_givenError);
        }
    }
}
