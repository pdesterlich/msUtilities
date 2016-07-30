using System;
using System.Windows.Forms;

namespace msUtilities.Database
{
    public partial class msConnectionForm : Form
    {
        public bool showDialog(string title, ref MsConnectionParams connectionParams)
        {
            bool result = false;

            this.Text = title;

            btnShowPassword.Text = Messages.buttonShow;
            btnOk.Text = Messages.buttonOk;
            btnCancel.Text = Messages.buttonCancel;

            labelType.Text = Messages.labelConnectionType;
            labelHost.Text = Messages.labelConnectionHost;
            labelDatabase.Text = Messages.labelConnectionDatabase;
            labelUsername.Text = Messages.labelConnectionUsername;
            labelPassword.Text = Messages.labelConnectionPassword;

            cboTipo.SelectedIndex = cboTipo.Items.IndexOf(connectionParams.DatabaseType.ToString());
            txtHost.Text = connectionParams.Host;
            txtDatabase.Text = connectionParams.Database;
            txtUsername.Text = connectionParams.Username;
            txtPassword.Text = connectionParams.Password;

            if (this.ShowDialog() == DialogResult.OK)
            {
                connectionParams.DatabaseType = (MsDatabaseType)Enum.Parse(typeof(MsDatabaseType), cboTipo.SelectedItem.ToString());
                connectionParams.Host = txtHost.Text;
                connectionParams.Database = txtDatabase.Text;
                connectionParams.Username = txtUsername.Text;
                connectionParams.Password = txtPassword.Text;
                result = true;
            }

            return result;
        }

        public msConnectionForm()
        {
            InitializeComponent();

            cboTipo.Items.Clear();
            cboTipo.Items.AddRange(Enum.GetNames(typeof(MsDatabaseType)));
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar)
            {
                txtPassword.UseSystemPasswordChar = false;
                (sender as Button).Text = Messages.buttonHide;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                (sender as Button).Text = Messages.buttonShow;
            }
        }
    }
}
