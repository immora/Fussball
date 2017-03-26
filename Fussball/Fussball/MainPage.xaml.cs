using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.Notifications;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Fussball.Players.Model;
using Fussball.Players;
using Fussball.Gameplay.ViewModels;

namespace Fussball
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class MainPage : ContentPage
  {
		GameViewModel pageModel;

		public MainPage()
    {
      InitializeComponent();
			//BindingContext = new GameViewModel(new List<Player>());
			pageModel = BindingContext as GameViewModel;
		}

    private void ResetScore(object sender, EventArgs e)
    {
			//BindingContext = new GameViewModel(pageModel.Players);
    }
  }
}
