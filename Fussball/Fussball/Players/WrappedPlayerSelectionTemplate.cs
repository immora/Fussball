
using Xamarin.Forms;

namespace Fussball.Players
{
	public partial class SelectPlayersPage : ContentPage
	{
		public class WrappedPlayerSelectionTemplate : ViewCell
		{
			public WrappedPlayerSelectionTemplate() : base()
			{
				Label name = new Label();
				name.SetBinding(Label.TextProperty, new Binding("Player.DisplayName"));

				Switch mainSwitch = new Switch();
				mainSwitch.SetBinding(Switch.IsToggledProperty, new Binding("IsSelected"));

				RelativeLayout layout = new RelativeLayout();
				layout.Children.Add(
					name,
					Constraint.Constant(5),
					Constraint.Constant(5),
					Constraint.RelativeToParent(p => p.Width - 60),
					Constraint.RelativeToParent(p => p.Height - 10));
				layout.Children.Add(
					mainSwitch,
					Constraint.RelativeToParent(p => p.Width - 55),
					Constraint.Constant(5),
					Constraint.Constant(50),
					Constraint.RelativeToParent(p => p.Height - 10));

				View = layout;
			}
		}
	}
}
