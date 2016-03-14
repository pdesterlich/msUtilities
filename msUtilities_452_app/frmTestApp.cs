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
  }
}
