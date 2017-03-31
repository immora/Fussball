using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using Fussball.Utils.ExtensionMethods;
using Fussball.Players.Model;
using ImageCircle.Forms.Plugin.Abstractions;
using Xamarin.Forms;
using Fussball.Utils;

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
			countDownTimerLabel.SetBinding(Label.TextProperty, new Binding("TimeLeft"));

      #region tapGesture

      var tapGoalForTeamHome = new TapGestureRecognizer();
			tapGoalForTeamHome.SetBinding(TapGestureRecognizer.CommandProperty, new Binding("GoalTeamOneTapCommand"));

			var tapGoalForTeamHomePlayerOne = new TapGestureRecognizer();
			tapGoalForTeamHomePlayerOne.SetBinding(TapGestureRecognizer.CommandProperty, new Binding("GoalTeamOneTapCommand"));
			var tapGoalForTeamHomePlayerTwo = new TapGestureRecognizer();
			tapGoalForTeamHomePlayerTwo.SetBinding(TapGestureRecognizer.CommandProperty, new Binding("GoalTeamOneTapCommand"));

			var tapGoalForTeamAway = new TapGestureRecognizer();
			tapGoalForTeamAway.SetBinding(TapGestureRecognizer.CommandProperty, new Binding("GoalTeamTwoTapCommand"));

			var tapGoalForTeamAwayPlayerOne = new TapGestureRecognizer();
			tapGoalForTeamAwayPlayerOne.SetBinding(TapGestureRecognizer.CommandProperty, new Binding("GoalTeamTwoTapCommand"));
			var tapGoalForTeamAwayPlayerTwo = new TapGestureRecognizer();
			tapGoalForTeamAwayPlayerTwo.SetBinding(TapGestureRecognizer.CommandProperty, new Binding("GoalTeamTwoTapCommand"));

      #endregion tapGesture

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

			ContentView contentForTapScoreOne = new ContentView
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand
			};
			contentForTapScoreOne.GestureRecognizers.Add(tapGoalForTeamHome);

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

			ContentView contentForTapScoreTwo = new ContentView
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand
			};
			contentForTapScoreTwo.GestureRecognizers.Add(tapGoalForTeamAway);

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

      CircleImage teamHomePlayer1 = new CircleImage
      {
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
        Aspect = Aspect.AspectFit,
        BorderColor = Color.Accent,
        BorderThickness = 3
			};
			teamHomePlayer1.SetBinding(Image.SourceProperty, new Binding("TeamHomePlayers[0].AvatarPath"));
			tapGoalForTeamHomePlayerOne.SetBinding(TapGestureRecognizer.CommandParameterProperty, new Binding("TeamHomePlayers[0]"));
			teamHomePlayer1.GestureRecognizers.Add(tapGoalForTeamHomePlayerOne);


			CircleImage teamHomePlayer2 = new CircleImage
      {
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
        Aspect = Aspect.AspectFit,
        BorderColor = Color.Accent,
        BorderThickness = 3
      };
			teamHomePlayer2.SetBinding(Image.SourceProperty, new Binding("TeamHomePlayers[1].AvatarPath"));
			tapGoalForTeamHomePlayerTwo.SetBinding(TapGestureRecognizer.CommandParameterProperty, new Binding("TeamHomePlayers[1]"));
			teamHomePlayer2.GestureRecognizers.Add(tapGoalForTeamHomePlayerTwo);

			CircleImage teamAwayPlayer1 = new CircleImage
      {
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
        Aspect = Aspect.AspectFit,
        BorderColor = Color.Accent,
        BorderThickness = 3
      };
			teamAwayPlayer1.SetBinding(Image.SourceProperty, new Binding("TeamAwayPlayers[0].AvatarPath"));
			tapGoalForTeamAwayPlayerOne.SetBinding(TapGestureRecognizer.CommandParameterProperty, new Binding("TeamAwayPlayers[0]"));
			teamAwayPlayer1.GestureRecognizers.Add(tapGoalForTeamAwayPlayerOne);

			CircleImage teamAwayPlayer2 = new CircleImage
      {
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
        Aspect = Aspect.AspectFit,
        BorderColor = Color.Accent,
        BorderThickness = 3
      };
			teamAwayPlayer2.SetBinding(Image.SourceProperty, new Binding("TeamAwayPlayers[1].AvatarPath"));
			tapGoalForTeamAwayPlayerTwo.SetBinding(TapGestureRecognizer.CommandParameterProperty, new Binding("TeamAwayPlayers[1]"));
			teamAwayPlayer2.GestureRecognizers.Add(tapGoalForTeamAwayPlayerTwo);

			playersGrid.Children.Add(teamHomePlayer1, 0, 0);
			playersGrid.Children.Add(teamHomePlayer2, 0, 1);
			playersGrid.Children.Add(teamAwayPlayer1, 1, 0);
			playersGrid.Children.Add(teamAwayPlayer2, 1, 1);

      #endregion playersGrid

      Button startGameButton = new Button
      {
        HorizontalOptions = LayoutOptions.FillAndExpand
      };
      startGameButton.SetBinding(Button.CommandProperty, new Binding("StartOrPauseGameCommand"));
			startGameButton.SetBinding(Button.TextProperty, new Binding("MatchStatusText"));

			ToolbarItem resetToolbarItem = new ToolbarItem();
			resetToolbarItem.Order = ToolbarItemOrder.Primary;
			resetToolbarItem.Icon = "resetGameIcon.png";
			resetToolbarItem.SetBinding(ToolbarItem.CommandProperty, new Binding("ResetGameCommand"));

			ToolbarItems.Add(resetToolbarItem);

			Content = new StackLayout
			{
				Children =
				{
					countDownTimerLabel,
					scoreGrid,
					playersGrid,
          startGameButton
        }
			};

			SubscribeToEvents();
		}

		public void SubscribeToEvents()
		{
			MessagingCenter.Subscribe<GamePageModel, IDictionary<Player, int>>(this, "MatchEnded", (sender, arg) =>
			{
				DisplayAlert("Bieda statystyki", DictionaryToStringConverter.DictToString<Player, int>(arg), "Ok, whatever");
			});

		}
	}
}
