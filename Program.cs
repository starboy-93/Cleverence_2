class Program
{
    static void Main()
    {
        //Console.Write("Введите количество строк массива: ");
        //int rows = int.Parse(Console.ReadLine());
        //Console.Write("Введите количество столбцов массива: ");
        //int columns = int.Parse(Console.ReadLine());
        //Console.WriteLine();
        //int[,] arr = new int[rows, columns];
        //Console.WriteLine("Введите элементы массива через пробел, в конце строки нажмите Enter:");
        //for (int i = 0; i < arr.GetLength(0); i++)
        //{
        //    string enterString = Console.ReadLine();
        //    string[] massiveString = enterString.Split(new Char[] { ' ' });
        //    for (int j = 0; j < massiveString.Length; j++)
        //    {
        //        arr[i, j] = int.Parse(massiveString[j]);
        //    }
        //}


        

        Console.WriteLine("Введите количество строк массива:");
        string raws = Console.ReadLine();
        Console.WriteLine("Введите количество столбцов массива:");
        string columns = Console.ReadLine();

        int firstDimension;
        int secondDimension;

        // провекрка корректности размеров массива
        if (!int.TryParse(raws, out firstDimension) ||
            !int.TryParse(columns, out secondDimension))
            throw new Exception("Вы ввели не число!");

        var array = new int[firstDimension, secondDimension];

        //ввод всех элементов массива в строку
        //string rawStr = Console.ReadLine();
        //if (rawStr == null) // проверка массива на пустоту
        //    throw new Exception("Массив пуст");
        //var rawArray = rawStr.Split(' ');

        // проверка на соответствие массива требуемой размерности
        //if (rawArray.Length != firstDimension * secondDimension)
        //    throw new Exception("Неправильный размер массива");

        Console.WriteLine("Введите элементы массива через пробел, в конце строки нажмите Enter:");
        for (int i = 0; i < array.GetLength(0); i++)
        {
            string enterString = Console.ReadLine();
            string[] massiveString = enterString.Split(new Char[] { ' ' });
            for (int j = 0; j < massiveString.Length; j++)
            {
                array[i, j] = int.Parse(massiveString[j]);
            }
        }

        //проверка на число
        //for (int i = 0; i < firstDimension; i++)
        //{
        //    for (int j = 0; j < secondDimension; j++)
        //    {
        //        int next;
        //        if (int.TryParse(rawArray[i * secondDimension + j], out next))
        //            array[i, j] = next;
        //        else
        //            throw new Exception("Вы ввели не число!"); //если очередной элемент не число
        //    }
        //}

        Console.WriteLine("Ваш массив:");
        for (int i = 0; i < firstDimension; i++)
        {
            for (int j = 0; j < secondDimension; j++)
                Console.Write(array[i, j] + " ");
            Console.WriteLine();
        }

        Console.WriteLine("Ваш массив после преобразования:");
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
}

