using Fussball.Players.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fussball.Gameplay
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

			var goals = 0;
			PlayersGoals.TryGetValue(player, out goals);

			PlayersGoals[player] = ++goals;
		}

	}
}
