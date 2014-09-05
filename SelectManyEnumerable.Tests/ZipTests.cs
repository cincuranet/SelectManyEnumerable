using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SelectManyEnumerable.Tests
{
	[TestFixture]
	public class ZipTests : TestsBase
	{
		[Test]
		public void ZipTests_Basic()
		{
			var data1 = GetData();
			var data2 = GetData();
			var expected = Enumerable.Zip(data1, data2, (a, b) => Tuple.Create(a, b));
			var current = SelectManyEnumerable.Zip(data1, data2, (a, b) => Tuple.Create(a, b));
			CollectionAssert.AreEqual(expected, current);
		}

		[Test]
		public void ZipTests_SecondCollectionShorter()
		{
			var data1 = GetData();
			var data2 = GetData(100);
			var expected = Enumerable.Zip(data1, data2, (a, b) => Tuple.Create(a, b));
			var current = SelectManyEnumerable.Zip(data1, data2, (a, b) => Tuple.Create(a, b));
			CollectionAssert.AreEqual(expected, current);
		}

		[Test]
		public void ZipTests_FirstCollectionShorter()
		{
			var data1 = GetData(100);
			var data2 = GetData();
			var expected = Enumerable.Zip(data1, data2, (a, b) => Tuple.Create(a, b));
			var current = SelectManyEnumerable.Zip(data1, data2, (a, b) => Tuple.Create(a, b));
			CollectionAssert.AreEqual(expected, current);
		}
	}
}
