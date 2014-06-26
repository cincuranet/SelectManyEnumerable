using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SelectManyEnumerable.Tests
{
	[TestFixture]
	public class SkipWhileTests : TestsBase
	{
		[Test]
		public void SkipWhileTests_Basic()
		{
			var data = GetData();
			var expected = Enumerable.SkipWhile(data, x => x < 3);
			var current = SelectManyEnumerable.SkipWhile(data, x => x < 3);
			CollectionAssert.AreEqual(expected, current);
		}

		[Test]
		public void SkipWhileTests_WithIndex()
		{
			var data = GetData();
			var expected = Enumerable.SkipWhile(data, (x, i) => x + i < 3);
			var current = SelectManyEnumerable.SkipWhile(data, (x, i) => x + i < 3);
			CollectionAssert.AreEqual(expected, current);
		}
	}
}
