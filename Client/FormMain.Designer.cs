namespace Client
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemCompound = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemConnection = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemByIPaddress = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemByHostName = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDisconnection = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelText = new System.Windows.Forms.Label();
            this.labelHashedText = new System.Windows.Forms.Label();
            this.textBoxTextTransmission = new System.Windows.Forms.TextBox();
            this.textBoxHashedText = new System.Windows.Forms.TextBox();
            this.textButtonTransmitInfo = new System.Windows.Forms.Button();
            this.textButtonCheckInfo = new System.Windows.Forms.Button();
            this.groupBoxHashAlgorithm = new System.Windows.Forms.GroupBox();
            this.radioButtonDSA = new System.Windows.Forms.RadioButton();
            this.radioButtonRSA = new System.Windows.Forms.RadioButton();
            this.textBoxInformation = new System.Windows.Forms.TextBox();
            this.labelInformation = new System.Windows.Forms.Label();
            this.labelPrimeNumber = new System.Windows.Forms.Label();
            this.labelP = new System.Windows.Forms.Label();
            this.textBoxP = new System.Windows.Forms.TextBox();
            this.textBoxQ = new System.Windows.Forms.TextBox();
            this.labelQ = new System.Windows.Forms.Label();
            this.textBoxN = new System.Windows.Forms.TextBox();
            this.labelN = new System.Windows.Forms.Label();
            this.textBoxD = new System.Windows.Forms.TextBox();
            this.labelD = new System.Windows.Forms.Label();
            this.labelKeys = new System.Windows.Forms.Label();
            this.textButtonTakeTextFromFile = new System.Windows.Forms.Button();
            this.textButtonGenerateKeys = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBoxHashAlgorithm.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemCompound,
            this.toolStripMenuItemExit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(522, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItemCompound
            // 
            this.toolStripMenuItemCompound.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemConnection,
            this.toolStripMenuItemDisconnection});
            this.toolStripMenuItemCompound.Name = "toolStripMenuItemCompound";
            this.toolStripMenuItemCompound.Size = new System.Drawing.Size(80, 20);
            this.toolStripMenuItemCompound.Text = "Compound";
            // 
            // toolStripMenuItemConnection
            // 
            this.toolStripMenuItemConnection.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemByIPaddress,
            this.toolStripMenuItemByHostName});
            this.toolStripMenuItemConnection.Name = "toolStripMenuItemConnection";
            this.toolStripMenuItemConnection.Size = new System.Drawing.Size(150, 22);
            this.toolStripMenuItemConnection.Text = "Connection";
            // 
            // toolStripMenuItemByIPaddress
            // 
            this.toolStripMenuItemByIPaddress.Name = "toolStripMenuItemByIPaddress";
            this.toolStripMenuItemByIPaddress.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItemByIPaddress.Text = "by IP-address";
            this.toolStripMenuItemByIPaddress.Click += new System.EventHandler(this.ToolStripMenuItemByIPaddress_Click);
            // 
            // toolStripMenuItemByHostName
            // 
            this.toolStripMenuItemByHostName.Name = "toolStripMenuItemByHostName";
            this.toolStripMenuItemByHostName.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItemByHostName.Text = "by host name";
            this.toolStripMenuItemByHostName.Click += new System.EventHandler(this.ToolStripMenuItemByHostName_Click);
            // 
            // toolStripMenuItemDisconnection
            // 
            this.toolStripMenuItemDisconnection.Name = "toolStripMenuItemDisconnection";
            this.toolStripMenuItemDisconnection.Size = new System.Drawing.Size(150, 22);
            this.toolStripMenuItemDisconnection.Text = "Disconnection";
            this.toolStripMenuItemDisconnection.Click += new System.EventHandler(this.ToolStripMenuItemDisconnection_Click);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItemExit.Text = "Exit";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.ToolStripMenuItemExit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 391);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(522, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(253, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "No connection";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripStatusLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(253, 17);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.Location = new System.Drawing.Point(12, 50);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(103, 13);
            this.labelText.TabIndex = 10;
            this.labelText.Text = "Text for transmission";
            // 
            // labelHashedText
            // 
            this.labelHashedText.AutoSize = true;
            this.labelHashedText.Location = new System.Drawing.Point(250, 50);
            this.labelHashedText.Name = "labelHashedText";
            this.labelHashedText.Size = new System.Drawing.Size(64, 13);
            this.labelHashedText.TabIndex = 11;
            this.labelHashedText.Text = "Hashed text";
            // 
            // textBoxTextTransmission
            // 
            this.textBoxTextTransmission.Location = new System.Drawing.Point(12, 79);
            this.textBoxTextTransmission.Multiline = true;
            this.textBoxTextTransmission.Name = "textBoxTextTransmission";
            this.textBoxTextTransmission.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxTextTransmission.Size = new System.Drawing.Size(235, 191);
            this.textBoxTextTransmission.TabIndex = 12;
            // 
            // textBoxHashedText
            // 
            this.textBoxHashedText.Location = new System.Drawing.Point(253, 79);
            this.textBoxHashedText.Multiline = true;
            this.textBoxHashedText.Name = "textBoxHashedText";
            this.textBoxHashedText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxHashedText.Size = new System.Drawing.Size(240, 57);
            this.textBoxHashedText.TabIndex = 13;
            // 
            // textButtonTransmitInfo
            // 
            this.textButtonTransmitInfo.Location = new System.Drawing.Point(12, 325);
            this.textButtonTransmitInfo.Name = "textButtonTransmitInfo";
            this.textButtonTransmitInfo.Size = new System.Drawing.Size(142, 23);
            this.textButtonTransmitInfo.TabIndex = 14;
            this.textButtonTransmitInfo.Text = "Transmit text, ESD, key";
            this.textButtonTransmitInfo.UseVisualStyleBackColor = true;
            this.textButtonTransmitInfo.Click += new System.EventHandler(this.textButtonTransmitInfo_Click);
            // 
            // textButtonCheckInfo
            // 
            this.textButtonCheckInfo.Location = new System.Drawing.Point(12, 358);
            this.textButtonCheckInfo.Name = "textButtonCheckInfo";
            this.textButtonCheckInfo.Size = new System.Drawing.Size(142, 23);
            this.textButtonCheckInfo.TabIndex = 15;
            this.textButtonCheckInfo.Text = "Check ESD and view info";
            this.textButtonCheckInfo.UseVisualStyleBackColor = true;
            this.textButtonCheckInfo.Click += new System.EventHandler(this.textButtonCheckInfo_Click);
            // 
            // groupBoxHashAlgorithm
            // 
            this.groupBoxHashAlgorithm.Controls.Add(this.radioButtonDSA);
            this.groupBoxHashAlgorithm.Controls.Add(this.radioButtonRSA);
            this.groupBoxHashAlgorithm.Location = new System.Drawing.Point(160, 289);
            this.groupBoxHashAlgorithm.Name = "groupBoxHashAlgorithm";
            this.groupBoxHashAlgorithm.Size = new System.Drawing.Size(149, 76);
            this.groupBoxHashAlgorithm.TabIndex = 16;
            this.groupBoxHashAlgorithm.TabStop = false;
            this.groupBoxHashAlgorithm.Text = "Hash algorithm";
            // 
            // radioButtonDSA
            // 
            this.radioButtonDSA.AutoSize = true;
            this.radioButtonDSA.Location = new System.Drawing.Point(6, 49);
            this.radioButtonDSA.Name = "radioButtonDSA";
            this.radioButtonDSA.Size = new System.Drawing.Size(47, 17);
            this.radioButtonDSA.TabIndex = 7;
            this.radioButtonDSA.Text = "DSA";
            this.radioButtonDSA.UseVisualStyleBackColor = true;
            this.radioButtonDSA.CheckedChanged += new System.EventHandler(this.radioButtonDSA_CheckedChanged);
            // 
            // radioButtonRSA
            // 
            this.radioButtonRSA.AutoSize = true;
            this.radioButtonRSA.Checked = true;
            this.radioButtonRSA.Location = new System.Drawing.Point(6, 22);
            this.radioButtonRSA.Name = "radioButtonRSA";
            this.radioButtonRSA.Size = new System.Drawing.Size(45, 18);
            this.radioButtonRSA.TabIndex = 6;
            this.radioButtonRSA.TabStop = true;
            this.radioButtonRSA.Text = "RSA";
            this.radioButtonRSA.UseCompatibleTextRendering = true;
            this.radioButtonRSA.UseVisualStyleBackColor = true;
            this.radioButtonRSA.CheckedChanged += new System.EventHandler(this.radioButtonRSA_CheckedChanged);
            // 
            // textBoxInformation
            // 
            this.textBoxInformation.Location = new System.Drawing.Point(253, 164);
            this.textBoxInformation.Multiline = true;
            this.textBoxInformation.Name = "textBoxInformation";
            this.textBoxInformation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxInformation.Size = new System.Drawing.Size(240, 106);
            this.textBoxInformation.TabIndex = 18;
            // 
            // labelInformation
            // 
            this.labelInformation.AutoSize = true;
            this.labelInformation.Location = new System.Drawing.Point(253, 139);
            this.labelInformation.Name = "labelInformation";
            this.labelInformation.Size = new System.Drawing.Size(59, 13);
            this.labelInformation.TabIndex = 19;
            this.labelInformation.Text = "Information";
            // 
            // labelPrimeNumber
            // 
            this.labelPrimeNumber.AutoSize = true;
            this.labelPrimeNumber.Location = new System.Drawing.Point(316, 290);
            this.labelPrimeNumber.Name = "labelPrimeNumber";
            this.labelPrimeNumber.Size = new System.Drawing.Size(76, 13);
            this.labelPrimeNumber.TabIndex = 24;
            this.labelPrimeNumber.Text = "Prime numbers";
            // 
            // labelP
            // 
            this.labelP.AutoSize = true;
            this.labelP.Location = new System.Drawing.Point(316, 311);
            this.labelP.Name = "labelP";
            this.labelP.Size = new System.Drawing.Size(22, 13);
            this.labelP.TabIndex = 25;
            this.labelP.Text = "p =";
            // 
            // textBoxP
            // 
            this.textBoxP.Location = new System.Drawing.Point(336, 309);
            this.textBoxP.Name = "textBoxP";
            this.textBoxP.Size = new System.Drawing.Size(62, 20);
            this.textBoxP.TabIndex = 26;
            this.textBoxP.Text = "101";
            this.textBoxP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxQ
            // 
            this.textBoxQ.Location = new System.Drawing.Point(336, 335);
            this.textBoxQ.Name = "textBoxQ";
            this.textBoxQ.Size = new System.Drawing.Size(62, 20);
            this.textBoxQ.TabIndex = 28;
            this.textBoxQ.Text = "103";
            this.textBoxQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelQ
            // 
            this.labelQ.AutoSize = true;
            this.labelQ.Location = new System.Drawing.Point(316, 337);
            this.labelQ.Name = "labelQ";
            this.labelQ.Size = new System.Drawing.Size(22, 13);
            this.labelQ.TabIndex = 27;
            this.labelQ.Text = "q =";
            // 
            // textBoxN
            // 
            this.textBoxN.Location = new System.Drawing.Point(431, 334);
            this.textBoxN.Name = "textBoxN";
            this.textBoxN.Size = new System.Drawing.Size(62, 20);
            this.textBoxN.TabIndex = 32;
            this.textBoxN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelN
            // 
            this.labelN.AutoSize = true;
            this.labelN.Location = new System.Drawing.Point(411, 336);
            this.labelN.Name = "labelN";
            this.labelN.Size = new System.Drawing.Size(22, 13);
            this.labelN.TabIndex = 31;
            this.labelN.Text = "n =";
            // 
            // textBoxD
            // 
            this.textBoxD.Location = new System.Drawing.Point(431, 308);
            this.textBoxD.Name = "textBoxD";
            this.textBoxD.Size = new System.Drawing.Size(62, 20);
            this.textBoxD.TabIndex = 30;
            this.textBoxD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelD
            // 
            this.labelD.AutoSize = true;
            this.labelD.Location = new System.Drawing.Point(411, 310);
            this.labelD.Name = "labelD";
            this.labelD.Size = new System.Drawing.Size(22, 13);
            this.labelD.TabIndex = 29;
            this.labelD.Text = "d =";
            // 
            // labelKeys
            // 
            this.labelKeys.AutoSize = true;
            this.labelKeys.Location = new System.Drawing.Point(411, 290);
            this.labelKeys.Name = "labelKeys";
            this.labelKeys.Size = new System.Drawing.Size(30, 13);
            this.labelKeys.TabIndex = 33;
            this.labelKeys.Text = "Keys";
            // 
            // textButtonTakeTextFromFile
            // 
            this.textButtonTakeTextFromFile.Location = new System.Drawing.Point(12, 289);
            this.textButtonTakeTextFromFile.Name = "textButtonTakeTextFromFile";
            this.textButtonTakeTextFromFile.Size = new System.Drawing.Size(142, 23);
            this.textButtonTakeTextFromFile.TabIndex = 34;
            this.textButtonTakeTextFromFile.Text = "Take text from file";
            this.textButtonTakeTextFromFile.UseVisualStyleBackColor = true;
            this.textButtonTakeTextFromFile.Click += new System.EventHandler(this.textButtonTakeTextFromFile_Click);
            // 
            // textButtonGenerateKeys
            // 
            this.textButtonGenerateKeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textButtonGenerateKeys.Location = new System.Drawing.Point(336, 361);
            this.textButtonGenerateKeys.Name = "textButtonGenerateKeys";
            this.textButtonGenerateKeys.Size = new System.Drawing.Size(157, 21);
            this.textButtonGenerateKeys.TabIndex = 35;
            this.textButtonGenerateKeys.Text = "Generate keys";
            this.textButtonGenerateKeys.UseVisualStyleBackColor = true;
            this.textButtonGenerateKeys.Click += new System.EventHandler(this.textButtonGenerateKeys_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(522, 413);
            this.Controls.Add(this.textButtonGenerateKeys);
            this.Controls.Add(this.textButtonTakeTextFromFile);
            this.Controls.Add(this.labelKeys);
            this.Controls.Add(this.textBoxN);
            this.Controls.Add(this.labelN);
            this.Controls.Add(this.textBoxD);
            this.Controls.Add(this.labelD);
            this.Controls.Add(this.textBoxQ);
            this.Controls.Add(this.labelQ);
            this.Controls.Add(this.textBoxP);
            this.Controls.Add(this.labelP);
            this.Controls.Add(this.labelPrimeNumber);
            this.Controls.Add(this.labelInformation);
            this.Controls.Add(this.textBoxInformation);
            this.Controls.Add(this.groupBoxHashAlgorithm);
            this.Controls.Add(this.textButtonCheckInfo);
            this.Controls.Add(this.textButtonTransmitInfo);
            this.Controls.Add(this.textBoxHashedText);
            this.Controls.Add(this.textBoxTextTransmission);
            this.Controls.Add(this.labelHashedText);
            this.Controls.Add(this.labelText);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBoxHashAlgorithm.ResumeLayout(false);
            this.groupBoxHashAlgorithm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCompound;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemConnection;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemByIPaddress;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemByHostName;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDisconnection;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;

        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.Label labelHashedText;
        private System.Windows.Forms.Label labelInformation;
        private System.Windows.Forms.TextBox textBoxTextTransmission;
        private System.Windows.Forms.TextBox textBoxHashedText;
        private System.Windows.Forms.TextBox textBoxInformation;

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button textButtonTransmitInfo;
        private System.Windows.Forms.Button textButtonCheckInfo;
        private System.Windows.Forms.GroupBox groupBoxHashAlgorithm;
        private System.Windows.Forms.RadioButton radioButtonDSA;
        private System.Windows.Forms.RadioButton radioButtonRSA;
        private System.Windows.Forms.Label labelPrimeNumber;
        private System.Windows.Forms.Label labelP;
        private System.Windows.Forms.TextBox textBoxP;
        private System.Windows.Forms.TextBox textBoxQ;
        private System.Windows.Forms.Label labelQ;
        private System.Windows.Forms.TextBox textBoxN;
        private System.Windows.Forms.Label labelN;
        private System.Windows.Forms.TextBox textBoxD;
        private System.Windows.Forms.Label labelD;
        private System.Windows.Forms.Label labelKeys;
        private System.Windows.Forms.Button textButtonTakeTextFromFile;
        private System.Windows.Forms.Button textButtonGenerateKeys;
    }
}

