using Acr.Notifications;
using Fussball.Interface;
using Fussball.Players.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Fussball.Gameplay.ViewModels
{

	public class GameViewModel : INotifyPropertyChanged
	{
		public ICommand IncreaseGoalCountCommand { get; }
		public ICommand GoalTeamOneTapCommand { get; }
		public ICommand GoalTeamTwoTapCommand { get; }
		public ICommand StartTimerCommand { get; set; }
		public ICommand ResetGameCommand { get; set; }

		bool stopTimer = false;

		string timeLeft;
		public string TimeLeft
		{
			get { return timeLeft; }
			set { timeLeft = value; OnPropertyChanged(); }
		}

		int teamOneScore;
		public int TeamOneScore
		{
			get { return teamOneScore; }
			set { teamOneScore = value; OnPropertyChanged(); }
		}

		int teamTwoScore;
		public int TeamTwoScore
		{
			get { return teamTwoScore; }
			set { teamTwoScore = value; OnPropertyChanged(); }
		}

		List<Player> players;
		public List<Player> Players
		{
			get { return players; }
			set { players = value; }
		}

		string firstPlayer;
		public string FirstPlayer
		{
			get { return firstPlayer; }
			set { firstPlayer = value; }
		}

		public GameViewModel(List<Player> players)
		{
			Players = players;
			//FirstPlayer = players[0].DisplayName;

			//IncreaseGoalCountCommand = new Command<string>(IncreaseGoalCount);

			GoalTeamOneTapCommand = new Command(GoalTeamOneTap);
			GoalTeamTwoTapCommand = new Command(GoalTeamTwoTap);

			StartTimerCommand = new Command(StartTimer);

			ResetGameCommand = new Command(ResetGame);

			TeamOneScore = 0;
			TeamTwoScore = 0;

			TimeLeft = TimeSpan.FromMinutes(5).ToString(@"mm\:ss");
		}

		private void ResetGame(object obj)
		{
			TeamOneScore = 0;
			TeamTwoScore = 0;
			TimeLeft = TimeSpan.FromMinutes(5).ToString(@"mm\:ss");
			stopTimer = true;
		}

		void GoalTeamOneTap()
		{
			TeamOneScore += 1;
		}

		void GoalTeamTwoTap()
		{
			TeamTwoScore += 1;
		}

		public void PlaySound()
		{
			DependencyService.Get<IAudio>().PlayAudioFile("whistle.mp3");
		}

		public void StartTimer()
		{
			int number = 300;
			stopTimer = false;

			Device.StartTimer(TimeSpan.FromSeconds(1), () =>
			{
				if (number-- == 0)
				{
					try
					{
						CrossNotifications.Current.Vibrate(3000);
						PlaySound();
					}
					catch (Exception e)
					{

					}

					return false;
				}
				else if (stopTimer)
				{
					return false;
				}
				else
				{
					TimeLeft = TimeSpan.FromSeconds(number).ToString(@"mm\:ss");
				}

				return true;
			});
		}

		public event PropertyChangedEventHandler PropertyChanged;
		void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
