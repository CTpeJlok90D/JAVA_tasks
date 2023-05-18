// Выбран вариант 10
using static Functions;

namespace Task1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			RepeatUntilNot((int[,] array) =>
			{
				int lookingNumber = ReadValue<int>("Введите искомые числа(С учётом модуля разности индексов) >> ");
				int result = ArrayEqualNumberCount(array, lookingNumber);
				Console.WriteLine($"Найдено подходящих элементов: {result}");
			});
		}

		public static int ArrayEqualNumberCount<T>(T[,] array, T number) where T : IComparable<T>
		{
			int result = 0;
			for (int y = 0; y < array.GetLength(0); y++)
			{
				for (int x = 0; x < array.GetLength(0); x++)
				{
					if (array[y, x].CompareTo(number) == 0 && MathF.Abs(x - y) % 2 != 0)
					{
						result++;
					}
				}
			}
			return result;
		}
	}
}