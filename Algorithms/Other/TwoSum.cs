namespace Algorithms.Other
{
	public class TwoSum
	{
		public static List<decimal> ReadData(string fileName)
		{
			string[] lines = File.ReadAllLines(fileName);

			var ints = lines.Select(l => decimal.Parse(l));

			return ints.ToList();
		}

		public static decimal GetNumber(List<decimal> rawData)
		{
			HashSet<decimal> h = new HashSet<decimal>(rawData);
			HashSet<(decimal, decimal)> exclude = new HashSet<(decimal, decimal)>();
			HashSet<decimal> sums = new HashSet<decimal>();

			int counter = 0;

			var data = h.Select(t => t).ToArray();
			int count = data.Count();
			for (int i = 0; i < count; i++)
			{
				var x = data[i];
				for (int j = -10_000; j <= 10_000; j++)
				{
					var y = j - x;
					if (exclude.Contains((x, y)))
						continue;

					if (h.Contains(y))
					{
						sums.Add(x + y);
						exclude.Add((y, x));
						counter++;
					}
				}

				if (h.Count == 0)
				{
					break;
				}
			}

			return sums.Count();
		}
	}
}