using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;

// 
// This code was originally written for Entexis, so we need a license statement. Note that this doesn't imply that this 
// is particularly solid or well designed code, it's still basically just a hack.
//
//Copyright 2013 Proflow Holding UG and Christoph Menge
//Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
namespace Pactas.SDK
{
    public static class RestResponseExtensions
    {
        public static T ResponseAs<T>(this RestResponse response)
        {
            try
            {
                // TODO: The deserializer has trouble with our convention of explicitly including null fields
                // and tries to invoke the ObjectId constructor...
                // ServiceStack.Text.JsConfig.ThrowOnDeserializationError = false;
                return ServiceStack.Text.JsonSerializer.DeserializeFromString<T>(response.ResponseBody);
            }
            catch (Exception ex)
            {
                throw new RestException(response, ex);
            }
        }
    }

    public class RestResponse
    {
        public string ResponseBody { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public RestRequest Request { get; set; }
        public string StatusDescription { get; set; }

        public string Log { get; set; }
    }

    [Serializable]
    public class RestException : Exception
    {
        public RestResponse Response { get; private set; }

        public RestException(RestResponse response)
            : base(response.Log)
        {
            Response = response;
        }

        public RestException(RestResponse response, Exception inner)
            : base(response.Log, inner)
        {
            Response = response;
        }

        public override string Message
        {
            get
            {
                if (Response != null && !string.IsNullOrEmpty(Response.ResponseBody))
                    return base.Message + Environment.NewLine + Response.ResponseBody;
                return base.Message;
            }
        }

        public RestException() { }
        public RestException(string message) : base(message) { }
        public RestException(string message, Exception inner) : base(message, inner) { }
        protected RestException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }

    public class RestClient
    {
        public string BaseUrl { get; private set; }
        Dictionary<string, string> DefaultParameters { get; set; }

        public RestClient(string baseUrl)
        {
            DefaultParameters = new Dictionary<string, string>();
            BaseUrl = baseUrl;
        }

        public void AddDefaultParameter(string key, string value, bool overwrite = false)
        {
            if (DefaultParameters.ContainsKey(key))
            {
                if (overwrite)
                    DefaultParameters[key] = value;
                else
                    throw new InvalidOperationException("Key already exists");
            }
            else
                DefaultParameters.Add(key, value);
        }

        public RestResponse Execute(RestRequest restRequest)
        {
            HttpWebResponse response = null;
            StreamReader reader = null;
            Stream dataStream = null;

            RestResponse restResponse = new RestResponse();
            try
            {
                restRequest.AttemptCount++;
                HttpWebRequest request = restRequest.CreateWebRequest(BaseUrl);

                foreach (var rover in DefaultParameters)
                    request.Headers.Add(rover.Key, rover.Value);

                if (restRequest.Body != null)
                {
                    byte[] byteArray = Encoding.UTF8.GetBytes(restRequest.Body);
                    request.ContentType = restRequest.ContentType ?? "application/json";
                    request.ContentLength = byteArray.Length;
                    dataStream = request.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();
                }

                // Get the response.
                response = (HttpWebResponse)request.GetResponse();
                string statusDescription = response.StatusDescription;

                dataStream = response.GetResponseStream();
                reader = new StreamReader(dataStream);
                restResponse.ResponseBody = reader.ReadToEnd();
                restResponse.StatusCode = response.StatusCode;
                restResponse.StatusDescription = response.StatusDescription;
                restResponse.Request = restRequest;

            }
            catch (WebException ex)
            {
                response = (HttpWebResponse)ex.Response;
                if (response != null)
                {
                    dataStream = response.GetResponseStream();
                    reader = new StreamReader(dataStream);
                    restResponse.ResponseBody = reader.ReadToEnd();
                    restResponse.StatusCode = response.StatusCode;
                    restResponse.StatusDescription = response.StatusDescription;
                }
                else
                {
                    restResponse.StatusDescription = ex.Message; // e.g. 'the operation has timed out'
                }

                restResponse.Request = restRequest;
            }
            catch //(Exception ex)
            {
                throw;
            }
            finally
            {
                // Clean up the streams.
                if (reader != null)
                    reader.Close();

                if (dataStream != null)
                    dataStream.Close();

                if (response != null)
                    response.Close();
            }

            return restResponse;
        }
    }

    public enum Method
    {
        GET = 0,
        POST = 1,
        PUT = 2,
        DELETE = 3,
        HEAD = 4,
        OPTIONS = 5,
        PATCH = 6,
    }

    public static class NameValueCollectionHelper
    {
        public static NameValueCollection ExtractProperties(object item)
        {
            NameValueCollection result = new NameValueCollection();
            if (item == null)
                return result;

            Type type = item.GetType();
            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                if (propertyInfo.CanRead)
                {
                    var pName = propertyInfo.Name;
                    var pValue = propertyInfo.GetValue(item, null);
                    if (pValue != null)
                        result.Add(pName, pValue.ToString());
                }
            }

            return result;
        }
    }

    public class RestRequest
    {
        private Method _method;

        public RestRequest(Method method, string url, object query = null)
        {
            Url = url;
            _method = method;
            Headers = new Dictionary<string, string>();
            Query = NameValueCollectionHelper.ExtractProperties(query);
        }

        public HttpWebRequest CreateWebRequest(string baseUrl)
        {
            Uri resultUri;
            Uri.TryCreate(new Uri(baseUrl), Url, out resultUri);
            var request = (HttpWebRequest)WebRequest.Create(resultUri);
            request.Method = _method.ToString();
            foreach (var rover in Headers)
                request.Headers.Add(rover.Key, rover.Value);
            return request;
        }

        private Dictionary<string, string> Headers { get; set; }
        public string Url { get; set; }
        public string ContentType { get; set; }
        public string Body { get; set; }
        public NameValueCollection Query { get; private set; }

        public int AttemptCount { get; set; }

        public void AddHeader(string name, string value)
        {
            Headers.Add(name, value);
        }
    }
}
