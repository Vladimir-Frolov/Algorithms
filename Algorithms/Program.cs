// See https://aka.ms/new-console-template for more information
using Algorithms.Multiplication;
using Algorithms.Other;
using Algorithms.Sorting;

Console.WriteLine("Multiplication");

//Implementation of recursive integer multiplication
RecIntMult.Test();
//Implementation of recursive karatsuba multiplication
KaratsubaMult.Test();

Console.WriteLine();


Console.WriteLine("Sorting");

//Implementation of merge sort algorithm
int[] array = new[] { 2, 8, 7, 4, 3, 6, 5, 1, 1, 3, 5 };
MergeSort ms = new MergeSort();
var t = ms.Sort(array);
Console.WriteLine(string.Join(',', t));

//Implementation of quick sort algorithm
var data = QuickSort.ReadData("Data/quick_sort.txt");

Console.WriteLine(string.Join(',', data.Take(20)));
QuickSort.Sort(data);
Console.WriteLine(string.Join(',', data.Take(20)));

Console.WriteLine();


Console.WriteLine("MedianMaintenance");
//Not exactly median
var median = MedianMaintenance.GetMedian("Data/medians.txt");
Console.WriteLine(median);

Console.WriteLine();


Console.WriteLine("2 Sum");

var twoSumData = TwoSum.ReadData("Data/2sum.txt");
Console.WriteLine(TwoSum.GetNumber(twoSumData));

Console.WriteLine();

Console.ReadLine();