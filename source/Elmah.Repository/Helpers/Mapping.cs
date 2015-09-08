using System;

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
                error.User);

            return errorRecord;
        }

        public static Error ToError(this ErrorRecord errorRecord)
        {
            throw new NotImplementedException();
        }
    }
}