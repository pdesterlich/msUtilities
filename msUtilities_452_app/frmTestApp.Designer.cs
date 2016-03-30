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
      this.tabTests = new System.Windows.Forms.TabControl();
      this.tabMain = new System.Windows.Forms.TabPage();
      this.buttonTestMessages = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.tabSendMail = new System.Windows.Forms.TabPage();
      this.label8 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.btnSendMail = new System.Windows.Forms.Button();
      this.txtSendMailBody = new System.Windows.Forms.TextBox();
      this.txtSendMailSubject = new System.Windows.Forms.TextBox();
      this.txtSendMailTo = new System.Windows.Forms.TextBox();
      this.txtSendMailFrom = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.chkSmtpSSL = new System.Windows.Forms.CheckBox();
      this.txtSmtpPort = new System.Windows.Forms.TextBox();
      this.txtSmtpPassword = new System.Windows.Forms.TextBox();
      this.txtSmtpUser = new System.Windows.Forms.TextBox();
      this.txtSmtpHost = new System.Windows.Forms.TextBox();
      this.btnTestMinutesToDateTime = new System.Windows.Forms.Button();
      this.tabTests.SuspendLayout();
      this.tabMain.SuspendLayout();
      this.tabSendMail.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnTestMsConnectionForms
      // 
      this.btnTestMsConnectionForms.Location = new System.Drawing.Point(6, 6);
      this.btnTestMsConnectionForms.Name = "btnTestMsConnectionForms";
      this.btnTestMsConnectionForms.Size = new System.Drawing.Size(200, 23);
      this.btnTestMsConnectionForms.TabIndex = 0;
      this.btnTestMsConnectionForms.Text = "test msConnectionForms";
      this.btnTestMsConnectionForms.UseVisualStyleBackColor = true;
      this.btnTestMsConnectionForms.Click += new System.EventHandler(this.btnTestMsConnectionForms_Click);
      // 
      // btnTestMsConnectionFormsSqlServer
      // 
      this.btnTestMsConnectionFormsSqlServer.Location = new System.Drawing.Point(6, 35);
      this.btnTestMsConnectionFormsSqlServer.Name = "btnTestMsConnectionFormsSqlServer";
      this.btnTestMsConnectionFormsSqlServer.Size = new System.Drawing.Size(200, 23);
      this.btnTestMsConnectionFormsSqlServer.TabIndex = 1;
      this.btnTestMsConnectionFormsSqlServer.Text = "test msConnectionForms (sql server)";
      this.btnTestMsConnectionFormsSqlServer.UseVisualStyleBackColor = true;
      this.btnTestMsConnectionFormsSqlServer.Click += new System.EventHandler(this.btnTestMsConnectionFormsSqlServer_Click);
      // 
      // tabTests
      // 
      this.tabTests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tabTests.Controls.Add(this.tabMain);
      this.tabTests.Controls.Add(this.tabSendMail);
      this.tabTests.Location = new System.Drawing.Point(12, 12);
      this.tabTests.Name = "tabTests";
      this.tabTests.SelectedIndex = 0;
      this.tabTests.Size = new System.Drawing.Size(660, 387);
      this.tabTests.TabIndex = 2;
      // 
      // tabMain
      // 
      this.tabMain.BackColor = System.Drawing.SystemColors.Control;
      this.tabMain.Controls.Add(this.btnTestMinutesToDateTime);
      this.tabMain.Controls.Add(this.buttonTestMessages);
      this.tabMain.Controls.Add(this.button1);
      this.tabMain.Controls.Add(this.btnTestMsConnectionForms);
      this.tabMain.Controls.Add(this.btnTestMsConnectionFormsSqlServer);
      this.tabMain.Location = new System.Drawing.Point(4, 22);
      this.tabMain.Name = "tabMain";
      this.tabMain.Padding = new System.Windows.Forms.Padding(3);
      this.tabMain.Size = new System.Drawing.Size(652, 361);
      this.tabMain.TabIndex = 0;
      this.tabMain.Text = "Main";
      // 
      // buttonTestMessages
      // 
      this.buttonTestMessages.Location = new System.Drawing.Point(6, 93);
      this.buttonTestMessages.Name = "buttonTestMessages";
      this.buttonTestMessages.Size = new System.Drawing.Size(200, 23);
      this.buttonTestMessages.TabIndex = 3;
      this.buttonTestMessages.Text = "test Messages";
      this.buttonTestMessages.UseVisualStyleBackColor = true;
      this.buttonTestMessages.Click += new System.EventHandler(this.buttonTestMessages_Click);
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(6, 64);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(200, 23);
      this.button1.TabIndex = 2;
      this.button1.Text = "test msSmtpConfigForm";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // tabSendMail
      // 
      this.tabSendMail.BackColor = System.Drawing.SystemColors.Control;
      this.tabSendMail.Controls.Add(this.label8);
      this.tabSendMail.Controls.Add(this.label7);
      this.tabSendMail.Controls.Add(this.label6);
      this.tabSendMail.Controls.Add(this.label5);
      this.tabSendMail.Controls.Add(this.btnSendMail);
      this.tabSendMail.Controls.Add(this.txtSendMailBody);
      this.tabSendMail.Controls.Add(this.txtSendMailSubject);
      this.tabSendMail.Controls.Add(this.txtSendMailTo);
      this.tabSendMail.Controls.Add(this.txtSendMailFrom);
      this.tabSendMail.Controls.Add(this.label4);
      this.tabSendMail.Controls.Add(this.label3);
      this.tabSendMail.Controls.Add(this.label2);
      this.tabSendMail.Controls.Add(this.label1);
      this.tabSendMail.Controls.Add(this.chkSmtpSSL);
      this.tabSendMail.Controls.Add(this.txtSmtpPort);
      this.tabSendMail.Controls.Add(this.txtSmtpPassword);
      this.tabSendMail.Controls.Add(this.txtSmtpUser);
      this.tabSendMail.Controls.Add(this.txtSmtpHost);
      this.tabSendMail.Location = new System.Drawing.Point(4, 22);
      this.tabSendMail.Name = "tabSendMail";
      this.tabSendMail.Padding = new System.Windows.Forms.Padding(3);
      this.tabSendMail.Size = new System.Drawing.Size(652, 361);
      this.tabSendMail.TabIndex = 1;
      this.tabSendMail.Text = "SendMail";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(67, 191);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(30, 13);
      this.label8.TabIndex = 17;
      this.label8.Text = "body";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(53, 165);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(41, 13);
      this.label7.TabIndex = 16;
      this.label7.Text = "subject";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(78, 139);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(16, 13);
      this.label6.TabIndex = 15;
      this.label6.Text = "to";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(67, 113);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(27, 13);
      this.label5.TabIndex = 14;
      this.label5.Text = "from";
      // 
      // btnSendMail
      // 
      this.btnSendMail.Location = new System.Drawing.Point(325, 284);
      this.btnSendMail.Name = "btnSendMail";
      this.btnSendMail.Size = new System.Drawing.Size(75, 23);
      this.btnSendMail.TabIndex = 13;
      this.btnSendMail.Text = "SendMail";
      this.btnSendMail.UseVisualStyleBackColor = true;
      this.btnSendMail.Click += new System.EventHandler(this.btnSendMail_Click);
      // 
      // txtSendMailBody
      // 
      this.txtSendMailBody.Location = new System.Drawing.Point(100, 188);
      this.txtSendMailBody.Multiline = true;
      this.txtSendMailBody.Name = "txtSendMailBody";
      this.txtSendMailBody.Size = new System.Drawing.Size(300, 90);
      this.txtSendMailBody.TabIndex = 12;
      // 
      // txtSendMailSubject
      // 
      this.txtSendMailSubject.Location = new System.Drawing.Point(100, 162);
      this.txtSendMailSubject.Name = "txtSendMailSubject";
      this.txtSendMailSubject.Size = new System.Drawing.Size(300, 20);
      this.txtSendMailSubject.TabIndex = 11;
      // 
      // txtSendMailTo
      // 
      this.txtSendMailTo.Location = new System.Drawing.Point(100, 136);
      this.txtSendMailTo.Name = "txtSendMailTo";
      this.txtSendMailTo.Size = new System.Drawing.Size(300, 20);
      this.txtSendMailTo.TabIndex = 10;
      // 
      // txtSendMailFrom
      // 
      this.txtSendMailFrom.Location = new System.Drawing.Point(100, 110);
      this.txtSendMailFrom.Name = "txtSendMailFrom";
      this.txtSendMailFrom.Size = new System.Drawing.Size(300, 20);
      this.txtSendMailFrom.TabIndex = 9;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(69, 87);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(25, 13);
      this.label4.TabIndex = 8;
      this.label4.Text = "port";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(42, 61);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(52, 13);
      this.label3.TabIndex = 7;
      this.label3.Text = "password";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(41, 35);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(53, 13);
      this.label2.TabIndex = 6;
      this.label2.Text = "username";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(67, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(27, 13);
      this.label1.TabIndex = 5;
      this.label1.Text = "host";
      // 
      // chkSmtpSSL
      // 
      this.chkSmtpSSL.AutoSize = true;
      this.chkSmtpSSL.Location = new System.Drawing.Point(206, 86);
      this.chkSmtpSSL.Name = "chkSmtpSSL";
      this.chkSmtpSSL.Size = new System.Drawing.Size(81, 17);
      this.chkSmtpSSL.TabIndex = 4;
      this.chkSmtpSSL.Text = "enable SSL";
      this.chkSmtpSSL.UseVisualStyleBackColor = true;
      // 
      // txtSmtpPort
      // 
      this.txtSmtpPort.Location = new System.Drawing.Point(100, 84);
      this.txtSmtpPort.Name = "txtSmtpPort";
      this.txtSmtpPort.Size = new System.Drawing.Size(100, 20);
      this.txtSmtpPort.TabIndex = 3;
      this.txtSmtpPort.Text = "25";
      // 
      // txtSmtpPassword
      // 
      this.txtSmtpPassword.Location = new System.Drawing.Point(100, 58);
      this.txtSmtpPassword.Name = "txtSmtpPassword";
      this.txtSmtpPassword.Size = new System.Drawing.Size(300, 20);
      this.txtSmtpPassword.TabIndex = 2;
      this.txtSmtpPassword.UseSystemPasswordChar = true;
      // 
      // txtSmtpUser
      // 
      this.txtSmtpUser.Location = new System.Drawing.Point(100, 32);
      this.txtSmtpUser.Name = "txtSmtpUser";
      this.txtSmtpUser.Size = new System.Drawing.Size(300, 20);
      this.txtSmtpUser.TabIndex = 1;
      // 
      // txtSmtpHost
      // 
      this.txtSmtpHost.Location = new System.Drawing.Point(100, 6);
      this.txtSmtpHost.Name = "txtSmtpHost";
      this.txtSmtpHost.Size = new System.Drawing.Size(300, 20);
      this.txtSmtpHost.TabIndex = 0;
      // 
      // btnTestMinutesToDateTime
      // 
      this.btnTestMinutesToDateTime.Location = new System.Drawing.Point(6, 122);
      this.btnTestMinutesToDateTime.Name = "btnTestMinutesToDateTime";
      this.btnTestMinutesToDateTime.Size = new System.Drawing.Size(200, 23);
      this.btnTestMinutesToDateTime.TabIndex = 4;
      this.btnTestMinutesToDateTime.Text = "test minutesToDateTime";
      this.btnTestMinutesToDateTime.UseVisualStyleBackColor = true;
      this.btnTestMinutesToDateTime.Click += new System.EventHandler(this.btnTestMinutesToDateTime_Click);
      // 
      // frmTestApp
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(684, 411);
      this.Controls.Add(this.tabTests);
      this.Name = "frmTestApp";
      this.Text = "msUtilites Test App";
      this.tabTests.ResumeLayout(false);
      this.tabMain.ResumeLayout(false);
      this.tabSendMail.ResumeLayout(false);
      this.tabSendMail.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnTestMsConnectionForms;
    private System.Windows.Forms.Button btnTestMsConnectionFormsSqlServer;
    private System.Windows.Forms.TabControl tabTests;
    private System.Windows.Forms.TabPage tabMain;
    private System.Windows.Forms.TabPage tabSendMail;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.CheckBox chkSmtpSSL;
    private System.Windows.Forms.TextBox txtSmtpPort;
    private System.Windows.Forms.TextBox txtSmtpPassword;
    private System.Windows.Forms.TextBox txtSmtpUser;
    private System.Windows.Forms.TextBox txtSmtpHost;
    private System.Windows.Forms.TextBox txtSendMailBody;
    private System.Windows.Forms.TextBox txtSendMailSubject;
    private System.Windows.Forms.TextBox txtSendMailTo;
    private System.Windows.Forms.TextBox txtSendMailFrom;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Button btnSendMail;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button buttonTestMessages;
    private System.Windows.Forms.Button btnTestMinutesToDateTime;
  }
}

