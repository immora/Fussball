using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Fussball.Gameplay
{
	public class GamePage : ContentPage
	{
		private const int PlayersCount = 4;

		public GamePage()
		{
			Label header = new Label
			{
				Text = "Piłkarzyki",
				FontSize = 50,
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.Center
			};

			Label countDownTimerLabel = new Label
			{
				FontSize = 96,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};
			countDownTimerLabel.SetBinding(Label.TextProperty, "TimeLeft");

			Button startGameButton = new Button
			{
				Text = "Start",
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			startGameButton.SetBinding(Button.CommandProperty, new Binding("StartTimerCommand"));

			#region scoreGrid
			Grid scoreGrid = new Grid
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				RowDefinitions =
				{
					new RowDefinition { Height = 100}
				},
				ColumnDefinitions =
				{
					new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star)},
					new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star)}
				}
			};

			#region ScoreTeamOne
			var tapGoalForTeamOne = new TapGestureRecognizer();
			tapGoalForTeamOne.SetBinding(TapGestureRecognizer.CommandProperty, new Binding("GoalTeamOneTapCommand"));

			ContentView contentForTapScoreOne = new ContentView
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand
			};
			contentForTapScoreOne.GestureRecognizers.Add(tapGoalForTeamOne);

			Label scoreTeamOneLabel = new Label
			{
				FontSize = 72,
				HorizontalOptions = LayoutOptions.Center,
				BackgroundColor = Color.Accent,
				TextColor = Color.White,
			};
			scoreTeamOneLabel.SetBinding(Label.TextProperty, new Binding("TeamOneScore"));

			#endregion ScoreTeamOne

			#region ScoreTeamTwo

			var tapGoalForTeamTwo = new TapGestureRecognizer();
			tapGoalForTeamTwo.SetBinding(TapGestureRecognizer.CommandProperty, new Binding("GoalTeamTwoTapCommand"));

			ContentView contentForTapScoreTwo = new ContentView
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand
			};
			contentForTapScoreTwo.GestureRecognizers.Add(tapGoalForTeamTwo);

			Label scoreTeamTwoLabel = new Label
			{
				FontSize = 72,
				HorizontalOptions = LayoutOptions.Center,
				BackgroundColor = Color.Accent,
				TextColor = Color.White
			};
			scoreTeamTwoLabel.SetBinding(Label.TextProperty, new Binding("TeamTwoScore"));

			#endregion ScoreTeamTwo

			scoreGrid.Children.Add(new BoxView { BackgroundColor = Color.Accent }, 0, 0);
			scoreGrid.Children.Add(scoreTeamOneLabel, 0, 0);
			scoreGrid.Children.Add(contentForTapScoreOne, 0, 0);

			scoreGrid.Children.Add(new BoxView { BackgroundColor = Color.Accent }, 1, 0);
			scoreGrid.Children.Add(scoreTeamTwoLabel, 1, 0);
			scoreGrid.Children.Add(contentForTapScoreTwo, 1, 0);

			#endregion scoreGrid

			#region playersGrid
			Grid playersGrid = new Grid
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				RowDefinitions =
				{
					new RowDefinition { Height = 100},
					new RowDefinition { Height = 100}
				},
				ColumnDefinitions =
				{
					new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star)},
					new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star)}
				}
			};

			Image playerImage1 = new Image
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
			};
			playerImage1.SetBinding(Image.SourceProperty, new Binding("Players[0].AvatarPath"));

			Image playerImage2 = new Image
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
			};
			playerImage2.SetBinding(Image.SourceProperty, new Binding("Players[1].AvatarPath"));

			Image playerImage3 = new Image
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
			};
			playerImage3.SetBinding(Image.SourceProperty, new Binding("Players[2].AvatarPath"));

			Image playerImage4 = new Image
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
			};
			playerImage4.SetBinding(Image.SourceProperty, new Binding("Players[3].AvatarPath"));

			playersGrid.Children.Add(playerImage1, 0, 0);
			playersGrid.Children.Add(playerImage2, 1, 0);
			playersGrid.Children.Add(playerImage3, 0, 1);
			playersGrid.Children.Add(playerImage4, 1, 1);

			#endregion playersGrid

			Button resetGameButton = new Button
			{
				Text = "Reset",
				HorizontalOptions = LayoutOptions.Center
			};
			resetGameButton.SetBinding(Button.CommandProperty, new Binding("ResetGameCommand"));

			Content = new StackLayout
			{
				Children =
				{
					//header,
					countDownTimerLabel,
					startGameButton,
					scoreGrid,
					playersGrid,
					resetGameButton
				}
			};
		}
	}
}
