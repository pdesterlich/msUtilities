using System;
using System.Windows;

namespace msUtilities.Database.Forms.Wpf
{
    /// <summary>
    /// Logica di interazione per msConnectionFormWpf.xaml
    /// </summary>
    public partial class msConnectionFormWpf : Window
    {
        public bool showDialog(string title, ref msConnectionParams connectionParams)
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

            CboType.SelectedIndex = CboType.Items.IndexOf(connectionParams.databaseType.ToString());
            TxtHost.Text = connectionParams.host;
            TxtDatabase.Text = connectionParams.database;
            TxtUsername.Text = connectionParams.username;
            TxtPassword.Password = connectionParams.password;

            var dialog = ShowDialog();
            if (dialog == null || !(bool)dialog) return false;

            connectionParams.databaseType = (MsDatabaseType)Enum.Parse(typeof(MsDatabaseType), CboType.SelectedItem.ToString());
            connectionParams.host = TxtHost.Text;
            connectionParams.database = TxtDatabase.Text;
            connectionParams.username = TxtUsername.Text;
            connectionParams.password = TxtPassword.Password;

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
