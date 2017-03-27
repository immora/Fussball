using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fussball.Players.Model;

namespace Fussball.Gameplay.Models
{
  public class Match
  {
    public List<Player> TeamHome { get; set; }

    public List<Player> TeamAway { get; set; }

    public int ScoreHome { get; set; }

    public int ScoreAway { get; set; }

    //todo: Achievements
  }
}
