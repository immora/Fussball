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
	}
}
