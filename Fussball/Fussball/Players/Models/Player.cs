using Fussball.Utils.ExtensionMethods;

namespace Fussball.Players.Model
{
	public class Player
	{
		public int Id { get; set; }

		public string DisplayName { get; set; }

		public string AvatarPath
		{
			get => DisplayName.ToLower().ReplacePolishSigns() + ".jpg";
		}

		public override string ToString()
		{
			return DisplayName;
		}
	}
}
