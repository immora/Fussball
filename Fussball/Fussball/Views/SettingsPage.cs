using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Fussball
{
  public class SettingsPage : ContentPage
  {
    Label matchCountLabel;
    Label matchTimeLabel;
    Label goalLimitLabel;
    Stepper goalLimitStepper;

    public SettingsPage()
    {
      matchCountLabel = new Label { };
      matchCountLabel.SetBinding(Label.TextProperty, new Binding("MatchCount", stringFormat: "Liczba meczy: {0}"));

      Stepper matchStepper = new Stepper
      {
        Value = 3,
        Minimum = 1,
        Maximum = 3,
        Increment = 1
      };
      matchStepper.SetBinding(Stepper.ValueProperty, new Binding("MatchCount"));

      matchTimeLabel = new Label { };
      matchTimeLabel.SetBinding(Label.TextProperty, new Binding("MatchTime", stringFormat: "Czas trwania meczu: {0}"));

      Stepper matchTimeStepper = new Stepper
      {
        Value = 5,
        Minimum = 1,
        Maximum = 30,
        Increment = 1
      };
      matchTimeStepper.SetBinding(Stepper.ValueProperty, new Binding("MatchTime"));

      goalLimitLabel = new Label { };
      goalLimitLabel.SetBinding(Label.TextProperty, new Binding("GoalLimit", stringFormat: "Limit bramek: {0}"));

      Switch goalLimitSwitch = new Switch();
      goalLimitSwitch.SetBinding(Switch.IsToggledProperty, new Binding("IsGoalLimitEnabled"));

      goalLimitStepper = new Stepper
      {
        IsVisible = false,
        Value = 10,
        Minimum = 5,
        Maximum = 100,
        Increment = 1
      };
      goalLimitStepper.SetBinding(Stepper.IsVisibleProperty, new Binding("IsGoalLimitEnabled"));
      goalLimitStepper.SetBinding(Stepper.ValueProperty, new Binding("GoalLimit"));

      Content = new StackLayout
      {
        Children = {
          matchCountLabel,
          matchStepper,
          matchTimeLabel,
          matchTimeStepper,
          goalLimitLabel,
          goalLimitSwitch,
          goalLimitStepper
        }
      };
    }

    private void GoalLimitStepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
      goalLimitLabel.Text = $"Limit bramek: {e.NewValue}";
    }

    private void GoalLimitSwitch_Toggled(object sender, ToggledEventArgs e)
    {
      if (e.Value == true)
      {
        goalLimitStepper.IsVisible = true;
      }
      else
      {
        goalLimitStepper.IsVisible = false;
        goalLimitStepper.Value = 10;
        goalLimitLabel.Text = "Limit bramek: brak limitu";
      }
    }

    private void MatchTimeStepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
      matchTimeLabel.Text = $"Czas trwania meczu: {(int)e.NewValue}:00";
    }

    private void MatchStepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
      matchCountLabel.Text = $"Liczba meczy: {e.NewValue}";
    }
  }
}