namespace msUtilities
{
  partial class msSmtpConfigForm
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
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnOk = new System.Windows.Forms.Button();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.btnShowPassword = new System.Windows.Forms.Button();
      this.txtPassword = new System.Windows.Forms.TextBox();
      this.txtUsername = new System.Windows.Forms.TextBox();
      this.txtHost = new System.Windows.Forms.TextBox();
      this.txtName = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.txtPort = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.chkEnableSSL = new System.Windows.Forms.CheckBox();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(92, 176);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(100, 23);
      this.btnCancel.TabIndex = 7;
      this.btnCancel.Text = "&Annulla";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // btnOk
      // 
      this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOk.Location = new System.Drawing.Point(292, 176);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(100, 23);
      this.btnOk.TabIndex = 8;
      this.btnOk.Text = "&Ok";
      this.btnOk.UseVisualStyleBackColor = true;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(34, 93);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(52, 13);
      this.label5.TabIndex = 19;
      this.label5.Text = "password";
      this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(49, 67);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(37, 13);
      this.label4.TabIndex = 18;
      this.label4.Text = "utente";
      this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(59, 41);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(27, 13);
      this.label2.TabIndex = 17;
      this.label2.Text = "host";
      this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // btnShowPassword
      // 
      this.btnShowPassword.Location = new System.Drawing.Point(317, 88);
      this.btnShowPassword.Name = "btnShowPassword";
      this.btnShowPassword.Size = new System.Drawing.Size(75, 23);
      this.btnShowPassword.TabIndex = 4;
      this.btnShowPassword.Text = "Mostra";
      this.btnShowPassword.UseVisualStyleBackColor = true;
      this.btnShowPassword.Click += new System.EventHandler(this.btnShowPassword_Click);
      // 
      // txtPassword
      // 
      this.txtPassword.Location = new System.Drawing.Point(92, 90);
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.Size = new System.Drawing.Size(219, 20);
      this.txtPassword.TabIndex = 3;
      this.txtPassword.UseSystemPasswordChar = true;
      // 
      // txtUsername
      // 
      this.txtUsername.Location = new System.Drawing.Point(92, 64);
      this.txtUsername.Name = "txtUsername";
      this.txtUsername.Size = new System.Drawing.Size(300, 20);
      this.txtUsername.TabIndex = 2;
      // 
      // txtHost
      // 
      this.txtHost.Location = new System.Drawing.Point(92, 38);
      this.txtHost.Name = "txtHost";
      this.txtHost.Size = new System.Drawing.Size(300, 20);
      this.txtHost.TabIndex = 1;
      // 
      // txtName
      // 
      this.txtName.Location = new System.Drawing.Point(92, 12);
      this.txtName.Name = "txtName";
      this.txtName.Size = new System.Drawing.Size(300, 20);
      this.txtName.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(53, 15);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(33, 13);
      this.label1.TabIndex = 23;
      this.label1.Text = "nome";
      this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // txtPort
      // 
      this.txtPort.Location = new System.Drawing.Point(92, 116);
      this.txtPort.Name = "txtPort";
      this.txtPort.Size = new System.Drawing.Size(100, 20);
      this.txtPort.TabIndex = 5;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(55, 119);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(31, 13);
      this.label3.TabIndex = 25;
      this.label3.Text = "porta";
      this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // chkEnableSSL
      // 
      this.chkEnableSSL.AutoSize = true;
      this.chkEnableSSL.Location = new System.Drawing.Point(92, 142);
      this.chkEnableSSL.Name = "chkEnableSSL";
      this.chkEnableSSL.Size = new System.Drawing.Size(76, 17);
      this.chkEnableSSL.TabIndex = 6;
      this.chkEnableSSL.Text = "abilita SSL";
      this.chkEnableSSL.UseVisualStyleBackColor = true;
      // 
      // msSmtpConfigForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(404, 211);
      this.Controls.Add(this.chkEnableSSL);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.txtPort);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txtName);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOk);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.btnShowPassword);
      this.Controls.Add(this.txtPassword);
      this.Controls.Add(this.txtUsername);
      this.Controls.Add(this.txtHost);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "msSmtpConfigForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "msSmtpConfigForm";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btnShowPassword;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.TextBox txtUsername;
    private System.Windows.Forms.TextBox txtHost;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtPort;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.CheckBox chkEnableSSL;
  }
}