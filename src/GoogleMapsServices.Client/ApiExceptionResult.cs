﻿namespace GoogleMapsServices.Client
{
    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.0.5.0 (NJsonSchema v10.0.22.0 (Newtonsoft.Json v11.0.0.0))")]
    public class ApiException<TResult> : ApiException
    {
        public TResult Result { get; private set; }

        public ApiException(string message, int statusCode, string response, IReadOnlyDictionary<string, IEnumerable<string>> headers, TResult result, Exception innerException)
            : base(message, statusCode, response, headers, innerException)
        {
            Result = result;
        }
    }

}

