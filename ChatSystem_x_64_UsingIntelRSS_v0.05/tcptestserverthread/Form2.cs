using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChatSystem
{
	public partial class Form2 : Form
	{
		public Form1 form1;
		public Form2()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (form1.isPROXY_SERVER_AVAILABLE)
			{
				form1.PROXY_SERVER_NAME = textBox1.Text;
				form1.PROXY_SERVER_PORT = textBox2.Text;
				form1.PROXY_ACCOUNT_NAME = textBox3.Text;
				form1.PROXY_ACCOUNT_PASSWORD = textBox4.Text;
			}
			this.Close();
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked)
			{
				form1.isPROXY_SERVER_AVAILABLE = true;
				textBox1.Enabled = true;
				textBox2.Enabled = true;
				textBox3.Enabled = true;
				textBox4.Enabled = true;
			}
			else
			{
				form1.isPROXY_SERVER_AVAILABLE = false;
				textBox1.Enabled = false;
				textBox2.Enabled = false;
				textBox3.Enabled = false;
				textBox4.Enabled = false;
			}
		}

		private void Form2_Load(object sender, EventArgs e)
		{
			textBox1.Text = form1.PROXY_SERVER_NAME;
			textBox2.Text = form1.PROXY_SERVER_PORT;

			checkBox1.Checked = false;
			textBox4.UseSystemPasswordChar = true;

			textBox1.Enabled = false;
			textBox2.Enabled = false;
			textBox3.Enabled = false;
			textBox4.Enabled = false;
			this.MaximizeBox = false;
			this.ActiveControl = this.button1;
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
		}
	}
}
