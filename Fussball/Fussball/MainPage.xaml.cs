using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.Notifications;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Fussball.Players.Model;
using Fussball.Players;

namespace Fussball
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class MainPage : ContentPage
  {
		SelectPlayersPage selectPlayersPage;

		public MainPage()
    {
      InitializeComponent();
      BindingContext = new MainPageViewModel();
    }

    private void ResetScore(object sender, EventArgs e)
    {
      BindingContext = new MainPageViewModel();
    }

		private async void SelectPlayers(object sender, EventArgs e)
		{
			var players = new List<Player>
			{
				new Player { DisplayName = "Kasia" },
				new Player { DisplayName = "Mario" },
				new Player { DisplayName = "Mariusz" },
				new Player { DisplayName = "Piotrek" },
				new Player { DisplayName = "Robert" },
				new Player { DisplayName = "Sławek" },
				new Player { DisplayName = "Gość" }
			};

			if (selectPlayersPage == null)
			{
				selectPlayersPage = new SelectPlayersPage(players) { Title = "Wybór graczy" };
			}

			await Navigation.PushAsync(selectPlayersPage);
		}

		public class MainPageViewModel : INotifyPropertyChanged
    {
      public ICommand IncreaseGoalCountCommand { get; }
      public ICommand GoalTeamOneTapCommand { get; }
      public ICommand GoalTeamTwoTapCommand { get; }
      public ICommand StartTimerCommand { get; set; }

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

      public MainPageViewModel()
      {
        IncreaseGoalCountCommand = new Command<string>(IncreaseGoalCount);

        GoalTeamOneTapCommand = new Command(GoalTeamOneTap);
        GoalTeamTwoTapCommand = new Command(GoalTeamTwoTap);

        StartTimerCommand = new Command(StartTimer);

        TeamOneScore = 0;
        TeamTwoScore = 0;

        TimeLeft = TimeSpan.FromMinutes(5).ToString(@"mm\:ss");
      }

      void IncreaseGoalCount(string team)
      {
        switch (team)
        {
          case "Goal for team 1":
            TeamOneScore += 1;
            break;
          case "Goal for team 2":
            TeamTwoScore += 1;
            break;
          default:
            break;
        }
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
        int number = 3;

        Device.StartTimer(TimeSpan.FromSeconds(1), () =>
        {
          if (number-- == 0)
          {
            try
            {
              CrossNotifications.Current.Vibrate(3000);
              PlaySound();
            }
            catch(Exception e)
            {

            }

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
}
