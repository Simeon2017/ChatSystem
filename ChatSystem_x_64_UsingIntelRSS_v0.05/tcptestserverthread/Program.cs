using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ChatSystem
{
	static class Program
	{
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());

#if false	
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

				Application.Run(new Form1(session));
				session.Dispose();
			}
#endif
		}
	}
}
