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
      this.label1 = new System.Windows.Forms.Label();
      this.txtHost = new System.Windows.Forms.TextBox();
      this.txtDatabase = new System.Windows.Forms.TextBox();
      this.txtPassword = new System.Windows.Forms.TextBox();
      this.txtUsername = new System.Windows.Forms.TextBox();
      this.btnShowPassword = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
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
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(62, 15);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(24, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "tipo";
      this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(59, 42);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(27, 13);
      this.label2.TabIndex = 7;
      this.label2.Text = "host";
      this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(35, 68);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(51, 13);
      this.label3.TabIndex = 8;
      this.label3.Text = "database";
      this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(49, 94);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(37, 13);
      this.label4.TabIndex = 9;
      this.label4.Text = "utente";
      this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(34, 120);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(52, 13);
      this.label5.TabIndex = 10;
      this.label5.Text = "password";
      this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.btnShowPassword);
      this.Controls.Add(this.txtPassword);
      this.Controls.Add(this.txtUsername);
      this.Controls.Add(this.txtDatabase);
      this.Controls.Add(this.txtHost);
      this.Controls.Add(this.label1);
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
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtHost;
    private System.Windows.Forms.TextBox txtDatabase;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.TextBox txtUsername;
    private System.Windows.Forms.Button btnShowPassword;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.Button btnCancel;
  }
}