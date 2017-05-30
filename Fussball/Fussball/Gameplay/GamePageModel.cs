using Acr.Notifications;
using Fussball.Gameplay.Models;
using Fussball.Interface;
using Fussball.Players.Model;
using Fussball.Utils;
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
    public ICommand StartOrPauseGameCommand { get; set; }
    public ICommand ResetGameCommand { get; set; }

    public const int MatchDurationInSeconds = 300;

    MatchService matchService;
    MyTimer timer;
    List<Match> matches;

    public GamePageModel(List<Player> players)
    {
      GameService gameService = new GameService();
      matchService = new MatchService();

      matches = gameService.GenerateMatches(players);
      TeamHomePlayers = matches.First().TeamHome;
      TeamAwayPlayers = matches.First().TeamAway;

      GoalTeamOneTapCommand = new Command<Player>(GoalTeamOneTap);
      GoalTeamTwoTapCommand = new Command<Player>(GoalTeamTwoTap);

      StartOrPauseGameCommand = new Command(StartOrPauseGame);
      ResetGameCommand = new Command(ResetGame);

      TeamOneScore = 0;
      TeamTwoScore = 0;
      MatchNumber = 0;
      MatchPaused = true;

      MatchStatusText = $"Start (mecz {MatchNumber + 1})";

      TimeLeft = TimeSpan.FromMinutes(MatchDurationInSeconds / 60).ToString(@"mm\:ss");

      timer = new MyTimer(TimeSpan.FromSeconds(1),
        OnMatchEnded,
        (x) => TimeLeft = TimeSpan.FromSeconds(x).ToString(@"mm\:ss"));
    }

    private void OnMatchEnded()
    {
      CrossNotifications.Current.Vibrate(3000);
      PlaySound();
      MatchNumber++;
      MatchEnded = true;
      ResetGame();

      MessagingCenter.Send<GamePageModel, IDictionary<Player, int>>(this, "MatchEnded", matchService.PlayersGoals);

      if (MatchNumber >= 3)
      {
        return;
      }

      TeamHomePlayers = matches[MatchNumber].TeamHome;
      TeamAwayPlayers = matches[MatchNumber].TeamAway;

      matchService.PlayersGoals.Clear();
    }

    private void StartOrPauseGame()
    {
      if (MatchPaused)
      {
        StartTimer();
        MatchStatusText = $"Pauza (mecz {MatchNumber + 1})";
        MatchPaused = false;
      }
      else
      {
        PauseTimer();
        MatchStatusText = $"Kontynuuj (mecz {MatchNumber + 1 })";
        MatchPaused = true;
      }
    }

    private void StartTimer()
    {
      timer.Start(MatchDurationInSeconds);
    }

    private void PauseTimer()
    {
      timer.Pause();
    }

    private void ResetGame()
    {
      TeamOneScore = 0;
      TeamTwoScore = 0;

      MatchPaused = true;

      TimeLeft = TimeSpan.FromMinutes(MatchDurationInSeconds / 60).ToString(@"mm\:ss");
      MatchStatusText = $"Start (mecz {MatchNumber + 1})";

      timer.Stop();
      timer.Reset();
    }

    // todo: one method
    private void GoalTeamOneTap(Player player = null)
    {
      TeamOneScore += 1;
      matchService.AddGoal(player);
    }

    private void GoalTeamTwoTap(Player player = null)
    {
      TeamTwoScore += 1;
      matchService.AddGoal(player);
    }

    private void PlaySound()
    {
      DependencyService.Get<IAudio>().PlayAudioFile("whistle.mp3");
    }

    public event PropertyChangedEventHandler PropertyChanged;
    void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    int matchNumber;
    public int MatchNumber
    {
      get { return matchNumber; }
      set { matchNumber = value; OnPropertyChanged(); }
    }

    List<Player> teamHomePlayers;
    public List<Player> TeamHomePlayers
    {
      get { return teamHomePlayers; }
      set { teamHomePlayers = value; OnPropertyChanged(); }
    }

    List<Player> teamAwayPlayers;
    public List<Player> TeamAwayPlayers
    {
      get { return teamAwayPlayers; }
      set { teamAwayPlayers = value; OnPropertyChanged(); }
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

    string timeLeft;
    public string TimeLeft
    {
      get { return timeLeft; }
      set { timeLeft = value; OnPropertyChanged(); }
    }

    bool matchPaused;
    public bool MatchPaused
    {
      get { return matchPaused; }
      set { matchPaused = value; OnPropertyChanged(); }
    }

    bool matchEnded;
    public bool MatchEnded
    {
      get { return matchEnded; }
      set { matchEnded = value; OnPropertyChanged(); }
    }

    string matchStatusText;
    public string MatchStatusText
    {
      get { return matchStatusText; }
      set { matchStatusText = value; OnPropertyChanged(); }
    }

  }
}
