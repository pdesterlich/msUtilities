using System;
using System.Windows;

namespace msUtilities.Database.Forms.Wpf
{
    /// <summary>
    /// Logica di interazione per msConnectionFormWpf.xaml
    /// </summary>
    public partial class msConnectionFormWpf : Window
    {
        public bool showDialog(string title, ref MsConnectionParams connectionParams)
        {
            Title = title;

            BtnMostraPassword.Content = Messages.buttonShow;
            BtnConfirm.Content = Messages.buttonOk;
            BtnCancel.Content = Messages.buttonCancel;

            LblType.Content = Messages.labelConnectionType;
            LblHost.Content = Messages.labelConnectionHost;
            LblDatabase.Content = Messages.labelConnectionDatabase;
            LblUsername.Content = Messages.labelConnectionUsername;
            LblPassword.Content = Messages.labelConnectionPassword;

            CboType.SelectedIndex = CboType.Items.IndexOf(connectionParams.DatabaseType.ToString());
            TxtHost.Text = connectionParams.Host;
            TxtDatabase.Text = connectionParams.Database;
            TxtUsername.Text = connectionParams.Username;
            TxtPassword.Password = connectionParams.Password;

            var dialog = ShowDialog();
            if (dialog == null || !(bool)dialog) return false;

            connectionParams.DatabaseType = (MsDatabaseType)Enum.Parse(typeof(MsDatabaseType), CboType.SelectedItem.ToString());
            connectionParams.Host = TxtHost.Text;
            connectionParams.Database = TxtDatabase.Text;
            connectionParams.Username = TxtUsername.Text;
            connectionParams.Password = TxtPassword.Password;

            return true;
        }

        public msConnectionFormWpf()
        {
            InitializeComponent();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            CboType.Items.Clear();
            CboType.ItemsSource = Enum.GetNames(typeof(MsDatabaseType));
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void BtnMostraPassword_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(TxtPassword.Password, Title);
        }
    }
}
