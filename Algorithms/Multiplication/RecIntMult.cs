using System.Numerics;

namespace Algorithms.Multiplication
{
	public static class RecIntMult
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
				string a = GetFirstHalf(x);
				string b = GetSecondHalf(x);

				string c = GetFirstHalf(y);
				string d = GetSecondHalf(y);

				BigInteger ac = Multiply(a, c);
				BigInteger ad = Multiply(a, d);

				BigInteger bc = Multiply(b, c);
				BigInteger bd = Multiply(b, d);

				return BigInteger.Pow(10, padLength) * ac + BigInteger.Pow(10, padLength / 2) * (ad + bc) + bd;
			}
		}

		public static string GetFirstHalf(string aStr)
		{
			return aStr.Substring(0, aStr.Length / 2);
		}

		public static string GetSecondHalf(string aStr)
		{
			return aStr.Substring(aStr.Length / 2);
		}
	}
}
