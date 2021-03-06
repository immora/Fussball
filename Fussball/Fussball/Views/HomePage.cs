﻿using Fussball.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using ImageCircle.Forms.Plugin.Abstractions;
using Fussball.ViewModels;

namespace Fussball.Views
{
	public class HomePage : ContentPage
	{
		SelectPlayersPage selectPlayersPage;
		CircleImage PlayerImg1;
    CircleImage PlayerImg2;
    CircleImage PlayerImg3;
    CircleImage PlayerImg4;
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

			PlayerImg1 = new CircleImage
      {
				WidthRequest = 200,
				HeightRequest = 200,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
        Aspect = Aspect.AspectFill,
        Source = ImageSource.FromFile("anon1.png")
			};
			PlayerImg2 = new CircleImage
      {
				WidthRequest = 200,
				HeightRequest = 200,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
        Aspect = Aspect.AspectFill,
        Source = ImageSource.FromFile("anon2.png")
			};
			PlayerImg3 = new CircleImage
      {
				WidthRequest = 200,
				HeightRequest = 200,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
        Aspect = Aspect.AspectFill,
        Source = ImageSource.FromFile("anon3.png")
			};
			PlayerImg4 = new CircleImage
      {
				WidthRequest = 200,
				HeightRequest = 200,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
        Aspect = Aspect.AspectFill,
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

			letsPlayButton = new Button
			{
				Text = "Gramy!",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				IsVisible = false
			};

			letsPlayButton.Clicked += StartGame;

      ToolbarItem settingsToolbarItem = new ToolbarItem();
      settingsToolbarItem.Order = ToolbarItemOrder.Primary;
      settingsToolbarItem.Icon = "settingsIcon.png";
      settingsToolbarItem.SetBinding(ToolbarItem.CommandProperty, new Binding("ShowSettingsPage"));
      settingsToolbarItem.Clicked += ShowSettingsPage;

      ToolbarItems.Add(settingsToolbarItem);

      Content = new StackLayout
			{
				Children =
				{
					header,
					choosePlayersButton,
					playersGrid,
					letsPlayButton
				}
			};
		}

    private void ShowSettingsPage(object sender, EventArgs e)
    {
      var settingsPage = new SettingsPage();
      settingsPage.BindingContext = new SettingsPageViewModel();

      Navigation.PushAsync(settingsPage, true);
    }

    private void StartGame(object sender, EventArgs e)
		{
			var gamePage = new GamePage();
			gamePage.BindingContext = new GamePageViewModel(selectedPlayers);

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
				selectedPlayers = selectPlayersPage.GetSelection();

        PlayerImg1.Source = ImageSource.FromFile(selectedPlayers[0].AvatarFileName);
        PlayerImg1.BorderColor = Color.White;
        PlayerImg1.BorderThickness = 3;

				PlayerImg2.Source = ImageSource.FromFile(selectedPlayers[1].AvatarFileName);
        PlayerImg2.BorderColor = Color.White;
        PlayerImg2.BorderThickness = 3;

        PlayerImg3.Source = ImageSource.FromFile(selectedPlayers[2].AvatarFileName);
        PlayerImg3.BorderColor = Color.White;
        PlayerImg3.BorderThickness = 3;

        PlayerImg4.Source = ImageSource.FromFile(selectedPlayers[3].AvatarFileName);
        PlayerImg4.BorderColor = Color.White;
        PlayerImg4.BorderThickness = 3;

        letsPlayButton.IsVisible = true;
			}
			else
			{
				letsPlayButton.IsVisible = false;
			}
		}

	}
}
