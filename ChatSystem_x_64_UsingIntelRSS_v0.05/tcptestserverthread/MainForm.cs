using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

namespace ChatSystem
{
	public partial class MainForm : Form
	{
		public Form1 form1;
		string LineTest;
		public bool isTalking = false;
		public bool isInitialize = true;

		bool FirstTimeFlag = true;

		private PXCMSession session;
		private Dictionary<ToolStripMenuItem, Int32> modules = new Dictionary<ToolStripMenuItem, int>();
		private Dictionary<ToolStripMenuItem, PXCMAudioSource.DeviceInfo> devices = new Dictionary<ToolStripMenuItem, PXCMAudioSource.DeviceInfo>();

		public string g_file; //SM: ToDo function for return the file
		public string v_file; //SM: ToDo function for return the file
		System.Threading.Thread DoVoiceThread = null;
		bool isAutoSend = true;

		string[] toDocomoAPISendMes = {"認識がうまくいったら「認識OK」ボタンを押してね", "自動応答中"};
		public MainForm(PXCMSession Session)
		{
			this.session = Session;

			InitializeComponent();

			PopulateSource();
			PopulateModule();
			PopulateLanguage();
			dictationToolStripMenuItem_Click(null, null);

			Console2.AfterLabelEdit += new NodeLabelEditEventHandler(Console2_AfterLabelEdit);
			Console2.KeyDown += new KeyEventHandler(Console2_KeyDown);

			label1.Text = null;
			label2.Text = null;
			label3.Text = null;
			label4.Text = toDocomoAPISendMes[1];

			timer1.Interval = 100;
			timer1.Start();
		}

		public delegate void myLabel(string MesLabel1, string MesLabel2);
		public void PutLabel1Text(string Mes1, string Mes2)
		{
			if (this.label1.InvokeRequired)
			{
				myLabel d = new myLabel(PutLabel1Text);
				this.Invoke(d, new object[] { Mes1, Mes2 });
			}
			else
			{
				this.label1.Text = Mes1;
				this.label3.Text = Mes2;
				this.label1.Invalidate();
				this.label3.Invalidate();
			}
		}

		private void PopulateSource()
		{
			int SourceNo = -1;
			ToolStripMenuItem sm = new ToolStripMenuItem("Source");
			devices.Clear();

			PXCMAudioSource source = session.CreateAudioSource();
			if (source != null)
			{
				source.ScanDevices();

				for (int i = 0; ; i++)
				{
					PXCMAudioSource.DeviceInfo dinfo;
					if (source.QueryDeviceInfo(i, out dinfo) < pxcmStatus.PXCM_STATUS_NO_ERROR) break;

					ToolStripMenuItem sm1 = new ToolStripMenuItem(dinfo.name, null, new EventHandler(Source_Item_Click));
					devices[sm1] = dinfo;
					sm.DropDownItems.Add(sm1);

					if((sm1.ToString()).IndexOf("マイク") >= 0)
					{
						SourceNo = i;
					}
				}
				source.Dispose();
			}

			if (sm.DropDownItems.Count > 0)
				(sm.DropDownItems[SourceNo] as ToolStripMenuItem).Checked = true;
			MainMenu.Items.RemoveAt(0);
			MainMenu.Items.Insert(0, sm);
		}

		private void PopulateModule()
		{
			ToolStripMenuItem mm = new ToolStripMenuItem("Module");
			modules.Clear();

			PXCMSession.ImplDesc desc = new PXCMSession.ImplDesc();
			desc.cuids[0] = PXCMSpeechRecognition.CUID;
			for (int i = 0; ; i++)
			{
				PXCMSession.ImplDesc desc1;
				if (session.QueryImpl(desc, i, out desc1) < pxcmStatus.PXCM_STATUS_NO_ERROR) break;
				ToolStripMenuItem mm1 = new ToolStripMenuItem(desc1.friendlyName, null, new EventHandler(Module_Item_Click));
				modules[mm1] = desc1.iuid;
				mm.DropDownItems.Add(mm1);
			}

			if (mm.DropDownItems.Count > 0)
				(mm.DropDownItems[0] as ToolStripMenuItem).Checked = true;
			MainMenu.Items.RemoveAt(1);
			MainMenu.Items.Insert(1, mm);
		}

		private void PopulateLanguage()
		{
			PXCMSession.ImplDesc desc = new PXCMSession.ImplDesc();
			desc.cuids[0] = PXCMSpeechRecognition.CUID;
			desc.iuid = GetCheckedModule();
			int k = 0;

			PXCMSpeechRecognition vrec;
			if (session.CreateImpl<PXCMSpeechRecognition>(desc, out vrec) < pxcmStatus.PXCM_STATUS_NO_ERROR) return;

			ToolStripMenuItem lm = new ToolStripMenuItem("Language");
			for (int i = 0; ; i++)
			{
				PXCMSpeechRecognition.ProfileInfo pinfo;
				if (vrec.QueryProfile(i, out pinfo) < pxcmStatus.PXCM_STATUS_NO_ERROR) break;
				ToolStripMenuItem lm1 = new ToolStripMenuItem(LanguageToString(pinfo.language), null, new EventHandler(Language_Item_Click));
				lm.DropDownItems.Add(lm1);

				if (pinfo.language == PXCMSpeechRecognition.LanguageType.LANGUAGE_JP_JAPANESE)
				{
					k = i;
				}
			}
			vrec.Dispose();

			if (lm.DropDownItems.Count > 0)
				(lm.DropDownItems[k] as ToolStripMenuItem).Checked = true;
			MainMenu.Items.RemoveAt(2);
			MainMenu.Items.Insert(2, lm);
		}

		public PXCMAudioSource.DeviceInfo GetCheckedSource()
		{
			foreach (ToolStripMenuItem m in MainMenu.Items)
			{
				if (!m.Text.Equals("Source")) continue;
				foreach (ToolStripMenuItem e in m.DropDownItems)
				{
					if (e.Checked) return devices[e];
				}
			}
			return null;
		}

		public Int32 GetCheckedModule()
		{
			foreach (ToolStripMenuItem m in MainMenu.Items)
			{
				if (!m.Text.Equals("Module")) continue;
				foreach (ToolStripMenuItem e in m.DropDownItems)
				{
					if (e.Checked) return modules[e];
				}
			}
			return 0;
		}

		public int GetCheckedLanguage()
		{
			foreach (ToolStripMenuItem m in MainMenu.Items)
			{
				if (!m.Text.Equals("Language")) continue;
				for (int i = 0; i < m.DropDownItems.Count; i++)
				{
					if (m.DropDownItems[i] == null)
						continue;
					if ((m.DropDownItems[i] as ToolStripMenuItem).Checked)
						return i;
				}
			}
			return 0;
		}

		public bool IsCommandControl()
		{
			return commandControlToolStripMenuItem.Checked;
		}

		private void RadioCheck(object sender, string name)
		{
			foreach (ToolStripMenuItem m in MainMenu.Items)
			{
				if (!m.Text.Equals(name)) continue;
				foreach (ToolStripMenuItem e1 in m.DropDownItems)
				{
					e1.Checked = (sender == e1);
				}
			}
		}

		private void Source_Item_Click(object sender, EventArgs e)
		{
			RadioCheck(sender, "Source");
		}

		private void Module_Item_Click(object sender, EventArgs e)
		{
			RadioCheck(sender, "Module");
			PopulateLanguage();
		}

		private void Language_Item_Click(object sender, EventArgs e)
		{
			RadioCheck(sender, "Language");
		}

		private void commandControlToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Status2.Nodes.Clear();
			//			ConsoleMode.Text = "Command Control:";
			commandControlToolStripMenuItem.Checked = true;
			dictationToolStripMenuItem.Checked = false;
			Console2.Nodes.Clear();
			Console2.LabelEdit = true;
			setGrammarFromFileToolStripMenuItem.Enabled = true;
			addVocabularyFromFileToolStripMenuItem.Enabled = false;
			AlwaysAddNewCommand();
		}

		private void dictationToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Status2.Nodes.Clear();
			//			ConsoleMode.Text = "Dictation:";
			commandControlToolStripMenuItem.Checked = false;
			dictationToolStripMenuItem.Checked = true;
			Console2.LabelEdit = false;
			setGrammarFromFileToolStripMenuItem.Enabled = false;
			addVocabularyFromFileToolStripMenuItem.Enabled = true;
			Console2.Nodes.Clear();
		}

		private delegate void VoiceRecognitionCompleted();
		private void DoVoiceRecognition()
		{
			VoiceRecognition vr = new VoiceRecognition();
			vr.DoIt(this, session);

			try
			{
				this.Invoke(new VoiceRecognitionCompleted(
					delegate
					{
						borderlessButton4.Enabled = false;
						MainMenu.Enabled = true;
						if (closing) Close();
					}
				));
			}
			catch
			{
				;
			}
		}

		private void Stop_Click(object sender, EventArgs e)
		{
			stop = true;
			this.Close();
		}

		private void Console2_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
		{
			if (e.Label == null) return;
			if (e.Label.Length == 0) return;
			e.Node.EndEdit(false);
			if (e.Node.Text.Equals("[Enter New Command]"))
				Console2.Nodes.Add("[Enter New Command]");
		}

		public static string TrimScore(string s)
		{
			s = s.Trim();
			int x = s.IndexOf('[');
			if (x < 0) return s;
			return s.Substring(0, x);
		}

		private string LanguageToString(PXCMSpeechRecognition.LanguageType language)
		{
			switch (language)
			{
				case PXCMSpeechRecognition.LanguageType.LANGUAGE_US_ENGLISH: return "US English";
				case PXCMSpeechRecognition.LanguageType.LANGUAGE_GB_ENGLISH: return "British English";
				case PXCMSpeechRecognition.LanguageType.LANGUAGE_DE_GERMAN: return "Deutsch";
				case PXCMSpeechRecognition.LanguageType.LANGUAGE_IT_ITALIAN: return "Italiano";
				case PXCMSpeechRecognition.LanguageType.LANGUAGE_BR_PORTUGUESE: return "BR Português";
				case PXCMSpeechRecognition.LanguageType.LANGUAGE_CN_CHINESE: return "中文";
				case PXCMSpeechRecognition.LanguageType.LANGUAGE_FR_FRENCH: return "Français";
				case PXCMSpeechRecognition.LanguageType.LANGUAGE_JP_JAPANESE: return "日本語";
				case PXCMSpeechRecognition.LanguageType.LANGUAGE_US_SPANISH: return "US Español";
				case PXCMSpeechRecognition.LanguageType.LANGUAGE_LA_SPANISH: return "LA Español";
			}
			return null;
		}

		private delegate void TreeViewCleanDelegate();

		public void CleanConsole()
		{
			Console2.Invoke(new TreeViewCleanDelegate(delegate { Console2.Nodes.Clear(); }));
		}

		private delegate void TreeViewUpdateDelegate(string line);
		public void PrintConsole(string line)
		{
			/////////////////////////////////////////// 認識結果の獲得
			if (!form1.GetTalkingStatus())
			{
				LineTest = line;
				Console2.Invoke(new TreeViewUpdateDelegate(delegate(string line1) { Console2.Nodes.Add(line1).EnsureVisible(); }), new object[] { line });
				if (isAutoSend)
				{
					PerformClickButton1();
				}
			}
		}

		delegate void PerformClickButton();
		void PerformClickButton1()
		{
			if (this.button1.InvokeRequired)
			{
				PerformClickButton d = new PerformClickButton(PerformClickButton1);
				this.Invoke(d, new object[] { });
			}
			else
			{
				this.button1.PerformClick();
			}
		}


		delegate void PrintMessage();
		void PrintRecognized()
		{
			textBox1.Text = LineTest;
		}

		public void PrintStatus(string line)
		{
			try
			{
				Status2.Invoke(new TreeViewUpdateDelegate(delegate(string line1) { Status2.Nodes.Add(line1).EnsureVisible(); }), new object[] { line });
			}
			catch
			{
				;
			}
		}

		private delegate void ConsoleReplaceTextDelegate(TreeNode tn1, string text);

		public void ClearScores()
		{
			foreach (TreeNode n in Console2.Nodes)
			{
				string s = TrimScore(n.Text);
				if (s.Length > 0)
					Console2.Invoke(new ConsoleReplaceTextDelegate(delegate(TreeNode tn1, string text) { tn1.Text = text; }), new object[] { n, s });
			}
		}

		public void SetScore(int label, int confidence)
		{
			for (int i = 0; i < Console2.Nodes.Count; i++)
			{
				string s = TrimScore(Console2.Nodes[i].Text);
				if (s.Length == 0) continue;
				if ((label--) != 0) continue;
				Console2.Invoke(new ConsoleReplaceTextDelegate(delegate(TreeNode tn1, string text) { tn1.Text = text; }), new object[] { Console2.Nodes[i], Console2.Nodes[i].Text + " [" + confidence + "%]" });
				break;
			}
		}

		public string[] GetCommands()
		{
			int ncmds = 0;
			foreach (TreeNode tn in Console2.Nodes)
				if (TrimScore(tn.Text).Length > 0) ncmds++;
			if (ncmds == 0) return null;
			string[] cmds = new string[ncmds];
			for (int i = 0, k = 0; i < Console2.Nodes.Count; i++)
			{
				string cmd = TrimScore(Console2.Nodes[i].Text);
				if (cmd.Length <= 0) continue;
				cmds[k++] = cmd;
			}
			return cmds;
		}

		public void FillCommandListConsole(string filename)
		{
			string line;

			CleanConsole();
			PrintConsole("[Enter New Command]");

			System.IO.StreamReader file = new System.IO.StreamReader(filename);
			try
			{
				while ((line = file.ReadLine()) != null)
				{
					PrintConsole(line);
				}
				file.Close();
			}
			catch
			{
				file.Close();
			}

		}

		public string AlertToString(PXCMSpeechRecognition.AlertType label)
		{
			switch (label)
			{
				case PXCMSpeechRecognition.AlertType.ALERT_SNR_LOW: return "SNR_LOW";
				case PXCMSpeechRecognition.AlertType.ALERT_SPEECH_UNRECOGNIZABLE: return "SPEECH_UNRECOGNIZABLE";
				case PXCMSpeechRecognition.AlertType.ALERT_VOLUME_HIGH: return "VOLUME_HIGH";
				case PXCMSpeechRecognition.AlertType.ALERT_VOLUME_LOW: return "VOLUME_LOW";
				case PXCMSpeechRecognition.AlertType.ALERT_SPEECH_BEGIN: return "SPEECH_BEGIN";
				case PXCMSpeechRecognition.AlertType.ALERT_SPEECH_END: return "SPEECH_END";
				case PXCMSpeechRecognition.AlertType.ALERT_RECOGNITION_ABORTED: return "REC_ABORT";
				case PXCMSpeechRecognition.AlertType.ALERT_RECOGNITION_END: return "REC_END";
			}
			return "Unknown";
		}

		private volatile bool stop = true;
		private bool closing = false;

		public bool IsStop()
		{
			return stop;
		}

		private void AlwaysAddNewCommand()
		{
			foreach (TreeNode tn in Console2.Nodes)
				if (tn.Text.Equals("[Enter New Command]")) return;
			Console2.Nodes.Add("[Enter New Command]").EnsureVisible();
		}

		private void Console2_KeyDown(Object sender, KeyEventArgs e)
		{
			if (!IsCommandControl()) return;
			if (e.KeyCode != Keys.Delete) return;
			if (Console2.SelectedNode != null)
				Console2.Nodes.Remove(Console2.SelectedNode);
			AlwaysAddNewCommand();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			textBox1.Text = LineTest;
			doChat();
		}

		private void doChat()
		{
			form1.ConnectDocomoAPI(LineTest);

			string Mes_yomi = form1.DocomoTalkMes_yomi;
			string Mes_utt = form1.DocomoTalkMes_utt;
			form1.voiceSetClientSendMsg(Mes_yomi, Mes_utt);
			form1.ExternPutTextBox5(Mes_utt);
		}

		private void MainForm_Load_1(object sender, EventArgs e)
		{
			this.Location = new Point(form1.Location.X, form1.Location.Y + form1.Height + 10); 
			this.ActiveControl = this.button1;
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			this.TopMost = true;
			this.MaximizeBox = false;

			borderlessButton4.Enabled = true;
			borderlessButton1.BackColor = Color.MistyRose;
			MainMenu.Enabled = false;

			stop = false;
			label1.Text = "初期化中...";
			this.button1.ForeColor = Color.DarkGray;
			DoVoiceThread = new System.Threading.Thread(DoVoiceRecognition);
			///////////////////////////////////
			DoVoiceThread.IsBackground = true;
			DoVoiceThread.Start();
			System.Threading.Thread.Sleep(500);
		}

		private void MainForm_FormClosing_1(object sender, FormClosingEventArgs e)
		{
			label1.Text = "終了中";
			stop = true;
			System.Threading.Thread.Sleep(200);
			timer1.Stop();
			closing = true;
		}

		private void borderlessButton1_Click(object sender, EventArgs e)
		{
			Process[] ps = Process.GetProcessesByName(Form1.UnityExecName);
			if (0 < ps.Length)
			{
				//見つかった時は、アクティブにする
				Microsoft.VisualBasic.Interaction.AppActivate(ps[0].Id);
			}
		}

		public void putTextLabel(string Mes)
		{
			string MesTmp = null;
			if (Mes.Length >= 22)
			{
				MesTmp = Mes.Substring(0, 21) + "…";
			}
			else
			{
				MesTmp = Mes;
			}
			label2.Text = MesTmp;
		}

		private void borderlessButton4_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (isInitialize)
			{
				return;
			}

			isTalking = form1.GetTalkingStatus();
			string Label1Mes = null;
			string Label3Mes = null;
			if (isTalking)
			{
				label1.ForeColor = Color.Red;
				label3.ForeColor = Color.Red;
				Label1Mes = "ゆうきたんお話中...";
				Label3Mes = "ちょっと待ってて";
			}
			else
			{
				label1.ForeColor = Color.Black;
				label3.ForeColor = Color.Black;
				Label1Mes = "音声認識中...";
				Label3Mes = "マイクに向かって何か話して";
			}
			PutLabel1Text(Label1Mes, Label3Mes);
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked)
			{
				this.button1.ForeColor = Color.DarkGray;
				label4.Enabled = false;
				label4.Text = toDocomoAPISendMes[1];
				isAutoSend = true;
			}
			else
			{
				this.button1.ForeColor = Color.Black;
				label4.Enabled = true;
				label4.Text = toDocomoAPISendMes[0];
				isAutoSend = false;
			}
		}

		private void MainForm_LocationChanged(object sender, EventArgs e)
		{
			Control c = (Control)sender;
			if (!FirstTimeFlag)
			{
				int NewX = c.Location.X;
				int NewY = c.Location.Y - form1.Height - 10;
				if (NewX <= 0)
				{
					NewX = 0;
				}
				if (NewY <= 0)
				{
					NewY = 0;
				}
				form1.Location = new Point(NewX, NewY);
			}
			FirstTimeFlag = false;
		}

	}
}
