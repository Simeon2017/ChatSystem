using System;
using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace ChatSystem
{
	[DataContract]
	class JsonData
	{
		[DataMember]
		public string utt;
		[DataMember]
		public string yomi;
		[DataMember]
		public string mode;
		[DataMember]
		public int da;
		[DataMember]
		public string context;
	}
}
