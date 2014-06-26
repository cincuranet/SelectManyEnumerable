using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SelectManyEnumerable.Tests
{
	[TestFixture]
	public class TakeWhileTests : TestsBase
	{
		[Test]
		public void TakeWhileTests_Basic()
		{
			var data = GetData();
			var expected = Enumerable.TakeWhile(data, x => x < 3);
			var current = SelectManyEnumerable.TakeWhile(data, x => x < 3);
			CollectionAssert.AreEqual(expected, current);
		}

		[Test]
		public void TakeWhileTests_WithIndex()
		{
			var data = GetData();
			var expected = Enumerable.TakeWhile(data, (x, i) => x + i < 3);
			var current = SelectManyEnumerable.TakeWhile(data, (x, i) => x + i < 3);
			CollectionAssert.AreEqual(expected, current);
		}
	}
}
