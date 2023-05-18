using static Functions;

//Вариант 10
//C# не имеет c++ и JAVА вектора(Только математический), поэтому вместо него используется List

namespace Task2
{
	internal static class Program
	{
		static void Main(string[] args)
		{
			RepeatUntilNot((int[,] array) =>
			{
				List<int> list = CreateListFromArray(array);
				Console.WriteLine("Получившийся список:");
				Console.WriteLine(String.Join(" ", list));
			});
		}

		private static List<int> CreateListFromArray<T>(T[,] array) where T : IComparable<T>
		{
			List<int> result = new();
			for (int y = 0; y < array.GetLength(0); y++)
			{
				T minRowValue = array.GetMinValue(y);
				int count = array.Count(y, minRowValue);
				result.Add(count);
			}
			return result;
		}

		public static T GetMinValue<T>(this T[,] array, int row) where T : IComparable<T>
		{
			T result = array[row,0];
			for (int i = 0; i < array.GetLength(1); i++)
			{
				if (result.CompareTo(array[row, i]) == 1)
				{
					result = array[row, i];
				}
			}
			return result;
		}

		public static int Count<T>(this T[,] array, int row, T value) where T : IComparable<T>
		{
			int result = 0;
			for (int i = 0; i < array.GetLength(1); i++)
			{
				if (value.CompareTo(array[row, i]) == 0)
				{
					result++;
				}
			}
			return result;
		}
	}
}