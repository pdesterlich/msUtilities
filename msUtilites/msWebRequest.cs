using System;
using System.Collections.Generic;
using System.Net;
using System.IO;

namespace msUtilites
{
  /**
   * mooreaWebRequestHeader
   * support class to manage custom Headers
   **/
  class msWebRequestHeader
  {
    // header name
    public string name { get; set; }
    // header value
    public string value { get; set; }

    /**
     * mooreaWebRequestHeader init function
     **/
    public msWebRequestHeader(String name, String value)
    {
      this.name = name;
      this.value = value;
    }
  }

  /**
   * msWebRequest
   * manage HTTP(S) web requests, encapsulating WebRequest object and functionalities
   **/
  class msWebRequest
  {
    // internal WebRequest object
    private WebRequest request;
    // flag to enable requests to self signed https hosts
    public Boolean IgnoreInvalidSSL { get; set; }
    // string containing chained parameters for POST requests (example: param01=value&param02=value)
    public String PostParams { get; set; }
    // content type for request (if not specified, POST requests use "application/x-www-form-urlencoded" content type)
    public String ContentType { get; set; }
    // custom headers list
    public List<msWebRequestHeader> Headers { get; set; }
    // response status
    private String status = "";
    public String Status { get { return status; } }

    /**
     * mooreaWebRequest init function
     * @param String url address for request
     **/
    public msWebRequest(string url)
    {
      // Create a request using a URL that can receive a post.
      request = WebRequest.Create(url);
      // set init values for class properties
      IgnoreInvalidSSL = false;
      PostParams = "";
      ContentType = "";
      Headers = new List<msWebRequestHeader>();
    }

    /**
     * mooreaWebRequest init function (with method)
     * @param String url    address for request
     * @param String method method for request (accepted values: GET, POST)
     **/
    public msWebRequest(string url, string method)
            : this(url)
    {

      if (method.Equals("GET") || method.Equals("POST"))
      {
        // Set the Method property of the request to POST.
        request.Method = method;
      }
      else
      {
        throw new Exception("Invalid Method Type");
      }
    }

    /**
     * connect to target url and get response
     **/
    public string GetResponse()
    {
      try
      {
        // if needed, disable SSL certificates verification
        if (IgnoreInvalidSSL == true)
        {
          ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        }

        // add custom headers
        foreach (var header in Headers)
        {
          request.Headers.Add(header.name, header.value);
        }

        // if there are post parameters, those are added to the request
        if (PostParams != "")
        {
          // Set the ContentType property of the WebRequest.
          if (ContentType == "")
          {
            request.ContentType = "application/x-www-form-urlencoded";
          }
          else
          {
            request.ContentType = ContentType;
          }

          // add post parameters
          using (var streamWriter = new StreamWriter(request.GetRequestStream()))
          {
            string json = PostParams;

            streamWriter.Write(json);
            streamWriter.Flush();
            streamWriter.Close();
          }
        }

        // Get the original response.
        WebResponse response = request.GetResponse();

        // set response status
        status = ((HttpWebResponse)response).StatusDescription;

        // parse response from stream reader
        String responseFromServer = "";
        using (var streamReader = new StreamReader(response.GetResponseStream()))
        {
          responseFromServer = streamReader.ReadToEnd();
        }

        // return response
        return responseFromServer;
      }
      // in case of errors returns them
      catch (System.Net.WebException err)
      {
        return String.Format("error: {0} - {1}", err.Status, err.Message);
      }
    }
  }
}
