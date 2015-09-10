using System.Collections.Generic;
using System.Linq;
using Elmah.Repository.Helpers;
using Elmah.Repository.Tests.Helpers;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace Elmah.Repository.Tests.Steps
{
    [Binding]
    public class ConvertIDictionaryToKeyValueListSteps
    {
        private readonly GivenData _given;
        private IReadOnlyCollection<KeyValueItem> _result;

        public ConvertIDictionaryToKeyValueListSteps(GivenData given)
        {
            _given = given;
        }

        [When(@"I call ToKeyValueList")]
        public void WhenICallToKeyValueList()
        {
            _result = _given.Dictionary.ToKeyValueCollection();
        }
        
        [Then(@"a name value list should be returned with values")]
        public void ThenANameValueListShouldBeReturnedWithValues(Table table)
        {
            var actualKeys = _result.Select(pair => pair.Key);
            var actualValues = _result.Select(pair => pair.Value);

            var expectedKeys = table.Rows.Select(row => row["Key"]);
            var expectedValues = table.Rows.Select(row => row["Value"]);

            actualKeys.ShouldAllBeEquivalentTo(expectedKeys);
            actualValues.ShouldAllBeEquivalentTo(expectedValues);
        }

        [Then(@"an empty name value list should be returned")]
        public void ThenAnEmptyNameValueListShouldBeReturned()
        {
            _result.Count.Should().Be(0);
        }
    }
}
