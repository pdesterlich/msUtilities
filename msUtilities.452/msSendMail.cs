using System;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace msUtilities
{
  /// <summary>
  /// class msSendMail
  /// a simple class to send a mail message (with optional attachment)
  /// </summary>
  public class msSendMail
  {
    private MailMessage _message = new MailMessage();

    public msSmtpConfig smtpConfig { get; set; } = new msSmtpConfig();
    public string From {
      get { return this._message.From.ToString(); }
      set { this._message.From = new MailAddress(value); }
    }
    public string Subject
    {
      get { return this._message.Subject; }
      set { this._message.Subject = value; }
    }
    public string Body
    {
      get { return this._message.Body; }
      set { this._message.Body = value; }
    }

    /// <summary>
    /// class initialization (empty
    /// </summary>
    public msSendMail()
    {
      this._init();
    }

    /// <summary>
    /// class initialization (with smtp config parameters)
    /// </summary>
    /// <param name="smtpConfig">smtp configuration</param>
    public msSendMail(msSmtpConfig smtpConfig)
    {
      this._init();
      this.smtpConfig = smtpConfig;
    }

    /// <summary>
    /// reset class parameters, to prepare class for another message
    /// </summary>
    public void Reset()
    {
      this._init();
    }

    /// <summary>
    /// dispose class properties
    /// </summary>
    public void Dispose()
    {
      this._message.Dispose();
    }

    /// <summary>
    /// private class initialization
    /// initialize message and smtpConfig properties
    /// </summary>
    private void _init()
    {
      this.smtpConfig = new msSmtpConfig();
      this._message = new MailMessage();
    }

    /// <summary>
    /// add a To address
    /// </summary>
    /// <param name="address">address to add</param>
    public void addTo(string address)
    {
      this._message.To.Add(address);
    }

    /// <summary>
    /// add a CC address
    /// </summary>
    /// <param name="address">address to add</param>
    public void addCC(string address)
    {
      this._message.CC.Add(address);
    }

    /// <summary>
    /// add a BCC address
    /// </summary>
    /// <param name="address">address to add</param>
    public void addBCC(string address)
    {
      this._message.Bcc.Add(address);
    }

    /// <summary>
    /// add a file attachment
    /// </summary>
    /// <param name="fileName">file name (and path) to attach</param>
    public void addAttachment(string fileName)
    {
      if (File.Exists(fileName))
      {
        this._message.Attachments.Add(new Attachment(fileName));
      }
    }

    /// <summary>
    /// send the message
    /// </summary>
    /// <param name="error">error message (in case of sending error)</param>
    /// <returns>boolean true if message is sent, false otherwise</returns>
    public bool Send(out string error)
    {
      error = "";

      bool result = false;

      try
      {
        SmtpClient smtp = new SmtpClient();

        smtp.Host = this.smtpConfig.Host;
        smtp.Port = this.smtpConfig.Port;
        smtp.EnableSsl = this.smtpConfig.EnableSSL;
        smtp.Credentials = new NetworkCredential(this.smtpConfig.Username, this.smtpConfig.Password);

        smtp.Send(this._message);

        result = true;
      }
      catch (Exception err)
      {
        error = err.Message;
      }

      return result;
    }
  }
}
