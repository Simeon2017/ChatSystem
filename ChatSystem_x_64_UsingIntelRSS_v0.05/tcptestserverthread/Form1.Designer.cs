namespace ChatSystem
{
	partial class Form1
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.label3 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.borderlessButton3 = new ChatSystem.BorderlessButton();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.borderlessButton5 = new ChatSystem.BorderlessButton();
			this.borderlessButton4 = new ChatSystem.BorderlessButton();
			this.borderlessButton2 = new ChatSystem.BorderlessButton();
			this.borderlessButton1 = new ChatSystem.BorderlessButton();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// textBox3
			// 
			this.textBox3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.textBox3.Location = new System.Drawing.Point(5, 24);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(147, 19);
			this.textBox3.TabIndex = 5;
			this.textBox3.Enter += new System.EventHandler(this.textBox3_Enter);
			this.textBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox3_KeyDown);
			this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
			this.textBox3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBox3_MouseDown);
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label3.Location = new System.Drawing.Point(61, 168);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(31, 11);
			this.label3.TabIndex = 7;
			this.label3.Text = "label3";
			// 
			// comboBox1
			// 
			this.comboBox1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(5, 72);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(147, 20);
			this.comboBox1.TabIndex = 12;
			this.comboBox1.Enter += new System.EventHandler(this.comboBox1_Enter);
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.borderlessButton3);
			this.panel1.Controls.Add(this.checkBox1);
			this.panel1.Controls.Add(this.comboBox1);
			this.panel1.Controls.Add(this.radioButton2);
			this.panel1.Controls.Add(this.radioButton1);
			this.panel1.Controls.Add(this.textBox3);
			this.panel1.Location = new System.Drawing.Point(82, 6);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(160, 102);
			this.panel1.TabIndex = 13;
			// 
			// borderlessButton3
			// 
			this.borderlessButton3.Image = global::ChatSystem.Properties.Resources.th_round_corners_stop_button_25;
			this.borderlessButton3.Location = new System.Drawing.Point(79, 53);
			this.borderlessButton3.Name = "borderlessButton3";
			this.borderlessButton3.Size = new System.Drawing.Size(20, 18);
			this.borderlessButton3.TabIndex = 20;
			this.borderlessButton3.UseVisualStyleBackColor = true;
			this.borderlessButton3.Click += new System.EventHandler(this.borderlessButton3_Click);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Font = new System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.checkBox1.Location = new System.Drawing.Point(79, 8);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(68, 15);
			this.checkBox1.TabIndex = 15;
			this.checkBox1.Text = "チャット";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.Enter += new System.EventHandler(this.checkBox1_Enter);
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Font = new System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.radioButton2.Location = new System.Drawing.Point(6, 55);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(71, 16);
			this.radioButton2.TabIndex = 14;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "歌を歌う";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Checked = true;
			this.radioButton1.Font = new System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.radioButton1.Location = new System.Drawing.Point(6, 6);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(47, 16);
			this.radioButton1.TabIndex = 14;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "話す";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// textBox5
			// 
			this.textBox5.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.textBox5.Location = new System.Drawing.Point(6, 115);
			this.textBox5.Multiline = true;
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(237, 43);
			this.textBox5.TabIndex = 2;
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Checked = true;
			this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox2.Font = new System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.checkBox2.Location = new System.Drawing.Point(61, 184);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(57, 15);
			this.checkBox2.TabIndex = 15;
			this.checkBox2.Text = "最前面";
			this.checkBox2.UseVisualStyleBackColor = true;
			this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 207);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(230, 11);
			this.label1.TabIndex = 21;
			this.label1.Text = "2015 Copyleft(c)  HAL東京 先端ロボット開発学科";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(11, 78);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(30, 30);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 17;
			this.pictureBox1.TabStop = false;
			// 
			// borderlessButton5
			// 
			this.borderlessButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.borderlessButton5.Image = global::ChatSystem.Properties.Resources.Microphone_Normal_Red_icon;
			this.borderlessButton5.Location = new System.Drawing.Point(8, 164);
			this.borderlessButton5.Name = "borderlessButton5";
			this.borderlessButton5.Size = new System.Drawing.Size(40, 40);
			this.borderlessButton5.TabIndex = 3;
			this.borderlessButton5.UseVisualStyleBackColor = true;
			this.borderlessButton5.Click += new System.EventHandler(this.borderlessButton5_Click);
			// 
			// borderlessButton4
			// 
			this.borderlessButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.borderlessButton4.Image = global::ChatSystem.Properties.Resources.close_pink_s;
			this.borderlessButton4.Location = new System.Drawing.Point(177, 176);
			this.borderlessButton4.Name = "borderlessButton4";
			this.borderlessButton4.Size = new System.Drawing.Size(65, 23);
			this.borderlessButton4.TabIndex = 4;
			this.borderlessButton4.UseVisualStyleBackColor = true;
			this.borderlessButton4.Click += new System.EventHandler(this.borderlessButton4_Click);
			// 
			// borderlessButton2
			// 
			this.borderlessButton2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.borderlessButton2.Image = global::ChatSystem.Properties.Resources.th_snowmobile_sign_25;
			this.borderlessButton2.Location = new System.Drawing.Point(43, 76);
			this.borderlessButton2.Name = "borderlessButton2";
			this.borderlessButton2.Size = new System.Drawing.Size(30, 30);
			this.borderlessButton2.TabIndex = 1;
			this.borderlessButton2.UseVisualStyleBackColor = true;
			this.borderlessButton2.Click += new System.EventHandler(this.borderlessButton2_Click);
			// 
			// borderlessButton1
			// 
			this.borderlessButton1.Image = global::ChatSystem.Properties.Resources.default_open_yuuki_70;
			this.borderlessButton1.Location = new System.Drawing.Point(8, 6);
			this.borderlessButton1.Name = "borderlessButton1";
			this.borderlessButton1.Size = new System.Drawing.Size(70, 70);
			this.borderlessButton1.TabIndex = 0;
			this.borderlessButton1.UseVisualStyleBackColor = true;
			this.borderlessButton1.Click += new System.EventHandler(this.borderlessButton1_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 11F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Snow;
			this.ClientSize = new System.Drawing.Size(251, 222);
			this.Controls.Add(this.borderlessButton5);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.borderlessButton4);
			this.Controls.Add(this.borderlessButton2);
			this.Controls.Add(this.borderlessButton1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.checkBox2);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "☆ゆうきたんとお話☆";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private BorderlessButton borderlessButton1;
		private BorderlessButton borderlessButton2;
		private BorderlessButton borderlessButton3;
		private BorderlessButton borderlessButton4;
		private System.Windows.Forms.Label label1;
		private BorderlessButton borderlessButton5;
	}
}

