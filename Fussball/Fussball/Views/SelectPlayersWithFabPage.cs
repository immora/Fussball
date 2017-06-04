using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Fussball.Views
{
  public class SelectPlayersWithFabPage : ContentPage
  {
    public SelectPlayersWithFabPage()
    {
      Content = new StackLayout
      {
        Children = {
          new Label { Text = "Hello Page" }
        }
      };
    }
  }
}