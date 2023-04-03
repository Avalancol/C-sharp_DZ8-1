// ----------------Заполнение массива
int[,] GetArray(int m, int n, int minValue, int maxValue)
{
    int[,] res = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            res[i, j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return res;
}

// -----------------Вывод массива-----------------
void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine();
    }
}

//Задача 57: Составить частотный словарь элементов двумерного массива. Частотный словарь содержит информацию о том, сколько раз встречается элемент входных данных.
Console.Clear();
Console.WriteLine("Задача 57: Составить частотный словарь элементов двумерного массива. Частотный словарь содержит информацию о том, сколько раз встречается элемент входных данных.");
Console.Write("Введите количество строк: ");
int rows = int.Parse(Console.ReadLine()!);

Console.Write("Введите количество столбцов : ");
int columns = int.Parse(Console.ReadLine()!);

int[,] array = GetArray(rows, columns, 1, 9);
Console.WriteLine("\nИсходный массив:");
PrintArray(array);
CountElements(OneRowSorted(array));

int[] OneRowSorted(int[,] array)
{
    int[] OneRowArray = new int[array.GetLength(0) * array.GetLength(1)];
    int count = 0;
    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(1); j++)
        {
            OneRowArray[count] = array[i, j];
            count++;
        }
    SortArray(OneRowArray);
    return OneRowArray;
}


void SortArray(int[] array)
{
    for (int i = 0; i < array.Length - 1; i++)
    {
        int minPosition = i;
        for (int j = i + 1; j < array.Length; j++)
        {
            if (array[j] < array[minPosition]) minPosition = j;

        }
        int temporary = array[i];
        array[i] = array[minPosition];
        array[minPosition] = temporary;
    }
}

void CountElements(int[] array)
{
    int elem = array[0];
    int count = 1;
    for (int i = 1; i < array.Length; i++)
    {
        if (array[i] == elem)
        {
            count++;
        }
        else
        {
            Console.WriteLine($"Элемент [{elem}] встречается {count} раз");
            count = 1;
            elem = array[i];
        }
    }
    Console.WriteLine($"Элемент [{elem}] встречается {count} раз");
}

// -------------------то же самое, но с двумя циклами---------------------------
// void CountElements(int[] array)
// {
//     for (int i = 0; i < array.Length; i++)
//     {
//         int elem = array[i];
//         int count = 1;
//         for (int j = i + 1; j < array.Length; j++)
//         {
//             if (elem == array[j])
//             {
//                 count++;
//                 i++;
//             }
//         }
//         Console.WriteLine($"Элемент [{elem}] встречается {count} раз");
//     }
// }

// //Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Console.WriteLine("\nЗадача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки массива.");
Console.Write("Введите количество строк: ");
rows = int.Parse(Console.ReadLine()!);

Console.Write("Введите количество столбцов : ");
columns = int.Parse(Console.ReadLine()!);

array = GetArray(rows, columns, 1, 9);
Console.WriteLine("\nИсходный массив:");
PrintArray(array);
Console.WriteLine("\nОтсортированный массив:");
PrintArray(SortDecArray(array));

// -----------------Сортировка строк массива-----------------
int[,] SortDecArray(int[,] array)
{
    for (int k = 0; k < array.GetLength(0); k++)
    {
        for (int i = 0; i < array.GetLength(1) - 1; i++)
        {
            int maxPosition = i;
            for (int j = i + 1; j < array.GetLength(1); j++)
            {
                if (array[k, j] > array[k, maxPosition]) maxPosition = j;
            }
            int temporary = array[k, i];
            array[k, i] = array[k, maxPosition];
            array[k, maxPosition] = temporary;
        }
    }
    return array;
}

//Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Console.WriteLine("\nЗадача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.");
Console.Write("Введите количество строк первой матрицы: ");
rows = int.Parse(Console.ReadLine()!);

Console.Write("Введите количество столбцов первой матрицы: ");
columns = int.Parse(Console.ReadLine()!);

Console.Write("Введите количество столбцов второй матрицы: ");
int columns2 = int.Parse(Console.ReadLine()!);

int[,] array1 = GetArray(rows, columns, 1, 9);
int[,] array2 = GetArray(columns, columns2, 1, 9);
Console.WriteLine("Первая матрица:");
PrintArray(array1);
Console.WriteLine("\nВторая матрица:");
PrintArray(array2);
Console.WriteLine("\nРезультирующая матрица:");
PrintArray(MultiplyMatrix(array1, array2));

//-----------------Умножение матриц-----------------
int[,] MultiplyMatrix(int[,] array1, int[,] array2)
{
    int[,] Rezult = new int[array1.GetLength(0), array2.GetLength(1)];
    for (int i = 0; i < array1.GetLength(0); i++)
    {
        for (int j = 0; j < array2.GetLength(1); j++)
        {
            Rezult[i, j] = 0;
            for (int k = 0; k < array1.GetLength(1); k++)
            {
                Rezult[i, j] += array1[i, k] * array2[k, j];
            }
        }
    }
    return Rezult;
}