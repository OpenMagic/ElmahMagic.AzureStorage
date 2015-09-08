using System;
using System.Collections.Generic;

namespace Elmah.Repository.Tests.Helpers
{
    public class GivenData
    {
        public Dictionary<string, object> Dictionary { get; set; }
        public string Key { get; set; }
        public object Value { get; set; }
        public TypeCode TypeCode { get; set; }
    }
}