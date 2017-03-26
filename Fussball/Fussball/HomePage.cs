using Fussball.Gameplay;
using Fussball.Gameplay.ViewModels;
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
		Image PlayerImg1;
		Image PlayerImg2;
		Image PlayerImg3;
		Image PlayerImg4;
		Button letsPlayButton;

		List<Player> selectedPlayers;

		public HomePage()
		{
			selectedPlayers = new List<Player>();

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

			PlayerImg1 = new Image
			{
				WidthRequest = 200,
				HeightRequest = 200,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Source = ImageSource.FromFile("anon1.png")
			};
			PlayerImg2 = new Image
			{
				WidthRequest = 200,
				HeightRequest = 200,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Source = ImageSource.FromFile("anon2.png")
			};
			PlayerImg3 = new Image
			{
				WidthRequest = 200,
				HeightRequest = 200,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Source = ImageSource.FromFile("anon3.png")
			};
			PlayerImg4 = new Image
			{
				WidthRequest = 200,
				HeightRequest = 200,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Source = ImageSource.FromFile("anon4.png")
			};

			Grid playersGrid = new Grid
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				RowDefinitions =
				{
					new RowDefinition { Height = new GridLength(150)},
					new RowDefinition { Height = new GridLength(150)},
				},
				ColumnDefinitions =
				{
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)},
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)}
				}
			};

			playersGrid.Children.Add(PlayerImg1, 0, 0);
			playersGrid.Children.Add(PlayerImg2, 0, 1);

			playersGrid.Children.Add(PlayerImg3, 1, 0);
			playersGrid.Children.Add(PlayerImg4, 1, 1);

			//ImageButton playerImageButton = new ImageButton
			//{
			//	ImageHeightRequest = 150,
			//	ImageWidthRequest = 150,
			//	Orientation = XLabs.Enums.ImageOrientation.ImageOnBottom,
			//	Source = ImageSource.FromFile("kasia.jpg")
			//};

			letsPlayButton = new Button
			{
				Text = "Gramy!",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				IsVisible = false
			};

			letsPlayButton.Clicked += StartGame;

			Content = new StackLayout
			{
				Children =
				{
					header,
					//timePicker,
					choosePlayersButton,
					//pickedPlayersLabel,
					//playerImageButton,
					//PlayerImg1,
					//PlayerImg2,
					//PlayerImg3,
					//PlayerImg4
					playersGrid,
					letsPlayButton
				}
			};
		}

		private void StartGame(object sender, EventArgs e)
		{
			//var scorePage = new MainPage();
			//scorePage.BindingContext = new GameViewModel(selectedPlayers);

			////var fsdfsv = Navigation.NavigationStack; pytanie czy nie dałoby się wyczyścić stacka
			//Navigation.PushAsync(scorePage, true);

			var gamePage = new GamePage();
			gamePage.BindingContext = new GameViewModel(selectedPlayers);

			Navigation.PushAsync(gamePage, true);
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

			if (selectPlayersPage != null && selectPlayersPage.GetSelection().Count > 0)
			{
				//pickedPlayersLabel.Text = "";

				selectedPlayers = selectPlayersPage.GetSelection();

				PlayerImg1.Source = ImageSource.FromFile(selectedPlayers[0].AvatarPath);
				PlayerImg2.Source = ImageSource.FromFile(selectedPlayers[1].AvatarPath);
				PlayerImg3.Source = ImageSource.FromFile(selectedPlayers[2].AvatarPath);
				PlayerImg4.Source = ImageSource.FromFile(selectedPlayers[3].AvatarPath);

				letsPlayButton.IsVisible = true;
			}
			else
			{
				//reset avatars?

				letsPlayButton.IsVisible = false;
			}
		}

	}
}
