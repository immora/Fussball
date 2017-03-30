using Fussball.Players.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fussball.Utils
{
	public static class DictionaryToStringConverter
	{
		public static string DictToString<T, V>(IEnumerable<KeyValuePair<T, V>> items)
		{
			StringBuilder itemString = new StringBuilder();
			foreach (var item in items)
			{
				itemString.AppendLine($"{ item.Key.ToString()} : {item.Value}");
			}

			return itemString.ToString();
		}
	}
}
