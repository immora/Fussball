using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Fussball.Utils
{
	public class MyTimer
	{
		private readonly TimeSpan interval;
		private readonly Action onTimerEnded;
		private readonly Action<double> callback;

		private int countdownDuration;
		private bool started = false;
		private CancellationTokenSource cancellation;
		private int pausedValue;

		public MyTimer(TimeSpan interval, Action onTimerEnded, Action<double> callback)
		{
			this.interval = interval;
			this.onTimerEnded = onTimerEnded;
			this.cancellation = new CancellationTokenSource();
			this.callback = callback;
			this.pausedValue = int.MaxValue;
		}

		public void Start(int countdownDuration)
		{
			if (started) // secure from multiple timers running
			{
				return;
			}

			CancellationTokenSource cts = this.cancellation; // safe copy

			started = true;

			this.countdownDuration = pausedValue < countdownDuration ? pausedValue : countdownDuration;

			Device.StartTimer(this.interval,
					() =>
					{
						if (cts.IsCancellationRequested)
						{
							return false;
						}

						if (this.countdownDuration-- == 0)
						{
							pausedValue = int.MaxValue;

							this.onTimerEnded.Invoke();

							return false;
						}
						else
						{
							this.callback.Invoke(this.countdownDuration);
						}

						return true;
					});
		}

		public void Pause()
		{
			pausedValue = countdownDuration;

			this.Stop();
		}

		public void Stop()
		{
			started = false;

			Interlocked.Exchange(ref this.cancellation, new CancellationTokenSource()).Cancel();
		}

		public void Reset()
		{
			pausedValue = int.MaxValue;
		}
	}
}
