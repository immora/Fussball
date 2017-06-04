using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Fussball.Models;
using Fussball.ViewModels;

namespace Fussball.Views
{
	public partial class SelectPlayersPage : ContentPage
	{
		public List<WrappedSelection> WrappedItems = new List<WrappedSelection>();

		public SelectPlayersPage(List<Player> players)
		{
			WrappedItems = players.Select(player => new WrappedSelection() { Player = player, IsSelected = false }).ToList();

			ListView mainList = new ListView()
			{
				ItemsSource = WrappedItems,
				ItemTemplate = new DataTemplate(typeof(WrappedPlayerSelectionTemplate))
			};

			mainList.ItemSelected += (sender, e) =>
			{
				if (e.SelectedItem == null) return;

				var o = (WrappedSelection)e.SelectedItem;
				o.IsSelected = !o.IsSelected;
				
				((ListView)sender).SelectedItem = null; //deselect
			};

			var height = Application.Current.MainPage.Height;
			mainList.RowHeight = (int)(height - 50)/ players.Count;

      ToolbarItem addPlayerToolbarItem = new ToolbarItem();
      addPlayerToolbarItem.Order = ToolbarItemOrder.Primary;
      addPlayerToolbarItem.Icon = "addIcon.png";
      addPlayerToolbarItem.Clicked += AddPlayerToolbarItem_Clicked;

      ToolbarItems.Add(addPlayerToolbarItem);

      Content = mainList;
		}

    private void AddPlayerToolbarItem_Clicked(object sender, System.EventArgs e)
    {
      var newPlayerPage = new NewPlayerPage();

      Navigation.PushAsync(newPlayerPage, true);
    }

    public List<Player> GetSelection()
		{
			var selectedItems = WrappedItems.Where(item => item.IsSelected).Select(wrappedItem => wrappedItem.Player).ToList();

			if (selectedItems.Count < 4)
			{
				return new List<Player>();
			}

			return selectedItems.Take(4).ToList();
		}

		private void SelectNone()
		{
			foreach (var wi in WrappedItems)
			{
				wi.IsSelected = false;
			}
		}

    protected override void OnAppearing()
    {
      base.OnAppearing();
      //listView.ItemsSource = App.Database.GetItems();
    }
  }
}
