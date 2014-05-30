using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SelectManyEnumerable.Tests
{
	[TestFixture]
	public class SelectTests : TestsBase
	{
		[Test]
		public void SelectTests_Basic()
		{
			var data = GetData();
			var expected = Enumerable.Select(data, x => x * x);
			var current = SelectManyEnumerable.Select(data, x => x * x);
			CollectionAssert.AreEqual(expected, current);
		}

		[Test]
		public void SelectTests_BasicWithIndex()
		{
			var data = GetData();
			var expected = Enumerable.Select(data, (x, i) => x + i);
			var current = SelectManyEnumerable.Select(data, (x, i) => x + i);
			CollectionAssert.AreEqual(expected, current);
		}
	}
}
