using System;
using System.IO;
using System.Net;

// original code: http://www.codeproject.com/Tips/443588/Simple-Csharp-FTP-Class

namespace msUtilities
{
  public class msFtpUpload
  {
    public static void uploadFile(out string error, string host, string user, string password, string remoteFile, string localFile)
    {
      error = "";

      if (!File.Exists(localFile))
      {
        error = "il file locale non esiste";
      }
      else
      {
        try
        {
          int bufferSize = 2048;

          /* Create an FTP Request */
          FtpWebRequest ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + remoteFile);
          /* Log in to the FTP Server with the User Name and Password Provided */
          ftpRequest.Credentials = new NetworkCredential(user, password);
          /* When in doubt, use these options */
          ftpRequest.UseBinary = true;
          ftpRequest.UsePassive = true;
          ftpRequest.KeepAlive = true;
          /* Specify the Type of FTP Request */
          ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
          /* Establish Return Communication with the FTP Server */
          Stream ftpStream = ftpRequest.GetRequestStream();
          /* Open a File Stream to Read the File for Upload */
          FileStream localFileStream = new FileStream(localFile, FileMode.Open);
          /* Buffer for the Downloaded Data */
          byte[] byteBuffer = new byte[bufferSize];
          int bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize);
          /* Upload the File by Sending the Buffered Data Until the Transfer is Complete */
          try
          {
            while (bytesSent != 0)
            {
              ftpStream.Write(byteBuffer, 0, bytesSent);
              bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize);
            }
          }
          catch (Exception err)
          {
            error = String.Format("errore in upload file su {0}\n{1}", host, err.Message);
          }
          /* Resource Cleanup */
          localFileStream.Close();
          ftpStream.Close();
          ftpRequest = null;
        }
        catch (Exception err)
        {
          error = String.Format("errore in upload file su {0}\n{1}", host, err.Message);
        }

      }
    }
  }
}
