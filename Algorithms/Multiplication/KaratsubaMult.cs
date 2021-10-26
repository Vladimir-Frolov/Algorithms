using System.Numerics;

namespace Algorithms.Multiplication
{
	public static class KaratsubaMult
	{
		public static void Test()
		{
			string a = "3141592653589793238462643383279502884197169399375105820974944592";
			string b = "2718281828459045235360287471352662497757247093699959574966967627";

			BigInteger expected = BigInteger.Parse(a) * BigInteger.Parse(b);

			var actual = Multiply(a, b);
			var areEqual = actual == expected;

			Console.WriteLine(actual);
			Console.WriteLine(expected);
			Console.WriteLine("Are equal: " + areEqual);
		}

		public static BigInteger Multiply(string x, string y)
		{
			var padLength = x.Length > y.Length ? x.Length : y.Length;

			if (padLength > 1)
			{
				padLength += padLength % 2;
			}

			x = x.PadLeft(padLength, '0');
			y = y.PadLeft(padLength, '0');

			if (padLength == 1)
			{
				return int.Parse(x) * int.Parse(y);
			}
			else
			{
				BigInteger a = GetFirstHalf(x);
				BigInteger b = GetSecondHalf(x);

				BigInteger c = GetFirstHalf(y);
				BigInteger d = GetSecondHalf(y);

				BigInteger p = a + b;
				BigInteger q = c + d;

				BigInteger ac = Multiply(a.ToString(), c.ToString());
				BigInteger bd = Multiply(b.ToString(), d.ToString());
				BigInteger pq = Multiply(p.ToString(), q.ToString());

				BigInteger adbc = pq - ac - bd;

				return BigInteger.Pow(10, padLength) * ac + BigInteger.Pow(10, padLength / 2) * adbc + bd;
			}
		}

		public static BigInteger GetFirstHalf(string aStr)
		{
			return BigInteger.Parse(aStr.Substring(0, aStr.Length / 2));
		}

		public static BigInteger GetSecondHalf(string aStr)
		{
			return BigInteger.Parse(aStr.Substring(aStr.Length / 2));
		}
	}
}
