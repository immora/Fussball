using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fussball.Utils.ExtensionMethods
{
	public static class StringExtensions
	{
		public static string ReplacePolishSigns(this string str)
		{
			return str
				.Replace('ą', 'a')
				.Replace('ć', 'c')
				.Replace('ę', 'e')
				.Replace('ł', 'l')
				.Replace('ó', 'o')
				.Replace('ś', 's')
				.Replace('ź', 'z')
				.Replace('ż', 'z');
		}
	}
}
