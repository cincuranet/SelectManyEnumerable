using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SelectManyEnumerable.Tests
{
	[TestFixture]
	public class TakeTests : TestsBase
	{
		[Test]
		public void TakeTests_Basic()
		{
			var data = GetData();
			var expected = Enumerable.Take(data, 6);
			var current = SelectManyEnumerable.Take(data, 6);
			CollectionAssert.AreEqual(expected, current);
		}
	}
}
