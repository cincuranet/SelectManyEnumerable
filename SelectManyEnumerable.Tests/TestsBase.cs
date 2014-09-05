using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectManyEnumerable.Tests
{
	public class TestsBase
	{
		protected static int[] GetData(int count = 128)
		{
			return Enumerable.Range(1, count).ToArray();
		}
	}
}
