namespace voice_recognition.cs
{
    partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.MainMenu = new System.Windows.Forms.MenuStrip();
			this.moduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.languageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.commandControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dictationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.setGrammarFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addVocabularyFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Status2 = new System.Windows.Forms.TreeView();
			this.Stop = new System.Windows.Forms.Button();
			this.GrammarFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.VocabFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.Console2 = new System.Windows.Forms.TreeView();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.MainMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// MainMenu
			// 
			this.MainMenu.Enabled = false;
			this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moduleToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.languageToolStripMenuItem1,
            this.modeToolStripMenuItem});
			this.MainMenu.Location = new System.Drawing.Point(0, 0);
			this.MainMenu.Name = "MainMenu";
			this.MainMenu.Size = new System.Drawing.Size(261, 26);
			this.MainMenu.TabIndex = 0;
			this.MainMenu.Text = "MainMenu";
			this.MainMenu.Visible = false;
			// 
			// moduleToolStripMenuItem
			// 
			this.moduleToolStripMenuItem.Name = "moduleToolStripMenuItem";
			this.moduleToolStripMenuItem.Size = new System.Drawing.Size(60, 22);
			this.moduleToolStripMenuItem.Text = "Source";
			// 
			// languageToolStripMenuItem
			// 
			this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
			this.languageToolStripMenuItem.Size = new System.Drawing.Size(61, 22);
			this.languageToolStripMenuItem.Text = "Module";
			// 
			// languageToolStripMenuItem1
			// 
			this.languageToolStripMenuItem1.Name = "languageToolStripMenuItem1";
			this.languageToolStripMenuItem1.Size = new System.Drawing.Size(76, 22);
			this.languageToolStripMenuItem1.Text = "Language";
			// 
			// modeToolStripMenuItem
			// 
			this.modeToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commandControlToolStripMenuItem,
            this.dictationToolStripMenuItem,
            this.toolStripSeparator1,
            this.setGrammarFromFileToolStripMenuItem,
            this.addVocabularyFromFileToolStripMenuItem});
			this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
			this.modeToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.modeToolStripMenuItem.Size = new System.Drawing.Size(51, 22);
			this.modeToolStripMenuItem.Text = "Mode";
			// 
			// commandControlToolStripMenuItem
			// 
			this.commandControlToolStripMenuItem.Name = "commandControlToolStripMenuItem";
			this.commandControlToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
			this.commandControlToolStripMenuItem.Text = "Command Control";
			this.commandControlToolStripMenuItem.Click += new System.EventHandler(this.commandControlToolStripMenuItem_Click);
			// 
			// dictationToolStripMenuItem
			// 
			this.dictationToolStripMenuItem.Name = "dictationToolStripMenuItem";
			this.dictationToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
			this.dictationToolStripMenuItem.Text = "Dictation";
			this.dictationToolStripMenuItem.Click += new System.EventHandler(this.dictationToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(218, 6);
			// 
			// setGrammarFromFileToolStripMenuItem
			// 
			this.setGrammarFromFileToolStripMenuItem.Enabled = false;
			this.setGrammarFromFileToolStripMenuItem.Name = "setGrammarFromFileToolStripMenuItem";
			this.setGrammarFromFileToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
			this.setGrammarFromFileToolStripMenuItem.Text = "Set Grammar from File";
			this.setGrammarFromFileToolStripMenuItem.Click += new System.EventHandler(this.setGrammarFromFileToolStripMenuItem_Click);
			// 
			// addVocabularyFromFileToolStripMenuItem
			// 
			this.addVocabularyFromFileToolStripMenuItem.Enabled = false;
			this.addVocabularyFromFileToolStripMenuItem.Name = "addVocabularyFromFileToolStripMenuItem";
			this.addVocabularyFromFileToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
			this.addVocabularyFromFileToolStripMenuItem.Text = "Add Vocabulary from File";
			this.addVocabularyFromFileToolStripMenuItem.Click += new System.EventHandler(this.addVocabularyFromFileToolStripMenuItem_Click);
			// 
			// Status2
			// 
			this.Status2.Enabled = false;
			this.Status2.Indent = 5;
			this.Status2.Location = new System.Drawing.Point(27, 355);
			this.Status2.Name = "Status2";
			this.Status2.ShowLines = false;
			this.Status2.Size = new System.Drawing.Size(196, 20);
			this.Status2.TabIndex = 2;
			this.Status2.Visible = false;
			// 
			// Stop
			// 
			this.Stop.Enabled = false;
			this.Stop.Location = new System.Drawing.Point(173, 284);
			this.Stop.Name = "Stop";
			this.Stop.Size = new System.Drawing.Size(75, 21);
			this.Stop.TabIndex = 5;
			this.Stop.Text = "閉じる";
			this.Stop.UseVisualStyleBackColor = true;
			this.Stop.Click += new System.EventHandler(this.Stop_Click);
			// 
			// GrammarFileDialog
			// 
			this.GrammarFileDialog.DefaultExt = "jsgf";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(12, 209);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(130, 19);
			this.textBox1.TabIndex = 6;
			// 
			// Console2
			// 
			this.Console2.FullRowSelect = true;
			this.Console2.Indent = 5;
			this.Console2.LabelEdit = true;
			this.Console2.Location = new System.Drawing.Point(7, 35);
			this.Console2.Name = "Console2";
			this.Console2.ShowLines = false;
			this.Console2.Size = new System.Drawing.Size(241, 105);
			this.Console2.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(67, 167);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 7;
			this.button1.Text = "認識";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(5, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 12);
			this.label1.TabIndex = 8;
			this.label1.Text = "label1";
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new System.Drawing.Point(13, 171);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(48, 16);
			this.checkBox1.TabIndex = 9;
			this.checkBox1.Text = "自動";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 243);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 12);
			this.label2.TabIndex = 10;
			this.label2.Text = "命令コード：";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(76, 243);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 12);
			this.label3.TabIndex = 11;
			this.label3.Text = "label3";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label4.Location = new System.Drawing.Point(6, 299);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(152, 12);
			this.label4.TabIndex = 11;
			this.label4.Text = "音声命令 ROBOTIS-MINI";
			this.label4.Click += new System.EventHandler(this.label4_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(5, 315);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(253, 12);
			this.label5.TabIndex = 11;
			this.label5.Text = "2016 Coplyleft(c) HAL東京 先端ロボット開発学科";
			this.label5.Click += new System.EventHandler(this.label4_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.White;
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pictureBox1.Image = global::DF_SpeechRecognition.cs.Properties.Resources.default_open;
			this.pictureBox1.Location = new System.Drawing.Point(148, 161);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(100, 100);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 12;
			this.pictureBox1.TabStop = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(261, 335);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.Console2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.Stop);
			this.Controls.Add(this.Status2);
			this.Controls.Add(this.MainMenu);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.MainMenu;
			this.Name = "MainForm";
			this.Text = "音声命令 ROBOTIS-MINI";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.MainMenu.ResumeLayout(false);
			this.MainMenu.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem moduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandControlToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem dictationToolStripMenuItem;
		private System.Windows.Forms.TreeView Status2;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.ToolStripMenuItem setGrammarFromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addVocabularyFromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.OpenFileDialog GrammarFileDialog;
        private System.Windows.Forms.OpenFileDialog VocabFileDialog;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TreeView Console2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}