using System;
using System.Globalization;
using Xamarin.Forms;

namespace Fussball.Players
{
	public partial class SelectPlayersPage : ContentPage
	{
		public class WrappedPlayerSelectionTemplate : ViewCell
		{
			public WrappedPlayerSelectionTemplate() : base()
			{
				Image image = new Image();
				image.SetBinding(Image.SourceProperty, new Binding("Player.AvatarPath"));

				Label name = new Label();
				name.SetBinding(Label.TextProperty, new Binding("Player.DisplayName"));

				Switch mainSwitch = new Switch();
				mainSwitch.SetBinding(Switch.IsToggledProperty, new Binding("IsSelected"));

				RelativeLayout layout = new RelativeLayout();
				layout.Children.Add(
					image,
					Constraint.Constant(5),
					Constraint.Constant(5),
					Constraint.RelativeToParent(p => p.Width - 60),
					Constraint.RelativeToParent(p => p.Height - 10));
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

				//Tapped += async (sender, args) =>
				//{
				//	this.View.BackgroundColor = Color.Red;
				//};

				layout.SetBinding(RelativeLayout.BackgroundColorProperty, new Binding("IsSelected", converter: new IsSelectedToBackgroundConvert(), converterParameter: layout.BackgroundColor));

				View = layout;
			}
		}
	}

	internal class IsSelectedToBackgroundConvert : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			Color defaultColor = Color.White;
			Color selectedColor = Color.FromHex("#B2DFDB");

			return (bool)value ? selectedColor : defaultColor;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
