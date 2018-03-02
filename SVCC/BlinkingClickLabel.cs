using System;
using System.Windows.Forms;
using System.ComponentModel;

namespace SVCC
{
	/// <summary>
	/// Summary description for BlinkingClickLabel.
	/// </summary>
	public class BlinkingClickLabel : LinkLabel
	{
		Timer _timer;

		System.Drawing.Color _alternatingColor1 = System.Drawing.Color.Black;
		System.Drawing.Color _alternatingColor2 = System.Drawing.Color.Red;

		[Category("Appearance"),
		Description("Intervalo (milisegundos) entre los 'ticks' del timer")]
		public int TimerInterval
		{
			get
			{
				return _timer.Interval;
			}
			set
			{
				_timer.Enabled = false;
				_timer.Interval = value;
				_timer.Enabled = true;
			}
		}

		[Category("Appearance"),
		Description("La etiqueta mostrará este color y el color definido por 'LinkColor'")]
		public System.Drawing.Color AlternatingColor2
		{
			get
			{
				return _alternatingColor2;
			}
			set
			{
				_alternatingColor2 = value;
			}
		}

		private void timerTick(Object sender, EventArgs e)
		{
			if (this.LinkColor == _alternatingColor1)
				this.LinkColor = _alternatingColor2;
			else
				this.LinkColor = _alternatingColor1;
		}

		private void EnabledChangedValue(Object sender, EventArgs e)
		{
			if (this.Enabled)
			{
				_timer.Start();
				_timer.Enabled = true;
			}
			else
			{
				_timer.Stop();
				_timer.Enabled = false;
			}
		}

		public BlinkingClickLabel()
		{
			_timer = new Timer();
			this._alternatingColor1 = this.LinkColor;
			_timer.Tick += new EventHandler(timerTick);
			_timer.Enabled = true;
			_timer.Start();

			this.EnabledChanged += new EventHandler(EnabledChangedValue);
		}
	}
}

