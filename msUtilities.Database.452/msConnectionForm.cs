using System;
using System.Windows.Forms;

namespace msUtilities.Database
{
    public partial class msConnectionForm : Form
    {
        public bool showDialog(string title, ref msConnectionParams connectionParams)
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

            cboTipo.SelectedIndex = cboTipo.Items.IndexOf(connectionParams.databaseType.ToString());
            txtHost.Text = connectionParams.host;
            txtDatabase.Text = connectionParams.database;
            txtUsername.Text = connectionParams.username;
            txtPassword.Text = connectionParams.password;

            if (this.ShowDialog() == DialogResult.OK)
            {
                connectionParams.databaseType = (MsDatabaseType)Enum.Parse(typeof(MsDatabaseType), cboTipo.SelectedItem.ToString());
                connectionParams.host = txtHost.Text;
                connectionParams.database = txtDatabase.Text;
                connectionParams.username = txtUsername.Text;
                connectionParams.password = txtPassword.Text;
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
