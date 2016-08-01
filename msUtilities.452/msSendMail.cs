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
    public class MsSendMail
    {
        private MailMessage _message = new MailMessage();

        public msSmtpConfig SmtpConfig { get; set; } = new msSmtpConfig();
        public string From
        {
            get { return _message.From.ToString(); }
            set { _message.From = new MailAddress(value); }
        }
        public string Subject
        {
            get { return _message.Subject; }
            set { _message.Subject = value; }
        }
        public string Body
        {
            get { return _message.Body; }
            set { _message.Body = value; }
        }

        /// <summary>
        /// class initialization (empty
        /// </summary>
        public MsSendMail()
        {
            _init();
        }

        /// <summary>
        /// class initialization (with smtp config parameters)
        /// </summary>
        /// <param name="smtpConfig">smtp configuration</param>
        public MsSendMail(msSmtpConfig smtpConfig)
        {
            _init();
            SmtpConfig = smtpConfig;
        }

        /// <summary>
        /// reset class parameters, to prepare class for another message
        /// </summary>
        public void Reset()
        {
            _init();
        }

        /// <summary>
        /// dispose class properties
        /// </summary>
        public void Dispose()
        {
            _message.Dispose();
        }

        /// <summary>
        /// private class initialization
        /// initialize message and smtpConfig properties
        /// </summary>
        private void _init()
        {
            SmtpConfig = new msSmtpConfig();
            _message = new MailMessage();
        }

        /// <summary>
        /// add a To address
        /// </summary>
        /// <param name="address">address to add</param>
        public void AddTo(string address)
        {
            _message.To.Add(address);
        }

        /// <summary>
        /// add a CC address
        /// </summary>
        /// <param name="address">address to add</param>
        public void AddCc(string address)
        {
            _message.CC.Add(address);
        }

        /// <summary>
        /// add a BCC address
        /// </summary>
        /// <param name="address">address to add</param>
        public void AddBcc(string address)
        {
            _message.Bcc.Add(address);
        }

        /// <summary>
        /// add a file attachment
        /// </summary>
        /// <param name="fileName">file name (and path) to attach</param>
        public void AddAttachment(string fileName)
        {
            if (File.Exists(fileName))
            {
                _message.Attachments.Add(new Attachment(fileName));
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

            try
            {
                var smtp = new SmtpClient
                {
                    Host = SmtpConfig.Host,
                    Port = SmtpConfig.Port,
                    EnableSsl = SmtpConfig.EnableSSL,
                    Credentials = new NetworkCredential(SmtpConfig.Username, SmtpConfig.Password)
                };

                smtp.Send(_message);

                return true;
            }
            catch (Exception err)
            {
                error = err.Message;
                return false;
            }
        }
    }
}