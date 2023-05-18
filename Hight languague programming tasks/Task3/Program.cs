using static Functions;
// Вариант 10

namespace Task3
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			RepeatUntilNot((int[,] array) =>
			{
				List<int> sums = ArraySums(array);
				List<int> unsortedSums = new(sums);

				int[,] result = new int[array.GetLength(0),array.GetLength(1)];
				for (int i = 0; i < sums.Count; i++)
				{
					int minValueIndex = MinValueIndex(sums, i);
					(sums[i], sums[minValueIndex]) = (sums[minValueIndex], sums[i]);
				}

				Console.WriteLine("Отсортированно по суммам:");
				
				for (int i = 0; i < sums.Count; i++)
				{
					for (int j = 0; j < unsortedSums.Count; j++)
					{
						if (sums[i] == unsortedSums[j])
						{
							for (int x = 0; x < array.GetLength(1); x++)
							{
								Console.Write(array[j, x] + " ");
							}
							Console.WriteLine($"Сумма: {unsortedSums[j]}");
						}
					}
				}
			});
		}

		private static List<int> ArraySums(int[,] array)
		{
			List<int> sums = new();
			for (int i = 0; i < array.GetLength(0); i++)
			{
				sums.Add(RowSum(array, i));
			}
			return sums;
		}

		private static int RowSum(int[,] array, int row)
		{
			int result = 0;
			for (int i = 0; i < array.GetLength(1); i++)
			{
				result += array[row, i];
			}
			return result;
		}

		private static int MinValueIndex(List<int> list, int begin = 0)
		{
			int result = begin;

			for (int i = begin; i < list.Count; i++)
			{
				if (list[i] < list[result])
				{
					result = i;
				}
			}
			return result;
		}
	}
}