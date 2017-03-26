using Fussball.Utils.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fussball.Players.Model
{
	public class Player
	{
		public int Id { get; set; }

		public string DisplayName { get; set; }

		public string AvatarPath {
			get => DisplayName.ToLower().ReplacePolishSigns() + ".jpg";
		}
	}
}
