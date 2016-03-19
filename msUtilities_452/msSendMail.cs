using System;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace msUtilities
{
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

    public msSendMail()
    {
      this._init();
    }

    public msSendMail(msSmtpConfig smtpConfig)
    {
      this._init();
      this.smtpConfig = smtpConfig;
    }

    public void Dispose()
    {
      this._message.Dispose();
    }

    private void _init()
    {
      this.smtpConfig = new msSmtpConfig();
      this._message = new MailMessage();
    }

    public void addTo(string address)
    {
      this._message.To.Add(address);
    }

    public void addCC(string address)
    {
      this._message.CC.Add(address);
    }

    public void addBCC(string address)
    {
      this._message.Bcc.Add(address);
    }

    public void addAttachment(string fileName)
    {
      if (File.Exists(fileName))
      {
        this._message.Attachments.Add(new Attachment(fileName));
      }
    }

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
