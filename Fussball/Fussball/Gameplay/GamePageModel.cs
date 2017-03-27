using Acr.Notifications;
using Fussball.Gameplay.Models;
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

namespace Fussball.Gameplay
{

	public class GamePageModel : INotifyPropertyChanged
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

		List<Player> teamHomePlayers;
		public List<Player> TeamHomePlayers
		{
			get { return teamHomePlayers; }
			set { teamHomePlayers = value; }
		}

		List<Player> teamAwayPlayers;
		public List<Player> TeamAwayPlayers
		{
			get { return teamAwayPlayers; }
			set { teamAwayPlayers = value; }
		}

		public GamePageModel(List<Player> players)
		{
			GameService gameService = new GameService();
			List<Match> matches = gameService.GenerateMatches(players);

			TeamHomePlayers = matches.First().TeamHome;
			TeamAwayPlayers = matches.First().TeamAway;

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
