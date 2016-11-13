using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Resources;
using System.Windows;
using System.Windows.Forms;

namespace ChatSystem
{
	class BorderlessButton : Button
	{
		protected override void OnPaint(PaintEventArgs pevent)
		{
			base.OnPaint(pevent);
			pevent.Graphics.DrawRectangle(new Pen(this.BackColor, 5), this.ClientRectangle);
		}
	}
}
