using System;
using System.Windows.Forms;
using msUtilities;

namespace msUtilities_452_app
{
  public partial class frmTestApp : Form
  {
    public frmTestApp()
    {
      InitializeComponent();
    }

    private void btnTestMsConnectionForms_Click(object sender, EventArgs e)
    {
      var connectionForm = new msConnectionForm();
      var connectionParams = new msConnectionParams();
      if (connectionForm.showDialog("msUtilities Test App", ref connectionParams))
      {
        MessageBox.Show(connectionParams.ToString());
        MessageBox.Show(connectionParams.getConnectionString());
      }
    }

    private void btnTestMsConnectionFormsSqlServer_Click(object sender, EventArgs e)
    {
      var connectionForm = new msConnectionForm();
      var connectionParams = new msConnectionParams();
      connectionParams.databaseType = DatabaseType.dtSqlServer;
      connectionParams.database = "database";
      if (connectionForm.showDialog("msUtilities Test App", ref connectionParams))
      {
        MessageBox.Show(connectionParams.ToString());
        MessageBox.Show(connectionParams.getConnectionString());
      }
    }

    private void btnSendMail_Click(object sender, EventArgs e)
    {
      msSendMail mailer = new msSendMail();
      mailer.From = txtSendMailFrom.Text;
      mailer.addTo(txtSendMailTo.Text);
      mailer.Subject = txtSendMailSubject.Text;
      mailer.Body = txtSendMailBody.Text;
      mailer.smtpConfig.Host = txtSmtpHost.Text;
      mailer.smtpConfig.Port = msConversion.stringToInt(txtSmtpPort.Text, 25);
      mailer.smtpConfig.Username = txtSmtpUser.Text;
      mailer.smtpConfig.Password = txtSmtpPassword.Text;
      mailer.smtpConfig.EnableSSL = chkSmtpSSL.Checked;

      string error = "";
      if (mailer.Send(out error))
      {
        MessageBox.Show("messaggio inviato");
      }
      else
      {
        MessageBox.Show("ci sono errori: " + error);
      }
    }
  }
}
