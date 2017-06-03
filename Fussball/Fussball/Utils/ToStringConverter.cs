using Fussball.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fussball.Utils
{
  public static class ToStringConverter
  {
    public static string GetPoorStatistics<T, V>(IEnumerable<KeyValuePair<T, V>> items)
    {
      StringBuilder itemString = new StringBuilder();
      foreach (var item in items)
      {
        itemString.AppendLine($"{ item.Key.ToString()} : {item.Value}");
      }

      return itemString.ToString();
    }

    public static string GetTeamStatistics(List<TeamPlayerGoals> items)
    {
      StringBuilder itemString = new StringBuilder();

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
