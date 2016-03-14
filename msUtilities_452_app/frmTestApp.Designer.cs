namespace msUtilities_452_app
{
  partial class frmTestApp
  {
    /// <summary>
    /// Variabile di progettazione necessaria.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Pulire le risorse in uso.
    /// </summary>
    /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Codice generato da Progettazione Windows Form

    /// <summary>
    /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
    /// il contenuto del metodo con l'editor di codice.
    /// </summary>
    private void InitializeComponent()
    {
      this.btnTestMsConnectionForms = new System.Windows.Forms.Button();
      this.btnTestMsConnectionFormsSqlServer = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btnTestMsConnectionForms
      // 
      this.btnTestMsConnectionForms.Location = new System.Drawing.Point(12, 12);
      this.btnTestMsConnectionForms.Name = "btnTestMsConnectionForms";
      this.btnTestMsConnectionForms.Size = new System.Drawing.Size(200, 23);
      this.btnTestMsConnectionForms.TabIndex = 0;
      this.btnTestMsConnectionForms.Text = "test msConnectionForms";
      this.btnTestMsConnectionForms.UseVisualStyleBackColor = true;
      this.btnTestMsConnectionForms.Click += new System.EventHandler(this.btnTestMsConnectionForms_Click);
      // 
      // btnTestMsConnectionFormsSqlServer
      // 
      this.btnTestMsConnectionFormsSqlServer.Location = new System.Drawing.Point(12, 41);
      this.btnTestMsConnectionFormsSqlServer.Name = "btnTestMsConnectionFormsSqlServer";
      this.btnTestMsConnectionFormsSqlServer.Size = new System.Drawing.Size(200, 23);
      this.btnTestMsConnectionFormsSqlServer.TabIndex = 1;
      this.btnTestMsConnectionFormsSqlServer.Text = "test msConnectionForms (sql server)";
      this.btnTestMsConnectionFormsSqlServer.UseVisualStyleBackColor = true;
      this.btnTestMsConnectionFormsSqlServer.Click += new System.EventHandler(this.btnTestMsConnectionFormsSqlServer_Click);
      // 
      // frmTestApp
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(444, 265);
      this.Controls.Add(this.btnTestMsConnectionFormsSqlServer);
      this.Controls.Add(this.btnTestMsConnectionForms);
      this.Name = "frmTestApp";
      this.Text = "msUtilites Test App";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnTestMsConnectionForms;
    private System.Windows.Forms.Button btnTestMsConnectionFormsSqlServer;
  }
}

