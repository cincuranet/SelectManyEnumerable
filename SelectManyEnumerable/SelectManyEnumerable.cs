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
			return source.SelectMany((x, i) => predicate(x, i) ? new[] { x } : new TSource[] { });
		}

		public static IEnumerable<TSource> Skip<TSource>(this IEnumerable<TSource> source, int count)
		{
			return source.SelectMany((x, i) => i >= count ? new[] { x } : new TSource[] { });
		}

		public static IEnumerable<TSource> Take<TSource>(this IEnumerable<TSource> source, int count)
		{
			return source.SelectMany((x, i) => i < count ? new[] { x } : new TSource[] { });
		}

		public static IEnumerable<TSource> SkipWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			return SkipWhile(source, (x, _) => predicate(x));
		}
		public static IEnumerable<TSource> SkipWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
		{
			return source.SelectMany((x, i) => !predicate(x, i) ? new[] { x } : new TSource[] { });
		}

		public static IEnumerable<TSource> TakeWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			return TakeWhile(source, (x, _) => predicate(x));
		}
		public static IEnumerable<TSource> TakeWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
		{
			return source.SelectMany((x, i) => predicate(x, i) ? new[] { x } : new TSource[] { });
		}

		public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
		{
			return first
				.SelectMany((x, i) => new[] { Tuple.Create(x, i) }, (_, x) => Tuple.Create(x.Item1, Take(Skip(second, x.Item2), 1)))
				.SelectMany(x => x.Item2, (a, b) => resultSelector(a.Item1, b));
		}
	}
}
