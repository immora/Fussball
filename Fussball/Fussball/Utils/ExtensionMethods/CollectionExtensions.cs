using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fussball.Utils.ExtensionMethods
{
	public static class CollectionExtensions
	{
		public static void Shuffle<T>(this IList<T> list, Random rnd)
		{
			for (var i = 0; i < list.Count; i++)
			{
				list.Swap(i, rnd.Next(i, list.Count));
			}
		}

		public static void Swap<T>(this IList<T> list, int i, int j)
		{
			var temp = list[i];
			list[i] = list[j];
			list[j] = temp;
		}

		public static List<T> ToList<T>(this Tuple<T, T> tuple)
		{
			return new List<T> { tuple.Item1, tuple.Item2 };
		}
	}
}
