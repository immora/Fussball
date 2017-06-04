using Fussball.Models;
using System.Collections.Generic;

namespace Fussball.Services
{
	public class MatchService
	{
		public IDictionary<Player, int> PlayersGoals;

		public MatchService()
		{
			PlayersGoals = new Dictionary<Player, int>();
		}

		//todo: which team
		public void AddGoal(Player player)
		{
			if (player == null)
			{
				return;
			}

			PlayersGoals.TryGetValue(player, out var goals);

			PlayersGoals[player] = ++goals;
		}

    public MatchStatistics CalculateStatistics(List<Player> teamHomePlayers, int teamHomeScore, int teamAwayScore)
    {
      MatchStatistics result = new MatchStatistics();

      foreach (var goalsForPlayer in PlayersGoals)
      {
        TeamPlayerGoals stats = new TeamPlayerGoals
        {
          Player = goalsForPlayer.Key,
          Goals = goalsForPlayer.Value,
          Team = teamHomePlayers.Contains(goalsForPlayer.Key) ? "Team home" : "Team away"
        };

        result.GoalsForEachTeamPlayer.Add(stats);
      }

      result.TeamHomeScore = teamHomeScore;
      result.TeamAwayScore = teamAwayScore;

      return result;
    }
	}
}
