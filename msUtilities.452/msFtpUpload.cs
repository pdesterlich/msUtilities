﻿using System;
using System.IO;
using System.Net;

// original code: http://www.codeproject.com/Tips/443588/Simple-Csharp-FTP-Class

namespace msUtilities
{
    public static class MsFtpUpload
    {
        /// <summary>
        /// upload a single file on a remote ftp server
        /// </summary>
        /// <param name="error">possible error message</param>
        /// <param name="host">remote ftp host</param>
        /// <param name="user">optional username</param>
        /// <param name="password">optional password</param>
        /// <param name="remotePath">optional remote path</param>
        /// <param name="localFile">local file to upload</param>
        public static void UploadFile(out string error, string host, string user, string password, string remotePath, string localFile)
        {
            error = "";

            if (!File.Exists(localFile))
            {
                error = Messages.ftpLocalFileMissing;
            }
            else
            {
                try
                {
                    const int bufferSize = 2048;

                    /* Create an FTP Request */
                    var ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + remotePath);
                    /* Log in to the FTP Server with the User Name and Password Provided */
                    ftpRequest.Credentials = new NetworkCredential(user, password);
                    /* When in doubt, use these options */
                    ftpRequest.UseBinary = true;
                    ftpRequest.UsePassive = true;
                    ftpRequest.KeepAlive = true;
                    /* Specify the Type of FTP Request */
                    ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
                    /* Establish Return Communication with the FTP Server */
                    var ftpStream = ftpRequest.GetRequestStream();
                    /* Open a File Stream to Read the File for Upload */
                    var localFileStream = new FileStream(localFile, FileMode.Open);
                    /* Buffer for the Downloaded Data */
                    var byteBuffer = new byte[bufferSize];
                    var bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize);
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
                        error = string.Format(Messages.ftpErrorUpload, host, err.Message);
                    }
                    /* Resource Cleanup */
                    localFileStream.Close();
                    ftpStream.Close();
                    ftpRequest = null;
                }
                catch (Exception err)
                {
                    error = string.Format(Messages.ftpErrorGeneric, host, err.Message);
                }

            }
        }
    }
}
