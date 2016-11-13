namespace ChatSystem
{
	partial class MainForm
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.Status2 = new System.Windows.Forms.TreeView();
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
			this.GrammarFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.VocabFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.button1 = new System.Windows.Forms.Button();
			this.Console2 = new System.Windows.Forms.TreeView();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.borderlessButton4 = new ChatSystem.BorderlessButton();
			this.borderlessButton1 = new ChatSystem.BorderlessButton();
			this.MainMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// Status2
			// 
			this.Status2.Indent = 5;
			this.Status2.Location = new System.Drawing.Point(74, 251);
			this.Status2.Name = "Status2";
			this.Status2.ShowLines = false;
			this.Status2.Size = new System.Drawing.Size(109, 20);
			this.Status2.TabIndex = 11;
			this.Status2.Visible = false;
			// 
			// MainMenu
			// 
			this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moduleToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.languageToolStripMenuItem1,
            this.modeToolStripMenuItem});
			this.MainMenu.Location = new System.Drawing.Point(0, 0);
			this.MainMenu.Name = "MainMenu";
			this.MainMenu.Size = new System.Drawing.Size(251, 26);
			this.MainMenu.TabIndex = 9;
			this.MainMenu.Text = "MainMenu";
			this.MainMenu.Visible = false;
			// 
			// moduleToolStripMenuItem
			// 
			this.moduleToolStripMenuItem.Name = "moduleToolStripMenuItem";
			this.moduleToolStripMenuItem.Size = new System.Drawing.Size(56, 22);
			this.moduleToolStripMenuItem.Text = "マイク";
			// 
			// languageToolStripMenuItem
			// 
			this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
			this.languageToolStripMenuItem.Size = new System.Drawing.Size(80, 22);
			this.languageToolStripMenuItem.Text = "モジュール";
			// 
			// languageToolStripMenuItem1
			// 
			this.languageToolStripMenuItem1.Name = "languageToolStripMenuItem1";
			this.languageToolStripMenuItem1.Size = new System.Drawing.Size(44, 22);
			this.languageToolStripMenuItem1.Text = "言語";
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
			this.modeToolStripMenuItem.Size = new System.Drawing.Size(56, 22);
			this.modeToolStripMenuItem.Text = "モード";
			// 
			// commandControlToolStripMenuItem
			// 
			this.commandControlToolStripMenuItem.Name = "commandControlToolStripMenuItem";
			this.commandControlToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
			this.commandControlToolStripMenuItem.Text = "Command Control";
			// 
			// dictationToolStripMenuItem
			// 
			this.dictationToolStripMenuItem.Name = "dictationToolStripMenuItem";
			this.dictationToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
			this.dictationToolStripMenuItem.Text = "Dictation";
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
			// 
			// addVocabularyFromFileToolStripMenuItem
			// 
			this.addVocabularyFromFileToolStripMenuItem.Enabled = false;
			this.addVocabularyFromFileToolStripMenuItem.Name = "addVocabularyFromFileToolStripMenuItem";
			this.addVocabularyFromFileToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
			this.addVocabularyFromFileToolStripMenuItem.Text = "Add Vocabulary from File";
			// 
			// GrammarFileDialog
			// 
			this.GrammarFileDialog.DefaultExt = "jsgf";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 196);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 13;
			this.button1.Text = "認識OK";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Console2
			// 
			this.Console2.FullRowSelect = true;
			this.Console2.Indent = 5;
			this.Console2.LabelEdit = true;
			this.Console2.Location = new System.Drawing.Point(12, 83);
			this.Console2.Name = "Console2";
			this.Console2.ShowLines = false;
			this.Console2.Size = new System.Drawing.Size(227, 90);
			this.Console2.TabIndex = 10;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(12, 227);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(227, 19);
			this.textBox1.TabIndex = 12;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(97, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 12);
			this.label1.TabIndex = 14;
			this.label1.Text = "label1";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(14, 255);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 12);
			this.label2.TabIndex = 16;
			this.label2.Text = "label2";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(97, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 12);
			this.label3.TabIndex = 18;
			this.label3.Text = "label3";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Enabled = false;
			this.label4.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label4.Location = new System.Drawing.Point(10, 184);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(31, 11);
			this.label4.TabIndex = 19;
			this.label4.Text = "label4";
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new System.Drawing.Point(93, 201);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(48, 16);
			this.checkBox1.TabIndex = 21;
			this.checkBox1.Text = "自動";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// borderlessButton4
			// 
			this.borderlessButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.borderlessButton4.Image = global::ChatSystem.Properties.Resources.close_pink_s;
			this.borderlessButton4.Location = new System.Drawing.Point(174, 278);
			this.borderlessButton4.Name = "borderlessButton4";
			this.borderlessButton4.Size = new System.Drawing.Size(65, 23);
			this.borderlessButton4.TabIndex = 20;
			this.borderlessButton4.UseVisualStyleBackColor = true;
			this.borderlessButton4.Click += new System.EventHandler(this.borderlessButton4_Click);
			// 
			// borderlessButton1
			// 
			this.borderlessButton1.Image = global::ChatSystem.Properties.Resources.default_open_yuuki_70;
			this.borderlessButton1.Location = new System.Drawing.Point(12, 7);
			this.borderlessButton1.Name = "borderlessButton1";
			this.borderlessButton1.Size = new System.Drawing.Size(70, 70);
			this.borderlessButton1.TabIndex = 17;
			this.borderlessButton1.UseVisualStyleBackColor = true;
			this.borderlessButton1.Click += new System.EventHandler(this.borderlessButton1_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Snow;
			this.ClientSize = new System.Drawing.Size(251, 313);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.borderlessButton4);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.borderlessButton1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.MainMenu);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.Console2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Status2);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "音声チャット";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing_1);
			this.Load += new System.EventHandler(this.MainForm_Load_1);
			this.LocationChanged += new System.EventHandler(this.MainForm_LocationChanged);
			this.MainMenu.ResumeLayout(false);
			this.MainMenu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TreeView Status2;
		private System.Windows.Forms.MenuStrip MainMenu;
		private System.Windows.Forms.ToolStripMenuItem moduleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem commandControlToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem dictationToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem setGrammarFromFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addVocabularyFromFileToolStripMenuItem;
		private System.Windows.Forms.OpenFileDialog GrammarFileDialog;
		private System.Windows.Forms.OpenFileDialog VocabFileDialog;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TreeView Console2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private BorderlessButton borderlessButton1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private BorderlessButton borderlessButton4;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.CheckBox checkBox1;
	}
}