//#define _DEBUG_
//#define _DEBUG_LEVLE2_
#define _VR_SYSTEM_

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace ChatSystem
{
	public partial class Form1 : Form
	{
		string ipString = "127.0.0.1";
		int port = 50377;
		string stCurrentDir = null;
		string UnityExecNameFullPath = null;

#if _VR_SYSTEM_
		public const string UnityExecName = "chat_test006_side_by_side_x64";
#else
		public const string UnityExecName = "chat_test005_x64";
#endif
		Process UnityProcess = null;

		PXCMSession session = null;

		System.IO.MemoryStream ms = null;
		System.Net.Sockets.NetworkStream ns = null;
		System.Net.Sockets.TcpListener listener = null;
		System.Net.Sockets.TcpClient client = null;
		System.Text.Encoding enc = null;
		
		Thread ServerThread = null;
		Thread ServerWaitingThread = null;
		string resMsg = null;
		string HostIP_Port = null;
		string ClientIP_Port = null;
		string ClientCommand = null;
		string ClientSendMsg = null;
		string[] FromClientMessage = null;
		private bool isFirstTimeFlag = true;
		string ImageDir = null;

		MainForm mainForm = null;
//		public PXCMSession Session;

		int cnt = 0;
		static public string UserProfile = Environment.GetEnvironmentVariable("USERPROFILE");

		public string PROXY_SERVER_NAME = "proxy.tokyo.hal.ac.jp";
		public string PROXY_SERVER_PORT = "8080";
		public string PROXY_ACCOUNT_NAME = null;
		public string PROXY_ACCOUNT_PASSWORD = null;
		public bool isPROXY_SERVER_AVAILABLE = false;
		System.Text.Encoding chatEncode = System.Text.Encoding.GetEncoding("utf-8");
		public string DocomoTalkMes_utt = null;
		public string DocomoTalkMes_yomi = null;
		public string DocomoTalkMes_context = null;

		private bool isChatting = false;

		#region To Docomo API

		string yomi = "";
		string text = "今日の天気";

		string utt = "";	//テキスト
		string context = "";	//APIが返すコンテキスト
		string nickname = "中3女子";	//ニックネーム
		string nickname_y = "ちゅうさんじょし";	//ニックネームの読み
		string sex = "男";	//性別
		string bloodtype = "A"; //血液型
		int birthdateY = 1900; //生年
		int birthdateM = 1;	//生月
		int birthdateD = 1;	//生日
		int age = 16;	//年齢
		string constellations = "山羊座";	//星座
		string place = "東京";	//住んでいる場所
		int chara = 20;
		string mode = "";	//モード dialogまたはsrtr

		string url = "https://api.apigw.smt.docomo.ne.jp/dialogue/v1/dialogue?APIKEY=7a767a436a74434c6c74717768624d704c4a325157746354566e44736f354e4a68336243614a4651394f36";
		#endregion

		public Form1()
		{
			InitializeComponent();
			//session = PXCMSession.CreateInstance();
			//PXCMMetadata md = session.QueryInstance<PXCMMetadata>();
			//if (md != null)
			//{
			//    string sample_name = "Voice Recognition CS";
			//    md.AttachBuffer(1297303632, System.Text.Encoding.Unicode.GetBytes(sample_name));
			//}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			Form2 form2 = new Form2();
			form2.form1 = this;
			form2.ShowDialog();

#if _DEBUG_
			stCurrentDir = @"C:\Users\Simeon\ゆうきたんとおしゃべり";
#else
			stCurrentDir = System.Environment.CurrentDirectory;
#endif
			UnityExecNameFullPath = stCurrentDir + @"\Unity\" + UnityExecName;
			ImageDir = stCurrentDir + @"\Songs\";
			string[] SongFiles = System.IO.Directory.GetFiles(ImageDir, "*.wav", System.IO.SearchOption.AllDirectories);
			int FilesLength = SongFiles.Length;

			for (int i = 0; i < FilesLength; i++)
			{
				string SongFilesTmp = SongFiles[i];
				string[] splitted =SongFilesTmp.Split('\\');
				comboBox1.Items.Add(splitted[splitted.Length - 1]);
			}
			borderlessButton3.Enabled = false;
			enc = System.Text.Encoding.UTF8;
			timer1.Interval = 100;
			timer1.Start();

			if (checkBox2.Checked)
			{
				this.TopMost = true;
			}
			else
			{
				this.TopMost = false;
			}
			this.MaximizeBox = false;
			this.ActiveControl = this.borderlessButton1;
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			this.borderlessButton2.Enabled = false;
			this.borderlessButton3.Enabled = false;
			this.borderlessButton4.Enabled = false;
			this.borderlessButton5.Enabled = false;
		}

		void ServerReadWrite()
		{
			while (true)
			{
				resMsg = null;
				ns = client.GetStream();
				ns.ReadTimeout = Timeout.Infinite;
				ns.WriteTimeout = Timeout.Infinite;

				bool disconnected = false;
				ms = new System.IO.MemoryStream();
				byte[] resBytes = new byte[256];
				int resSize = 0;
				do
				{
					try
					{
						resSize = ns.Read(resBytes, 0, resBytes.Length);
						if (resSize == 0)
						{
							disconnected = true;
							Console.WriteLine("クライアントが切断しました。");
							ServerThread.Abort();
							break;
						}
						ms.Write(resBytes, 0, resSize);
					}
					catch
					{
						;
					}
				} while (ns.DataAvailable || resBytes[resSize - 1] != '\n');

				resMsg = enc.GetString(ms.GetBuffer(), 0, (int)ms.Length);
				ms.Close();
				resMsg = resMsg.TrimEnd('\n');

				FromClientMessage = resMsg.Split(':');
				string rcvMsgNo = FromClientMessage[0] + ":" + FromClientMessage[1];
				string rcvMsg = FromClientMessage[2];

				if (rcvMsgNo == "1002:0000")
				{
					DisableButton4();
				}
				else if (rcvMsgNo == "1002:0001")
				{
					EnableButton4();
				}
				else if (rcvMsgNo == "1004:0000")
				{
					//StreamWriter sw = new System.IO.StreamWriter(ImageDir+ "context.txt", false, Encoding.GetEncoding("shift_jis"));
					//sw.Write(resMsg[3]);
					//sw.Close();
				}
				PutServerText();
				if (!disconnected)
				{
					string sendMsg = resMsg.Length.ToString();
					byte[] sendBytes = enc.GetBytes(sendMsg + '\n');
					Console.WriteLine(sendMsg);
				}
			}
		}

		public bool GetTalkingStatus()
		{
			string rcvMsgNo = FromClientMessage[0] + ":" + FromClientMessage[1];
			if (rcvMsgNo == "1004:0001")
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		delegate void MyText();
		private void PutServerText()
		{
			if (this.textBox5.InvokeRequired || this.textBox5.InvokeRequired)
			{
				MyText d = new MyText(PutServerText);
				this.Invoke(d);
			}
			else
			{
				string rcvMsgNo = FromClientMessage[0] + ":" + FromClientMessage[1];
				this.textBox5.Text = FromClientMessage[2];

				if (rcvMsgNo == "1004:0001")
				{
					this.textBox3.SelectAll();
					borderlessButton2.Enabled = false;
					pictureBox1.Image = Properties.Resources.th_led_circle_red;
				}
				else if (rcvMsgNo == "1001:0001")
				{
					pictureBox1.Image = Properties.Resources.th_led_circle_yellow;
					borderlessButton2.Enabled = false;
				}
				else if (rcvMsgNo == "1002:0001")
				{
					pictureBox1.Image = Properties.Resources.th_led_circle_blue;
					borderlessButton2.Enabled = false;
				}
				else
				{
					pictureBox1.Image = Properties.Resources.th_led_circle_green;
					borderlessButton2.Enabled = true;
				}
			}
		}

		private void DisableButton4()
		{
			if (this.borderlessButton3.InvokeRequired)
			{
				MyText d = new MyText(DisableButton4);
				this.Invoke(d);
			}
			else
			{
				this.borderlessButton3.Enabled = false;
			}
		}

		private void EnableButton4()
		{
			if (this.borderlessButton3.InvokeRequired)
			{
				MyText d = new MyText(EnableButton4);
				this.Invoke(d);
			}
			else
			{
				this.borderlessButton3.Enabled = true;
			}
		}

		void ServerWaiting()
		{
			System.Net.IPAddress ipAdd = System.Net.IPAddress.Parse(ipString);

			listener = new System.Net.Sockets.TcpListener(ipAdd, port);
			listener.Start();

			HostIP_Port = ((IPEndPoint)listener.LocalEndpoint).Address.ToString() + " : " + ((IPEndPoint)listener.LocalEndpoint).Port.ToString();
			client = listener.AcceptTcpClient();
			ClientIP_Port = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString() + " : " + ((System.Net.IPEndPoint)client.Client.RemoteEndPoint).Port.ToString();
			DispIPInfo();

			ServerThread = new Thread(ServerReadWrite);
			ServerThread.Priority = ThreadPriority.Lowest;
			ServerThread.Start();
		}

		private void DispIPInfo()
		{
			if (this.pictureBox1.InvokeRequired)
			{
				MyText d = new MyText(DispIPInfo);
				this.Invoke(d);
			}
			else
			{
				this.pictureBox1.Image = Properties.Resources.th_led_circle_green;
				this.borderlessButton1.Enabled = true;
				this.borderlessButton2.Enabled = true;
				this.borderlessButton3.Enabled = false;
				this.borderlessButton4.Enabled = true;
				this.borderlessButton5.Enabled = true;

				if (this.checkBox2.Checked)
				{
					this.TopMost = true;
				}
				else
				{
					this.TopMost = false;
				}
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			DateTime dt = DateTime.Now;
			label3.Text = dt.ToString("F");
			cnt++;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (ServerThread != null && ServerThread.IsAlive)
			{
				ns.Close();
				client.Close();
				listener.Stop();
				ServerThread.Abort();

				UnityProcess.Kill();
				UnityProcess.Close();
				UnityProcess.Dispose();
			}

			if (session != null)
			{
				session.Dispose();
			}
		}

		private void textBox3_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				borderlessButton2.PerformClick();
			}
		}

		void toClientSend()
		{
			byte[] sendBytes = enc.GetBytes(ClientSendMsg + '\n');
			ns.Write(sendBytes, 0, sendBytes.Length);
		}

		public void voiceSetClientSendMsg(string Mes_yomi, string Mes_utt)
		{
			ClientSendMsg = "1004;" + Mes_yomi + ";" + Mes_utt;
			toClientSend();
		}

		private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Escape)
			{
				e.Handled = true;
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			borderlessButton3.Enabled = false;
			ClientCommand = "1003";
			ClientSendMsg = ClientCommand + ":" + comboBox1.SelectedItem + ":" + " ";
			toClientSend();
		}

		private void textBox3_Enter(object sender, EventArgs e)
		{
			radioButton1.Checked = true;
			radioButton2.Checked = false;
			textBox3.SelectAll();
		}

		private void comboBox1_Enter(object sender, EventArgs e)
		{
			radioButton1.Checked = false;
			radioButton2.Checked = true;
		}

		private void checkBox1_Enter(object sender, EventArgs e)
		{
			textBox3.Focus();
			radioButton1.Checked = true;
			radioButton2.Checked = false;
			textBox3.SelectAll();
		}

		private void textBox3_MouseDown(object sender, MouseEventArgs e)
		{
			textBox3.Focus();
			radioButton1.Checked = true;
			radioButton2.Checked = false;
			textBox3.SelectAll();
		}

		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox2.Checked)
			{
				this.TopMost = true;
			}
			else
			{
				this.TopMost = false;
			}
		}

		private void borderlessButton1_Click(object sender, EventArgs e)
		{
			if (isFirstTimeFlag)
			{
				borderlessButton1.Enabled = false;
				ServerWaitingThread = new Thread(ServerWaiting);
				ServerWaitingThread.Priority = ThreadPriority.Lowest;
				ServerWaitingThread.Start();
				UnityProcess = Process.Start(UnityExecNameFullPath);
				isFirstTimeFlag = false;
				borderlessButton1.BackColor = Color.MistyRose;
			}
			else if (!isFirstTimeFlag)
			{
				Process[] ps = Process.GetProcessesByName(UnityExecName);
				if (0 < ps.Length)
				{
					//見つかった時は、アクティブにする
					Microsoft.VisualBasic.Interaction.AppActivate(ps[0].Id);
				}
			}
		}

		private void borderlessButton2_Click(object sender, EventArgs e)
		{
			if (radioButton1.Checked)
			{
				if (checkBox1.Checked)
				{
					ConnectDocomoAPI(textBox3.Text);
					//StreamReader sr = new StreamReader(ImageDir+ "context.txt", Encoding.GetEncoding("Shift_JIS"));
					//string Context = sr.ReadToEnd();
					//sr.Close();
					//Context = Context.TrimEnd('\n');
					//Context = Context.TrimEnd('\r');
					ClientCommand = "1004";
					ClientSendMsg = ClientCommand + ";" + DocomoTalkMes_yomi + ";" + DocomoTalkMes_utt;

					textBox3.Focus();
					textBox3.SelectAll();
				}
				else
				{
					ClientCommand = "1001";
					ClientSendMsg = ClientCommand + ";" + textBox3.Text + ";" + " ";
				}
			}
			else if (radioButton2.Checked)
			{
				ClientCommand = "1002";
				ClientSendMsg = ClientCommand + ";" + ImageDir + comboBox1.SelectedItem + ";" + " ";
				//label1.Text = ClientSendMsg;
				borderlessButton3.Enabled = true;
			}
			toClientSend();
		}

		public void ConnectDocomoAPI(string text)
		{
			string postData = "{\"utt\":\"" + text + "\"," +
				"\"context\":\"" + context + "\"," +
				"\"nickname\":\"" + nickname + "\"," +
				"\"nickname_y\":\"" + nickname_y + "\"," +
				"\"sex\":\"" + sex + "\"," +
				"\"bloodtype\":\"" + bloodtype + "\"," +
				"\"birthdateY\":\"" + birthdateY + "\"," +
				"\"birthdateM\":\"" + birthdateM + "\"," +
				"\"birthdateD\":\"" + birthdateD + "\"," +
				"\"age\":\"" + age + "\"," +
				"\"constellations\":\"" + constellations + "\"," +
				"\"place\":\"" + place + "\"," +
				"\"mode\":\"" + mode + "\"}";

			Console.WriteLine(postData);
			System.Net.WebClient wc = new System.Net.WebClient();
			wc.Encoding = chatEncode;
			wc.Headers.Add("Content-Type", "application/json;charset=UTF-8");
			System.Net.WebProxy proxy;
			if (isPROXY_SERVER_AVAILABLE)
			{
				proxy = new System.Net.WebProxy(PROXY_SERVER_NAME + ":" + PROXY_SERVER_PORT);
				proxy.Credentials = new System.Net.NetworkCredential(PROXY_ACCOUNT_NAME, PROXY_ACCOUNT_PASSWORD);
			}
			else
			{
				proxy = null;
			}

			wc.Proxy = proxy;
			try
			{
				string resText = wc.UploadString(url, postData);
				Console.WriteLine(resText);
				wc.Dispose();
				var serializer = new DataContractJsonSerializer(typeof(JsonData));
				using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(resText)))
				{
					var data = (JsonData)serializer.ReadObject(ms);
					Console.WriteLine(data.utt);
					Console.WriteLine(data.yomi);
					DocomoTalkMes_utt = data.utt;
					DocomoTalkMes_yomi = data.yomi;
					DocomoTalkMes_context = data.context;
				}
				if (mainForm != null)
				{
					mainForm.putTextLabel(DocomoTalkMes_utt);
				}
			}
			catch
			{
				;
			}
		}

		private void borderlessButton3_Click(object sender, EventArgs e)
		{
			borderlessButton3.Enabled = false;
			ClientCommand = "1003";
			ClientSendMsg = ClientCommand + ";" + comboBox1.SelectedItem + ";" + " ";
			toClientSend();
		}

		private void borderlessButton4_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void borderlessButton5_Click(object sender, EventArgs e)
		{

			PXCMSession session = PXCMSession.CreateInstance();
			if (session != null)
			{
				// Optional steps to send feedback to Intel Corporation to understand how often each SDK sample is used.
				PXCMMetadata md = session.QueryInstance<PXCMMetadata>();
				if (md != null)
				{
					string sample_name = "Voice Recognition CS";
					md.AttachBuffer(1297303632, System.Text.Encoding.Unicode.GetBytes(sample_name));
				}
				mainForm = new MainForm(session);
				mainForm.form1 = this;

				textBox3.Enabled = false;
				comboBox1.Enabled = false;
				radioButton1.Enabled = false;
				radioButton2.Enabled = false;
				checkBox1.Enabled = false;
				borderlessButton1.Enabled = false;
				borderlessButton4.Enabled = false;

				DialogResult dr = mainForm.ShowDialog();

				textBox3.Enabled = true;
				comboBox1.Enabled = true;
				radioButton1.Enabled = true;
				radioButton2.Enabled = true;
				checkBox1.Enabled = true;
				borderlessButton1.Enabled = true;
				borderlessButton4.Enabled = true;
				session.Dispose();
			}
		}

		public void ExternPutTextBox5(string Mes)
		{
			textBox5.Text = Mes;
		}

	}
}
