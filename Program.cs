class Program
{
    static void Main()
    {
        Console.Write("Введите число строк: ");
        int rows = GetInt();

        Console.Write("Введите число столбцов: ");
        int cols = GetInt();

        int[,] array = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"Введите элемент [{i},{j}]: ");
                array[i, j] = GetInt();
            }
        }

        Console.WriteLine("Ваш исходный массив:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(array[i, j] + "\t");
            }
            Console.WriteLine();
        }


        Console.WriteLine("Результирующий массив:");
        var result = SpiralOrderCounterClockwise(array);

        Console.WriteLine($"[{string.Join(", ", result)}]");
    }

    public static int[] SpiralOrder(int[,] matrix)
    {
        if (matrix == null || matrix.Length == 0)
            return new int[0];

        int m = matrix.GetLength(0);
        int n = matrix.GetLength(1);
        int[] dx = { 0, 1, 0, -1 };
        int[] dy = { 1, 0, -1, 0 };
        int x = 0, y = 0, di = 0;
        int[] result = new int[m * n];
        int count = 0;

        for (int i = 0; i < m * n; i++)
        {
            result[i] = matrix[x, y];
            matrix[x, y] = int.MinValue; // Помечаем посещенные элементы

            int newX = x + dx[di];
            int newY = y + dy[di];

            if (newX < 0 || newX >= m || newY < 0 || newY >= n || matrix[newX, newY] == int.MinValue)
            {
                di = (di + 1) % 4;
                newX = x + dx[di];
                newY = y + dy[di];
            }

            x = newX;
            y = newY;
        }

        return result;
    }

    public static int[] SpiralOrderCounterClockwise(int[,] matrix)
    {
        if (matrix == null || matrix.Length == 0)
            return new int[0];

        int m = matrix.GetLength(0);
        int n = matrix.GetLength(1);
        int[] dx = { 0, 1, 0, -1 };
        int[] dy = { 1, 0, -1, 0 };
        int x = 0, y = 0, di = 0;
        int[] result = new int[m * n];
        int count = 0;

        for (int i = 0; i < m * n; i++)
        {
            result[i] = matrix[y, x];
            matrix[y, x] = int.MinValue; // Помечаем посещенные элементы

            int newX = x + dx[di];
            int newY = y + dy[di];

            if (newX < 0 || newX >= n || newY < 0 || newY >= m || matrix[newY, newX] == int.MinValue)
            {
                di = (di + 1) % 4;
                newX = x + dx[di];
                newY = y + dy[di];
            }

            x = newX;
            y = newY;
        }

        return result;
    }

    static int GetInt()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int num))
            {
                return num;
            }
            else
            {
                Console.Write("Ошибка ввода. Пожалуйста, введите корректное число: ");
            }
        }
    }
}

