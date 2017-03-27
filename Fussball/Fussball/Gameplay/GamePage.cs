using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Fussball.Players.Model;
using ImageCircle.Forms.Plugin.Abstractions;
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
			countDownTimerLabel.SetBinding(Label.TextProperty, new Binding("TimeLeft"));

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

      CircleImage playerImage1 = new CircleImage
      {
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
        Aspect = Aspect.AspectFit,
        BorderColor = Color.Accent,
        BorderThickness = 3
			};
			playerImage1.SetBinding(Image.SourceProperty, new Binding("Players[0].AvatarPath"));

      CircleImage playerImage2 = new CircleImage
      {
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
        Aspect = Aspect.AspectFit,
        BorderColor = Color.Accent,
        BorderThickness = 3
      };
			playerImage2.SetBinding(Image.SourceProperty, new Binding("Players[1].AvatarPath"));

      CircleImage playerImage3 = new CircleImage
      {
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
        Aspect = Aspect.AspectFit,
        BorderColor = Color.Accent,
        BorderThickness = 3
      };
			playerImage3.SetBinding(Image.SourceProperty, new Binding("Players[2].AvatarPath"));

      CircleImage playerImage4 = new CircleImage
      {
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
        Aspect = Aspect.AspectFit,
        BorderColor = Color.Accent,
        BorderThickness = 3
      };
			playerImage4.SetBinding(Image.SourceProperty, new Binding("Players[3].AvatarPath"));

			playersGrid.Children.Add(playerImage1, 0, 0);
			playersGrid.Children.Add(playerImage2, 1, 0);
			playersGrid.Children.Add(playerImage3, 0, 1);
			playersGrid.Children.Add(playerImage4, 1, 1);

      #endregion playersGrid

      Button startGameButton = new Button
      {
        Text = "Start",
        HorizontalOptions = LayoutOptions.FillAndExpand
      };
      startGameButton.SetBinding(Button.CommandProperty, new Binding("StartTimerCommand"));

      Button resetGameButton = new Button
			{
				Text = "Reset",
				HorizontalOptions = LayoutOptions.FillAndExpand,
        
      };
			resetGameButton.SetBinding(Button.CommandProperty, new Binding("ResetGameCommand"));

      StackLayout buttons = new StackLayout
      {
        Orientation = StackOrientation.Horizontal
      };
      buttons.Children.Add(startGameButton);
      buttons.Children.Add(resetGameButton);
      
      Content = new StackLayout
			{
				Children =
				{
					//header,
					countDownTimerLabel,
					scoreGrid,
					playersGrid,
          buttons
          //startGameButton,
          //resetGameButton
        }
			};
		}
    //protected override void OnBindingContextChanged()
    //{
    //  base.OnBindingContextChanged();

    //  pageModel = BindingContext as GamePageModel;

    //  // Modify the page based on the pageModel
    //}
  }
}
