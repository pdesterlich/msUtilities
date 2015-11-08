using System;
using System.Collections.Generic;
using System.Net;
using System.IO;

namespace msUtilities
{
  /**
   * mooreaWebRequestHeader
   * support class to manage custom Headers
   **/
  public class msWebRequestParam
  {
    // header name
    public string name { get; set; }
    // header value
    public string value { get; set; }

    /**
     * mooreaWebRequestHeader init function
     **/
    public msWebRequestParam(String name, String value)
    {
      this.name = name;
      this.value = value;
    }
  }

  /**
   * msWebRequest
   * manage HTTP(S) web requests, encapsulating WebRequest object and functionalities
   **/
  public class msWebRequest
  {

    /// <summary>
    /// request address
    /// </summary>
    private String url = "";

    /// <summary>
    /// request method
    /// </summary>
    private String method = "GET";

    /// <summary>
    /// flag to enable requests to self signed https hosts
    /// </summary>
    public Boolean IgnoreInvalidSSL { get; set; }

    /// <summary>
    /// string containing chained parameters for POST requests (example: param01=value&param02=value)
    /// </summary>
    public String PostParams { get; set; }

    /// <summary>
    /// content type for request (if not specified, POST requests use "application/x-www-form-urlencoded" content type)
    /// </summary>
    public String ContentType { get; set; }

    /// <summary>
    /// list of get parameters
    /// </summary>
    private List<msWebRequestParam> GetParams;

    /// <summary>
    /// list of request headers
    /// </summary>
    public List<msWebRequestParam> Headers;

    /// <summary>
    /// additional get parameters
    /// </summary>
    public String additionalGetParams { get; set; }

    /// <summary>
    /// response status
    /// </summary>
    private String status = "";

    public String Status { get { return status; } }

    /// <summary>
    /// class init function (with method)
    /// </summary>
    /// <param name="url">address for request</param>
    public msWebRequest(string url)
    {
      this.url = url;
      // set init values for class properties
      this.IgnoreInvalidSSL = false;
      this.PostParams = "";
      this.ContentType = "application/x-www-form-urlencoded";
      this.additionalGetParams = "";
      this.Headers = new List<msWebRequestParam>();
      this.GetParams = new List<msWebRequestParam>();
    }

    /// <summary>
    /// class init function (with method)
    /// </summary>
    /// <param name="url">address for request</param>
    /// <param name="method">method for request (accepted values: GET, POST)</param>
    public msWebRequest(string url, string method)
            : this(url)
    {
      if (method.Equals("GET") || method.Equals("POST"))
      {
        // Set the Method property of the request to POST.
        this.method = method;
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
    public string GetResponse()
    {
      String address = url;

      foreach (var param in GetParams)
      {
        address += String.Format("{0}{1}={2}", ((address.Contains("?")) ? "?" : "&"), param.name, param.value);
      }

      // add additional get parameters
      if (additionalGetParams != "") address += (address.Contains("?") ? "?" : "&") + additionalGetParams;

      // Create a request using a URL that can receive a post.
      WebRequest request = WebRequest.Create(address);

      request.Method = method;

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
          request.ContentType = ContentType;

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

    /// <summary>
    /// addGetParam
    /// add a new get parameters
    /// </summary>
    /// <param name="name">parameter name</param>
    /// <param name="value">parameter value</param>
    public void addGetParam(String name, String value)
    {
      GetParams.Add(new msWebRequestParam(name, value));
    }

    /// <summary>
    /// addHeader
    /// add a new header
    /// </summary>
    /// <param name="name">header name</param>
    /// <param name="value">header value</param>
    public void addHeader(String name, String value)
    {
      Headers.Add(new msWebRequestParam(name, value));
    }
  }
}
