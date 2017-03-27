using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fussball.Gameplay.Models;
using Fussball.Players.Model;
using Fussball.Utils.ExtensionMethods;

namespace Fussball
{
	public class GameService
	{
		public List<Match> matches;
		public const int MatchCount = 3;

		public GameService()
		{
			matches = new List<Match>();
		}

		public List<Match> GenerateMatches(List<Player> players)
		{
			List<Tuple<Player, Player>> playersWithoutDuplicates = new List<Tuple<Player, Player>>();

			Random rand = new Random();
			players.Shuffle(rand);

			var cartesianProductOfPlayers = from x in players
																			from y in players
																			where x != y
																			select new Tuple<Player, Player>(x, y);


			foreach (var tuple in cartesianProductOfPlayers)
			{
				if (!playersWithoutDuplicates.Contains(tuple) && !playersWithoutDuplicates.Contains(new Tuple<Player, Player>(tuple.Item2, tuple.Item1)))
				{
					playersWithoutDuplicates.Add(tuple);
				}
			}

			matches = new List<Match>
			{
				new Match(playersWithoutDuplicates.First().ToList(), playersWithoutDuplicates.Last().ToList()),
				new Match(playersWithoutDuplicates[1].ToList(), playersWithoutDuplicates[4].ToList()),
				new Match(playersWithoutDuplicates[2].ToList(), playersWithoutDuplicates[3].ToList())
			};

			return matches;
		}
	}
}
