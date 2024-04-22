namespace Orange_UAC_Collector
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            ConnectionMethodListBox = new CheckedListBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBoxRemoteUsername = new TextBox();
            textBoxPrivateKeyPassphrase = new TextBox();
            SelectPrivatekeybtn = new Button();
            label4 = new Label();
            textBoxRemoteUserPassword = new TextBox();
            textBoxPrivateKeyPath = new TextBox();
            toolTip1 = new ToolTip(components);
            richTextBox1 = new RichTextBox();
            ImportHostsbtn = new Button();
            label5 = new Label();
            SelectUacFilebtn = new Button();
            textBoxUacPath = new TextBox();
            Connectbtn = new Button();
            label6 = new Label();
            textBoxSFTPUser = new TextBox();
            label7 = new Label();
            textBoxSFTPPassword = new TextBox();
            label8 = new Label();
            textBoxSFTPIP = new TextBox();
            label9 = new Label();
            textBoxSFTPPort = new TextBox();
            CsirtDefaultbtn = new Button();
            richTextBox2 = new RichTextBox();
            label10 = new Label();
            textBoxVersion = new TextBox();
            SuspendLayout();
            // 
            // ConnectionMethodListBox
            // 
            ConnectionMethodListBox.CheckOnClick = true;
            ConnectionMethodListBox.FormattingEnabled = true;
            ConnectionMethodListBox.Items.AddRange(new object[] { "SSH-Agent", "Publik/Private keys", "Username/Password" });
            ConnectionMethodListBox.Location = new Point(35, 52);
            ConnectionMethodListBox.Name = "ConnectionMethodListBox";
            ConnectionMethodListBox.Size = new Size(202, 88);
            ConnectionMethodListBox.TabIndex = 0;
            ConnectionMethodListBox.ItemCheck += ConnectionMethodListBox_ItemCheck;
            ConnectionMethodListBox.SelectedIndexChanged += ConnectionMethodListBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 24);
            label1.Name = "label1";
            label1.Size = new Size(170, 25);
            label1.TabIndex = 1;
            label1.Text = "Connection method";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 154);
            label2.Name = "label2";
            label2.Size = new Size(165, 25);
            label2.TabIndex = 2;
            label2.Text = "Remote User Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(35, 225);
            label3.Name = "label3";
            label3.Size = new Size(193, 25);
            label3.TabIndex = 3;
            label3.Text = "Remote User Password";
            // 
            // textBoxRemoteUsername
            // 
            textBoxRemoteUsername.Location = new Point(35, 182);
            textBoxRemoteUsername.Name = "textBoxRemoteUsername";
            textBoxRemoteUsername.Size = new Size(209, 31);
            textBoxRemoteUsername.TabIndex = 4;
            // 
            // textBoxPrivateKeyPassphrase
            // 
            textBoxPrivateKeyPassphrase.Location = new Point(35, 421);
            textBoxPrivateKeyPassphrase.Name = "textBoxPrivateKeyPassphrase";
            textBoxPrivateKeyPassphrase.Size = new Size(209, 31);
            textBoxPrivateKeyPassphrase.TabIndex = 5;
            // 
            // SelectPrivatekeybtn
            // 
            SelectPrivatekeybtn.Enabled = false;
            SelectPrivatekeybtn.Location = new Point(35, 300);
            SelectPrivatekeybtn.Name = "SelectPrivatekeybtn";
            SelectPrivatekeybtn.Size = new Size(209, 31);
            SelectPrivatekeybtn.TabIndex = 6;
            SelectPrivatekeybtn.Text = "Select private Key";
            SelectPrivatekeybtn.UseVisualStyleBackColor = true;
            SelectPrivatekeybtn.Click += SelectPrivatekeybtn_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(35, 388);
            label4.Name = "label4";
            label4.Size = new Size(192, 25);
            label4.TabIndex = 7;
            label4.Text = "Private Key passphrase";
            // 
            // textBoxRemoteUserPassword
            // 
            textBoxRemoteUserPassword.Location = new Point(35, 258);
            textBoxRemoteUserPassword.Name = "textBoxRemoteUserPassword";
            textBoxRemoteUserPassword.Size = new Size(209, 31);
            textBoxRemoteUserPassword.TabIndex = 8;
            // 
            // textBoxPrivateKeyPath
            // 
            textBoxPrivateKeyPath.Location = new Point(35, 338);
            textBoxPrivateKeyPath.Name = "textBoxPrivateKeyPath";
            textBoxPrivateKeyPath.Size = new Size(209, 31);
            textBoxPrivateKeyPath.TabIndex = 9;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(276, 52);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(224, 398);
            richTextBox1.TabIndex = 12;
            richTextBox1.Text = "";
            toolTip1.SetToolTip(richTextBox1, "Specify one host per line.\r\nIP addresses are recommende unless you have \r\nreliable name resolution.\r\nIf different usernames are used, use the format \r\nusername@ipaddress\r\n");
            // 
            // ImportHostsbtn
            // 
            ImportHostsbtn.Location = new Point(276, 462);
            ImportHostsbtn.Name = "ImportHostsbtn";
            ImportHostsbtn.Size = new Size(224, 34);
            ImportHostsbtn.TabIndex = 11;
            ImportHostsbtn.Text = "Import hosts from file";
            ImportHostsbtn.UseVisualStyleBackColor = true;
            ImportHostsbtn.Click += ImportHostsbtn_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(296, 24);
            label5.Name = "label5";
            label5.Size = new Size(180, 25);
            label5.TabIndex = 13;
            label5.Text = "Hosts to be collected";
            // 
            // SelectUacFilebtn
            // 
            SelectUacFilebtn.Location = new Point(276, 511);
            SelectUacFilebtn.Name = "SelectUacFilebtn";
            SelectUacFilebtn.Size = new Size(224, 34);
            SelectUacFilebtn.TabIndex = 14;
            SelectUacFilebtn.Text = "Local UAC Path";
            SelectUacFilebtn.UseVisualStyleBackColor = true;
            SelectUacFilebtn.Click += button1_Click;
            // 
            // textBoxUacPath
            // 
            textBoxUacPath.Location = new Point(276, 563);
            textBoxUacPath.Name = "textBoxUacPath";
            textBoxUacPath.Size = new Size(224, 31);
            textBoxUacPath.TabIndex = 15;
            // 
            // Connectbtn
            // 
            Connectbtn.Location = new Point(276, 739);
            Connectbtn.Name = "Connectbtn";
            Connectbtn.Size = new Size(224, 34);
            Connectbtn.TabIndex = 16;
            Connectbtn.Text = "Collect";
            Connectbtn.UseVisualStyleBackColor = true;
            Connectbtn.Click += Connectbtn_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(64, 466);
            label6.Name = "label6";
            label6.Size = new Size(135, 25);
            label6.TabIndex = 17;
            label6.Text = "Local SFTP User";
            label6.Click += label6_Click;
            // 
            // textBoxSFTPUser
            // 
            textBoxSFTPUser.Location = new Point(35, 499);
            textBoxSFTPUser.Name = "textBoxSFTPUser";
            textBoxSFTPUser.Size = new Size(209, 31);
            textBoxSFTPUser.TabIndex = 18;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(44, 543);
            label7.Name = "label7";
            label7.Size = new Size(175, 25);
            label7.TabIndex = 19;
            label7.Text = "Local SFTP Password";
            // 
            // textBoxSFTPPassword
            // 
            textBoxSFTPPassword.Location = new Point(35, 576);
            textBoxSFTPPassword.Name = "textBoxSFTPPassword";
            textBoxSFTPPassword.Size = new Size(209, 31);
            textBoxSFTPPassword.TabIndex = 20;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(84, 627);
            label8.Name = "label8";
            label8.Size = new Size(115, 25);
            label8.TabIndex = 21;
            label8.Text = "Local SFTP IP";
            label8.Click += label8_Click;
            // 
            // textBoxSFTPIP
            // 
            textBoxSFTPIP.Location = new Point(35, 660);
            textBoxSFTPIP.Name = "textBoxSFTPIP";
            textBoxSFTPIP.Size = new Size(209, 31);
            textBoxSFTPIP.TabIndex = 22;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(75, 707);
            label9.Name = "label9";
            label9.Size = new Size(132, 25);
            label9.TabIndex = 23;
            label9.Text = "Local SFTP Port";
            // 
            // textBoxSFTPPort
            // 
            textBoxSFTPPort.Location = new Point(35, 740);
            textBoxSFTPPort.Name = "textBoxSFTPPort";
            textBoxSFTPPort.Size = new Size(209, 31);
            textBoxSFTPPort.TabIndex = 24;
            // 
            // CsirtDefaultbtn
            // 
            CsirtDefaultbtn.Location = new Point(276, 690);
            CsirtDefaultbtn.Name = "CsirtDefaultbtn";
            CsirtDefaultbtn.Size = new Size(224, 34);
            CsirtDefaultbtn.TabIndex = 25;
            CsirtDefaultbtn.Text = "CSIRT Defaults";
            CsirtDefaultbtn.UseVisualStyleBackColor = true;
            CsirtDefaultbtn.Click += CsirtDefaultbtn_Click;
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(526, 52);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(396, 719);
            richTextBox2.TabIndex = 26;
            richTextBox2.Text = "";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(312, 612);
            label10.Name = "label10";
            label10.Size = new Size(124, 25);
            label10.TabIndex = 27;
            label10.Text = "Using Version:";
            // 
            // textBoxVersion
            // 
            textBoxVersion.Location = new Point(276, 644);
            textBoxVersion.Name = "textBoxVersion";
            textBoxVersion.Size = new Size(224, 31);
            textBoxVersion.TabIndex = 28;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(970, 860);
            Controls.Add(textBoxVersion);
            Controls.Add(label10);
            Controls.Add(richTextBox2);
            Controls.Add(CsirtDefaultbtn);
            Controls.Add(textBoxSFTPPort);
            Controls.Add(label9);
            Controls.Add(textBoxSFTPIP);
            Controls.Add(label8);
            Controls.Add(textBoxSFTPPassword);
            Controls.Add(label7);
            Controls.Add(textBoxSFTPUser);
            Controls.Add(label6);
            Controls.Add(Connectbtn);
            Controls.Add(textBoxUacPath);
            Controls.Add(SelectUacFilebtn);
            Controls.Add(label5);
            Controls.Add(richTextBox1);
            Controls.Add(ImportHostsbtn);
            Controls.Add(textBoxPrivateKeyPath);
            Controls.Add(textBoxRemoteUserPassword);
            Controls.Add(label4);
            Controls.Add(SelectPrivatekeybtn);
            Controls.Add(textBoxPrivateKeyPassphrase);
            Controls.Add(textBoxRemoteUsername);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ConnectionMethodListBox);
            Name = "Form1";
            Text = "Orange CSIRT UAC Collector";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox ConnectionMethodListBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBoxRemoteUsername;
        private TextBox textBoxPrivateKeyPassphrase;
        private Button SelectPrivatekeybtn;
        private Label label4;
        private TextBox textBoxRemoteUserPassword;
        private TextBox textBoxPrivateKeyPath;
        private ToolTip toolTip1;
        private Button ImportHostsbtn;
        private RichTextBox richTextBox1;
        private Label label5;
        private Button SelectUacFilebtn;
        private TextBox textBoxUacPath;
        private Button Connectbtn;
        private Label label6;
        private TextBox textBoxSFTPUser;
        private Label label7;
        private TextBox textBoxSFTPPassword;
        private Label label8;
        private TextBox textBoxSFTPIP;
        private Label label9;
        private TextBox textBoxSFTPPort;
        private Button CsirtDefaultbtn;
        private RichTextBox richTextBox2;
        private Label label10;
        private TextBox textBoxVersion;
    }
}