namespace Algorithms.Other
{
	public class MedianMaintenance
	{
		public static int GetMedian(string fileName)
		{
			var maxHeap = new SortedSet<int>();
			var minHeap = new SortedSet<int>();

			int iteration = 0;
			int median = 0;
			foreach (string line in File.ReadLines(fileName))
			{
				var number = int.Parse(line);

				if(number > minHeap.Max)
				{
					maxHeap.Add(number);
				}
				else
				{
					minHeap.Add(number);
				}

				var diff = maxHeap.Count - minHeap.Count;

				if(diff == 2)
				{
					var min = maxHeap.Min;
					maxHeap.Remove(min);

					minHeap.Add(min);
				}

				if(diff == -2)
				{
					var max = minHeap.Max;

					minHeap.Remove(max);
					maxHeap.Add(max);
				}

				if(diff == 0 || diff == 2 || diff == -2)
				{
					median += minHeap.Max;
				}

				if(diff == 1)
				{
					median += maxHeap.Min;
				}

				if(diff == -1)
				{
					median += minHeap.Max;
				}

				iteration++;
			}

			return median % 10000;
		}
	}
}
