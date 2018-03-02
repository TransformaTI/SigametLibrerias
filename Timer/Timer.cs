using System;

namespace CTimer
{
	/// <summary>
	/// Summary description for Timer.
	/// </summary>
	/// 

	public enum Period
	{
		Hour = 3600000,
		Minute = 60000,
		Second = 1000,
		CentOfSecond = 100,
		Millisecond = 1
	}

	public class Timer : System.Windows.Forms.Control
	{
		private System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();

		public event EventHandler TimerStop;

		public EventHandler Tick;

		public EventHandler TimerStart;
		//public EventHandler TimerStop;

		protected virtual void onTick(System.EventArgs e)
		{
			EventHandler handler = Tick;
			if (handler != null)
				handler(this, e);
		}

		protected virtual void onStart(System.EventArgs e)
		{
			EventHandler handler = TimerStart;
			if (handler != null)
				handler(this, e);
		}

		protected virtual void onStop(System.EventArgs e)
		{
			EventHandler handler = TimerStop;
			if (handler != null)
				handler(this, e);
		}

		private int _secondsEllapsedTime = 0;
		private int _minutesEllapsedTime = 0;
		private int _hoursEllapsedTime = 0;

		private int _waitTime = 0;
		private int _currentWaitTime = 0;
		        
		public int Seconds
		{
			get
			{
				return _secondsEllapsedTime;
			}
		}

		public int Minutes
		{
			get
			{
				return _minutesEllapsedTime;
			}
		}

		public int Hours
		{
			get
			{
				return _hoursEllapsedTime;
			}
		}

		public int WaitPeriod
		{
			get
			{
				return _waitTime;
			}
			set
			{
				_waitTime = value;
				_currentWaitTime = _waitTime;
			}
		}

		public Timer()
		{
			_timer.Interval = Convert.ToInt32(Period.Second);
			_timer.Tick += new EventHandler(TickEvt);
		}

		public void StartTimer()
		{
			_currentWaitTime = _waitTime;
			_timer.Enabled = true;
			_timer.Start();
			onStart(EventArgs.Empty);
		}

		public void StopTimer()
		{
			if (_timer.Enabled)
			{
				_timer.Stop();
				onStop(EventArgs.Empty);
			}
		}

		public void ResetTimer()
		{
			_secondsEllapsedTime = 0;
			_minutesEllapsedTime = 0;
			_hoursEllapsedTime = 0;
			_currentWaitTime = _waitTime;
		}

		private void TickEvt(object sender, System.EventArgs e)
		{
			onTick(EventArgs.Empty);
			ellapsedTime();
		}

		private void ellapsedTime()
		{
			_currentWaitTime -= 1;
			_secondsEllapsedTime += 1;
			if (_secondsEllapsedTime >= 59)
			{
				_minutesEllapsedTime += 1;
				_secondsEllapsedTime = 0;
			}
			if (_minutesEllapsedTime >= 59)
			{
				_hoursEllapsedTime += 1;
				_minutesEllapsedTime = 0;
			}
			if ((_currentWaitTime == 0) && (_waitTime != 0))
			{
				StopTimer();
				ResetTimer();
			}
		}

		protected void Dispose()
		{
			_timer.Stop();
		}
	}
}
