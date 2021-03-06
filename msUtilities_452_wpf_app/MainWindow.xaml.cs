﻿using msUtilities.Database;
using msUtilities.Database.Forms.Wpf;
using System.Windows;

namespace msUtilities_452_wpf_app
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnConnectionForm_Click(object sender, RoutedEventArgs e)
        {
            var connectionParams = new MsConnectionParams();
            var connectionForm = new msConnectionFormWpf();
            if (connectionForm.showDialog("wpf test", ref connectionParams))
            {
                MessageBox.Show(connectionParams.ToString());
                MessageBox.Show(connectionParams.GetConnectionString());
            }
        }

        private void BtnConnectionFormSqlServer_Click(object sender, RoutedEventArgs e)
        {
            var connectionParams = new MsConnectionParams();
            connectionParams.DatabaseType = MsDatabaseType.SqlServer;
            var connectionForm = new msConnectionFormWpf();
            if (connectionForm.showDialog("wpf test", ref connectionParams))
            {
                MessageBox.Show(connectionParams.ToString());
                MessageBox.Show(connectionParams.GetConnectionString());
            }
        }
    }
}
