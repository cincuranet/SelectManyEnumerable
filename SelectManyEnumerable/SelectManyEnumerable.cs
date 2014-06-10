using System;
using System.Collections.Generic;
using System.Linq;

namespace SelectManyEnumerable
{
	public static class SelectManyEnumerable
	{
		public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
		{
			return Select(source, (x, _) => selector(x));
		}
		public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, TResult> selector)
		{
			return source.SelectMany((x, i) => new[] { selector(x, i) });
		}

		public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			return Where(source, (x, _) => predicate(x));
		}
		public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
		{
			return source.SelectMany((x, i) => predicate(x, i) ? new[] { x } : new TSource[0]);
		}

		public static IEnumerable<TSource> Skip<TSource>(this IEnumerable<TSource> source, int count)
		{
			return source.SelectMany(x => --count < 0 ? new[] { x } : new TSource[0]);
		}
	}
}
