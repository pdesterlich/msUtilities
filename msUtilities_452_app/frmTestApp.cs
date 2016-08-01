using msUtilities;
using msUtilities.Database;
using System;
using System.Windows.Forms;

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
            var connectionParams = new MsConnectionParams();
            if (connectionForm.showDialog("msUtilities Test App", ref connectionParams))
            {
                MessageBox.Show(connectionParams.ToString());
                MessageBox.Show(connectionParams.GetConnectionString());
            }
        }

        private void btnTestMsConnectionFormsSqlServer_Click(object sender, EventArgs e)
        {
            var connectionForm = new msConnectionForm();
            var connectionParams = new MsConnectionParams();
            connectionParams.DatabaseType = MsDatabaseType.SqlServer;
            connectionParams.Database = "database";
            if (connectionForm.showDialog("msUtilities Test App", ref connectionParams))
            {
                MessageBox.Show(connectionParams.ToString());
                MessageBox.Show(connectionParams.GetConnectionString());
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
            mailer.smtpConfig.Port = MsConversion.StringToInt(txtSmtpPort.Text, 25);
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

        private void button1_Click(object sender, EventArgs e)
        {
            var smtpConfigForm = new msSmtpConfigForm();
            var smtpConfig = new msSmtpConfig();
            if (smtpConfigForm.showDialog("msUtilities Test App", ref smtpConfig))
            {
                MessageBox.Show(smtpConfig.Name);
                MessageBox.Show(smtpConfig.Host);
            }
        }

        private void buttonTestMessages_Click(object sender, EventArgs e)
        {
            var message = string.Format(Messages.databaseConnectionError, "some host", "some database", "some error").NewLine();
            MessageBox.Show(message);
        }

        private void btnTestMinutesToDateTime_Click(object sender, EventArgs e)
        {
            MessageBox.Show(1000.MinutesToDateTime().ToString());
        }

        private void txtStringToFloat_TextChanged(object sender, EventArgs e)
        {
            lblStringToFloat.Text = "String to Float: " + (sender as TextBox).Text.StringToFloat(0).ToString();
        }
    }
}
