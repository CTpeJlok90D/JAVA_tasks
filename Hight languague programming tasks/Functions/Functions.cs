using System.ComponentModel;

public static class Functions
{
	public static int[,] TwoDimensionalRandomArray(int sizeX, int sizeY, int minValue, int maxValue, Random? seed = null)
	{
		seed ??= new Random();

		int[,] result = new int[sizeX, sizeY];
		for (int y = 0; y < result.GetLength(0); y++)
		{
			for (int x = 0; x < result.GetLength(1); x++)
			{
				result[y, x] = seed.Next(minValue, maxValue);
			}
		}

		return result;
	}

	public static T ReadValue<T>(string message)
	{
		string? input;
		TypeConverter convertor = TypeDescriptor.GetConverter(typeof(T));
		T result;
		do
		{
			Console.Write(message);
			input = Console.ReadLine();
			try
			{
				result = (T)convertor.ConvertFromString(input);
				break;
			}
			catch
			{
				continue;
			}
		} while (true);

		return result;
	}

	public static void PrintArray(int[,] array)
	{
		for (int y = 0; y < array.GetLength(0); y++)
		{
			for (int x = 0; x < array.GetLength(1); x++)
			{
				Console.Write(array[y, x] + " ");
			}
			Console.WriteLine();
		}
	}

	public delegate void Action(int[,] array);
	public static void RepeatUntilNot(Action function)
	{
		string? input;
		do
		{
			input = "";
			int sizeX = ReadValue<int>("Введите размер двумерного массива по Х >> ");
			int sizeY = ReadValue<int>("Введите размер двумерного массива по Y >> ");

			int[,] array = TwoDimensionalRandomArray(sizeX, sizeY, -50, 50);

			Console.WriteLine("Сгенерированный массив:");
			PrintArray(array);

			function.Invoke(array);

			Console.WriteLine("Повторить?(Y|N)");
			while (input != "N" && input != "Y")
			{
				input = Console.ReadLine();
			}
			Console.Clear();
		} while (input == "Y");
	}
}