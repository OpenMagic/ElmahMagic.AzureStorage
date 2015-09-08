using System.Collections.Generic;
using System.Linq;
using Elmah.Repository.Helpers;
using Elmah.Repository.Tests.Helpers;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace Elmah.Repository.Tests.Steps
{
    [Binding]
    public class ConvertIDictionaryToKeyValueCollectionSteps
    {
        private readonly GivenData _given;
        private IReadOnlyCollection<KeyValueItem>  _result;

        public ConvertIDictionaryToKeyValueCollectionSteps(GivenData given)
        {
            _given = given;
        }

        [Given(@"a dictionary with values")]
        public void GivenADictionaryWithValues(Table table)
        {
            _given.Dictionary = new Dictionary<string, object>();

            foreach (var row in table.Rows.Select(r => new KeyValueRow(r)))
            {
                _given.Dictionary.Add(row.Key, row.Value);
            }
        }

        [Given(@"an empty dictionary")]
        public void GivenAnEmptyDictionary()
        {
            _given.Dictionary = new Dictionary<string, object>();
        }

        [When(@"I call ToKeyValueCollection")]
        public void WhenICallToKeyValueCollection()
        {
            _result = _given.Dictionary.ToKeyValueCollection();
        }

        [Then(@"a name value collection should be returned with values")]
        public void ThenAKeyValueCollectionShouldBeReturnedWithValues(Table table)
        {
            var actualKeys = _result.Select(pair => pair.Key);
            var actualValues = _result.Select(pair => pair.Value);

            var expectedKeys = table.Rows.Select(row => row["Key"]);
            var expectedValues = table.Rows.Select(row => row["Value"]);

            actualKeys.ShouldAllBeEquivalentTo(expectedKeys);
            actualValues.ShouldAllBeEquivalentTo(expectedValues);
        }

        [Then(@"an empty name value collection should be returned")]
        public void ThenAnEmptyKeyValueCollectionShouldBeReturned()
        {
            _result.Count.Should().Be(0);
        }
    }
}
