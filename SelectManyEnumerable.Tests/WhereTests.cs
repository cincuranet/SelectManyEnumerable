using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SelectManyEnumerable.Tests
{
	[TestFixture]
	public class WhereTests : TestsBase
	{
		[Test]
		public void WhereTests_Basic()
		{
			var data = GetData();
			var expected = Enumerable.Where(data, x => (x % 2) == 0);
			var current = SelectManyEnumerable.Where(data, x => (x % 2) == 0);
			CollectionAssert.AreEqual(expected, current);
		}

		[Test]
		public void WhereTests_BasicWithIndex()
		{
			var data = GetData();
			var expected = Enumerable.Where(data, (x, i) => ((x + i) % 2) == 0);
			var current = SelectManyEnumerable.Where(data, (x, i) => ((x + i) % 2) == 0);
			CollectionAssert.AreEqual(expected, current);
		}
	}
}
