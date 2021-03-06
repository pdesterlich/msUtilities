﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace msUtilities
{
    public struct MsWebRequestResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public string Response { get; set; }
    }

    /**
     * msWebRequest
     * manage HTTP(S) web requests, encapsulating WebRequest object and functionalities
     **/
    public class MsWebRequest
    {

        /// <summary>
        /// request address
        /// </summary>
        private readonly string _url;

        /// <summary>
        /// request method
        /// </summary>
        public string Method = "GET";

        /// <summary>
        /// flag to enable requests to self signed https hosts
        /// </summary>
        public bool IgnoreInvalidSsl { get; set; }

        /// <summary>
        /// string containing parameters for POST requests
        /// </summary>
        public string PostParams { get; set; }

        /// <summary>
        /// content type for request (if not specified, POST requests use "application/x-www-form-urlencoded" content type)
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// list of get parameters
        /// </summary>
        public Dictionary<string, string> GetParams { get; }

        /// <summary>
        /// list of request headers
        /// </summary>
        public Dictionary<string, string> Headers { get; }

        /// <summary>
        /// additional get parameters
        /// </summary>
        public string AdditionalGetParams { get; set; }

        /// <summary>
        /// class init function (with method)
        /// </summary>
        /// <param name="url">address for request</param>
        public MsWebRequest(string url)
        {
            _url = url;
            // set init values for class properties
            IgnoreInvalidSsl = false;
            PostParams = "";
            ContentType = "application/x-www-form-urlencoded";
            AdditionalGetParams = "";
            Headers = new Dictionary<string, string>();
            GetParams = new Dictionary<string, string>();
        }

        /// <summary>
        /// class init function (with method)
        /// </summary>
        /// <param name="url">address for request</param>
        /// <param name="method">method for request (accepted values: GET, POST)</param>
        public MsWebRequest(string url, string method)
                : this(url)
        {
            if (method.Equals("GET") || method.Equals("POST"))
            {
                // Set the Method property of the request to POST.
                Method = method;
            }
            else
            {
                throw new Exception("Invalid Method Type");
            }
        }

        /// <summary>
        /// connect to target url and get response
        /// </summary>
        /// <returns></returns>
        public MsWebRequestResponse GetResponse()
        {
            var result = new MsWebRequestResponse();

            var address = _url;

            var getParams = "";

            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var param in GetParams)
            {
                // ReSharper disable once UseStringInterpolation
                getParams += string.Format("{0}{1}={2}", getParams == "" ? "" : "&", param.Key, param.Value);
            }

            // add additional get parameters
            if (AdditionalGetParams != "") getParams += (getParams == "" ? "" : "&") + AdditionalGetParams;

            // add composite get params to address
            if (getParams != "") address += "?" + getParams;

            // Create a request using obtained url
            var request = WebRequest.Create(address);

            // sets request method
            request.Method = Method;

            try
            {
                // if needed, disable SSL certificates verification
                if (IgnoreInvalidSsl)
                {
                    ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                }

                // add custom headers
                foreach (var header in Headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }

                // if there are post parameters, those are added to the request
                if (PostParams != "")
                {
                    // Set the ContentType property of the WebRequest.
                    request.ContentType = ContentType;

                    // add post parameters
                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    {
                        streamWriter.Write(PostParams);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }
                }

                // Get the original response.
                var response = request.GetResponse();

                // set response status
                result.StatusDescription = ((HttpWebResponse)response).StatusDescription;

                // set response code
                result.StatusCode = ((HttpWebResponse)response).StatusCode;

                // parse response from stream reader
                var responseFromServer = "";

                var responseStream = response.GetResponseStream();

                if (responseStream != null)
                    using (var streamReader = new StreamReader(responseStream))
                    {
                        responseFromServer = streamReader.ReadToEnd();
                    }

                // set response string
                result.Response = responseFromServer;

            }
            // in case of errors returns them
            catch (WebException err)
            {
                result.Response = $"error: {err.Status} - {err.Message}";
            }

            // return response
            return result;
        }

        /// <summary>
        /// addGetParam
        /// add a new get parameters
        /// </summary>
        /// <param name="name">parameter name</param>
        /// <param name="value">parameter value</param>
        public void AddGetParam(string name, string value)
        {
            GetParams.Add(name, value);
        }

        /// <summary>
        /// addHeader
        /// add a new header
        /// </summary>
        /// <param name="name">header name</param>
        /// <param name="value">header value</param>
        public void AddHeader(string name, string value)
        {
            Headers.Add(name, value);
        }
    }
}
