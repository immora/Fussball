using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fussball.Models
{
  public class MatchStatistics
  {
    public List<TeamPlayerGoals> GoalsForEachTeamPlayer { get; set; }

    public int TeamHomeScore { get; set; }

    public int TeamAwayScore { get; set; }

    public MatchStatistics()
    {
      GoalsForEachTeamPlayer = new List<TeamPlayerGoals>();
    }

    public override string ToString()
    {
      StringBuilder itemString = new StringBuilder();

      itemString.AppendLine("Wynik:");
      itemString.AppendLine($"{this.TeamHomeScore} : {this.TeamAwayScore}");
      itemString.AppendLine();

      List<TeamPlayerGoals> items = this.GoalsForEachTeamPlayer;
      var teams = items.GroupBy(x => x.Team).ToList();
      teams.Reverse();

      foreach (var item in teams)
      {
        itemString.AppendLine(item.Key);

        var playersGoals = teams.SelectMany(group => group).Where(x => x.Team == item.Key).ToList();

        foreach (var playerGoals in playersGoals)
        {
          itemString.AppendLine($"{ playerGoals.Player.DisplayName} : {playerGoals.Goals}");
        }

        itemString.AppendLine();
      }

      return itemString.ToString();
    }
  }
}
