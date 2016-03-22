namespace msUtilities
{
  partial class msConnectionForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.cboTipo = new System.Windows.Forms.ComboBox();
      this.labelType = new System.Windows.Forms.Label();
      this.txtHost = new System.Windows.Forms.TextBox();
      this.txtDatabase = new System.Windows.Forms.TextBox();
      this.txtPassword = new System.Windows.Forms.TextBox();
      this.txtUsername = new System.Windows.Forms.TextBox();
      this.btnShowPassword = new System.Windows.Forms.Button();
      this.labelHost = new System.Windows.Forms.Label();
      this.labelDatabase = new System.Windows.Forms.Label();
      this.labelUsername = new System.Windows.Forms.Label();
      this.labelPassword = new System.Windows.Forms.Label();
      this.btnOk = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // cboTipo
      // 
      this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cboTipo.FormattingEnabled = true;
      this.cboTipo.Location = new System.Drawing.Point(92, 12);
      this.cboTipo.Name = "cboTipo";
      this.cboTipo.Size = new System.Drawing.Size(300, 21);
      this.cboTipo.TabIndex = 0;
      // 
      // labelType
      // 
      this.labelType.Location = new System.Drawing.Point(12, 15);
      this.labelType.Name = "labelType";
      this.labelType.Size = new System.Drawing.Size(74, 13);
      this.labelType.TabIndex = 1;
      this.labelType.Text = "tipo";
      this.labelType.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // txtHost
      // 
      this.txtHost.Location = new System.Drawing.Point(92, 39);
      this.txtHost.Name = "txtHost";
      this.txtHost.Size = new System.Drawing.Size(300, 20);
      this.txtHost.TabIndex = 2;
      // 
      // txtDatabase
      // 
      this.txtDatabase.Location = new System.Drawing.Point(92, 65);
      this.txtDatabase.Name = "txtDatabase";
      this.txtDatabase.Size = new System.Drawing.Size(300, 20);
      this.txtDatabase.TabIndex = 3;
      // 
      // txtPassword
      // 
      this.txtPassword.Location = new System.Drawing.Point(92, 117);
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.Size = new System.Drawing.Size(219, 20);
      this.txtPassword.TabIndex = 5;
      this.txtPassword.UseSystemPasswordChar = true;
      // 
      // txtUsername
      // 
      this.txtUsername.Location = new System.Drawing.Point(92, 91);
      this.txtUsername.Name = "txtUsername";
      this.txtUsername.Size = new System.Drawing.Size(300, 20);
      this.txtUsername.TabIndex = 4;
      // 
      // btnShowPassword
      // 
      this.btnShowPassword.Location = new System.Drawing.Point(317, 115);
      this.btnShowPassword.Name = "btnShowPassword";
      this.btnShowPassword.Size = new System.Drawing.Size(75, 23);
      this.btnShowPassword.TabIndex = 6;
      this.btnShowPassword.Text = "Mostra";
      this.btnShowPassword.UseVisualStyleBackColor = true;
      this.btnShowPassword.Click += new System.EventHandler(this.btnShowPassword_Click);
      // 
      // labelHost
      // 
      this.labelHost.Location = new System.Drawing.Point(12, 42);
      this.labelHost.Name = "labelHost";
      this.labelHost.Size = new System.Drawing.Size(74, 13);
      this.labelHost.TabIndex = 7;
      this.labelHost.Text = "host";
      this.labelHost.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // labelDatabase
      // 
      this.labelDatabase.Location = new System.Drawing.Point(12, 68);
      this.labelDatabase.Name = "labelDatabase";
      this.labelDatabase.Size = new System.Drawing.Size(74, 13);
      this.labelDatabase.TabIndex = 8;
      this.labelDatabase.Text = "database";
      this.labelDatabase.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // labelUsername
      // 
      this.labelUsername.Location = new System.Drawing.Point(12, 94);
      this.labelUsername.Name = "labelUsername";
      this.labelUsername.Size = new System.Drawing.Size(74, 13);
      this.labelUsername.TabIndex = 9;
      this.labelUsername.Text = "utente";
      this.labelUsername.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // labelPassword
      // 
      this.labelPassword.Location = new System.Drawing.Point(12, 120);
      this.labelPassword.Name = "labelPassword";
      this.labelPassword.Size = new System.Drawing.Size(74, 13);
      this.labelPassword.TabIndex = 10;
      this.labelPassword.Text = "password";
      this.labelPassword.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // btnOk
      // 
      this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOk.Location = new System.Drawing.Point(292, 156);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(100, 23);
      this.btnOk.TabIndex = 11;
      this.btnOk.Text = "&Ok";
      this.btnOk.UseVisualStyleBackColor = true;
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(92, 156);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(100, 23);
      this.btnCancel.TabIndex = 12;
      this.btnCancel.Text = "&Annulla";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // msConnectionForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(404, 191);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOk);
      this.Controls.Add(this.labelPassword);
      this.Controls.Add(this.labelUsername);
      this.Controls.Add(this.labelDatabase);
      this.Controls.Add(this.labelHost);
      this.Controls.Add(this.btnShowPassword);
      this.Controls.Add(this.txtPassword);
      this.Controls.Add(this.txtUsername);
      this.Controls.Add(this.txtDatabase);
      this.Controls.Add(this.txtHost);
      this.Controls.Add(this.labelType);
      this.Controls.Add(this.cboTipo);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "msConnectionForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "msConnectionForm";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ComboBox cboTipo;
    private System.Windows.Forms.Label labelType;
    private System.Windows.Forms.TextBox txtHost;
    private System.Windows.Forms.TextBox txtDatabase;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.TextBox txtUsername;
    private System.Windows.Forms.Button btnShowPassword;
    private System.Windows.Forms.Label labelHost;
    private System.Windows.Forms.Label labelDatabase;
    private System.Windows.Forms.Label labelUsername;
    private System.Windows.Forms.Label labelPassword;
    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.Button btnCancel;
  }
}