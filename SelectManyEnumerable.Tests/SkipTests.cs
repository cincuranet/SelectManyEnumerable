using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SelectManyEnumerable.Tests
{
	[TestFixture]
	public class SkipTests : TestsBase
	{
		[Test]
		public void SkipTests_Basic()
		{
			var data = GetData();
			var expected = Enumerable.Skip(data, 6);
			var current = SelectManyEnumerable.Skip(data, 6);
			CollectionAssert.AreEqual(expected, current);
		}
	}
}
