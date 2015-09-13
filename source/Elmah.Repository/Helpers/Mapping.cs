using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Elmah.Repository.Helpers
{
    public static class Mapping
    {
        public static ErrorRecord ToErrorRecord(this Error error)
        {
            var errorRecord = new ErrorRecord(
                error.Time.ToUniversalTime(),
                error.Message,
                error.ApplicationName,
                error.Cookies?.ToKeyValueCollection(),
                error.Detail,
                error.Exception?.Data.ToKeyValueCollection(),
                error.Form?.ToKeyValueCollection(),
                error.HostName, 
                error.QueryString?.ToKeyValueCollection(), 
                error.ServerVariables?.ToKeyValueCollection(), 
                error.Source, 
                error.StatusCode, 
                error.Type, 
                error.User, 
                error.WebHostHtmlMessage);

            return errorRecord;
        }

        public static Error ToError(this ErrorRecord errorRecord)
        {
            var error = new Error()
            {
                ApplicationName = errorRecord.ApplicationName,
                Detail = errorRecord.Detail,
                HostName = errorRecord.HostName,
                Message = errorRecord.Message,
                Source = errorRecord.Source,
                StatusCode = errorRecord.StatusCode,
                Type = errorRecord.Type,
                Time = errorRecord.WhenUtc,
                User = errorRecord.User,
                WebHostHtmlMessage = errorRecord.WebHostHtmlMessage
            };
            
            AddItems(error.Cookies, errorRecord.Cookies);
            AddItems(error.Form, errorRecord.Form);
            AddItems(error.QueryString, errorRecord.QueryString);
            AddItems(error.ServerVariables, errorRecord.ServerVariables);

            return error;
        }

        private static void AddItems(NameValueCollection nameValueCollection, IReadOnlyCollection<KeyValueItem> keyValueCollection)
        {
            foreach (var keyValueItem in keyValueCollection)
            {
                nameValueCollection.Add(keyValueItem.Key, keyValueItem.Value.ToString());
            }
        }
    }
}