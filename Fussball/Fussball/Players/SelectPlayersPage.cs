using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using Fussball.Players.Model;

namespace Fussball.Players
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

			Content = mainList;

			//ToolbarItems.Add(new ToolbarItem("None", null, SelectNone, ToolbarItemOrder.Primary));
		}

		public List<Player> GetSelection()
		{
			return WrappedItems.Where(item => item.IsSelected).Select(wrappedItem => wrappedItem.Player).ToList();
		}

		private void SelectNone()
		{
			foreach(var wi in WrappedItems)
			{
				wi.IsSelected = false;
			}
		}
	}
}
