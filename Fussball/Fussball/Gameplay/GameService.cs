using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fussball.Gameplay.Models;
using Fussball.Players.Model;

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
      matches = new List<Match>();

      Random rand = new Random();

      for (int i = 0; i < MatchCount; i++)
      {
        List<Player> copyOfPlayers = new List<Player>();
        copyOfPlayers.AddRange(players);

        Match match = new Match();

        Player p1 = copyOfPlayers[rand.Next(0, 3)];
        copyOfPlayers.Remove(p1);
        Player p2 = copyOfPlayers[rand.Next(0, 2)];
        copyOfPlayers.Remove(p2);

        match.TeamHome = new List<Player> { p1, p2 };
        match.TeamAway = new List<Player>();
        match.TeamAway.AddRange(copyOfPlayers);

        matches.Add(match);
      }

      return matches;
    }
  }
}
