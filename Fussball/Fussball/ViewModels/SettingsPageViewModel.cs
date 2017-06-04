using Fussball.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Fussball.ViewModels
{
  public class SettingsPageViewModel : INotifyPropertyChanged
  {
    public ICommand ChangeMatchCountCommand { get; }
    public ICommand ChangeMatchTimeCommand { get; }
    //public ICommand ToggleGoalLimitCommand { get; }
    public ICommand SetGoalLimitCommand { get; }

    public SettingsPageViewModel()
    {
      ChangeMatchCountCommand = new Command<int>(ChangeMatchCount);
      ChangeMatchTimeCommand = new Command<int>(ChangeMatchTime);
      //ToggleGoalLimitCommand = new Command<bool>(ToggleGoalLimit);
      SetGoalLimitCommand = new Command<int>(SetGoalLimit);

      IsGoalLimitEnabled = false;
    }

    private void ChangeMatchCount(int obj)
    {
      throw new NotImplementedException();
    }

    private void ChangeMatchTime(int obj)
    {
      throw new NotImplementedException();
    }


    private void SetGoalLimit(int obj)
    {
      throw new NotImplementedException();
    }

    public event PropertyChangedEventHandler PropertyChanged;
    void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    public int MatchCount
    {
      get => Settings.MatchCount;
      set { Settings.MatchCount = value; OnPropertyChanged(); }
    }

    public int MatchTime
    {
      get => Settings.MatchTime;
      set { Settings.MatchTime = value; OnPropertyChanged(); }
    }

    bool isGoalLimitEnabled;
    public bool IsGoalLimitEnabled
    {
      get => isGoalLimitEnabled;
      set
      {
        isGoalLimitEnabled = value;

        if (isGoalLimitEnabled == false)
        {
          GoalLimit = 0;
        }

        OnPropertyChanged();
      }
    }

    public int GoalLimit
    {
      get => Settings.GoalLimit;
      set { Settings.GoalLimit = value; OnPropertyChanged(); }
    }
  }
}
