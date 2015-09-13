using TechTalk.SpecFlow;

namespace Elmah.Repository.Tests.Steps
{
    [Binding]
    public class CreateErrorRecordFromErrorSteps
    {
        [Given(@"an ELMAH Error")]
        public void GivenAnELMAHError()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I call ToErrorRecord")]
        public void WhenICallToErrorRecord()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the result should be an ErrorRecord")]
        public void ThenTheResultShouldBeAnErrorRecord()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"all public Error properties are copied to ErrorRecord")]
        public void ThenAllPublicErrorPropertiesAreCopiedToErrorRecord()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
