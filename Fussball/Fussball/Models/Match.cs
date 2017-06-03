using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fussball.Models;

namespace Fussball.Models
{
  public class Match
  {
	  public List<Player> TeamHome { get; set; }

    public List<Player> TeamAway { get; set; }

    public int ScoreHome { get; set; }

    public int ScoreAway { get; set; }

		public Match(List<Player> teamHome, List<Player> teamAway)
		{
			TeamHome = teamHome;
			TeamAway = teamAway;
		}

    //todo: Achievements
  }
}
