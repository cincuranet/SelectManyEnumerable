using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectManyEnumerable
{
	class Program
	{
		static void Main(string[] args)
		{
			Enumerable.Empty<int>();
		}
	}

	static class SelectManyEnumerable
	{
		public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
		{
			return source.SelectMany(x => new[] { selector(x) });
		}

		public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, TResult> selector)
		{
			return source.SelectMany((x, i) => new[] { selector(x, i) });
		}
	}
}
