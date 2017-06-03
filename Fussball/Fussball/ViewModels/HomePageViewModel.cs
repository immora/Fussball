using Acr.Notifications;
using Fussball.Interface;
using Fussball.Models;
using Fussball.Services;
using Fussball.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Fussball.ViewModels
{

  public class HomePageModel : INotifyPropertyChanged
  {
    public HomePageModel()
    {
    }

    public event PropertyChangedEventHandler PropertyChanged;
  }
}
