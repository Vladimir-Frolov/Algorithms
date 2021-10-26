namespace Algorithms.Sorting
{
	public class QuickSort
	{
		public static int Total = 0;
		public static int[] ReadData(string fileName)
		{
			string[] lines = File.ReadAllLines(fileName);

			var ints = lines.Select(l => int.Parse(l));

			return ints.ToArray();
		}

		public static void Sort(int[] a)
		{
			QuickSortRec(a, 0, a.Length - 1);
		}

		public static void QuickSortRec(int[] A, int l, int r)
		{
			if (l >= r)
			{
				return;
			}

			Total += r - l;
			int i = ChoosePivot(A, l, r);
			int temp = A[i];
			A[i] = A[l];
			A[l] = temp;

			int j = Partition(A, l, r);

			QuickSortRec(A, l, j - 1);
			QuickSortRec(A, j + 1, r);

			return;
		}

		public static int ChoosePivot(int[] A, int l, int r)
		{
			int middleIndex = (r - l) / 2 + l;
			if (middleIndex == 0)
			{
				if (A[l] > A[r])
				{
					return r;
				}
				else
				{
					return l;
				}
			}

			int first = A[l];
			int last = A[r];
			int middle = A[middleIndex];

			var arr = new List<int>() { first, last, middle };
			arr.Sort();
			var median = arr[1];

			if (median == first)
			{
				return l;
			}

			if (median == middle)
			{
				return middleIndex;
			}

			return r;
		}

		public static int Partition(int[] A, int l, int r)
		{
			int p = A[l];
			int i = l + 1;

			for (int j = l + 1; j <= r; j++)
			{
				if (A[j] < p)
				{
					int temp = A[i];
					A[i] = A[j];
					A[j] = temp;
					i++;
				}
			}

			int temp2 = A[l];
			A[l] = A[i - 1];
			A[i - 1] = temp2;

			return i - 1;
		}
	}
}