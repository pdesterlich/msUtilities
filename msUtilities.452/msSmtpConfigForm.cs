using System;
using System.Windows.Forms;

namespace msUtilities
{
  public partial class msSmtpConfigForm : Form
  {
    public bool showDialog(string title, ref msSmtpConfig smtpConfig)
    {
      bool result = false;

      this.Text = title;

      txtName.Text = smtpConfig.Name;
      txtHost.Text = smtpConfig.Host;
      txtUsername.Text = smtpConfig.Username;
      txtPassword.Text = smtpConfig.Password;
      txtPort.Text = smtpConfig.Port.ToString();
      chkEnableSSL.Checked = smtpConfig.EnableSSL;

      if (this.ShowDialog() == DialogResult.OK)
      {
        smtpConfig.Name = txtName.Text;
        smtpConfig.Host = txtHost.Text;
        smtpConfig.Username = txtUsername.Text;
        smtpConfig.Password = txtPassword.Text;
        smtpConfig.Port = MsConversion.StringToInt(txtPort.Text, 25);
        smtpConfig.EnableSSL = chkEnableSSL.Checked;

        result = true;
      }

      return result;
    }

    public msSmtpConfigForm()
    {
      InitializeComponent();
    }

    private void btnShowPassword_Click(object sender, EventArgs e)
    {
      if (txtPassword.UseSystemPasswordChar)
      {
        txtPassword.UseSystemPasswordChar = false;
        (sender as Button).Text = "nascondi";
      }
      else
      {
        txtPassword.UseSystemPasswordChar = true;
        (sender as Button).Text = "mostra";
      }
    }
  }
}
