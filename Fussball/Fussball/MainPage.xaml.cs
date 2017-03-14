using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Fussball
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			BindingContext = new MainPageViewModel();
		}

		private void ResetScore(object sender, EventArgs e)
		{
			BindingContext = new MainPageViewModel();
		}

		class MainPageViewModel : INotifyPropertyChanged
		{
			public ICommand IncreaseGoalCountCommand { get; }
			public ICommand GoalTeamOneTapCommand { get; }
			public ICommand GoalTeamTwoTapCommand { get; }

			int teamOneScore;
			public int TeamOneScore
			{
				get { return teamOneScore; }
				set { teamOneScore = value; OnPropertyChanged(); }
			}

			int teamTwoScore;
			public int TeamTwoScore
			{
				get { return teamTwoScore; }
				set { teamTwoScore = value; OnPropertyChanged(); }
			}

			public MainPageViewModel()
			{
				IncreaseGoalCountCommand = new Command<string>(IncreaseGoalCount);

				GoalTeamOneTapCommand = new Command(GoalTeamOneTap);
				GoalTeamTwoTapCommand = new Command(GoalTeamTwoTap);

				TeamOneScore = 0;
				TeamTwoScore = 0;
			}

			void IncreaseGoalCount(string team)
			{
				switch (team)
				{
					case "Goal for team 1":
						TeamOneScore += 1;
						break;
					case "Goal for team 2":
						TeamTwoScore += 1;
						break;
					default:
						break;
				}
			}

			void GoalTeamOneTap()
			{
				TeamOneScore += 1;
			}

			void GoalTeamTwoTap()
			{
				TeamTwoScore += 1;
			}

			public event PropertyChangedEventHandler PropertyChanged;
			void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
