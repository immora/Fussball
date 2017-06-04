using System;
using System.Collections.Generic;
using System.Linq;
using Fussball.Models;
using Fussball.Utils.ExtensionMethods;

namespace Fussball.Services
{
	public class GameService
	{
		public List<Match> Matches;
		public const int MatchCount = 3;

		public GameService()
		{
			Matches = new List<Match>();
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

			Matches = new List<Match>
			{
				new Match(playersWithoutDuplicates.First().ToList(), playersWithoutDuplicates.Last().ToList()),
				new Match(playersWithoutDuplicates[1].ToList(), playersWithoutDuplicates[4].ToList()),
				new Match(playersWithoutDuplicates[2].ToList(), playersWithoutDuplicates[3].ToList())
			};

			return Matches;
		}

    public void CalculateStatistics()
    {

    }
	}
}
