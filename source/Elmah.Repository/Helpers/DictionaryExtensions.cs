using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace Elmah.Repository.Helpers
{
    public static class DictionaryExtensions
    {
        public static IReadOnlyCollection<KeyValueItem> ToKeyValueCollection(this IDictionary dictionary)
        {
            return new ReadOnlyCollection<KeyValueItem>(dictionary.ToKeyValueList());
        }

        public static IReadOnlyCollection<KeyValueItem> ToKeyValueCollection(this NameValueCollection collection)
        {
            throw new NotImplementedException();
        }

        public static IList<KeyValueItem> ToKeyValueList(this IDictionary dictionary)
        {
            var query =
                from object key in dictionary.Keys
                select new KeyValueItem(key.ToString(), dictionary[key]);

            return query.ToList();
        }
    }
}