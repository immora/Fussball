using Fussball.Players;
using Fussball.Players.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace Fussball
{
	public class HomePage : ContentPage
	{
		SelectPlayersPage selectPlayersPage;
		Label pickedPlayersLabel;

		public HomePage()
		{
			Label header = new Label
			{
				Text = "Piłkarzyki",
				FontSize = 50,
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.Center
			};

			//https://gist.github.com/yuv4ik/c7137c4ea89ededa99dfee51bfb1de4e http://stackoverflow.com/questions/35931470/timepicker-with-seconds
			//TimePicker timePicker = new TimePicker
			//{
			//	Format = @"mm\:ss",
			//	Time = TimeSpan.FromMinutes(5),
			//	TextColor = Color.Green,
			//	HeightRequest = 200
			//};

			Button choosePlayersButton = new Button
			{
				Text = "Wybierz graczy",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			choosePlayersButton.Clicked += SelectPlayers;

			pickedPlayersLabel = new Label
			{
				FontSize = 28
			};

			ImageButton playerImageButton = new ImageButton
			{
				ImageHeightRequest = 150,
				ImageWidthRequest = 150,
				Orientation = XLabs.Enums.ImageOrientation.ImageOnTop,
				Source = ImageSource.FromFile("kasia.jpg")
			};

			Image image = new Image
			{
				Source = ImageSource.FromFile("kasia.jpg")
			};

			Content = new StackLayout
			{
				Children =
				{
					header,
					//timePicker,
					choosePlayersButton,
					pickedPlayersLabel,
					playerImageButton,
					image
				}
			};
		}

		private async void SelectPlayers(object sender, EventArgs e)
		{
			var players = new List<Player>
			{
				new Player { DisplayName = "Kasia" },
				new Player { DisplayName = "Mario" },
				new Player { DisplayName = "Mariusz" },
				new Player { DisplayName = "Piotrek" },
				new Player { DisplayName = "Robert" },
				new Player { DisplayName = "Sławek" },
				new Player { DisplayName = "Gość" }
			};

			if (selectPlayersPage == null)
			{
				selectPlayersPage = new SelectPlayersPage(players) { Title = "Wybór graczy" };
			}

			await Navigation.PushAsync(selectPlayersPage);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (selectPlayersPage != null)
			{
				pickedPlayersLabel.Text = "";

				var players = selectPlayersPage.GetSelection();

				foreach (Player player in players)
				{
					pickedPlayersLabel.Text += player.DisplayName + ", ";
				}
			}
			else
			{
				pickedPlayersLabel.Text = "(brak)";
			}
		}

	}
}
