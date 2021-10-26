namespace Algorithms.Sorting
{
	public class MergeSort
	{
		public int[] Sort(int[] a)
		{
			if (a.Length == 0 || a.Length == 1)
			{
				return a;
			}

			int half = a.Length / 2;

			int[] c = Sort(a.Take(half).ToArray());
			int[] d = Sort(a.Skip(half).ToArray());

			return Merge(c, d);
		}

		private int[] Merge(int[] a, int[] b)
		{
			int[] result = new int[a.Length + b.Length];

			int i = 0;
			int j = 0;

			for (int k = 0; k < result.Length; k++)
			{
				if (i >= a.Length)
				{
					result[k] = b[j];
					j++;
					continue;
				}

				if (j >= b.Length)
				{
					result[k] = a[i];
					i++;
					continue;
				}

				if (a[i] < b[j])
				{
					result[k] = a[i];
					i++;
				}
				else if (b[j] < a[i])
				{
					result[k] = b[j];
					j++;
				}
				else
				{
					result[k] = a[i];
					i++;

					result[k + 1] = b[j];
					j++;

					k++;
				}
			}


			return result;
		}
	}
}