using System.ComponentModel;

using Xamarin.Forms;
using Fussball.Models;

namespace Fussball.Views
{
	public partial class SelectPlayersPage : ContentPage
	{
		public class WrappedSelection : INotifyPropertyChanged
		{
			public event PropertyChangedEventHandler PropertyChanged = delegate { };

			public Player Player { get; set; }

			bool isSelected = false;
			public bool IsSelected
			{
				get
				{
					return isSelected;
				}
				set
				{
					if (isSelected != value)
					{
						isSelected = value;
						PropertyChanged(this, new PropertyChangedEventArgs(nameof(IsSelected)));
					}
				}
			}
		}
	}
}
